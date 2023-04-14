namespace PokemonGame;

public class Pokemon : ICloneable
{
    public float Attack {get ; private set; }
    public int BaseTotal {get; private set; }
    public int CaptureRate {get; private set; }
    public float Defence {get ; private set; }
    public float Hp {get ; private set; }
    public int SpAttack {get ; private set; }
    public int SpDefence { get ; private set; }
    public int Speed {get ; private set;}
    public int Generation { get ; private set; }

    public bool IsLegend {get ; private set; }

    public string Name {get ; private set; }

    public PokemonType Type1 {get ; private set;}
    public PokemonType? Type2 {get ; private set;}

    public float[] AgainstTypeTabl { get ; private set; } = new float[Enum.GetNames(typeof(PokemonType)).Length];

    public Pokemon(
        float attack,
        int base_total,
        int capture_rate,
        float defence,
        float hp,
        int sp_attack,
        int sp_defence,
        int speed,
        int generation,
        bool is_legend,
        string name,
        PokemonType type1,
        PokemonType? type2,
        float[] againstTypeTable)
    {
       Attack = attack;
       BaseTotal = base_total;
       CaptureRate = capture_rate;
       Defence = defence;
       Hp = hp;
       SpAttack = sp_attack;
       SpDefence = sp_defence;
       Speed = speed;
       Generation = generation;
       IsLegend = is_legend;
       Name = name;
       Type1 = type1;
       Type2 = type2;
       AgainstTypeTabl = againstTypeTable;
    }

    public bool isDead
    {
        get
        {
            return Hp <= 0;
        }
    }

    public object Clone()
    {
        object clone = new Pokemon(this.Attack,this.BaseTotal,this.CaptureRate,this.Defence,this.Hp,this.SpAttack,this.SpDefence,this.Speed,this.Generation,this.IsLegend,this.Name,this.Type1,this.Type2,this.AgainstTypeTabl);
        return clone;
    }

    public void AttackPokemon(Pokemon target)
    {
        float damage;
        if(this.Type2 is not null)
        {
            damage = ((this.AgainstTypeTabl[(int)target.Type1]+this.AgainstTypeTabl[(int)target.Type2])/2)*this.Attack - this.Defence;
        }
        else
        {
            damage = this.AgainstTypeTabl[(int)target.Type1]*this.Attack - this.Defence;
        }   
        if(damage>0f)
        {
            target.Hp -= damage;
        }
    }
}