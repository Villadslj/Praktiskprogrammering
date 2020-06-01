using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
class mainA{
	static int Main(){

	double xa = 0;
	double xb = 3;
	vector ya =  new vector(0.5);

	Func<double,vector, vector> ydiff = delegate(double x, vector y){
	var res = new vector(y[0] * (1-y[0]));
	return res;
	};

	List<double> xs = new List<double>();
	List<vector> ys = new List<vector>();

	vector yb = ode.rk23(ydiff,xa,ya,xb,xs,ys);

	double analytic = 0;
	for(int i  = 0; i < xs.Count; i++){
		analytic = 1/(1+Exp(-xs[i]));
		WriteLine($"x step value {xs[i]}, gives numerical solution {ys[i][0]} compared to analytical result {analytic}");
	}
	return 0;
	}
}
