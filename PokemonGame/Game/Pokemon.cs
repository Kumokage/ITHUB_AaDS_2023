namespace PokemonGame;

public class Pokemon : ICloneable
{
    private float attack { get; set; }
    private float defence { get; set; }
    private float hp { get; set; }
    private float[] againstTypeTable { get; set; }
    private int base_total { get; set; }
    private int capture_rate { get; set; }
    private int sp_attacl { get; set; }
    private int sp_defence { get; set; }
    private int speed { get; set; }
    private int generation { get; set; }
    private bool is_legend { get; set; }
    public string name { get; set; }
    private PokemonType type1 { get; set; }
    private PokemonType? type2 { get; set; }
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
        throw new NotImplementedException();
    }

    public object Clone()
    {

        Pokemon pok = new Pokemon(attack, base_total, capture_rate, defence, hp, sp_attacl, sp_defence, speed, generation, is_legend, name, type1, type2, againstTypeTable);
        return pok;
    }

    public bool isDead
    {
        get
        {
            if(this.hp < 1)
            {
                return true;
            }
            else
            {
                return false;
            };
        }
    }

    public void AttackPokemon(Pokemon target)
    {
        if (target.type2 != null)
        {
            
        }



        throw new NotImplementedException();
    }
}