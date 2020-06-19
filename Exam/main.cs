using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	
	
	WriteLine("My last 2 digits in my student number is 22 so 22 mod 22 = 0, which is then the exam project I have done.");
	WriteLine("In this project I use the Lanczos algorithm to produce the Matrixes V and T where A = V T V^{T}");
	WriteLine("The real symmetric matrix we choose as en example is");
	//Define symmetric matrix
	var A = new matrix("1 2 3;2 4 5;3 5 8");
	A.print("A = ");
	
	WriteLine("We then apply the Lanczos algortihm to get the V and T matrices.");
	//Call V and T matrix from Lanczos algorithm
	matrix T = Lanczos.execute(A,3,0);
	matrix V = Lanczos.execute(A,3,1);
	//Print them
	T.print("T = ");
	V.print("V = ");
	
	//Recreate A to check that T and V are correct
	matrix A2 = V * T * V.transpose();
	
	
	A2.print("Were A should be V T V^T. We calculate this to check, V T V^T =  ");
	WriteLine("Which gives exactley A again");



}

}
