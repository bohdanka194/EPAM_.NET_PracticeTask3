using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPAM_.NET_PracticeTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Polynom1 (polynomial)... ");
            // 1*x^0 + 3*x^1 + 3*x^2 + 1*x^3
            Polynomial polynom1 = new Polynomial(3, new double[] { 1,3,3,1});
            Console.WriteLine("Polynom1 = " + polynom1);
            Thread.Sleep(2000);

            Console.WriteLine("\nCreating Polynom2... ");
            // 9*x^0 + 6*x^1 + 1*x^2
            Polynomial polynom2 = new Polynomial(2, new double[] { 9, 6, 1 });
            Console.WriteLine("Polynom2 = " + polynom2);
            Thread.Sleep(2000);

            Polynomial suma = polynom1.AddPolynomial(polynom2);
            Console.WriteLine("\nPolynom1 + Polynom2 = " + suma);
            Polynomial subtract = polynom1.SubtractPolynomial(polynom2);
            Thread.Sleep(2000);

            Console.WriteLine("\nPolynom1 - Polynom2 = " + subtract);
            Thread.Sleep(2000);

            Polynomial multiplication = polynom1.MultiplyByPolynomial(polynom2);       
            Console.WriteLine("\nPolynom1 * Polynom2 = " + multiplication);
            Thread.Sleep(2000);

            Console.WriteLine("\nCreating Polynom3... ");
            // 4 + x -3*x^3 + x^5
            var polynom3 = new Polynomial(5,new double[] { 4, 1, 0, -3, 0, 1 });
            Console.WriteLine("Polynom3 = " + polynom3.ToString());
            Console.WriteLine("When x = -1, polynom3 = " + polynom3.CalculateValue(-1));

            Console.WriteLine("\nSuccessfully completed the program!!!");
            Console.Read();
        }
    }
}
