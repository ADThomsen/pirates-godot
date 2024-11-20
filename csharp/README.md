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
