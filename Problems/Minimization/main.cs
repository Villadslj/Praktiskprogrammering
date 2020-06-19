using static System.Console;
using System;
using static System.Math;
using System.IO;



public class main{
    
	public static void Main(){
	
	
	double EPS = Pow(10,-6);
	//
	Func<vector,double> f = (z) =>  Pow(1-z[0],2) + 100 * Pow(z[1] - Pow(z[0],2),2); 
        vector x01 = new vector(0,0);
        
	int StepCounts = Quasi.qnewton(f,ref x01);
        
        WriteLine("");
        x01.print("Starting point:    ");
        WriteLine($"steps = {StepCounts}");
        WriteLine($"Found minimum = ({x01[0]:f5}, {x01[1]:f5},)");
        WriteLine($"Exact minimum = (1,1)");
        WriteLine($"Tolerance for gradient = {EPS}");
        
        
        //
        Func<vector,double> f2 = (z) =>  Pow((Pow(z[0],2) + z[1] - 11),2) + Pow(z[0] + Pow(z[1],2) - 7,2); 
        vector x02 = new vector(-2 ,3);
        
	int StepCounts2 = Quasi.qnewton(f2,ref x02);
        
       	x02.print("Starting point:   ");
        
        
        WriteLine($"steps = {StepCounts2}");
        
        WriteLine($"The minimum was found at minimum = ({x02[0]:f5}, {x02[1]:f5})");
        WriteLine($"Where the analytical minimum = (-2.805118, 3.131312)");
        WriteLine($"The tolorence for gradient is = {EPS}");

	
	
	
	
	
	
	
	}
}
