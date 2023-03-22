//Imports
using System;

namespace ChemTestApp
{
    class Program
    {
        //Global variables


       
        

        //Methods and/or functions
        static void OneChemical()
        {
            //Enter and store chemical name
            Console.WriteLine("Enter a chemical:");
            string chemicalName = Console.ReadLine();

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
            Console.WriteLine($"\n{chemicalName} has an efficency rating of: {sumEfficiency / 5}\n");

        }
        
        static void Main(string[] args)
        {
            //Create a loop to input multiple chemicals
            string flag = "";
            while (!flag.Equals("End"))
            {
                OneChemical();

                Console.WriteLine("Press [ENTER] to continue and add another chemical,\nor type 'End' to close the program.");
                flag = Console.ReadLine();
            }

            //Calculate and display the least and most efficient chemicals

        }

    }

}
