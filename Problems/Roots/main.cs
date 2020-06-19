using static System.Console;
using System;
using static System.Math;
using System.IO;



public class main{
    
	public static void Main(){
	
	
	//Part A
	Func<vector,vector> f = (z) => {return new vector(-2.0*(1-z[0]) - 400*(z[1] - Pow(z[0],2)) * z[0], 200 * (z[1] - Pow(z[0],2)));
					};
        
        vector x = new vector(3, 4);
        
        vector result = RootFinder.Newton(f, x);
        
        Write("We are finding the minumum of the Rosenbrock's valley function, by Newton's method with numerical Jacobian and back-tracking linesearch");
        result.print("The minimum was found to be = ");
        Write("Which is the exact same as the analytical result.");
        
        //Part B
        
       
        StreamWriter outdata = new StreamWriter("out.data", append:false);
       
        double rmax = 10;


        // Defining the function to find root of
        Func<vector, vector> fe_root = (vector m) => {
            double e = m[0];
            double fe_rmax = hydrogen.find(e, rmax);
            return new vector(fe_rmax);
        }; 
    
        // Start condition
        vector m0 = new vector(-0.5);   
        vector mroots = RootFinder.Newton(fe_root, m0);

        double e_found = mroots[0];
	
	//collecting data for plotting
        for(double i = 0; i < rmax; i += 0.1){
            outdata.WriteLine("{0} {1} {2}", i, hydrogen.find(e_found,i), i * Exp(-i));
        }

        vector e_found_vec = new vector(e_found);
        
        Write(" In part B , the error was found at root = {0}.",fe_root(e_found_vec)[0]);

        outdata.Close();
        //outBtxt.Close();
        
     
    	
    	
	}
	
}
