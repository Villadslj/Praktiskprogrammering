using System;
using System.Collections.Generic;

public class OD_QR_Fitter{

	public static (vector,matrix) fit( vector x, vector y, vector dy, Func<double,double>[] f){
	int n = x.size;
	int m = f.Length;
	matrix A = new matrix(n,m);
	vector b = new vector(n);
	
	matrix R = new matrix(m,m);
	matrix Rm = new matrix(m,m);
	
	// producing A matrix and b vector
	
	for(int i = 0; i < n; i++){
            b[i] = y[i]/dy[i];
        }
        
        for(int i = 0; i < n; i++){
        for(int k = 0; k < m; k++){
                A[i,k] = f[k](x[i])/dy[i];
            }
            }
	
	linear.qr_gs_decomp(A,R);
	vector c = linear.qr_gs_solve(A,R,b);
        linear.qr_gs_decomp(R,Rm);
        matrix IR = linear.qr_gs_inverse(R,Rm);
        matrix S = IR * IR.T;
        return (c,S);
	
	}

}
