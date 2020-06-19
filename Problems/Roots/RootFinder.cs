using System; 
using static System.Console; 
using static System.Math;
using static vector;


public class RootFinder{
    public static vector Newton(Func<vector,vector> f, vector x) {
        
     	
     	double epsilon=1e-3;
     	double dx=1e-7;
        int n = x.size;
        
        vector x_temp;
       	
       	vector dfdx = new vector(n);
       
        vector delta_x;
       
        matrix J = new matrix(n, n);


	
        do{
            // Calculating Jacobian matrix
            for(int k = 0; k < n; k++){
                
                x_temp = x.copy();
                
                x_temp[k] = x_temp[k] + dx;
                
                dfdx = (f(x_temp) - f(x))/dx;
                
                	for(int i = 0; i < n; i++){
                
                	    J[i,k] = dfdx[i];
                	}
            }
            //solving the jacobian matrix 
            
            matrix R = new matrix(n,n);
            linear.qr_gs_decomp(J,R);
            delta_x = linear.qr_gs_solve(J , R , -1.0 * f(x));


            double l = 1.0;
            while(f(x + l * delta_x).norm() > (1 - l/(2 * 0.6)) * f(x).norm() && l >= 1/64 ){
                
                l = l/2;
            }
            x = x + l * delta_x;
            
            }
	while(f(x).norm() > epsilon);    
            
        return x;
    } 
}
