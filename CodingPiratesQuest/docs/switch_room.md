# Skift rum

Når du skal skifte fra ét rum til et andet, skal du gøre følgende:

1. Åben den scene du gerne vil skifte fra
2. Træk `door_component.tscn` ind i scenen

![switch_room_1](./images/switch_room_1.png)

3. Klik på DoorComponent i venstre side af Godot og tilføj en CollisionShape2D

![switch_room_2](./images/switch_room_2.png)

4. Vælg `CollisionShape2D` og klik på `Shape` i højre side af Godot. Vælg den shape, der passer til din dør
5. Tilpas din shape til der hvor spilleren skal skifte rum. Her har jeg valgt en cirkel, fordi min spiller skal falde ned i grotten, hvis ham rammer hullet

![switch_room_3](./images/switch_room_3.png)

![switch_room_4](./images/switch_room_4.png)

6. Vælg igen DoorComponent i venstre side af Godot og klik på `Inspector` i højre side.
7. Skriv path til den scene du vil skifte til i feltet `Leads To Path`
   - Du får den rigtige path ved at **højreklikke** på den scene du vil skifte til og klikke på `Copy Path`
   - Sæt den derefter ind i feltet med `Ctrl + V` (eller `Cmd + V` på Mac)

![switch_room_5](./images/switch_room_5.png)

Nu vil din spiller skifte rum, når han rammer døren.