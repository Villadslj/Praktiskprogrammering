all: out.txt plot.svg

plot.svg: plot.gpi
	gnuplot plot.gpi

out.txt : main.exe
	mono $< >$@
	
outdata.txt : main.exe
	mono $< >$@	

main.exe : main.cs math.dll
	mcs $< -reference:math.dll


math.dll : matrix.cs vector.cs montecarlo.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg
