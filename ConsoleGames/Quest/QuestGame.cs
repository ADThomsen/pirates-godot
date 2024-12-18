namespace Quest;

public class QuestGame
{
    private readonly GameManager _gameManager;

    public QuestGame()
    {
        Rum indgang = new()
        {
            Beskrivelse = "Du står i en mørk hule. Der er en dør mod nord.",
        };
        Rum skattekammer = new()
        {
            Beskrivelse = "Du er i skattekammeret. Du har vundet!",
            SlutRum = true
        };
        Rum troldeRummet = new()
        {
            Beskrivelse = @"Du er i trolderummet, hvor Trolden sover. Det ser ud til han sover oven på en nøgle.
Vil du angribe trolden og stjæle hans nøgle? (tryk m for at angribe)",
            Monster = new Monster
            {
                Navn = "Troldepus",
                Liv = 100,
                Damage = 12,
                Sover = true
            }
        };
        Rum korridor = new()
        {
            Beskrivelse = "Du er i en mørk korridor. Du kan kun lige skimte dørene.",
        };
        Rum portalRum = new()
        {
            Beskrivelse = "Der er en portal i rummet. Går du ind i den? (tryk p for at gå ind)",
            Portal = indgang
        };

        indgang.Udgange[Retning.Nord] = korridor;
        korridor.Udgange[Retning.Syd] = indgang;
        korridor.Udgange[Retning.Nord] = troldeRummet;
        korridor.Udgange[Retning.Vest] = portalRum;
        troldeRummet.Udgange[Retning.Syd] = korridor;
        troldeRummet.Udgange[Retning.Nord] = skattekammer;
        portalRum.Udgange[Retning.Øst] = korridor;

        Hero hero = new()
        {
            Navn = "Anders",
            Liv = 100,
            Damage = 10
        };

        _gameManager = new GameManager([indgang, skattekammer, troldeRummet, korridor], hero);
    }

    public async Task Run()
    {
        while (true)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.Write(_gameManager.Tegn());

            ConsoleKey input = Console.ReadKey(true).Key;

            Retning? retning = input switch
            {
                ConsoleKey.W => Retning.Nord,
                ConsoleKey.D => Retning.Øst,
                ConsoleKey.S => Retning.Syd,
                ConsoleKey.A => Retning.Vest,
                ConsoleKey.Q => Retning.Op,
                ConsoleKey.Z => Retning.Ned,
                _ => null
            };
            if (retning != null)
            {
                _gameManager.GåMod(retning.Value);
                continue;
            }

            if (input == ConsoleKey.P)
            {
                _gameManager.EnterPortal();
            }

            if (input == ConsoleKey.M)
            {
                _gameManager.AngribMonster();
            }

            if (input == ConsoleKey.Spacebar)
            {
                _gameManager.ShiftDisplayState();
            }

            if (input == ConsoleKey.Backspace)
            {
                _gameManager.AfslutKamp();
            }

            if (input == ConsoleKey.Enter)
            {
                if (_gameManager.Battle != null)
                {
                    if (_gameManager.Battle.Afsluttet)
                    {
                        _gameManager.AfslutKamp();
                    }
                    else
                    {
                        _gameManager.Battle.AngrebsRunde();
                    }
                    continue;
                }
            }
        }
    }
}