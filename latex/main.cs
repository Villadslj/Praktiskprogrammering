using static System.Console;
using static System.Math;
class main{
	static void Main(){
	
	for(double L = 0; L <= 2*PI; L += 0.05){
		
		double y = Trig.sin(L);
		WriteLine($"{L} {y}");
		}
	}

}
