//Imports
using System;

namespace ChemTestApp
{
    class Program
    {
        //Global variables
        static string mostEfficient = "";
        static float mostEfficientRating = 0;
        static string leastEfficient = "";
        static float leastEfficientRating = 99999;

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
                Console.WriteLine("\nError 2:\n\nYou must either enter 'End' or press [ENTER] to continue.\n");

            }

        }

        static string CheckChemical()
        {
            while (true)
            {
                Console.WriteLine("Please enter one of the chemical listed below:\nChlorine dioxide, Ethanol, Hydrogen peroxide, Hypochlorite, \nIodophor disinfectant, Isopropanol, Peracetic acid, \nPotassium cyanide, Quaternary ammonium compounds, Sulphuric acid.");
                string chemicalName = Console.ReadLine();

                if (!chemicalName.Equals(""))
                {
                    //Convert the chemical name into a capitalized name.
                    chemicalName = chemicalName[0].ToString().ToUpper() + chemicalName.Substring(1);
                    
                    //Check if the user entered a real chemical
                    if (chemicalName.Equals("Chlorine dioxide")|| chemicalName.Equals("Ethanol") || chemicalName.Equals("Hydrogen peroxide") || chemicalName.Equals("Hypochlorite") || chemicalName.Equals("Iodophor disinfectant") || chemicalName.Equals("Isopropanol") || chemicalName.Equals("Peracetic acid") || chemicalName.Equals("Potassium cyanide") || chemicalName.Equals("Quaternary ammonium compounds") || chemicalName.Equals("Sulphuric acid"))
                    {
                        return chemicalName;
                    }
                    
                }

                //Display error whenever no chemical is entered
                Console.WriteLine("Error 1:\n\nYou must enter a chemical\n");
            }

        }

        static void OneChemical()
        {
            //Enter and store chemical name
            string chemicalName = CheckChemical();

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
            Console.WriteLine($"\n{chemicalName} has an efficency rating of: {avgEfficiency}\n");
            
            //Determin whether the chemical tested is the least or most efficient
            if (avgEfficiency > mostEfficientRating)
            {
                mostEfficientRating = avgEfficiency;
                mostEfficient = chemicalName;
            }
            if (avgEfficiency < leastEfficientRating)
            {
                leastEfficientRating = avgEfficiency;
                leastEfficient = chemicalName;
            }

        }
        
        static void Main(string[] args)
        {
            //Create a loop to input multiple chemicals
            string flag = "";
            while (!flag.Equals("End"))
            {
                OneChemical();

                flag = CheckFlag();
            }

            //Calculate and display the least and most efficient chemicals
            Console.WriteLine($"\n\tThe most efficient chemical tested is {mostEfficient},\n\twith an efficiency rating of: {mostEfficientRating}.");
            Console.WriteLine($"\n\tThe least efficient chemical tested is {leastEfficient},\n\twith an efficiency rating of: {leastEfficientRating}.");

        }

    }

}