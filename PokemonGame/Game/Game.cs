using static PokemonGame.Game;

namespace PokemonGame
{
    static class Game
    {
        static PokemonCollection pokemonCollection = new PokemonCollection("../../../../data/pokemon.csv");

        public class Player
        {
            public string PlayerName;
            public int Points;
            public FightingQueue FightingQueue;
            public Pokemon ActivePokemon => FightingQueue.Top();
            public bool HaveLegend;
            public bool QueueIsFull;

            public Player(string playerName)
            {
                PlayerName = playerName;
                Points = 1000;
                HaveLegend = false;
                QueueIsFull = false;
                FightingQueue = new FightingQueue();
            }
        }

        public static void Attack(Player attack, Player defence, Pokemon target)
        {
            if (attack.ActivePokemon.isDead)
            {
                attack.FightingQueue.Pop();
            }

            Pokemon attacker = attack.ActivePokemon;

            float damage = attacker.AttackPokemon(target);
            if (damage != 0)
            {
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(attacker.Name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" наносит ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(damage);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" урона ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(target.Name);
                Console.ForegroundColor = ConsoleColor.White;

                if (target.isDead) Console.Write(" и побеждает его!\n");
                else Console.Write("\n");
            }
            else
            {
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(target.Name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" успешно защищается от атаки");
            }
        }

        public static void BattleInfo(Player player1, Player player2)
        {
            string[] pokemons1 = player1.FightingQueue.ToString().Split(",");
            string[] pokemons2 = player2.FightingQueue.ToString().Split(",");

            Console.Write("\n----------------------------------------------------------------\n");
            Console.Write("  {0} | ", player1.PlayerName);

            for (int i = 0; i < pokemons1.Length; ++i)
            {
                Console.Write(pokemons1[i] + ": ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("HP-");
                Console.Write(player1.FightingQueue.FindByName(pokemons1[i]).Hp);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ");
            }
            Console.Write("\n");

            Console.Write("  {0} | ", player2.PlayerName);

            for (int i = 0; i < pokemons2.Length; ++i)
            {
                Console.Write(pokemons2[i] + ": ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("HP-");
                Console.Write(player2.FightingQueue.FindByName(pokemons2[i]).Hp);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ");
            }
            Console.Write("\n----------------------------------------------------------------\n\n");
        }

        public static void PokemonChoose(Player player1, Player player2)
        {
            FightingQueue everyoneQueue = new FightingQueue();

            Player player = player1;

            while (true)
            {
                Console.Write($"------------------------\n| ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(String.Format("{0,-20}", player.PlayerName));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" |\n------------------------\n");

                Console.Write("Очки: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(player.Points);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ваши покемоны: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(player.FightingQueue.ToString());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("______________________________________________________________\n");
                Console.WriteLine("Чтобы остановить набор покемонов - введите stop.");
                Console.Write("Введите имя покемона: ");

                while (true) 
                {
                    try
                    {

                        string name = "";

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        while (name == "") { name = Console.ReadLine(); }
                        Console.ForegroundColor = ConsoleColor.White;

                        if (name.ToLower() == "stop")
                        {
                            if (player.FightingQueue.Length == 0) 
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Вы не выбрали ни одного покемона!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\nВыберите покемона: ");
                                continue;
                            }

                            player.QueueIsFull = true;
                            break;
                        }

                        Pokemon pokemon = pokemonCollection.FindByName(name);

                        try
                        {
                            everyoneQueue.FindByName(pokemon.Name);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Покемон уже выбран!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nВыберите другого покемона: ");

                            continue;

                        }
                        catch { }

                        if (pokemon.IsLegend)
                        {
                            if (player.HaveLegend)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Неможет быть больше одного легендарного покемона!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\nВыберите другого покемона: ");
                                continue;
                            }
                        }

                        if (player.Points - pokemon.BaseTotal >= 0)
                        {
                            player.FightingQueue.Push(pokemon);
                            everyoneQueue.Push(pokemon);
                            player.Points -= pokemon.BaseTotal;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Нехватает очков!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nВыберите другого покемона: ");
                            continue;
                        }

                        if (pokemon.IsLegend)
                        {
                            player.HaveLegend = true;
                        }

                        break;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Покемон не найден! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nВведите имя покемона еще раз: ");
                    }
                }

                Console.Clear();

                if (player.PlayerName == player1.PlayerName && !player2.QueueIsFull) player = player2;
                else if (player.PlayerName == player2.PlayerName && !player1.QueueIsFull) player = player1;
                else if(player2.QueueIsFull && player1.QueueIsFull) break;
            }
        }

        public static void PokemonBattle(Player player1, Player player2)
        {
            Player attack = player1;
            Player defence = player2;

            while (true)
            {
                if (attack.ActivePokemon.isDead)
                {
                    attack.FightingQueue.Pop();
                }
                if (attack.FightingQueue.Length == 0) 
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\n{0} одержал победу!", defence.PlayerName);
                    Console.ForegroundColor = ConsoleColor.White;

                    return;
                }

                BattleInfo(player1, player2);
                Console.Write($"------------------------\n| ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(String.Format("{0,-20}", attack.PlayerName));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" |\n------------------------\n");
                Console.Write("Ваш атакующий покемон: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(attack.ActivePokemon.Name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n________________________________________________________________\n");
                Console.Write("Введите имя покемона которого хотите атокавать: ");

                Pokemon pokemon;
                while (true)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        pokemon = defence.FightingQueue.FindByName(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Покемон не найден! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nВведите имя покемона еще раз: ");
                    }
                }

                Console.WriteLine("");
                Attack(attack,defence, pokemon);
                Console.WriteLine("");

                Console.WriteLine("Enter - продолжить");
                Console.ReadKey();

                Console.Clear();

                Player buf = attack;
                attack = defence;
                defence = buf;
            }
        }

        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Player player1;
                Player player2;

                Console.WriteLine("\nВведите именна игроков\n");
                Console.Write("Player 1: ");
                player1 = new Player(Console.ReadLine());
                Console.Write("Player 2: ");
                player2 = new Player(Console.ReadLine());

                Console.Clear();

                PokemonChoose(player1, player2);

                PokemonBattle(player1, player2);

                Console.WriteLine("\nПродолжить - play\nВыйти из игры - quit");

                if (Console.ReadLine().ToLower() == "quit") break;

                Console.Clear();
            }
        }
    }
}