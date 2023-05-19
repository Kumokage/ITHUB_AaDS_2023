namespace PokemonGame;

public class Pokemon : ICloneable
{
    public float Attack { get; private set; }
    public int BaseTotal { get; private set; }
    public int Capture_rate { get; private set; }
    public float Defence { get; private set; }
    public float Hp { get; private set; }
    public int SpAttack { get; private set; }
    public int SpDefence { get; private set; }
    public int Speed { get; private set; }
    public int Generation { get; private set; }
    public bool Is_legend { get; private set; }
    public string Name { get; private set; }
    public PokemonType Type1 { get; private set; }
    public PokemonType? Type2 { get; private set; }
    public float[] AgainstTypeTable { get; private set; }

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
        this.Attack = attack;
        this.BaseTotal = base_total;
        this.Capture_rate = capture_rate;
        this.Defence = defence;
        this.Hp = hp;
        this.SpAttack = sp_attack;
        this.SpDefence = sp_defence;
        this.Speed = speed;
        this.Generation = generation;
        this.Is_legend = is_legend;
        this.Name = name;
        this.Type1 = type1;
        this.Type2 = type2;
        this.AgainstTypeTable = againstTypeTable;
    }

    public object Clone()
    {
        return new Pokemon(
            Attack,
            BaseTotal,
            Capture_rate,
            Defence,
            Hp,
            SpAttack,
            SpDefence,
            Speed,
            Generation,
            Is_legend,
            Name,
            Type1,
            Type2,
            AgainstTypeTable);
    }

    public bool isDead
    {
        get
        {
            return Hp <= 0;
        }
    }

    public void AttackPokemon(Pokemon target)
    {
        float dmg;
        if(Type2 is null){
             dmg = Attack * AgainstTypeTable[Convert.ToInt32(target.Type1)];
        }else{
            dmg = Attack *(AgainstTypeTable[Convert.ToInt32(target.Type1)] + AgainstTypeTable[Convert.ToInt32(target.Type2)]) / 2;
        }
             if(SpAttack <= target.SpDefence){
                if(dmg - target.Defence > 0){
                    target.Hp -= dmg - target.Defence;
                }
             }
             else{
                target.Hp -= dmg;
             }
        
    }
} 