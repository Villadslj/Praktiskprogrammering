using System;
using static System.Console;
using static System.Math;
class main{

const double inf = System.Double.PositiveInfinity;
	// Excercise A
	static double gamma(double z){

		if (z < 0) return - PI/Sin(PI*z)/gamma(1+z);
		if (z <=1) return gamma(z+1)/z;
		if (z > 2) return gamma(z-1)*(z-1);
		Func<double,double> f = (x) => Pow(x,z-1) * Exp(-x);
	return quad.o8av(f,0,inf, acc:1e-6, eps:0);
	}

	static Func<double,double> A1 = x => (Log(x)/Sqrt(x)); 
	static Func<double,double> A2 = x => Exp(-Pow(x,2));
	static double A3(double p){
		Func<double,double> f = x => Pow(Log(1/x),p);
		return  quad.o8av(f,0,1, acc:1e-6, eps:0);
	}



	static void Main(){
		WriteLine($"Integral of ln(x)/sqrt(x) from 0 to 1 is = {quad.o8av(A1,0,1)} which is approxematly 4.");
		WriteLine($"Integral of Exp(-Pow(x,2)) from -inf to inf is = {quad.o8av(A2,-inf,inf)}, sqrt(pi) = {Sqrt(PI)}");
		for(double x = 1; x<5; x += 1)
		WriteLine("Integral of Pow((Log(1/x),{0:f2}) from 0 to 1 is = {1:f6}, Here gamma({0:f2} + 1) = {2:f6}",x,A3(x),gamma(x+1));
 
	}
}
