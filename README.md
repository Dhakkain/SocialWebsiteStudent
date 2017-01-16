# SocialWebsiteStudent


Celem pracy jest stworzenie portalu społecznościowego przeznaczonego dla studentów. Główną częścią systemu jest aplikacja internetowa oparta na najnowszych technologiach. Serwis ten ma za zadanie zapewnić szybki dostęp do informacji udostępnianych przez innych studentów oraz umożliwić łatwą komunikację pomiędzy użytkownikami. Użytkownicy będą posiadać możliwość umieszczania krótkich wpisów na stronie oraz tworzenia nowych znaczników. Każdy ze wpisów będzie mógł zostać odpowiednio oznakowany znacznikami oraz zostać skomentowany, dodatkowo możliwe jest przesyłanie prywatnych wiadomości pomiędzy użytkownikami. Portal będzie oparty na budowie dziennika internetowego, do którego dostęp będzie posiadał każdy odwiedzający portal. Wymagania, które powinien spełniać projekt:
*	rejestracja użytkowników,
* profile użytkowników, 
*	tworzenie nowych i komentowanie istniejących wpisów,
*	komunikacja pomiędzy użytkownikami przy użyciu prywatnych wiadomości, 
*	możliwość przeglądania wpisów innych użytkowników,
*	powiadomienia dla użytkowników po zajściu pewnych akcji,
*	wyszukiwanie użytkowników oraz znaczników,
*	klasyfikowanie wpisów przy pomocy znaczników.



SocialWebsiteStudent.Domain- zawiera encje i logikę związaną z domeną biznesową, a przede wszystkim połączenie z bazą danych oraz wykonywanie na niej zapytań, 

SocialWebsiteStudent - przechowuje kontrolery i widoki, zawiera interfejs użytkownika aplikacji. Ta warstwa zależy od warstwy pierwszej. 

Wzorce projektowe:
* MVC
* Repozytorium
* IOC - odwrócenie sterowania (niezależne od kontrolera, tworzenie obiektu repozytorium)
