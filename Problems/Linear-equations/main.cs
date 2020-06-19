using static System.Console;
class main{
public static void Main(){


	WriteLine("Part A");
	
	
        var rand = new System.Random();
        
        int m = 3 + rand.Next(5);
        int n = m + rand.Next(5);
        
        var A1 = linear.random_matrix(n, m);
        var A1_copy = A1.copy();
        
        WriteLine("We first make a random matrix of random dimensions:");
        
        A1.print("A1 = ");
        
        var R1 = new matrix(A1.size2, A1.size2);
        
        linear.qr_gs_decomp(A1,R1); 
        
        WriteLine("");
        WriteLine("We then decompose into Q and R with the use of GS-factorization:");
        
        A1.print("Decomposition Q = ");
        R1.print("Decomposition R1 = ");
        
        var temp = A1.T*A1;
        
        WriteLine("");
        WriteLine("We have to amke sure Q^T*Q is the identity matrix:");
        
        temp.print("Q^T*Q = ");
        temp = A1 * R1 - A1_copy;
        WriteLine("And we check that Q*R1-A1 = 0");
        temp.print("Q*R1 - A1 = ");
        Write("\n \n");


        WriteLine("Next we loo k for at solution to Ax = b.");        
        var A2 = linear.random_matrix(m, m);
        WriteLine("making a second random square matrix, A2:");
        A2.print("A2 = ");
        var b = linear.random_vector(m);
        WriteLine("and a random vector b:");
        b.print("b = ");
        var R2 = new matrix(A2.size2, A2.size2);
        WriteLine("we sue QR-factorisation");
        linear.qr_gs_decomp(A2,R2); 
        
        
        vector x = linear.qr_gs_solve(A2,R2,b);
        WriteLine("where we can find x as a solution to equation:");
        x.print("x = ");
        WriteLine("And last we check that A*x-b = 0");
        var temp4 = A2 * R2 * x -b;
        temp4.print();

        Write("\n \n");
        WriteLine("Problem B");
        WriteLine("Like before we create a random square matrix:");
        var B1 = linear.random_matrix(m,m);
        var B1_copy = B1.copy();
        B1.print("B = ");
        
        
        WriteLine("and we calculate the inverse of A2 by QR-facorization");
        var R3 = new matrix(B1.size2, B1.size2);
        linear.qr_gs_decomp(B1,R3);

        matrix B2 = linear.qr_gs_inverse(B1,R3);
        WriteLine("Inverse of B is:");
        B2.print("B^(-1) = ");
        WriteLine("To make sure we found the invers we check, B * B^(-1) = I:");
        var temp3 = B1_copy * B2;
        temp3.print("B^(-1) * B");	
	WriteLine("So it seems to be correct");
        


	}



}




