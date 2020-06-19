using System;
using static System.Console;
using static System.Math;
using System.IO;

public class mainA{
    public static void Main(){
    
    	// First part of A
        int n = 5; // Size of quadratic matrix M.
        var rnd = new Random(1);
        Console.WriteLine("Part A1");
        matrix M = new matrix(n,n);
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                M[i,j] = 4 * rnd.NextDouble() - 1.5;
                M[j,i] = M[i,j];
            }
        }
        matrix M2 = M.copy();
        M.print("We choose an arbitrary matrix M = ");
        vector D = new vector(n);
        matrix V = new matrix(n,n);
        int sweeps = Jacobi_diagonalization.cyclic_sweep(M, V, D);
        matrix temp2 = V.T*M2*V;
        Console.WriteLine($"Total number of sweeps done is = {sweeps}");
        temp2.print("V.T*M*V = ");
        D.print("Eigenvalues = ");



    }
}

