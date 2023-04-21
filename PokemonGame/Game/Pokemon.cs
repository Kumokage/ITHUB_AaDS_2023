namespace PokemonGame;

public class Pokemon : ICloneable
{

    public float Attack { get; private set; }
    public int BaseTotal { get; private set; }
    public int CaptureRate { get; private set; }
    public float Defence { get; private set; }
    public float Hp { get; private set; }
    public int SpAttack { get; private set; }
    public int SpDeffence { get; private set; }
    public int Speed { get; private set; }
    public int Generation { get; private set; }
    public bool IsLegend { get; private set; }
    public string Name { get; private set; }
    public PokemonType Type1 { get; private set; }
    public PokemonType? Type2 { get; private set; }
    public float[] AgainstTypeTable { get; private set; }

    public Pokemon(float attack, int base_total, int capture_rate,
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
        this.Defence = defence;
        this.Attack = attack;
        this.Hp = hp;
        this.SpAttack = sp_attack;
        this.SpDeffence = sp_defence;
        this.Speed = speed;
        this.Generation = generation;
        this.IsLegend = is_legend;
        this.Name = name;
        
        this.Type1 = type1;
         this.Type2 = type2;
        this.AgainstTypeTable = againstTypeTable;
    }

    public object Clone()
    {
        //    new Pokemon = new pokemonPlayer;
        Pokemon pokemon = new Pokemon(Attack, BaseTotal, CaptureRate, Defence, Hp, SpAttack, SpDeffence,Speed,Generation,IsLegend,Name,Type1,Type2,AgainstTypeTable);
        return pokemon;
       // throw new NotImplementedException();
    }

    public bool isDead
    {
        get
        {
            if (Hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            return Hp < 0;
         //   throw new NotImplementedException();
        }
    }

    public void AttackPokemon(Pokemon target)
    {
        float damage = Attack;
       /* if (Type2 == pokemon)
        {
            for (int i = 0; i < AgainstTypeTable.Length; i++)
            {
                damage = damage + AgainstTypeTable[i];
            }
            damage = damage / AgainstTypeTable.Length;
            if (Sp_attack > Defence)
            {

            }
        }*/
        if (target.Type2 is PokemonType type2)
        {
            damage *= (AgainstTypeTable[(int)type2] + AgainstTypeTable[(int)target.Type1]) / 2;
        }
        else
        {
            damage *= AgainstTypeTable[(int)target.Type1];
        }
        if (SpAttack <= target.SpDeffence)
        {
            damage -= target.Defence;

        }
        if (damage > 0)
        {
            target.Hp -= damage;
        }
        //Здороьве = атака * 

    }
}