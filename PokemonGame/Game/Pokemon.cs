using System.Diagnostics.CodeAnalysis;

namespace PokemonGame;

public class Pokemon : ICloneable
{
    public float Attack { get; private set; }
    public int BaseTotal { get; private set; }
    public int CaptureRate { get; private set; }
    public float Defence { get; private set; }
    public float Hp { get; private set; }
    public int SpAttack { get; private set; }
    public int SpDefence { get; private set; }
    public int Speed { get; private set; }
    public int Generation { get; private set; }
    public bool IsLegend { get; private set; }
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
        this.CaptureRate = capture_rate;
        this.Defence = defence;
        this.Hp = hp;
        this.SpAttack = sp_attack;
        this.SpDefence = sp_defence;
        this.Speed = speed;
        this.Generation = generation;
        this.IsLegend = is_legend;
        Name = name;
        this.Type1 = type1;
        this.Type2 = type2;
        this.AgainstTypeTable = againstTypeTable;
    }

    public object Clone()
    {
        object New_Pokemon = new Pokemon(Attack,
          BaseTotal,
          CaptureRate,
          Defence,
          Hp,
          SpAttack,
          SpDefence,
          Speed,
          Generation,
          IsLegend,
          Name,
          Type1,
          Type2,
          AgainstTypeTable);
        return New_Pokemon;
    }

    public bool isDead
    {
        get
        {
            if (Hp <= 0) return true;
            return false;
        }
    }

    public void AttackPokemon(Pokemon target)
    {
        float sum = 0;
        if (target.Type2 != null)
        {
            for (int i = 0; i < target.AgainstTypeTable.Length; i++)
            {
                sum += target.AgainstTypeTable[i];

            }
            Attack *= sum / target.AgainstTypeTable.Length;

        }

        else
        {
            Attack *= target.AgainstTypeTable[0];

        }
        if (SpAttack <= target.SpDefence)
        {
            Attack -= target.Defence;

        }


    }
}