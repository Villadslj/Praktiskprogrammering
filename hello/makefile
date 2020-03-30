out.txt: hello.exe
	mono hello.exe > out.txt  # run hello.exe in mono, redirect output into out.txt

hello.exe : hello.cs           # bytecode hello.exe depends on source-code hello.cs
	mcs hello.cs -out:hello.exe   # compile hello.cs, output goes to hello.exe

.PHONEY:clean           # clean is a phoney target
clean:                  # does not depend on anything
	rm --force out.txt hello.exe # remove the files produced by making
