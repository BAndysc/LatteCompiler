
global printInt
global printString
global error
global readInt
global readString
global concat_string
global lat_malloc
global _main
extern _lat_malloc
extern _printInt
extern _printString
extern _error
extern _readInt
extern _readString
extern _concat_string
extern main
section .text
printInt:
    jmp _printInt
printString:
    jmp _printString
error: 
    jmp _error
readInt:
    jmp _readInt
readString: 
    jmp _readString
concat_string:
    jmp _concat_string
lat_malloc:
	jmp _lat_malloc
_main:
    jmp main
