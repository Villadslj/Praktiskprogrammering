public static class ivector3dfunctions{


public static double dot(ivector3d u, ivector3d v){
	return u.x*v.x+u.y*v.y+u.z*v.z;
	}

public static vector3d Cross(ivector3d u, ivector3d v){
	vector3d c=new vector3d(u.y*v.z-u.z*v.y, u.z*v.x-u.x*v.z, u.x*v.y-u.y*v.x);	
	return c;
	}


}





