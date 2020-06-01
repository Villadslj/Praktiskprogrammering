out.txt : main.exe
	mono $< > out.txt

main.exe : main.cs math.dll
	mcs $< -reference:math.dll


math.dll : quado8.cs
	mcs $^ -target:library -out:$@

clean:
	rm -f *.dll *.exe out*

