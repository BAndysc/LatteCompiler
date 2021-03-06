# LatteCompiler

Kompilator języka Latte na przedmiot Metody Realizacji Języków Programowania w języku C#. Kompilator działa zarówno na otwartoźródłowej implementacji .net - mono jak i .net framework od Microsoftu. 

# Środowisko

Kompilator może kompilować zarówno programy na Linuxie, OS X-ie jak i Windowsie (jednak nie jest możliwa kompilacja skrośna), więcej informacji na dole.

# Kompilacja

Do budowania używa standardowej metody kompilacji programów w dot net na mono - xbuild. Polecenie `make` wywołuje program xbuild, który buduje program, potem kopiuje zbdowany program do katalogu latc_data/ a następnie kopiuje skrypt scripts/latc_x86 do głównego katalogu. Ten skrypt po prostu uruchamia kompilator z folderu lib.

# Testy

Polecenie `make test` uruchomi przygotowane testy.

# Zakres

Kompilator składa się z frontendu (sprawdzanie typów, optymalizatora drzewa AST) oraz backendu (generator kodu pośredniego i kompilator do x86). Na ten moment obsługiwane są:
 
 * struktury
 * obiekty
 * dziedziczenie
 * metody (wirtualne)
 * tablice

## Frontend
W ramach frontendu sprawdzane są błędy typów, przekraczanie stałych w programie, typy argumentów, nazwy argumentów, występowanie instrukcji return.

Dodatkowo następuje wyliczenie i optymalizacja stałych. Przykładowo program

    int main() {
        if (!(true == false))
            return 1 + 2;
    }

zostanie wyoptymalizowany do postaci

    int main() {
        return 3;
    }

Z tego też powodu program zostanie zaakceptowany, mimo że return znajduje się w ifie bez else, czyli teoretycznie nie wiadomo czy w funkcji main zawsze zostanie zwrócowna wartość. Po wyoptymalizowaniu stałych jest to już oczywiste.

## Backend

Backend składa się z dwóch części:

 * generator kodu pośredniego (quadruples) z drzewa AST
 * translator kodu pośredniego na ASM x86

Kod pośredni oparty jest na wirtualnych rejestrach, które są następnie przypisywane do sprzętowych rejestrów. Dzięki temu bardzo łatwo dodać inne backendy, np. x86_64 czy asm.

# Projekty

Program składa się z następujących projektów:

 * `Backend` - projekt odpowiadający za inicjalizację struktur kompilatora, przekazanie programu (drzewa AST) do kompilacji i zapis pliku assembly i wywołanie `nasma` oraz `ld`
 * `Backend.Tests` - testy integracyjne kompilatora. Program jest kompilowany do pliku binarnego, a następnie uruchamiany żeby porównać output
 * `CLI` - interfejs linii komend, odpowiadający za odczytanie argumentów od użytkownika, przekazanie do frontendu, później do backendu
 * `Frontend` - projekt odpowiadający za inicjalizację struktur fronendu, w tym przekształcenie pliku tekstowego na drzewo i sprawdzenie typów
 * `LatteAntlr` - pliki wygenerowane przez Antlr do parsowania Latte oraz generator drzewa AST z drzewa CST (concrete syntax tree) od Antlra
 * `LatteBase` - podstawowe struktury drzewa AST Latte
 * `LatteTreeOptimizer` - klasy optymalizujące drzewo AST (wyliczenie stałych)
 * `LatteTypeChecker` - klasa sprawdzająca typy w drzewie AST
 * `LatteTypeChecker.Tests` - testy do type checkera
 * `QuadruplesCommon` - podstawowe struktury kodu pośredniego
 * `QuadruplesGenerator` - generator kodu pośredniego na podstawie drzewa AST (zakłada, że drzewo jest poprawne)
 * `QuadruplesGenerator.Tests` - testy do generatora kodu pośredniego
 * `TestPrograms` - projekt z drzewami AST programów testowych
 * `Utils` - pomocnicze narzędzia
 * `X86Assembly` - podstawowe struktury reprezentujące Assembly x86
 * `X86Generator` - generator assembly x86 na podstawie kodu pośredniego
 * `X86IntelAsm` - generator reprezentacji tekstowej assembly x86 na podstawie struktur z X86Assembly


# Optymaliacje

Zastosowano następujące optymalizacje:

 * wyliczenie stałych podczas kompilacji (patrz punkt Frontend)
 * usuwanie nieosiągalnego kodu (na podstawie drzewa AST)
 * optymalizacja rekurencji ogonowej
 * obiekty tej samej klasy mają wspólną vtable
 * stałe nie są trzymane na stosie
 * usuwanie zbędnych instrukcji:
 	mov A, B
 	mov B, A

# Użyte narzędzia

Kompilator jest napisany w języku C#, sprawdzony na mono.

Użyte biblioteki:

 - Antlr4 to parsowania
 - NUnit do testów (`make test`)

# Targety

## Linux

Do kompilacji na Linuxa wymagane są: `nasm` oraz `gcc`.

## OS X

Do kompilacji na OS X wymagane są: `nasm` oraz `gcc`. Najnowsza wersja Mojave nie jest jednak w stanie skompilować programów 32-bitowych ze względu na brak bibliotek. Należy ściągnąć SDK wersji 10.13 (https://github.com/phracker/MacOSX-SDKs/releases) i ustawić zmienną środowiskową LATTE_OS_X_SDK na ścieżkę do folderu z SDK.

## Windows

Do kompilacji na Windowsie wymagane jest zainstalowane Visual Studio z Visual C++. Dodatkowo należy dodać ścieżkę do kompilatora `cl.exe` do zmiennej środowiskowej `PATH` (zwykle: `C:\Program Files (x86)\Microsoft Visual Studio\[wersja]\[wersja]\VC\Tools\MSVC\[wersja]\bin\Hostx86\x86`), ponadto należy dodać zmienną środowiskową `LIB` oraz `INCLUDE`, na podstawie wartości tej zmiennej z środowiska `Developer Command Prompt for VS`. W tym celu należy uruchomić deweloperski wiersz poleceń, wypisać zmianne `echo %LIB%`, `echo %INCLUDE%`, a następnie ręcznie je dodać.
Do kompilacji wymagany jest również assembler `nasm`. Należy go ściągnąć (https://www.nasm.us/pub/nasm/releasebuilds/), a ścieżkę do niego dodać do zmieninej `PATH`. 