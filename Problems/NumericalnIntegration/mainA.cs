using static System.Console;
using static System.Math;
using static Nintegrator;
using System;


public class mainA{
    
    public static void Main(){
        Console.WriteLine("Part A.");
        Console.WriteLine("Calculating the integral of Sqrt(x) dx from a=0 to b=1");
        Func<double,double> f = (x) => Sqrt(x);

        double res1 = integrator(f, 0, 1, 1e-6, 1e-6);
        Console.WriteLine($"Tish gives {res1:f5}");
        Console.WriteLine($"Where the analytical result is {2.0/3:f5}.");
        Console.WriteLine("Next we calculate the integral of 4* Sqrt(1-x^2) dx from a=0 to b=1");
        Func<double, double> g = (x) => Sqrt(1-Pow(x,2)) * 4.0;
        double res2 = integrator(g, 0, 1, 1e-6, 1e-6);
        Console.WriteLine($"The result is {res2:f5}");
        Console.WriteLine($"Where again the analytical result is {PI:f5}. So both numerical integrals seem to match the analytical result");


    }
}
