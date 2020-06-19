using static System.Console;
using static System.Math;
using static Nintegrator;
using static quad;
using System;


public class mainB{
    
    public static void Main(){
        Console.WriteLine("Part B");
        
        Console.WriteLine("We want to calculate the integral 1/Sqrt(x) dx from a=0 to b=1 and ln(x)/Sqrt(x) with the same baundaries using the Clenshaw-Curtis transformaiton, to check if the transformation have improvements for integrals with integrable divergencies.");
        int noOfCalls = 0;
        Func<double,double> f1 = (x) => {noOfCalls++; return 1.0/Sqrt(x);};
        double res1 = clenshaw_curtis(f1, 0, 1, 1e-3, 1e-3);
        
        Console.WriteLine($"The result is {res1:f5}, with {noOfCalls} number of calls to the function. The analytical result is 2.000.");
        noOfCalls = 0;
        double res2 = integrator(f1,0,1,1e-3,1e-3);
        Console.WriteLine("Calculating the integral without Clenshaw-Curtis transformation gives {res2:f5}, with {noOfCalls} number of calls to the function");
        Console.WriteLine("");
        Console.WriteLine("We now calculate the integral of ln(x)/Sqrt(x) dx from a=0 to b=1 with Clenshaw-Curtis transformaiton. ");
        noOfCalls = 0;
        Func<double,double> f2 = (x) => {noOfCalls++; return Log(x)/Sqrt(x);};
        double res3 = clenshaw_curtis(f2,0,1, 1e-3, 1e-3);
        Console.WriteLine($"This gives {res3:f5}, with {noOfCalls} number of calls to the function. The analytical result is -4.00");
        noOfCalls = 0;
        double res4 = integrator(f2, 0, 1, 1e-3, 1e-3);
        Console.WriteLine($"Without the transformation we get {res4:f5}, with {noOfCalls} number of calls to the function");
        Console.WriteLine("The Clenshaw-Curtis transformaiton do infact reduce the number of calls quiet significantly");
        Console.WriteLine("");
        Console.WriteLine("At last we calculate the integral 4 * Sqrt(1-x^2) dx from a=0 to b=1 with Clenshaw-Curtis transformaiton");
        noOfCalls = 0;
        Func<double,double> f3 = (x) => {noOfCalls++; return 4 * Sqrt(1- Pow(x,2));};
        double res5 = clenshaw_curtis(f3, 0, 1, 1e-3, 1e-3);
        Console.WriteLine($"The result is {res5:f10}, with {noOfCalls} number of calls to the function, where the analtical resutl is pi");
        noOfCalls = 0;
        double res6 = integrator(f3, 0, 1, 1e-3, 1e-3);
        Console.WriteLine($"Again the result without the transformation is {res6:f10}, with {noOfCalls} number calls to the function");
        noOfCalls = 0;
        double res7 = o8av(f3, 0, 1, 1e-3, 1e-3);
        Console.WriteLine($"Comparing to the 'o8av' integrator routine from matlib, the result is {res7:f10}, with {noOfCalls} number of calls to the function");
        Console.WriteLine("We see that  'o8av' uses fewer calls but is also less accurate.");

    }
}
