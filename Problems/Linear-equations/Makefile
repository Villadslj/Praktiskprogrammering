all: out.txt

out.txt: main.exe
	mono $< >$@
	
main.exe: main.cs math.dll linear.cs
	mcs $< -reference:math.dll
	
math.dll: matrix.cs vector.cs linear.cs
	mcs $^ -target:library -out:$@
	
clean: 
	-$(RM) out* *.txt *.exe *.dll *.svg
