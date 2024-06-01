# Predmetni projekat 'Razvoj višeslojnih aplikacija'

## Inicijalni dijagram
Smisleno dopuniti diagram odgovarajucim poljima
![alt text](https://i.ibb.co/x1cRb6Y/3.png)

### Bitne napomene za bodovanje
- SOLID
- Pravilno implementirani obrasci
- Mnemonicko imenovanje klasa i promenljivih
- lock i using kod konkurencije

### Potencijalna podela
- Ilija i Bojana - MVVM klijent
- Zlatko i Vlada - WCF server

### Iz specifikacije
Dobijeni UML model proširiti podacima koji nedostaju:
- Dodati potrebna polja i property-je,
- Dodati klase ako treba.
Zadate podatke ne menjati:
- Ako je zadata klasa apstraktna, treba da ostane apstraktna,
- Ako je definisan neki deo relacije, treba ga uvažiti,
- Ako je definisana metoda, treba je implementirati.

## Najmanje 4 obrasca (Code Patterns)
- [ ] UML za svaki od obrazaca
- [X] Singleton (NavigationService)
- [X] Factory (ViewModelFactory)
- [ ] Observer (INotifyPropertyChanged)
- [ ] Command (Undo & Redo)

# TODO
- [ ] Prijava korisnika
- [ ] Odjava korisnika
- [X] Kreiranje inicialnog admina ('admin', 'admin')
  - [ ] Admin moze izvrsavati sve akcije
- [ ] Kreairanje korisnika od strane admina (dozvoljeno kreiranje admina)
- [ ] Azuriranje profila (id, username, password, name, lastName)
- [ ] Prikaz svih izdavaca
  - [ ] Pomocni prikaz knjiga
  - [ ] Pomocni prikaz autora
- [ ] Pretraga izdavaca
- [ ] CRUD
  - [ ] Izdavaca
  - [ ] Knjiga
  - [ ] Autora
- [ ] Dupliranje izdavaca
- [ ] Osvezavanje prikaza (na zahtev)
- [ ] Omoguciti rad vise instanci programa (bar 2 korisnika istovremeno)
- [ ] Detektovanje konfikta (DbUpdateConcurrencyException)
  - [ ] Odbaci svoje izmene (Reload)
  - [ ] Odbaci tudje izmene (Overwrite)
- [ ] Tabela obavestenja, svako obavestenje novi red


## Serverska aplikacija (WCF)
- [ ] Podrzati vise klijenata odjednom
- [X] Podaci se cuvaju u bazu (Postgres & EF6)
- [X] ServiceContract za klijentsku aplikaciju
- [ ] Logovanje u tekstualnoj datoteci [Log4net](https://logging.apache.org/log4net/)
  - [ ] Logovanje na klijentu i serveru, informacije o vremenu kada se događaj odigrao, tipu događaja
(DEBUG, INFO, WARN, ERROR, FATAL) i poruci koja opisuje sam događaj.
