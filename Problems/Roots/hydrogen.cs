using System;
using System.Collections.Generic;

public class hydrogen{

    public static double find(double e, double r){
        
        double r_min = 1e-6;
        
        if(r < r_min) return r - r*r; 

        // Defining ODE
        Func<double, vector, vector> f = (l,y) => {return new vector(y[1], - 2 * (e + 1.0/l) * y[0]);};

        // Defining initialconditions
        vector ymin = new vector(r_min - r_min * r_min, 1 - 2 * r_min);

        // Integrating the ODE 
        List<double> ts = new List<double>(); 
        List<vector> ys = new List<vector>();
        vector y_max = ODE_integrator.driver(f, r_min, ymin, r, 1e-3, 1e-6, 1e-6, ts, ys);
        
        
        return y_max[0];
    }  

    
}
