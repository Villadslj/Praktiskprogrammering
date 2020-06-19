using System; 
using static System.Console; 
using static System.Math;
using System.Collections.Generic;
using static vector;
using static Quasi;


public partial class ANN {
   
    
    Func<double,double> f;
    Func<double,double> fm;
    Func<double,double> fmm;
    Func<double,double> F;
    
    int n;
    vector p;
    Random rand = new Random();
    int calls;
    
    private void init (int n){
    calls = 0;
    
    f = (x) =>  x * Exp(-x * x);    // Activation function
    fm = (x) => Exp(-x * x) - 2 * x * x * Exp(-x * x);  // Deriv og f
    fmm = (x) => - 2 * x * Exp(-x * x) -4 * x * Exp(-x * x) + 4 * x * x * x * Exp(-x * x); // Double deriv of f
    F = (x) => -Exp(-x * x)/2;      // Integral of f
    p = new vector(3 * n);
    }



    public ANN(int m){
        
        init(m);
        n = m;        
        for(int i = 0; i < 3 * n; i++){
        
            	// generates numbers froma normal distribution
        	double u1 = 1.0 - rand.NextDouble(); 
        	double u2 = 1.0 - rand.NextDouble();
        	p[i] = Math.Sqrt(-2.0 * Math.Log(u1))* Math.Sin(2.0 * Math.PI * u2); 
        
        }
        
    }
	
	public double feedforward(double x){
        double y = 0;
        for(int i = 0; i < n; i++){
          
        double ai = p[3 * i + 0];
        double bi = p[3 * i + 1];
        double wi = p[3 * i + 2];
        y += wi * f((x-ai)/bi);
        }
        return y;
    }
   
    public void train(vector x,vector y){
        double res1 = 0;
        Func<vector,double> deltaP =  (k) => {
            p = k;
            double res = 0;
            for(int i = 0; i < x.size; i++){
                res += Pow((feedforward(x[i]) - y[i]), 2);
            
            }
            
            
            res1 = res;
            return res;
        };
        vector pa = p.copy();
        int ncounts = Quasi.qnewton(deltaP, ref pa);
        p = pa;
        
         
        double TH = 0.01;  //threshhold
        if(res1 > TH){
            calls++;
            res1 = 0;
            for(int i = 0; i < 3 * n; i++){
                double u1 = 1.0 - rand.NextDouble(); 
                double u2 = 1.0 - rand.NextDouble();
                p[i] = Math.Sqrt(-2.0* Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); 
                }
            train(x,y);
        }
        
    } 

    public double deriv(double x){  // gives the derivative of x
        double res = 0;
        for(int i = 0; i < n; i++){
            double ai = p[3 * i + 0];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];
            res += wi * fm((x-ai)/bi)/bi;
        }
        return res;
    } 

    public double integral(double x, double a){ // Gives the integral from a to x
        double res = 0;
        for(int i = 0; i < n; i++){
        
            double ai = p[3 * i + 0];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];
         
            res += wi * F((x-ai)/bi) * bi; 
            res -= wi * F((a-ai)/bi) * bi;           
        }
        return res;
    } 
}
