using static System.Math;
using static System.Console;
using System.IO;
class mainA{

	public static void Main(){
	
	// generating data
	int n=10;
	double a = 0, b= 4*PI;
	vector x = new vector((int) n);
	vector y = new vector((int) n);
	
	StreamWriter outputfileData = new StreamWriter("xyData.txt", append:false);
	
	for(int i = 0; i < n; i++){
            x[i] = (double) i * b/n ;
            y[i] = (double) (x[i])*(x[i])-(x[i])*(x[i])*(x[i]);
            outputfileData.WriteLine("{0} {1}", x[i], y[i]);
        }
	
	outputfileData.Close();
	
	// Doing line interpolation and integration for the function x^2-x^3
	StreamWriter outputfileSpline = new StreamWriter("linterpData.txt", append:false);
        StreamWriter outputfileIntegration = new StreamWriter("integrationData.txt", append:false);

        double Resolution = 30;
        double z = 0;
        a = x[0]; b = x[x.size-1];
        for(double i = 0.0; i < Resolution; i++){
            z = a + i * b/Resolution;
            outputfileSpline.WriteLine("{0} {1}", z, Linespline.linterp(x,y,z));
            outputfileIntegration.WriteLine("{0} {1} {2}", z, Linespline.linterpInteg(x,y,z), z*z*z/3-z*z*z*z/4);
        }
        outputfileSpline.Close();
        outputfileIntegration.Close();
	
	}


}
