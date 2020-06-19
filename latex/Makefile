all: paper.pdf out.txt plot.svg


plot.svg: plot.gpi
	gnuplot plot.gpi

paper.pdf : text.tex
	pdflatex $<

out.txt : main.exe
	mono $< | sed -e 's/,/./g' > $@	

main.exe : main.cs  math.dll
	mcs $< -reference:math.dll


math.dll : sin.cs quado8.cs
	mcs $^ -target:library -out:$@

clean:
	$(RM) *.log *.aux *.pdf *.txt
