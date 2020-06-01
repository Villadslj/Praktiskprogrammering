
using System;
using static System.Math;
using static cmath;
using static System.Console;
class main{
static void Main(){
	var a=new complex(0,1);
	var b=new complex(1,1);
	a.print("a =");
	Write("b  ={0}\n",b);
	Write("{0}\n",exp(1.2));
	Write("exp(b)={0}\n",exp(b));
	Write("exp(log(b))={0}\n",exp(log(b)));
	Write("sin(b)={0}\n",sin(b));
	Write("cos(b)={0}\n",cos(b));
	Write("log(exp(b))={0}\n",log(exp(b)));
	Write("a/b={0}\n",a/b);
	Write("(a/b)*b={0}\n",(a/b)*b);
	Write($"{a}.pow(2)={a.pow(2)}\n");
	Write($"{a}.pow({a})={a.pow(a)}, e^(-pi/2)={exp(-PI/2)}\n");
}
}
