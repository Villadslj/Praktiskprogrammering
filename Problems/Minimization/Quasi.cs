using System; 
using static System.Console; 
using static System.Math;
using static vector;
using static matrix;

public class Quasi{

public static double EPS=1.0/4194304;

	public static vector gradient(Func<vector, double> f, vector x){
        
        
    	vector res = new vector(x.size);
    	vector x_t;


    	for(int i = 0; i < x.size; i++ ){
		double dx = Abs(x[i]) * EPS;
		if(Abs(x[i]) < Sqrt(EPS)) dx = EPS;
	x_t = x.copy();
    	x_t[i] += dx;
    	res[i] = (f(x_t) - f(x))/dx;
    	}
    	return res;
	}

	public static int qnewton(Func<vector,double> f, ref vector x){  
        
	double eps = 1e-3;
        //  Hessian Matrix
        int n = x.size;
        matrix B = new matrix(n,n);
        B.set_unity();
                
        // Starting values
        double fx = f(x);
        vector gx = gradient(f,x);
        vector delta_x;

        int counts = 0;
        do{
            counts++;
            delta_x = -B * gx;

            // Back-tracking linesearch
            double fz, l = 1.0;
            while(true){
                fz = f(x + l * delta_x);    
                if( fz < fx) break; 
                if(l < EPS){
                    B.set_unity();
                    break;          
                }
                l = l/2;
            }
           
           
            
            vector s = l * delta_x;
            vector gz = gradient(f, x + s); 
            vector y = gz - gx;
            vector u = s - B * y;
            double udoty = u.dot(y);
            if( Abs(udoty) > 10e-6){      
                B = B +  outer(u, u) * 1/udoty;
            }
            
            
            x += s;
            gx = gz;
            fx = fz;
            
        } while(gx.norm() > eps && delta_x.norm() > EPS * x.norm() );
        
        return counts;
	}    
}
