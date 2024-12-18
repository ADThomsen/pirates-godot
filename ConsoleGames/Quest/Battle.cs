namespace Quest;

public record Battle(Hero Hero, Monster Monster)
{
    public List<Attack> HeroAttacks = new();
    public List<Attack> MonsterAttacks = new();

    public bool Afsluttet => Hero.Liv <= 0 || Monster.Liv <= 0;
    public bool HeroVinder => Monster.Liv <= 0;

    public void AngrebsRunde()
    {
        if (Afsluttet)
        {
            return;
        }

        HeroAttack();
        if (Afsluttet)
        {
            return;
        }

        MonsterAttack();
    }

    private void HeroAttack()
    {
        Monster.Liv -= Hero.Damage;
        HeroAttacks.Add(new Attack
        {
            Damage = Hero.Damage,
            Beskrivelse = $"{Hero.Navn} angriber monsteret {Monster.Navn} og giver det {Hero.Damage} damage"
        });
    }

    private void MonsterAttack()
    {
        if (Monster.Sover)
        {
            Monster.Sover = false;
            MonsterAttacks.Add(new Attack { Damage = 0, Beskrivelse = "Monsteret vågner" });
            return;
        }

        if (Monster.Liv <= 0)
        {
            MonsterAttacks.Add(new Attack { Damage = 0, Beskrivelse = $"{Monster.Navn} er død" });
            return;
        }

        Hero.Liv -= Monster.Damage;
        MonsterAttacks.Add(new Attack
        {
            Damage = Monster.Damage,
            Beskrivelse = $"{Monster.Navn} angriber {Hero.Navn} og giver {Monster.Damage} damage"
        });
    }

    public string Tegn()
    {
        string heroAttack = $@"
{HeroAttacks.LastOrDefault()?.Beskrivelse}
{Monster.Navn} har {Monster.Liv} liv tilbage
";

        string monsterAttack = $@"
{MonsterAttacks.LastOrDefault()?.Beskrivelse}
{Hero.Navn} har {Hero.Liv} liv tilbage
";

        string status = Afsluttet
            ? HeroVinder
                ? "Du har vundet! Tryk [enter] for at fortsætte"
                : "Du har tabt! Tryk [enter] for at fortsætte"
            : $"{heroAttack}{monsterAttack}";

        return $@"
__________    ___________________________.____     ___________
\______   \  /  _  \__    ___/\__    ___/|    |    \_   _____/
 |    |  _/ /  /_\  \|    |     |    |   |    |     |    __)_ 
 |    |   \/    |    \    |     |    |   |    |___  |        \
 |______  /\____|__  /____|     |____|   |_______ \/_______  /
        \/         \/                            \/        \/ 

{status}

---------------------------------------------------------------
[enter] for at angribe
[backspace] for at flygte
";
    }
}

public record Attack
{
    public required float Damage;
    public required string Beskrivelse;
}