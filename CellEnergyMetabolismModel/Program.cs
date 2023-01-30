using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CellEnergyMetabolismModel
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultsFolderPath = "[Inser there path to the folder, where results should be stored]";
            var noise = 0; // Gaussian noise amplitude (0.3 is equal to 30% Gaussian Noise)
            int timeSteps = 50000000; // Amount of steps of the simulation
            int timeStepsToSave = 1000; // How many steps should elapse between saving the result (this parameter is for reducing RAM consumption and resulting CSV files


            var settings = new SimulationSettings()
            {
                KeepGLCLevel = false, // should metabolisms "fuel" be exhausted or kept on the same level
                RunFattyAcids = true, // should Fatty Acids Beta Oxidation be turned on
                RunGlycolysis = true, // should Glycolysis be turned on
                RunKrebs = true, // should Krebs Cycle be turned on
                RunPPP = true, // should Pentose Phosphate Pathway be turned on
                KrebsRunCitBalance = true, // should Cit balancing flow in Krebs Cycle be turned on
                KrebsRunOxoBalance = true, // should Oxo balancing flow in Krebs Cycle be turned on
                KeepC16AcylCoAcyt = true, // should C16AcylCoAcyt be exhausted or kept on the constant level
                BetaOxidationAccoaBalance = true, // should Accoa balancing flow in Fatty Acids Beta Oxidation be turned on
                CGlycLowLevel = 0.001, // what level of Glyc serves as a switch between Glycolysis + PPP and Fatty Acids Beta Oxidation 
                FillZerosWithDelta = true // prevent substrates from reaching zero value by inserting minimal increment (delta)
            };
           

           
            var folderPath = Path.Combine(resultsFolderPath, DateTime.Now.ToString().Replace(':', '.').Replace(' ', '_') + settings.Summarize());
            if (Directory.Exists(folderPath) == false)
                Directory.CreateDirectory(folderPath);

            string destinationPath = folderPath;

            bool perform(int i)
            {
                var start = CellState.LiteratureState();

                var consts = Constants.LiteratureStart(start, noise);
                consts.SetSettings(settings);

                var list = new Simulation().SimulateOneCell(start, consts, settings, timeSteps, timeStepsToSave);

                var buildier = new StringBuilder();
                CellState.GetHeaderWithoutConstants().ToList().ForEach(x => buildier.Append($"{x};"));
                list.Select(x => x.GetStateWithoutConstants()).ToList().ForEach(x =>
                {
                    buildier.Append("\r\n");
                    x.ToList().ForEach(y => buildier.Append($"{y.ToString().Replace(',', '.')};"));
                });

                var path = Path.Combine(folderPath, $"{i}_substrates.csv");
                File.WriteAllText(path, buildier.ToString());

                var rates_header = consts.GetRatesNames(start.C_GLC);
                var rates = list.Select(x => consts.GetRates(start, x, noise)).ToList();

                var rates_buildier = new StringBuilder();
                rates_header.ToList().ForEach(x => rates_buildier.Append($"{x};"));
                rates.ForEach(x =>
                {
                    rates_buildier.Append("\r\n");
                    x.ToList().ForEach(y => rates_buildier.Append($"{y.ToString().Replace(',', '.')};"));
                });

                var rates_path = Path.Combine(folderPath, $"{i}_rates.csv");
                File.WriteAllText(rates_path, rates_buildier.ToString());

                return true;
            }
            perform(0); //use this line to perform one experiment
            //Enumerable.Range(0, 50).AsParallel().Select(x => perform(x)).ToList(); //uncomment this line to perform 50 experiments in parallel
        }
    }
}
