all: plotA.svg B.txt


plotA.svg: plotA.gpi outputFitData.txt outputData.txt
	gnuplot plotA.gpi
	

outputFitData.txt outputData B.txt: main.exe
	mono $< >$@
	
main.exe: main.cs math.dll
	mcs $< -reference:math.dll


math.dll: matrix.cs vector.cs linear.cs OD_QR_Fitter.cs
	mcs $^ -target:library -out:$@
	
clean:  	
	-$(RM) out* *.txt *.exe *.dll *.svg	
