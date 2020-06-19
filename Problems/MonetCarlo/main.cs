
using static System.Console;
using static System.Math;
using static montecarlo;
using System.IO;
using System;

public class mainA{
    public static void Main(){


	//Part A
	Func<vector,double> f = (v) => {return 1.0/Pow(PI,3) * 1.0/(1 - Cos(v[0]) * Sin(v[1]) * Cos(v[2]));};

	int N = (int) 1e6;
        vector a = new vector(0, 0, 0);
        vector b = new vector(PI, PI, PI);
        
        vector res = plainmc(f, a, b, N);
        
        double mean = res[0];
        double error  = res[1];
        WriteLine("Part A");
        WriteLine("The integral of interrest is (1/PI)^3 * 1/(1 - Cos(x) * Sin(y) * Cos(z))");
        
        double Analytical_res = 1.3932039296856768591842462603255;
        
        
        WriteLine($"The result from the montecarlo integration is ={mean}");
        WriteLine($"with errror estimate of = {error}");
        WriteLine($"Compared to the analytical result = {Analytical_res}");
        
        
        //Part B
        
        Func<vector,double> f1 = (v) => {return Sin(v[0]) * Sin(v[1]);};
        
        vector a1 = new vector(0,0);
        vector b1 = new vector(PI,PI);
        
       
        StreamWriter outdata = new StreamWriter("out.data", append:false);
        WriteLine("");
        WriteLine("Part B");
        WriteLine("To compare the error to the 1/Sqrt(N) dependency, we plot the monte carlo result - the analytical resut for the integral of ");
        WriteLine("sin(x)sin(y) from 0 to PI, which gives 4, and compare to a/Sqrt(N) where a is a constant (4 in this case)");
        WriteLine("This in plottet in this folder.");
        
        for(int i = 0; i<=500; i++){
        int x = i;
        vector res1 = plainmc(f1, a1, b1, x);
        double mean1 = res1[0];
        double error1  = res[1];
     
       	outdata.WriteLine($"{Abs(4 - mean1)} {x} {4/Sqrt(x)}");
        
        }
        
        outdata.Close();
        
        
        
        }
}
