namespace PokemonGame
{
    static class Game
    {
        static PokemonCollection pokemonCollection = new PokemonCollection("../../../../data/pokemon.csv");

        public struct Player
        {
            public string PlayerName;
            public int Points;
            public FightingQueue FightingQueue;
            public Pokemon ActivePokemon;
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

        public static bool Attack(Player attack, Player defence, Pokemon target)
        {
            if (attack.ActivePokemon.isDead)
            {
                attack.FightingQueue.Pop();
                attack.ActivePokemon = attack.FightingQueue.Top();
            }

            Pokemon attacker = attack.ActivePokemon;

            float damage = attacker.AttackPokemon(target);
            if (damage != 0) Console.WriteLine(" {0} наносит {1} урона {2}", attacker.Name, damage, target.Name);
            else Console.WriteLine(" {0} успешно защищается от атаки", target.Name);

            if (defence.FightingQueue.Length > 0) return false;
            else return true;
        }

        public static void BattleInfo(Player player1, Player player2)
        {
            Console.WriteLine(" {0}: HP-{1}", player1.ActivePokemon.Name, player1.ActivePokemon.Hp);
            Console.WriteLine(" {0}: HP-{1}", player2.ActivePokemon.Name, player2.ActivePokemon.Hp);
        }

        public static void PokemonChoose(Player player1, Player player2)
        {
            Player player = player1;

            while (true)
            {
                Console.WriteLine($"-----------------------\n| {String.Format("{0,-20}", player.PlayerName)} |\n-----------------------");
                Console.WriteLine("Очки: " + player.Points);
                Console.WriteLine("Ваши покемоны: " + player.FightingQueue.ToString());
                Console.WriteLine("______________________________________________\n");
                Console.WriteLine("Чтобы остановить набор покемонов - введите stop.");
                Console.Write("Введите имя покемона: ");

                while (true) 
                {
                    try
                    {
                        string name = Console.ReadLine();

                        if (name.ToLower() == "stop")
                        {
                            player.QueueIsFull = true;
                            break;
                        }

                        Pokemon pokemon = pokemonCollection.FindByName(name);

                        if (pokemon.IsLegend & player.HaveLegend)
                        {
                            Console.Write("Неможет быть больше одного легендарного покемона!\nВыберите другого покемона: ");
                            continue;
                        }

                        if (player.Points - pokemon.BaseTotal > 0)
                        {
                            player.FightingQueue.Push(pokemon);
                            player.Points -= pokemon.BaseTotal;
                        }
                        else
                        {
                            Console.Write("Нехватает очков! Выберите другого покемона: ");
                            continue;
                        }
                        break;
                    }
                    catch
                    {
                        Console.Write("Покемон не найден! Введите имя покемона еще раз: ");
                    }
                }

                Console.Clear();

                if (player.PlayerName == player1.PlayerName & !player1.QueueIsFull) player = player2;
                else if (player.PlayerName == player2.PlayerName & !player2.QueueIsFull) player = player1;
                else break;
            }
        }

        public static void PokemonBattle(Player player1, Player player2)
        {
            Player attack = player1;
            Player defence = player2;

            while (true)
            {
                Console.WriteLine($"----------------------\n| {String.Format("{0,-20}", attack.PlayerName)} |\n----------------------");
                Console.WriteLine("Покемоны противника: " + defence.FightingQueue.ToString());
                Console.WriteLine("Ваш покемон: " + attack.ActivePokemon.Name);
                Console.WriteLine("______________________________________________\n");
                Console.Write("Введите имя покемона: ");

                while (true)
                {
                    try
                    {
                        Pokemon pokemon = defence.FightingQueue.FindByName(Console.ReadLine());

                        if(Attack(attack, defence, pokemon))
                        {
                            Console.WriteLine(" {0} победил!", attack.PlayerName);
                            return;
                        }

                        break;
                    }
                    catch
                    {
                        Console.Write("Покемон не найден! Введите имя покемона еще раз: ");
                    }
                }

                Console.Clear();

                Player buf = attack;
                attack = defence;
                defence = attack;
            }
        }

        public static void Main()
        {
            while (true)
            {
                Player player1;
                Player player2;

                Console.WriteLine("Введите именна игроков");
                Console.Write("Player 1: ");
                player1 = new Player(Console.ReadLine());
                Console.Write("Player 2: ");
                Console.Write("Player 2: ");
                player2 = new Player(Console.ReadLine());

                Console.Clear();

                PokemonChoose(player1, player2);

                PokemonBattle(player1, player2);

                Console.WriteLine("Продолжить - play\nВыйти из игры - quit");

                if (Console.ReadLine().ToLower() == "quit") break;
            }
        }
    }
}