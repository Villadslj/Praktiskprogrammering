all: outA.txt outB.txt 


outB.txt : mainB.exe
	mono $< >$@

outA.txt : mainA.exe
	mono $< >$@


mainB.exe : mainB.cs math.dll
	mcs $< -reference:math.dll

mainA.exe : mainA.cs math.dll
	mcs $< -reference:math.dll


math.dll : matrix.cs vector.cs integrator.cs quado8.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg
