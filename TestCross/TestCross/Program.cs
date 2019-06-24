using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Integration;

namespace TestCross
{
    class Program
    {
        static void Main(string[] args)
        {

            /// Git test project
            Console.WriteLine("ASP joined the project");



            /// Simpsons Rule
            //---------------------------------------------
            Console.WriteLine("Simpson integration");
            Console.WriteLine("");

            // Composite approximation with 4 partitions
            double composite = SimpsonRule.IntegrateComposite(x => x * x, 0.0, 10.0, 4);

            // Approximate value using IntegrateComposite with 4 partitions is: 333.33333333333337
            Console.WriteLine("Approximate value using IntegrateComposite with 4 partitions is: " + composite);

            // Three point approximation
            double threePoint = SimpsonRule.IntegrateThreePoint(x => x * x, 0.0, 10.0);

            // Approximate value using IntegrateThreePoint is: 333.333333333333
            Console.WriteLine("Approximate value using IntegrateThreePoint is: " + threePoint);


            /// Gauss-Legendre integration
            //---------------------------------------------
            Console.WriteLine("");
            Console.WriteLine("Gauss-Legendre integration");
            Console.WriteLine("");

            // Create a 5-point Gauss-Legendre rule over the integration interval [0, 10]
            GaussLegendreRule rule = new GaussLegendreRule(0.0, 10.0, 5);

            double sum = 0; // Will hold the approximate value of the integral
            for (int i = 0; i < rule.Order; i++) // rule.Order = 5
            {
                // Access the ith abscissa and weight
                sum += rule.GetWeight(i) * rule.GetAbscissa(i) * rule.GetAbscissa(i);
            }

            // Approximate value is: 333.333333333333
            Console.WriteLine("Approximate value is: " + sum);

            // The order of the rule is: 5
            Console.WriteLine("The order of the rule is: " + rule.Order);

            // 1D integration using a 5-point Gauss-Legendre rule over the integration interval [0, 10]
            double integrate1D = GaussLegendreRule.Integrate(x => x * x * x, 0.0, 10.0, 5);

            // Approximate value of the 1D integral is: 333.333333333333
            Console.WriteLine("Approximate value of the 1D integral is: " + integrate1D);

            // 2D integration using a 5-point Gauss-Legendre rule over the integration interval [0, 10] X [1, 2]
            double integrate2D = GaussLegendreRule.Integrate((x, y) => (x * x) * (y * y), 0.0, 10.0, 1.0, 2.0, 5);

            // Approximate value of the 2D integral is: 777.777777777778
            Console.WriteLine("Approximate value of the 2D integral is: " + integrate2D);

            Console.ReadLine();








        }
    }
}
