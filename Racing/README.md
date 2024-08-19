# Racing - Coding Pirates Skovby - Efterår 2024

## Beskrivelse

Vi vil lave et racerspil for to spillere, som skal have følgende features:

- Spillerne skal kunne styre hver sin bil
- Spillet skal have en bane, som bilerne skal køre på
- Man skal ikke kunne snyde og køre udenfor banen
- Der skal være en målstreg, som bilerne skal køre over
- Der skal være power-ups, som spillerne kan samle op og bruge

## Inden vi starter

1. Tjek at Godot 4 er installeret på din computer (.NET-udgaven) https://godotengine.org/download/
2. Installer Visual Studio eller Visual Studio Code https://visualstudio.microsoft.com/downloads/
3. Download dette repository ved at trykke på den grønne knap "Code" og vælg "Download ZIP"
4. Pak filen up og åben mappen `Racing`
5. Kopier mappen `anders` og giv kopien dit eget navn

## Lav spillet

Lad os komme i gang med at lave spillet. Start med at åbne Godot og åbn projektet i mappen med dit navn inde i `Racing`-mappen.

Start spillet. Du skulle gerne se en blå bil, som kan styres rundt på skærmen med piletasterne.

### Opgave 1: Lav en bane

Når du kører rundt, vil du opdage at du kan køren igennem nogle vægge, men ikke andre. Det tager vi os af senere.

- Vælg `BaneTiles` i `Main`-scenen og vælg `TileMap`-noden nederst på skærmen.
- Byg den bane du gerne vil have, med de tiles du har lyst til. Sørg for at der som minimum er en målstreg, som bilerne skal køre over.
  - Andre idéer til banen:
    - Power-ups
    - Hindringer (fx sand, vand, olie eller andet, hvor vi kan lege med friction
    - Forkerte veje
    - Genveje

### Opgave 2: Kollision

Vi vil gerne have at bilen ikke kan køre igennem væggene. Det gør vi ved at tilføje collissions til vores TileMap. Følg step 4 i denne guide: https://www.nightquestgames.com/adding-collision-to-tilemaps-in-godot-4/