namespace PokemonGame
{
    public void Attack(Pokemon attacker, Pokemon defender)
    {
        attacker.AttackPokemon(defender);
        Console.WriteLine("{0}: HP-{1}", attacker);
    }
}