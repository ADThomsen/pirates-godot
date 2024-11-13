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

