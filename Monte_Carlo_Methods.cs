using System;
using System.Collections;

namespace _MSOE_OP_Problems
{
	public class Monte_Carlo_Methods
	{
		public static void Main(string[] args)
		{
			Console.WriteLine ("MONTE CARLO METHODS");
			Console.WriteLine ("Determines approximation of PI by generating random points and taking the percentage of those that lie within the upper right quadrant of the unit circle.\n");
			Point[] pointList;

			//estimation with 100 points
			Console.WriteLine ("Generating 100 points...");
			pointList = PointList (100);
			Console.WriteLine ("Calculating...");
			Console.WriteLine ("For {0} random points:\n# of points within circle: {1}\nPI: {2}\n", pointList.Length, TotalInsideCircle(pointList), PIestimation(TotalInsideCircle(pointList), pointList.Length));

			//estimation with 1,000 points
			Console.WriteLine ("\nGenerating 1,000 points...");
			pointList = PointList (1000);
			Console.WriteLine ("Calculating...");
			Console.WriteLine ("For {0} random points:\n# of points within circle: {1}\nPI: {2}\n", pointList.Length, TotalInsideCircle(pointList), PIestimation(TotalInsideCircle(pointList), pointList.Length));

			//estimation with 10,000 points
			Console.WriteLine ("\nGenerating 10,000 points...");
			pointList = PointList (10000);
			Console.WriteLine ("Calculating...");
			Console.WriteLine ("For {0} random points:\n# of points within circle: {1}\nPI: {2}\n", pointList.Length, TotalInsideCircle(pointList), PIestimation(TotalInsideCircle(pointList), pointList.Length));

			//estimation with 100,000 points
			Console.WriteLine ("\nGenerating 100,000 points...");
			pointList = PointList (100000);
			Console.WriteLine ("Calculating...");
			Console.WriteLine ("For {0} random points:\n# of points within circle: {1}\nPI: {2}\n", pointList.Length, TotalInsideCircle(pointList), PIestimation(TotalInsideCircle(pointList), pointList.Length));
		}

		protected static Point[] PointList(int size)
		{
			Point[] points = new Point[size];
			return PopulateArray (points);
		}

		protected static Point[] PopulateArray(Point[] list)
		{
			//for random numbers
			Random generator = new Random ();
			for (int i = 0; i < list.Length; i++)
			{
				//generate random coordinate values
				double x = generator.NextDouble ();
				double y = generator.NextDouble ();
				//create new point and add to list
				Point pt = new Point (x, y);
				list [i] = pt;
			}
			return list;
		}

		protected static int TotalInsideCircle(Point[] list)
		{
			//go through list and count how many points are inside of circle
			int totalInCircle = 0;
			for(int x = 0; x < list.Length; x++)
			{
				if (list [x].IsInQuarterCircle () == true)
				{
					totalInCircle++;
				}
			}
			return totalInCircle;
		}

		protected static double PIestimation(double ptsInCircle, double totalPts)
		{
			return (ptsInCircle/totalPts)*4;
		}

		public class Point
		{
			private double xCoor;
			private double yCoor;

			public Point(double x, double y)
			{
				xCoor = x;
				yCoor = y;
			}

			public double GetXcoordinate()
			{
				return xCoor;
			}

			public double GetYcoordinate()
			{
				return yCoor;
			}

			public bool IsInQuarterCircle()
			{
				//check to see if point lies within the quarter circle (PI/4)
				bool isInQcircle = false;
				if ((0 <= GetXcoordinate () && GetXcoordinate () <= 0.25) && (0 <= GetYcoordinate () && GetYcoordinate () <= 1))
				{
					isInQcircle = true;
				}
				else if ((0 <= GetXcoordinate () && GetXcoordinate () <= 0.5) && (0 <= GetYcoordinate () && GetYcoordinate () <= (7 / 8)))
				{
					isInQcircle = true;
				}
				else if ((0 <= GetXcoordinate () && GetXcoordinate () <= 0.75) && (0 <= GetYcoordinate () && GetYcoordinate () <= 0.75))
				{
					isInQcircle = true;
				}
				else if ((0 <= GetXcoordinate () && GetXcoordinate () <= (7/8)) && (0 <= GetYcoordinate () && GetYcoordinate () <= 0.5))
				{
					isInQcircle = true;
				}
				else if ((0 <= GetXcoordinate () && GetXcoordinate () <= 1) && (0 <= GetYcoordinate () && GetYcoordinate () <= 0.25))
				{
					isInQcircle = true;
				}

				return isInQcircle;
			}

		}
	}
}

