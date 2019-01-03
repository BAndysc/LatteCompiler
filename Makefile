all:
	xbuild /p:Configuration=Release
	mkdir -p latc_data
	cp -r CLI/bin/Release/* latc_data/
	cp scripts/latc_x86 .
	cp scripts/latc_x86 latc
	gcc -m32 -c lib/runtime.c -o lib/runtime.o

clean:
	rm -rf latc_x86
	rm -rf latc
	rm -rf latc_data

test:
	xbuild
	mono packages/NUnit.ConsoleRunner.3.9.0/tools/nunit3-console.exe LatteTypeChecker.Tests/bin/Debug/LatteTypeChecker.Tests.dll QuadruplesGenerator.Tests/bin/Debug/QuadruplesGenerator.Tests.dll
