using System;
using static System.Math;
public static class Trig{
	public static double sin(double L){
	
		int a = 0;
		Func<double,double> sinus = (x) => Sin(x);
		double y =  quad.o8av(sinus,a,L,acc:1e-6, eps:1e-6);
		
	return y;
	}
}
