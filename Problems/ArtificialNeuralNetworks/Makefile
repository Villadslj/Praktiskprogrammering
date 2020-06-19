all: out.txt plotA.svg plotB.svg

plotA.svg: plotA.gpi
	gnuplot plotA.gpi
	

plotB.svg: plotB.gpi
	gnuplot plotB.gpi

outdata.txt : main.exe
	mono $< >$@		


out.txt : main.exe
	mono $< >$@

main.exe : main.cs math.dll ANN.cs
	mcs $< -reference:math.dll


math.dll : matrix.cs vector.cs Quasi.cs ANN.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg
