using System;
using System.IO;

namespace _MSOE_OP_Problems
{
	public class Pyramid_of_Balls
	{
		public static void Main (string[] args)
		{
			string userInput;
			bool isNumber;
			int pyramidLayers;
			Console.WriteLine ("PYRAMID OF BALLS");
			Console.WriteLine ("Determines number of balls needed for a pyramid, given layer depth, where the number of balls of any layer is the square of a layer.\n");
			Console.WriteLine ("Enter the number of layers for this pyramid: ");

			//validate input; make sure input is an integer and it is not less than 1
			userInput = Console.ReadLine ();
			isNumber = int.TryParse (userInput, out pyramidLayers);
			while (isNumber == false || (isNumber == true && (pyramidLayers < 1)) )
			{
				Console.WriteLine ("Please enter a valid positive number: ");
				userInput = Console.ReadLine ();
				isNumber = int.TryParse (userInput, out pyramidLayers);
			}
			Console.WriteLine ("Calculating...");
			Console.WriteLine ("For a pyramid that is {0} layers deep, you will need a total of {1} balls.", pyramidLayers, Sigma(pyramidLayers));
		}

		protected static int Sigma(int pLayer)
		{
			//find the total number of balls in pyramid using sigma notation
			//Sum of x^2, from 1 to the number of layers;
			//where x is current layer and (x^2) is the number of balls for current layer
			int ballTotal = 0;

			for (int x = 1; x <= pLayer; x++)
			{
				ballTotal += (x * x);
			}

			return ballTotal;
		}
	}
}

