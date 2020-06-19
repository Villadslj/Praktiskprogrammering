all: out.txt


out.txt : main.exe
	mono $< >$@

main.exe : main.cs math.dll
	mcs $< -reference:math.dll


math.dll : matrix.cs vector.cs Quasi.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg
