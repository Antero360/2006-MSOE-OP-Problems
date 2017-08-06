using System;

namespace _MSOE_OP_Problems
{
	public class Amortization_Schedule
	{
		private double loanAmount;
		private double loanAPR;
		private int loanPeriod;

		public Amortization_Schedule (double amount, double annualInterest, int years)
		{
			//ensure that loan amount always stays within 2 decimal places.
			loanAmount = Math.Round(amount, 2);
			loanAPR = annualInterest;
			loanPeriod = years;
		}

		private double InterestRate(double apr)
		{
			return (apr / (12 * 100));
		}

		private double PeriodicPayment()
		{
			//number of payments equals number of total months in loan period
			int totalPayments = GetLoanPeriod () * 12;
			double interest = GetInterestRate();

			//monthly payments: (loan amount) * [(interest * ((1 + interest)^(number of monthly payments))) / (((1 + interest)^(number of monthly payments)) - 1)]
			double moPayment = (GetLoanAmount() * ((interest * Math.Pow((1 + interest),totalPayments)) / (Math.Pow((1 + interest),totalPayments) - 1)));
			return Math.Round (moPayment, 2);
		}

		public double GetLoanAmount()
		{
			return Math.Round(loanAmount,2);
		}

		public double GetLoanAPR()
		{
			return loanAPR;
		}

		public double GetInterestRate()
		{
			return InterestRate(GetLoanAPR());
		}

		public int GetLoanPeriod()
		{
			return loanPeriod;
		}

		public double GetMonthlyPayment()
		{
			return PeriodicPayment ();
		}

		public static void Main(string[] args)
		{
			string userInput;
			double loan;
			double loanAPR;
			int loanPeriod;
			bool isValidInput;

			Console.WriteLine ("AMORTIZATION SCHEDULE");
			Console.WriteLine ("Determines monthly payments of a loan, given amount of loan, APR, and loan period in years.\n");

			//user input and validation; input is an integer and greater than 0
			//loan amount
			Console.WriteLine ("Enter the amount being loaned: ");
			userInput = Console.ReadLine ();
			isValidInput = double.TryParse (userInput, out loan);
			while((isValidInput == false) || ((isValidInput == true) && ( loan < 0 )))
			{
				Console.WriteLine ("Please enter a valid positive amount: ");
				userInput = Console.ReadLine ();
				isValidInput = double.TryParse (userInput, out loan);
			}

			//loan interest
			Console.WriteLine ("Enter the APR being applied to loan: ");
			userInput = Console.ReadLine ();
			isValidInput = double.TryParse (userInput, out loanAPR);
			while((isValidInput == false) || ((isValidInput == true) && ( loanAPR < 0 )))
			{
				Console.WriteLine ("Please enter a valid positive amount: ");
				userInput = Console.ReadLine ();
				isValidInput = double.TryParse (userInput, out loanAPR);
			}

			//loan period
			Console.WriteLine ("Enter the loan period in years: ");
			userInput = Console.ReadLine ();
			isValidInput = int.TryParse (userInput, out loanPeriod);
			while((isValidInput == false) || ((isValidInput == true) && ( loanPeriod < 0 )))
			{
				Console.WriteLine ("Please enter a valid positive number: ");
				userInput = Console.ReadLine ();
				isValidInput = int.TryParse (userInput, out loanPeriod);
			}

			Console.WriteLine ("\nCalculating...\n");
			Console.WriteLine ("#\tPRINCIPAL\tINTEREST\tBALANCE");

			//set up Amortization Schedule and print out payment plan
			Amortization_Schedule paymentPlan = new Amortization_Schedule (loan, loanAPR, loanPeriod);
			double currentBalance = paymentPlan.GetLoanAmount();
			double principal;
			double interest;

			//for each payment, calculate principal amount, interest amount, and balance after applying principal
			for(int payNum = 1; payNum <= (paymentPlan.GetLoanPeriod()*12); payNum++)
			{
				interest = Math.Round ((paymentPlan.GetInterestRate() * currentBalance),2);
				principal = Math.Round((paymentPlan.GetMonthlyPayment () - (paymentPlan.GetInterestRate () * currentBalance)),2 );
				currentBalance = Math.Round((currentBalance - principal),2);
				Console.WriteLine ("{0}\t${1}\t${2}\t${3}",payNum,principal,interest,currentBalance);
			}
		}
	}
}

