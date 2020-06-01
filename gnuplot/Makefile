all: Errfun.svg Gamma.svg

Gamma.svg: gammafunction.gpi out.Gamma.txt gamma_test.txt 
	gnuplot $< 

Errfun.svg: errorfunction.gpi out.errorfunction.txt errorfunctiontab.txt 
	gnuplot $<

out.errorfunction.txt: main.exe Makefile
	mono $< | sed -e 's/,/./g' > $@

main.exe: main.cs math.dll
	mcs $< -out:$@ -reference:math.dll 
	
main_Gamma.exe: main_Gamma.cs math.dll
	mcs $< -out:$@ -reference:math.dll 	

out.Gamma.txt: main_Gamma.exe Makefile
	mono $< | sed -e 's/,/./g' > $@


math.dll: errorfunction.cs gammafunction.cs
	mcs $^ -target:library -out:$@

.PHONEY: clean
clean:
	rm --force *.dll *.exe out* *.svg
