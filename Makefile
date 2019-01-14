UNAME_S := $(shell uname -s)
RUNTIME_FLAGS := ""
ifeq ($(UNAME_S),Darwin)
	RUNTIME_FLAGS += -isysroot ~/Downloads/MacOSX10.13.sdk
endif

all: libs
	xbuild src/Latte.sln /p:Configuration=Release
	mkdir -p latc_data
	cp -r src/CLI/bin/Release/* latc_data/
	cp scripts/latc_x86 .
	cp scripts/latc_x86 latc

libs:
	gcc -m32 -fno-stack-protector -c lib/runtime.c -nostdlib -o lib/runtime.o $(RUNTIME_FLAGS)
	nasm -f macho lib/osx_layer.s -o lib/osx_layer.o

clean:
	xbuild /t:clean src/Latte.sln /p:Configuration=Release
	xbuild /t:clean src/Latte.sln /p:Configuration=Debug
	rm -rf latc_x86
	rm -rf latc
	rm -rf latc_data

.PHONY: test
test:
	xbuild src/Latte.sln /p:Configuration=Debug
	cp -r lib src/Backend.Tests/bin/
	mono packages/NUnit.ConsoleRunner.3.9.0/tools/nunit3-console.exe src/LatteTypeChecker.Tests/bin/Debug/LatteTypeChecker.Tests.dll src/QuadruplesGenerator.Tests/bin/Debug/QuadruplesGenerator.Tests.dll src/Backend.Tests/bin/Debug/Backend.Tests.dll
