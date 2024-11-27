# C# Begynderkursus

## Modul 1: Introduktion til C# og variabler

**Formål**: Lær de grundlæggende begreber i C# som variabler, datatyper og input/output.

1. **Hvad er C#?**
    - C# er et programmeringssprog, som bruges til at lave mange slags applikationer, bl.a. spil.

2. **Variabler og datatyper**
    - En variabel bruges til at gemme data.
    - Forskellige datatyper:
        - `int`: heltal (fx 100)
        - `string`: tekst (fx "HelteKarl")
        - `float`: komma-tal (fx 12.5)
        - `bool`: sand/falsk (fx `true`)

3. **Opgave: Lav en simpel karakter**
    - Vi skal lave et lille program, der skaber en spilkarakter med navn, helbred og styrke.
    - Koden ser sådan ud:
      ```csharp
      using System;
 
      namespace Karakterskaber
      {
          class Program
          {
              static void Main(string[] args)
              {
                  string navn;
                  int helbred;
                  float styrke;
 
                  Console.WriteLine("Indtast karakterens navn:");
                  navn = Console.ReadLine();
 
                  Console.WriteLine("Indtast karakterens helbred (heltal):");
                  helbred = Convert.ToInt32(Console.ReadLine());
 
                  Console.WriteLine("Indtast karakterens styrke (komma-tal):");
                  styrke = float.Parse(Console.ReadLine());
 
                  Console.WriteLine($"Karakteren {navn} har {helbred} helbred og en styrke på {styrke}.");
              }
          }
      }
      ```
    - **Opgave**: Kør programmet og tilpas det. Prøv om du kan
      - Tilføje flere egenskaber til din karakter, fx `forsvar` eller `hastighed`.
      - Give karakteren et fast navn, som ikke kan ændres.

## Modul 2: Kontrolstrukturer (If-statements)

**Formål**: Lær at bruge `if-else`-strukturer for at tage beslutninger i din kode.

1. **Kontrolstrukturer**
    - `if`, `else if` og `else` bruges til at bestemme, hvad der skal ske i forskellige situationer.

2. **Opgave: Vælg en dør**
    - Her er et lille spil, hvor spilleren står foran tre døre. Bag hver dør er der enten en skat, en fjende, eller ingenting.
    - Koden ser sådan ud:
      ```csharp
      using System;
 
      namespace DoerVaelger
      {
          class Program
          {
              static void Main(string[] args)
              {
                  Console.WriteLine("Du står foran tre døre: 1, 2 eller 3. Hvilken dør vil du åbne?");
                  int valg = Convert.ToInt32(Console.ReadLine());
 
                  if (valg == 1)
                  {
                      Console.WriteLine("Du finder en skat! Tillykke!");
                  }
                  else if (valg == 2)
                  {
                      Console.WriteLine("Du møder en fjende! Forbered dig på kamp.");
                  }
                  else if (valg == 3)
                  {
                      Console.WriteLine("Du finder ingenting. Måske næste gang.");
                  }
                  else
                  {
                      Console.WriteLine("Ugyldigt valg. Prøv igen med et tal mellem 1 og 3.");
                  }
              }
          }
      }
      ```
    - **Opgave**: Kør programmet og tilpas det. Prøv om du kan: 
      - Tilføje flere døre 
      - Ændre, hvad der er bag hver dør. 
      - Tilføj flere muligheder, fx en hemmelig dør, hvis spilleren gætter et bestemt tal.
      - Lav flere trin. Hvis man fx vælger dør 1, skal der komme et nyt valg om tre døre.

### Modul 3: Løkker

**Formål**: Lær at bruge `for` og `while` løkker til at gentage kode.

1. **For og while løkker**
   - `for`-løkker bruges til at gentage en blok kode et bestemt antal gange.
     ```csharp
     for (int i = 0; i < 5; i++)
     {
         Console.WriteLine($"Dette er iteration nummer {i}");
     }
     ```
   - `while`-løkker bruges til at gentage en blok kode, så længe en betingelse er sand.
     ```csharp
     int tal = 0;
     while (tal < 5)
     {
         Console.WriteLine($"Tal er nu {tal}");
         tal++;
     }
     ```

2. **Opgave: Skattegravning**
   - Lav et spil, hvor spilleren skal gætte, hvilken kasse en skat er gemt i. Der er fx 5 kasser, og skatten er gemt i en af dem.
   - Brug en `for`-løkke til at give spilleren 3 forsøg på at gætte den rigtige kasse:
     ```csharp
     using System;

     namespace Skattegravning
     {
         class Program
         {
             static void Main(string[] args)
             {
                 int skatkasse = 3; // Skatten er gemt i kasse nummer 3

                 for (int i = 0; i < 3; i++)
                 {
                     Console.WriteLine("Gæt hvilken kasse (1-5) skatten er gemt i:");
                     int gaet = Convert.ToInt32(Console.ReadLine());

                     if (gaet == skatkasse)
                     {
                         Console.WriteLine("Tillykke! Du fandt skatten!");
                         break;
                     }
                     else
                     {
                         Console.WriteLine("Forkert kasse. Prøv igen.");
                     }
                 }

                 Console.WriteLine("Spillet er slut.");
             }
         }
     }
     ```
   - **Opgaver**: 
     - Kør programmet og tilpas det ved at ændre antallet af kasser eller antallet af forsøg, spilleren har.
     - Kan du bruge en `while`-løkke til at starte spillet forfra når man enten finder skatten eller løber tør for gæt?

### Modul 4: Arrays og lister

**Formål**: Lær at bruge arrays og lister til at håndtere flere stykker data.

1. **Arrays**
   - Arrays bruges til at gemme flere værdier af samme type.
     ```csharp
     int[] helbredspoint = { 100, 90, 80, 70, 60 };
     Console.WriteLine($"Første helbredspoint er {helbredspoint[0]}");
     ```

2. **Lister**
   - Lister er mere fleksible end arrays og kan ændre størrelse.
     ```csharp
     using System.Collections.Generic;

     List<string> fjender = new List<string>();
     fjender.Add("Ork");
     fjender.Add("Troll");
     fjender.Add("Drage");
     Console.WriteLine($"Første fjende er {fjender[0]}");
     ```

3. **Opgave: Fjender i en liste**
   - Lav en liste over fjender i et spil. Tilføj nogle fjender til listen, fjern en fjende, eller udskriv alle fjenderne:
   - Bemærk at vi her bruger en `foreach`-løkke. Den bruges til at gennemgå alle elementer i en liste.
     ```csharp
     using System;
     using System.Collections.Generic;

     namespace FjendeListe
     {
         class Program
         {
             static void Main(string[] args)
             {
                 List<string> fjender = new List<string> { "Ork", "Troll", "Drage" };

                 Console.WriteLine("Fjender i spillet:");
                 foreach (string fjende in fjender)
                 {
                     Console.WriteLine(fjende);
                 }

                 Console.WriteLine("Tilføj en ny fjende:");
                 string nyFjende = Console.ReadLine();
                 fjender.Add(nyFjende);

                 Console.WriteLine("Opdateret liste over fjender:");
                 foreach (string fjende in fjender)
                 {
                     Console.WriteLine(fjende);
                 }
             }
         }
     }
     ```
   - **Opgaver**: 
     - Lav spillet om, så man både kan tilføje og fjerne fjender.
     - Lav spillet, så det starter forfra og man kan tilføje eller fjerne en fjende mere.

## Modul 5: Funktioner

**Formål**: Lær at lave funktioner for at strukturere koden bedre.

### Startkode

Nedenfor ser du et simpelt program, som indeholder en kamp mellem en spiller og en fjende. Din opgave er at udvide dette program ved hjælp af funktioner for at gøre koden mere overskuelig og genbrugelig.

```csharp
using System;

namespace Kampmekanik
{
    class Program
    {
        static void Main(string[] args)
        {
            int spillerHelbred = 100;
            int fjendeHelbred = 80;
            int spillerStyrke = 10;
            int fjendeStyrke = 8;

            Console.WriteLine("Kampen starter!");

            while (spillerHelbred > 0 && fjendeHelbred > 0)
            {
                // Spilleren angriber fjenden
                int skade = spillerStyrke * new Random().Next(1, 4);
                fjendeHelbred -= skade;
                Console.WriteLine($"Spilleren angriber og giver {skade} skade! Fjendens helbred er nu {fjendeHelbred}.");

                if (fjendeHelbred <= 0)
                {
                    Console.WriteLine("Fjenden er besejret! Du vandt!");
                    break;
                }

                // Fjenden angriber spilleren
                skade = fjendeStyrke * new Random().Next(1, 4);
                spillerHelbred -= skade;
                Console.WriteLine($"Fjenden angriber og giver {skade} skade! Spillerens helbred er nu {spillerHelbred}.");

                if (spillerHelbred <= 0)
                {
                    Console.WriteLine("Du blev besejret af fjenden...");
                    break;
                }
            }
        }
    }
}
```

### Opgave 1: Lav en funktion til at beregne skade

- Opret en funktion kaldet `BeregnSkade`, som tager styrke som parameter og returnerer den beregnede skade.
- Brug funktionen i stedet for at beregne skaden direkte i `Main`-metoden.

**Eksempel**:

```csharp
static int BeregnSkade(int styrke)
{
    Random random = new Random();
    return styrke * random.Next(1, 4);
}
```

### Opgave 2: Lav en funktion til angreb

- Opret en funktion kaldet `Angrib`, som tager angriberens navn, modstanderens navn, modstanderens helbred (som `ref`), og angriberens styrke som parametre.
- Brug funktionen til at strukturere både spillerens og fjendens angreb.

**Eksempel**:

```csharp
static void Angrib(string angriber, ref int modstanderHelbred, int styrke)
{
    int skade = BeregnSkade(styrke);
    modstanderHelbred -= skade;
    Console.WriteLine($"{angriber} angriber og giver {skade} skade! Modstanderens helbred er nu {modstanderHelbred}.");
}
```

### Opgave 3: Udvid programmet med flere funktioner

- Lav en funktion kaldet `ErBesejret`, som tager helbred som parameter og returnerer en `bool`, der angiver, om karakteren er besejret.
- Brug funktionen til at tjekke, om spilleren eller fjenden er besejret, og afslut kampen, hvis det er tilfældet.

**Eksempel**:

```csharp
static bool ErBesejret(int helbred)
{
    return helbred <= 0;
}
```

### Opgave 4: Tilføj en forsvarsmekanisme

- Opret en ny funktion kaldet `Forsvar`, som reducerer skaden baseret på en forsvarsværdi.
- Tilføj en forsvarsværdi til spilleren og fjenden, og brug `Forsvar`-funktionen til at justere skaden, inden den trækkes fra helbredet.

**Eksempel**:

```csharp
static int Forsvar(int skade, int forsvar)
{
    return Math.Max(0, skade - forsvar); // Reducerer skaden med forsvarsværdien, men skaden kan ikke blive mindre end 0
}
```

### Opgave 5: Test og tilpas

- Test dit program og se, hvordan de nye funktioner virker sammen.
- Tilpas funktionerne eller tilføj nye, fx en helbredspotion, der kan bruges under kampen.

### Opsummering

- I denne opgave har du lært at oprette og bruge funktioner til at strukturere din kode bedre.
- Du har gjort koden mere overskuelig ved at opdele den i mindre dele, som kan genbruges.

Prøv at eksperimentere med at tilføje flere funktioner og se, hvordan det gør dit program lettere at vedligeholde og udvide.


## Modul 6: Klasser og objekter

**Formål**: Lær at lave klasser og objekter for at skabe komplekse datastrukturer og organisere din kode bedre.

### Startkode
Nedenfor ser du et simpelt program, der indeholder en spiller, som bevæger sig igennem en labyrint bestående af rum og døre. Din opgave er at udvide dette program ved at tilføje nye klasser og funktionalitet, så det bliver til et lille konsolbaseret RPG.

```csharp
using System;
using System.Collections.Generic;

class Rum
{
    public string Navn;
    public string Beskrivelse;
    public Dictionary<string, Rum> Udgange;

    public Rum(string navn, string beskrivelse)
    {
        Navn = navn;
        Beskrivelse = beskrivelse;
        Udgange = new Dictionary<string, Rum>();
    }

    public void VisInfo()
    {
        Console.WriteLine($"Du er i {Navn}. {Beskrivelse}");
        Console.WriteLine("Mulige udgange: " + string.Join(", ", Udgange.Keys));
    }
}

class Spiller
{
    public string Navn;
    public int Helbred;

    public Spiller(string navn, int helbred)
    {
        Navn = navn;
        Helbred = helbred;
    }

    public void Flyt(string retning)
    {
        Console.WriteLine($"{Navn} bevæger sig mod {retning}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Opret spilleren
        Spiller spiller = new Spiller("Eventyrer", 100);

        // Opret rummene
        Rum indgangsHallen = new Rum("Indgangshallen", "Du står i en stor hal med stenbelagte vægge.");
        Rum korridoren = new Rum("Korridoren", "En smal og mørk korridor.");
        Rum skattekammeret = new Rum("Skattekammeret", "Et lille rum fyldt med guld og skatte.");
        Rum fjendensRum = new Rum("Fjendens Lair", "Et truende rum med en fjende, der vogter indgangen.");

        // Definér udgange
        indgangsHallen.Udgange.Add("øst", korridoren);
        korridoren.Udgange.Add("vest", indgangsHallen);
        korridoren.Udgange.Add("øst", skattekammeret);
        korridoren.Udgange.Add("syd", fjendensRum);
        skattekammeret.Udgange.Add("vest", korridoren);
        fjendensRum.Udgange.Add("nord", korridoren);

        // Tegn din labyrint først på papir for at få overblik

        // Start spillet
        Rum nuværendeRum = indgangsHallen;
        Rum forrigeRum = null;

        Console.WriteLine("Velkommen til labyrinten!");
        while (spiller.Helbred > 0)
        {
            nuværendeRum.VisInfo();
            Console.WriteLine("Hvor vil du gå?");
            string retning = Console.ReadLine().ToLower();

            if (nuværendeRum.Udgange.ContainsKey(retning))
            {
                forrigeRum = nuværendeRum;
                nuværendeRum = nuværendeRum.Udgange[retning];
                spiller.Flyt(retning);

                // Hvis spilleren går ind i fjendens rum
                if (nuværendeRum == fjendensRum)
                {
                    Console.WriteLine("En fjende angriber dig!");
                    spiller.Helbred -= 20;
                    Console.WriteLine($"{spiller.Navn} tager 20 skade og har nu {spiller.Helbred} helbred tilbage.");
                    nuværendeRum = forrigeRum; // Send spilleren tilbage til det rum, de kom fra
                }

                // Hvis spilleren finder skattekammeret
                if (nuværendeRum == skattekammeret)
                {
                    Console.WriteLine("Tillykke! Du har fundet skattekammeret og vundet spillet!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Du kan ikke gå den vej.");
            }
        }

        if (spiller.Helbred <= 0)
        {
            Console.WriteLine("Du er løbet tør for helbred. Spillet er slut.");
        }
    }
}
```

### Opgave 1: Opret flere rum og planlæg din labyrint
- Start med at tegne din labyrint på papir. Planlæg, hvor rummene skal være, og hvordan de hænger sammen.
- Opret flere instanser af `Rum`-klassen og forbind dem ved hjælp af `Udgange`-dictionaryen, så spilleren kan navigere rundt i labyrinten.

**Eksempel**:
```csharp
Rum rum2 = new Rum("Biblioteket", "Et rum fyldt med støvede bøger.");
korridoren.Udgange.Add("nord", rum2);
rum2.Udgange.Add("syd", korridoren);
```

### Opgave 2: Tilføj fjender i flere rum
- Tilføj flere `Fjende`-instanser i forskellige rum.
- Hvis spilleren går ind i et rum med en fjende, skal fjenden angribe spilleren, og spilleren skal sendes tilbage til det forrige rum.

**Eksempel**:
```csharp
// Hvis spilleren går ind i fjendens rum
if (nuværendeRum == fjendensRum)
{
    Console.WriteLine("En fjende angriber dig!");
    spiller.Helbred -= 20;
    Console.WriteLine($"{spiller.Navn} tager 20 skade og har nu {spiller.Helbred} helbred tilbage.");
    nuværendeRum = forrigeRum; // Send spilleren tilbage til det rum, de kom fra
}
```

### Opgave 3: Spillets afslutning
- Hvis spillerens helbred ryger under 0, skal spillet slutte med en besked om, at spilleren er død.
- Spilleren vinder spillet, hvis de når til skattekammeret.

**Eksempel**:
```csharp
if (spiller.Helbred <= 0)
{
    Console.WriteLine("Du er løbet tør for helbred. Spillet er slut.");
}

if (nuværendeRum == skattekammeret)
{
    Console.WriteLine("Tillykke! Du har fundet skattekammeret og vundet spillet!");
    break;
}
```

### Opsummering
- I denne opgave har du lært at oprette og bruge klasser og objekter for at strukturere din kode bedre.
- Du har opbygget et simpelt RPG, hvor spilleren kan navigere gennem en labyrint, møde fjender og finde en skat.

Prøv at eksperimentere med at tilføje flere rum, fjender og udfordringer for at gøre dit spil mere spændende og udfordrende.

