using System; 
using static System.Console; 
using static System.Math;
using static vector;
using System.Collections.Generic;


public class montecarlo{

    static Random rand = new Random();
    
    public static vector randomx(vector a, vector b){
    
        vector x = new vector(a.size);
        
        for(int i = 0; i < x.size; i++){
            x[i] = a[i] + rand.NextDouble() * (b[i]-a[i]);
        }
        return x;
    }

    public static vector plainmc(Func<vector,double> f, vector a, vector b, int N){
        double volume = 1; 
        
        // Total volume
        for(int i = 0; i < a.size; i++){
            volume *= b[i] - a[i];
        }
        double sum = 0;         
        double sum2 = 0;     
        for(int i = 0; i < N; i++){  
            double fx = f(randomx(a,b));
            sum += fx;
            sum2 += fx*fx;
        }
        double mean = sum/N;	 // <f_i>
        double sigma = Sqrt(sum2/N - mean*mean); // sigma² = <(f_i)²> - <f_i>²
        double SIGMA = sigma/Sqrt(N);	// SIGMA² = <Q²> - <Q>²
        return new vector(mean*volume, volume * SIGMA );   
    }
    
    
} 


