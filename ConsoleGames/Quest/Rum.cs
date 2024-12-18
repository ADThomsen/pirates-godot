namespace Quest;

public record Rum
{
    public required string Beskrivelse;

    public Dictionary<Retning, Rum> Udgange = new();
    public Dictionary<Retning, Dør> Døre = new();
    public Rum? Portal = null;
    public Monster? Monster = null;
    public List<Item> Items = new();
    public bool SlutRum = false;

    public string Tegn()
    {
        if (SlutRum)
        {
            return SkatteKammer();
        }
        
        string rum = @"
WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WW                                                                      WW
WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
";

        if (Udgange.ContainsKey(Retning.Nord))
        {
            rum = ReplaceArea(rum, 34, 0,
                @"
   
   ");
        }

        if (Udgange.ContainsKey(Retning.Syd))
        {
            rum = ReplaceArea(rum, 34, 20,
                @"
   
   ");
        }

        if (Udgange.ContainsKey(Retning.Vest))
        {
            rum = ReplaceArea(rum, 0, 10,
                @"
   
   ");
        }

        if (Udgange.ContainsKey(Retning.Øst))
        {
            rum = ReplaceArea(rum, 71, 10,
                @"
   
   ");
        }

        if (Portal != null)
        {
            rum = ReplaceArea(rum, 52, 5, @"
  #####
 ##   ##
#       #
#       #
 ##   ##
  #####");
        }

        if (Monster != null)
        {
            if (Monster.Sover)
            {
                rum = ReplaceArea(rum, 12, 5, @"
   z Z Z
  (\   _   /)
   \ (-.-) /
    |  ^  |
   z(___)z");
            }
            else if (Monster.Død)
            {
                rum = ReplaceArea(rum, 12, 5, @"
  (\   _   /)
   \ (x.x) /
    |  -  |
   (_____)"); 
            }
            else
            {
                rum = ReplaceArea(rum, 12, 5, @"
  (\   _   /)
   \ (o.o) /
    |  ^  |
   (_____)"); 
            }
            
        }

        return rum;
    }

    private string SkatteKammer()
    {
        return @"
*******************************************************************************
          |                   |                  |                     |
 _________|________________.=""""_;=.______________|_____________________|_______
|                   |  ,-""_,=""""     `""=.|                  |
|___________________|__""=._o`""-._        `""=.______________|___________________
          |                `""=._o`""=._      _`""=._                     |
 _________|_____________________:=._o ""=._.""_.-=""'""=.__________________|_______
|                   |    __.--"" , ; `""=._o."" ,-""""""-._ "".   |
|___________________|_._""  ,. .` ` `` ,  `""-._""-._   "". '__|___________________
          |           |o`""=._` , ""` `; ."". ,  ""-._""-._; ;              |
 _________|___________| ;`-.o`""=._; ."" ` '`.""\` . ""-._ /_______________|_______
|                   | |o;    `""-.o`""=._``  '` "" ,__.--o;   |
|___________________|_| ;     (#) `-.o `""=.`_.--""_o.-; ;___|___________________
____/______/______/___|o;._    ""      `"".o|o_.--""    ;o;____/______/______/____
/______/______/______/_""=._o--._        ; | ;        ; ;/______/______/______/_
____/______/______/______/__""=._o--._   ;o|o;     _._;o;____/______/______/____
/______/______/______/______/____""=._o._; | ;_.--""o.--""_/______/______/______/_
____/______/______/______/______/_____""=.o|o_.--""""___/______/______/______/____
/______/______/______/______/______/______/______/______/______/______/______/____
*******************************************************************************";
    }


    static string ReplaceArea(string picture, int startX, int startY, string replacement)
    {
        // Split the picture and replacement into lines
        string[] pictureLines = picture.Trim('\n').Split('\n');
        string[] replacementLines = replacement.Trim('\n').Split('\n');

        // Modify the picture lines with the replacement
        for (int i = 0; i < replacementLines.Length; i++)
        {
            int rowIndex = startY + i;
            if (rowIndex >= pictureLines.Length)
                break; // Avoid out-of-bounds errors

            string row = pictureLines[rowIndex];
            string replacementRow = replacementLines[i];

            // Replace the specified section in the row
            if (startX + replacementRow.Length <= row.Length)
            {
                row = row.Substring(0, startX) + replacementRow + row.Substring(startX + replacementRow.Length);
            }

            // Update the modified row in the picture
            pictureLines[rowIndex] = row;
        }

        // Rejoin the modified lines into a single string
        return string.Join("\n", pictureLines);
    }
}

public enum Retning
{
    Nord = 'w',
    Øst = 'd',
    Syd = 's',
    Vest = 'a',
    Op = 'q',
    Ned = 'z'
}