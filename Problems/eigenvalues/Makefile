all: outA1.txt plotA.svg


plotA.svg : outA2.data plotA.gpi 
	gnuplot plotA.gpi

outA2.data eigenenergiesA2.data : mainA2.exe
	mono $< >$@

outA1.txt : mainA.exe
	mono $< >$@
	
mainA.exe : mainA.cs math.dll
	mcs $< -reference:math.dll

mainA2.exe : mainA2.cs math.dll
	mcs $< -reference:math.dll


math.dll : matrix.cs vector.cs Jacobi_diagonalization.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg
