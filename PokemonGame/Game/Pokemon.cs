namespace PokemonGame
{

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
            AgainstTypeTable = againstTypeTable;
        }

        public object Clone()
        {
            return new Pokemon(Attack,
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
        }

        public bool isDead
        {
            get
            {
                if (Hp <= 0) return true;
                else return false;
            }
        }

        public void AttackPokemon(Pokemon target)
        {
            float damage = (AgainstTypeTable[(int)Type1] + AgainstTypeTable[(int)Type2]) / 2 * Attack - Defence;

            if (damage < 0) return;

            target.Hp -= damage;
        }
    }
}