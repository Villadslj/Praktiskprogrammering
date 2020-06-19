using System;
using static System.Console;
using static System.Math;
using System.IO;

public class mainA2{
    public static void Main(){
	//Second part of A
	
	
	StreamWriter eigenenergies = new StreamWriter("eigenenergiesA2.data", append:false);
        StreamWriter outData = new StreamWriter("outA2.data", append:false);
        int m = 99;
        double s=1.0/(m+1);
        matrix H = new matrix(m,m);
        for(int i=0;i<m-1;i++){
            matrix.set(H,i,i,-2);
            matrix.set(H,i,i+1,1);
            matrix.set(H,i+1,i,1);
        }
        matrix.set(H,m-1,m-1,-2);
        matrix.scale(H,-1/s/s);
        
        vector D2 = new vector(m);
        matrix V2 = new matrix(m,m);
        
        int sweeps2 = Jacobi_diagonalization.cyclic_sweep(H, V2, D2);
        for (int k=0; k < m/3; k++){
            double exact = PI*PI*(k+1)*(k+1);
            double calculated = D2[k];
            eigenenergies.WriteLine($"{k} {calculated} {exact}");
        }

        for(int k=0;k<4;k++){
            outData.WriteLine($"{0} {0}");
            for(int i=0;i<m;i++){
                double factor = Sign(V2[0,k]);
                outData.WriteLine($"{(i+1.0)/(m+1.0)} {V2[i,k]*factor/Sqrt(s)}");
            }
            outData.WriteLine($"{1} {0}");
            outData.WriteLine("");
         }

        outData.Close();
        eigenenergies.Close();

        }
}
