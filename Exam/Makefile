all: out.txt

out.txt: main.exe
	mono $< >$@
	
main.exe: main.cs math.dll Lanczos.cs
	mcs $< -reference:math.dll
	
math.dll: Lanczos.cs matrix.cs vector.cs complex.cs cmath.cs 
	mcs $^ -target:library -out:$@
	
clean: 
	-$(RM) out* *.txt *.exe *.dll *.svg
