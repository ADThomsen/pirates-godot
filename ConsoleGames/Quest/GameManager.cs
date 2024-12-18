namespace Quest;

public class GameManager(List<Rum> rum, Hero hero)
{
    public Rum NuværendeRum = rum[0];
    private DisplayState _displayState = DisplayState.Rum;
    public Battle? Battle;

    public void GåMod(Retning retning)
    {
        if (NuværendeRum.Udgange.TryGetValue(retning, out Rum? rum))
        {
            NuværendeRum = rum;
        }
    }

    public void EnterPortal()
    {
        if (NuværendeRum.Portal != null)
        {
            NuværendeRum = NuværendeRum.Portal;
        }
    }

    public string Tegn()
    {
        switch (_displayState)
        {
            case DisplayState.Rum:
                return $@"{NuværendeRum.Beskrivelse}
{NuværendeRum.Tegn()}
Tryk [space] for at skifte visning";
            case DisplayState.Stats:
                return $@"{hero.TegnStats()}
{NuværendeRum.Monster?.TegnStats()}
Tryk [space] for at skifte visning";
            case DisplayState.BattleRunde:
                return Battle?.Tegn() ?? throw new InvalidOperationException("Battle is null");
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ShiftDisplayState()
    {
        _displayState = _displayState switch
        {
            DisplayState.Rum => DisplayState.Stats,
            DisplayState.Stats => DisplayState.Rum,
            DisplayState.BattleRunde => DisplayState.Rum,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public void AngribMonster()
    {
        if (NuværendeRum.Monster != null && !NuværendeRum.Monster.Død)
        {
            Battle = new Battle(hero, NuværendeRum.Monster);

            _displayState = DisplayState.BattleRunde;
        }
    }
    
    public void BattleRunde()
    {
        Battle?.AngrebsRunde();
        if (Battle?.Afsluttet == true)
        {
            //AfslutKamp();
        }
    }

    public void AfslutKamp()
    {
        if (Battle != null)
        {
            Battle = null;
            _displayState = DisplayState.Rum;
        }
    }
}

internal enum DisplayState
{
    Rum = 0,
    Stats = 1,
    BattleRunde = 2
}