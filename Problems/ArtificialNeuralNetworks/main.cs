using static System.Console;
using static System.Math;
using System.IO;
using static ANN;
using System;

public class mainA{

    public static void Main(){
    	
    	//Part A
        ANN my_ann = new ANN(4);

        // Creating data from a x^2
        int n = 15;
        double a = -PI;
        double b = PI;
        vector x = new vector(n+1);
        vector y = new vector(n+1);        
        for(int i = 0; i <= n; i++){
        
            x[i] = (double) a + i * (b-a)/n ;
            
            y[i] = (double) x[i]*x[i];
            
            //collects the tabulated data
            WriteLine($"{x[i]} {y[i]}");
        }
	WriteLine("");
	WriteLine("");


        my_ann.train(x, y);
        int L = 30;
        for(int i = 0; i <= L; i++){
        
            double xm = a + i * (b-a)/L;
            //collects the interpolated data
            WriteLine($"{xm} {my_ann.feedforward(xm)}");
        }
	// Part B
	
	// Generating data from sin(x), its derivative and its indefinite integral
	
	
        vector x1 = new vector(n+1);
        vector y1 = new vector(n+1);
        vector z1 = new vector(n+1);
        vector q1 = new vector(n+1);
        
        StreamWriter outdata = new StreamWriter("outB.txt", append:false);
        
                      
        for(int i = 0; i <= n; i++){
        	x1[i] = (double) a + i * (b-a)/n ;
        	y1[i] = (double) Sin(x1[i]);
            	z1[i] = (double) Cos(x1[i]); // Deriv of ys
            	q1[i] = (double) -Cos(x1[i]);
        	outdata.WriteLine($"{x1[i]} {y1[i]} {z1[i]} {q1[i]-1}");
        }
        outdata.WriteLine(""); 
        outdata.WriteLine("");

        my_ann.train(x1, y1);
        
        int K = 50;
        
        for(int i = 0; i <= K; i++){
        
        	double xm1 = a + i * (b-a)/K;
            
        	outdata.WriteLine($"{xm1} {my_ann.feedforward(xm1)} {my_ann.deriv(xm1)} {my_ann.integral(xm1,a)}");
        }
     	outdata.Close();
     
        
    }
}
