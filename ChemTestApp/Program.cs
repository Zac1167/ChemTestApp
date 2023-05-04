//Imports
using System;
using System.Collections.Generic;

namespace ChemTestApp
{
    class Program
    {
        //Global variables
        static string mostEfficient = "";
        static string secondMostEfficient = "";
        static string thirdMostEfficient = "";
        static float mostEfficientRating = 0;
        static float secondMostEfficientRating = 0;
        static float thirdMostEfficientRating = 0;
        static string leastEfficient = "";
        static string secondLeastEfficient = "";
        static string thirdLeastEfficient = "";
        static float leastEfficientRating = 99999;
        static float secondLeastEfficientRating = 99999;
        static float thirdLeastEfficientRating = 99999;
        static List<string> usedChemicals = new List<string>();
        static readonly List<string> ERRORMESSAGES = new List<string>() { "\nError 1:\n\nYou must enter a chemical.\n", "\nError 2:\n\nYou must either enter 'End' or press [ENTER] to continue.\n", "\nError 3:\n\nYou mustn't enter a chemical that has already been used.\n" };

        //Methods and/or functions
        static string CheckFlag()
        {
            while (true)
            {
                //Get the users choice
                Console.WriteLine("Press [ENTER] to continue and add another chemical,\nor type 'End' to close the program.");
                string userInput = Console.ReadLine();

                //Convert capatalized text into lower case 
                userInput = userInput.ToLower();

                //Convert first flag letter to capatalized
                if (!userInput.Equals(""))
                {
                    userInput = userInput[0].ToString().ToUpper() + userInput.Substring(1);
                }

                if (userInput.Equals("End") || userInput.Equals(""))
                {
                    return userInput;
                }
                Console.WriteLine(ERRORMESSAGES[1]);

            }

        }

        static string CheckChemical()
        {
            while (true)
            {
                Console.WriteLine("Please enter one of the chemical listed below:\nChlorine dioxide, Ethanol, Hydrogen peroxide, Hypochlorite, \nIodophor disinfectant, Isopropanol, Peracetic acid, \nPotassium cyanide, Quaternary ammonium compounds, Sulphuric acid.");
                string chemicalName = Console.ReadLine();
                Console.Clear();

                if (!chemicalName.Equals(""))
                {
                    //Convert the chemical name into a capitalized name.
                    chemicalName = chemicalName[0].ToString().ToUpper() + chemicalName.Substring(1);
                    
                    //Check if the user entered a real chemical
                    if (chemicalName.Equals("Chlorine dioxide")|| chemicalName.Equals("Ethanol") || chemicalName.Equals("Hydrogen peroxide") || chemicalName.Equals("Hypochlorite") || chemicalName.Equals("Iodophor disinfectant") || chemicalName.Equals("Isopropanol") || chemicalName.Equals("Peracetic acid") || chemicalName.Equals("Potassium cyanide") || chemicalName.Equals("Quaternary ammonium compounds") || chemicalName.Equals("Sulphuric acid"))
                    {
                        if (!usedChemicals.Contains(chemicalName))
                        {
                            return chemicalName;

                        }
                        //Display error whenever an already used chemical is entered
                        Console.WriteLine(ERRORMESSAGES[2]);
                        CheckChemical();
                     
                    }
                    
                }

                //Display error whenever no chemical is entered
                Console.WriteLine(ERRORMESSAGES[0]);

            }

        }

        static void OneChemical()
        {
            //Enter and store chemical name
            usedChemicals.Add(CheckChemical());

            float sumEfficiency = 0;

            //Loop 5 times
            for (int germLoop = 0; germLoop < 5; germLoop++)
            {
                //Generate a random number of initial germs
                Random ranGen = new Random();
                int initialGerms = ranGen.Next(500, 1000);

                //Meausre number of germs after chemical has been added
                int finalGerms = initialGerms - ranGen.Next(0, 499);

                //Calculate an efficiency rating for the chemical
                float efficiencyRating =(float)(initialGerms - finalGerms) /10;

                //Calculate final efficiency rating
                sumEfficiency += efficiencyRating;

            }

            //Show amount of time passing
            Console.WriteLine("\n10 minutes later...");

            //Display final chemical efficiency
            float avgEfficiency = sumEfficiency / 5;
            Console.WriteLine($"\n{usedChemicals[usedChemicals.Count-1]} has an efficency rating of: {avgEfficiency}\n");
            
            //Determin whether the chemical tested is the least or most efficient
            if (avgEfficiency > mostEfficientRating)
            {
                mostEfficientRating = avgEfficiency;
                mostEfficient = usedChemicals[usedChemicals.Count - 1];
            }
            if (avgEfficiency < mostEfficientRating && avgEfficiency > secondMostEfficientRating)
            {
                secondMostEfficientRating = avgEfficiency;
                secondMostEfficient = usedChemicals[usedChemicals.Count - 1];
            }
            if (avgEfficiency < secondMostEfficientRating && avgEfficiency > thirdMostEfficientRating)
            {
                thirdMostEfficientRating = avgEfficiency;
                thirdMostEfficient = usedChemicals[usedChemicals.Count - 1];
            }
            if (avgEfficiency < leastEfficientRating)
            {
                leastEfficientRating = avgEfficiency;
                leastEfficient = usedChemicals[usedChemicals.Count - 1];
            }
            if (avgEfficiency > leastEfficientRating && avgEfficiency < secondLeastEfficientRating)
            {
                secondLeastEfficientRating = avgEfficiency;
                secondLeastEfficient = usedChemicals[usedChemicals.Count - 1];
            }
            if (avgEfficiency > secondLeastEfficientRating && avgEfficiency < thirdLeastEfficientRating)
            {
                thirdLeastEfficientRating = avgEfficiency;
                thirdLeastEfficient = usedChemicals[usedChemicals.Count - 1];
            }

        }
        
        static void Main(string[] args)
        {
            //Display help/instructional messaging at the start of the program/process (ASCII)
            Console.WriteLine
                (
                "   ___ _                    _           _   _____          _            \n" +
               @"  / __\ |__   ___ _ __ ___ (_) ___ __ _| | /__   \___  ___| |_ ___ _ __ "+"\n" +
               @" / /  | '_ \ / _ \ '_ ` _ \| |/ __/ _` | |   / /\/ _ \/ __| __/ _ \ '__|"+"\n" +
               @"/ /___| | | |  __/ | | | | | | (_| (_| | |  / / |  __/\__ \ ||  __/ |   "+"\n" +
               @"\____/|_| |_|\___|_| |_| |_|_|\___\__,_|_|  \/   \___||___/\__\___|_|   "
                );

            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("\tWelcome to Chemical Tester!\n\tThis app will test and compare multiple cleaning\n\tchemicals, and give them an eficency rating out of 50.\n\tThe higher the number, the greater the efficiency.");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Press the [Enter] key to continue.");

            Console.ReadLine();
            Console.Clear();

            //Create a loop to input multiple chemicals
            string flag = "";
            while (!flag.Equals("End"))
            {
                OneChemical();

                flag = CheckFlag();

                Console.Clear();

            }

            //Calculate and display the least and most efficient chemicals
            Console.WriteLine($"\n\t   Most efficient chemicals\n" +
                $"\t|Position|Chemical name|Rating|\n" +
                $"\t1. {mostEfficient} {mostEfficientRating}\n" +
                $"\t2. {secondMostEfficient} {secondMostEfficientRating}\n" +
                $"\t3. {thirdMostEfficient} {thirdMostEfficientRating}");
            Console.WriteLine($"\n\t   Least efficient chemicals\n" +
                $"\t|Position|Chemical name|Rating|\n" +
                $"\t1. {leastEfficient} {leastEfficientRating}\n" +
                $"\t2. {secondLeastEfficient} {secondLeastEfficientRating}\n" +
                $"\t3. {thirdLeastEfficient} {thirdLeastEfficientRating}");

            Console.WriteLine("\nThank you for using Chemical Tester!\nPress the [Enter] key to close the program.");

        }

    }

}