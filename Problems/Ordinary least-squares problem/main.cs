using System;
using static System.Math;
using System.IO;

class main{
    public static void Main(){
        StreamWriter outB = new StreamWriter("B.txt", append:false);
        // Creating data
        var t = new vector(new double[] {1,2,3,4,6,9,10,13,15});
        var y = new vector(new double[] {117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1});
        var dy = y*1/20;
        
        Func<double,double>[] f = {(x) => 1, (x) => x};
        var lny = new vector(y.size);
        var lndy = new vector(dy.size);

        for(int i = 0; i < lny.size; i++){
            lny[i] = Log(y[i]);
            lndy[i] = dy[i]/y[i];
        }
        
        
        // Fitting
        
        var(c,S) = OD_QR_Fitter.fit(t,lny,lndy,f);
        
        outB.WriteLine($"lambda = {-c[1]:f5}, dlambda = {Sqrt(S[1,1]):f5}");

        outB.WriteLine($"T1/2 = {Log(2)/c[1]:f1} pm {Log(2)/Pow(c[1],2) * Sqrt(S[1,1]):f1} days");


        StreamWriter outputData = new StreamWriter("outputData.txt", append:false);
        StreamWriter outputFitData = new StreamWriter("outputFitData.txt", append:false);
        

        for(int i = 0; i < t.size; i++){
            outputData.WriteLine("{0} {1} {2}",t[i], y[i], dy[i]);
            
        }
        
        int n = 50; 
        double a = t[0], b  = t[t.size-1];
        var resy = new vector(n);
        var rest = new vector(n);
        var resyC0Plus = new vector(n);
        var resyC0Minus = new vector(n);
        var resyC1Plus = new vector(n);
        var resyC1Minus = new vector(n);
        for(int i = 0; i < n; i++){
            rest[i] = a + i * b/n;
            resy[i] = Exp(c[0] + c[1] * rest[i]); 
            resyC0Plus[i]  = Exp(c[0]+Sqrt(S[0,0]) + (c[1] * rest[i])); 
            resyC0Minus[i] = Exp(c[0]-Sqrt(S[0,0]) + (c[1] * rest[i])); 
            resyC1Plus[i]  = Exp(c[0] + (c[1] + S[1,1]) * rest[i]);     
            resyC1Minus[i] = Exp(c[0] + (c[1] - S[1,1]) * rest[i]);     
            outputFitData.WriteLine("{0} {1} {2} {3} {4} {5}", rest[i], resy[i], resyC0Plus[i], resyC0Minus[i], resyC1Plus[i], resyC1Minus[i]);
        }
        
        outputFitData.Close();
        outputData.Close();
        outB.Close();
        
        }
}

