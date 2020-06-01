all: PlotA.svg


PlotA.svg: ProblemA.gpi xyData.txt linterpData.txt integrationData.txt
	gnuplot $<

xyData.txt linterpData.txt integrationData.txt : mainA.exe
	mono  $< >$@

mainA.exe : mainA.cs math.dll
	mcs $< -reference:math.dll


math.dll : vector.cs Linespline.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg
