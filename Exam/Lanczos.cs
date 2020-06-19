using System; 
using static System.Math;
using static System.Random;

public class Lanczos{


	public static matrix execute(matrix A, int m, int K){
	
	//Generate vector with euclidian norm 1 and same dimonsion as matrix A. 
	int Dimension = A.size2;
	
	vector v1 = new vector((int) Dimension);
	for(int i=0; i<Dimension; i++){ 	
	v1[i] =  (i+1); 
	
	}
	
	// create empty arrays of vectors to store vectores in during algorithm run.
	vector[] wm = new vector[m];
	double[] Alpha = new double[m];
	double[] Beta = new double[m];
	vector[] w = new vector[m];
	vector[] v = new vector[Dimension];
	
	vector[] u = new vector[m];
	
	// First step of the Lanczos algorithm
	v[0]=v1/v1.norm();
	wm[0] =  A * v[0];
	Alpha[0] = wm[0].dot(v[0]);
	w[0] = wm[0] - Alpha[0] * v[0];
	
	// prepare to generate random numbers for vector generation in Lanczos alorithm
	var rand = new Random();
	
	//Lanczos algorithm
	
	for(int j = 1; j < m; j++){
		
		Beta[j]=w[j-1].norm();	
		if(Beta[j]==0){
			//Generate random vector 		
			u[j] = new vector((int) v[0].size);
			for(int i=0;i<=u[j].size;i++){
			u[j][i] = rand.Next(1000);
			}
			// Use Gram-smith algorithm make sure it is orthonormal 
			for(int i=1; i<j; i++){
			u[j] += - u[j].dot(v[i-1])/(v[i-1].dot(v[i-1]))*v[i-1];
			}
			
			v[j]=u[j]/u[j].norm();
		}
		else{
		
		v[j]= w[j-1]/Beta[j];
		
		}
		
	wm[j] = A * v[j];
	Alpha[j] = wm[j].dot(v[j]);
	w[j] = wm[j] - Alpha[j]*v[j] - Beta[j]*v[j-1];	
		
	}
	
	//Genrate V matrix from v_j  vectors as columns in the matrix
	matrix V = new matrix( (int) Dimension, (int) m);
	
	for(int i=0; i<m; i++){
	
	V[0][i]=v[0][i];
	
	}
	
	for(int i=0; i<m; i++){
	
	V[1][i]=v[1][i];
	
	}
	
	for(int i=0; i<m; i++){
	
	V[2][i]=v[2][i];
	
	}
	
	// Generate the Triangular matrix T
	matrix T = new matrix( (int) Dimension, (int) Dimension);
	
	for(int i=1; i<=m; i++){
		T[i-1][i-1]=Alpha[i-1];
			if(i<=m-1){
    			T[i-1][i]=Beta[i];
    			T[i][i-1]=Beta[i];
			}
		}
	
	
	// Check to see if the function should retun V or T, dependent on put value K. 
	if(K==0){
	return T;
	}
	else{
	return V;
	}
	
	}
	
	
	


	
	
	
	
	
	
}




