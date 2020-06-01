using static System.Console;
class main{
static void Main(){
	vector3d u=new vector3d(9,9,9);
	vector3d v=new vector3d(1,2,3);
	u.print("vector3d u =");
	v.print("vector3d v =");
	double d=ivector3dfunctions.dot(u,u);
	vector3d c=ivector3dfunctions.Cross(u,v);
	WriteLine($"The dot product of u with u is {d}");
	WriteLine($"The cross product og u with v is ({c.x},{c.y},{c.z})");
}
}
