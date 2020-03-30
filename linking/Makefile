CSFLAGS = -optimize -platform:x64
all: out.txt
	cat out.txt

out.txt: main.exe
	mono main.exe > out.txt
main.exe: main.cs world.dll
	mcs $(CSFLAGS) -out:main.exe -reference:world.dll main.cs
	
world.dll: world.cs
	mcs $(CSFLAGS) -out:world.dll -target:library world.cs	
.PHONEY:clean
clean:
	rm --force out.txt main.exe 
