using static System.Console;

// Linear spline interpolation
public class Linespline{


static public double linterp(vector x, vector y, double z){


// Bineary search algoritme 

int i=0, j=x.size-1;
while(j-i>1){
	int mid=(i+j)/2;
	if(z>x[mid]) i=mid; 
	else j=mid;
	}


	return y[i] + (y[i+1] - y[i])/(x[i+1]-x[i]) * (z-x[i]);

}

// intergrations of linear spline interpolation. given the function is y=x^2-x^3


static public double linterpInteg(vector x, vector y, double z){


int i = 0;             // Indicating where in the x-vector we are.
        double res = 0;
        while( z > x[i+1]){
            res += y[i] * (x[i+1]-x[i]) + 0.5 * (y[i+1]- y[i]) * (x[i+1] - x[i]);
            i++;
        }
        
	res += y[i]*(z-x[i]) + 0.5 * (y[i+1] - y[i])/(x[i+1] - x[i]) * (z - x[i]) * (z - x[i]);  
	return res;   
}
}
