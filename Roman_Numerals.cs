using System;

namespace _MSOE_OP_Problems
{
	public class Roman_Numerals
	{
		public static void Main(string[] args)
		{
			Console.WriteLine ("ROMAN NUMERALS");
			Console.WriteLine ("Converts a given Roman Numeral to decimal number.\n");

			Console.WriteLine ("Enter the numeral you would like converted to decimal, ignore case.\n");
			string userInput;
			userInput = Console.ReadLine ().ToUpper();
			while(IsValidNumeral(userInput) == false)
			{
				Console.WriteLine ("Invalid numeral. Please enter a valid Roman Numeral\n");
				userInput = Console.ReadLine().ToUpper();
			}
			Console.WriteLine ("Calculating...");
			Console.WriteLine ("{0} ==> {1}",userInput,Roman2Decimal(userInput));
		}

		private static int Roman2Decimal(string numeral)
		{
			/*
			 * if there is only one character, get the correct decimal number
			 * otherwise, go look through all characters but the last character.
			 * if the current character's decimal value is less than the next
			 * character decimal value, subtract from the total, otherwise add
			 * to total. Finally, add decimal value of the last character
			 */
			int romanDecimal = 0;
			if( numeral.Length == 1 )
			{
				romanDecimal = NumeralStandards (numeral.ToCharArray()[0]);
			}
			else
			{
				char[] numeralArr = numeral.ToCharArray ();
				for(int x = 0; x < numeralArr.Length - 1; x++)
				{
					if( NumeralStandards(numeralArr[x]) < NumeralStandards(numeralArr[x + 1]))
					{
						romanDecimal -= NumeralStandards (numeralArr [x]);
					}
					else
					{
						romanDecimal += NumeralStandards (numeralArr [x]);
					}
				}
				romanDecimal += NumeralStandards (numeral.Substring(numeral.Length - 1).ToCharArray()[0]);
			}
			return romanDecimal;
		}

		private static bool IsValidNumeral(string numeral)
		{
			//check if there are any invalid characters in the input
			//break out as soon as there is one invalid character
			bool isValid = false;
			foreach(char singleNumeral in numeral)
			{
				if( (singleNumeral == 'I') || (singleNumeral == 'V') || (singleNumeral == 'X') || (singleNumeral == 'L') || (singleNumeral == 'C') || (singleNumeral == 'D') || (singleNumeral == 'M'))
				{
					isValid = true;
				}
				else
				{
					isValid = false;
					break;
				}
			}
			return isValid;
		}

		private static int NumeralStandards(char numeral)
		{
			//looks at each character and returns the standard decimal number
			int standard = 0;
			switch (numeral)
			{
				case 'I':
					standard = 1;
					break;
				case 'V':
					standard = 5;
					break;
				case 'X':
					standard = 10;
					break;
				case 'L':
					standard = 50;
					break;
				case 'C':
					standard = 100;
					break;
				case 'D':
					standard = 500;
					break;
				case 'M':
					standard = 1000;
					break;
			}
			return standard;
		}
	}
}

