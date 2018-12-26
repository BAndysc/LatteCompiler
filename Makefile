all:
	xbuild /p:Configuration=Release
	cp -r CLI/bin/Release lib/
	cp scripts/latc_x86 .

clean:
	rm -rf latc_x86
	rm -rf lib

test:
	xbuild
	mono packages/NUnit.ConsoleRunner.3.9.0/tools/nunit3-console.exe LatteTypeChecker.Tests/bin/Debug/LatteTypeChecker.Tests.dll
