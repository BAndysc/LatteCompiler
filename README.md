# LatteCompiler

Kompilator języka Latte na przedmiot Metody Realizacji Języków Programowania w języku C#. Kompilator działa na otwartoźródłowej implementacji .net - mono. 

# Kompilacja

Do budowania używa standardowej metody kompilacji programów w dot net na mono - xbuild. Polecenie `make` wywołuje program xbuild, który buduje program, potem kopiuje zbdowany program do katalogu lib/ a następnie kopiuje skrypt scripts/latc_x86 do głównego katalogu. Ten skrypt po prostu uruchamia kompilator z folderu lib.

# Testy

Polecenie `make test` uruchomi przygotowane testy.

# Zakres

W tej wersji dostępny jest frontend do podstawowej wersji Latte. W ramach frontendu sprawdzane są błędy typów, przekraczanie stałych w programie, typy argumentów, nazwy argumentów, występowanie instrukcji return.

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

# Użyte narzędzia

Kompilator jest napisany w języku C#, sprawdzony na mono.

Użyte biblioteki:

 - Antlr4 to parsowania
 - NUnit do testów jednostkowych (`make test`)
