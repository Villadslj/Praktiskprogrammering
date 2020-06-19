all: plotA.svg plotB.svg

plotA.svg : plot.gpi outA.data
	gnuplot plot.gpi

plotB.svg : plotB.gpi outB1.data outB2.data outB3.data
	gnuplot plotB.gpi


outB1.data outB2.data outB3.data outB4.txt : mainB.exe
	mono mainB.exe
	
mainB.exe : mainB.cs math.dll
	mcs $< -reference:math.dll	

outA.data : mainA.exe
	mono $< 

mainA.exe : mainA.cs math.dll
	mcs $< -reference:math.dll

math.dll : matrix.cs vector.cs ODE_integrator.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg
