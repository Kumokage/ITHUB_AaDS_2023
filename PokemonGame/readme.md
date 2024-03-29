# PokemonGame
В данной консольной игре принимают участия два игрока. Каждый игрок по очереди выбирает покемонов из коллекции на 1000 очков, не более одного легендарного покемона. Покемоны выстраиваются в очередь по скорости, затем согласно очередности игроки выбирают какого покемона противника атаковать. Первый игрок, который лишится всех своих покемонов проигрывает.

# Part 1
В первой части задания вам будет необходимо реализовать классы `Pokemon` и `PokemonCollection`.  

## Pokemon
Реализация покемона.

**Атрибуты**
- `float attack` - сила атаки покемона;
- `int base_total` - количество очков необходимое для взятия покемона;
- `int capture_rate` - шанс поймать покемона;
- `float defence` - защита покемона;
- `float hp` - здоровье покемона;
- `int sp_attack` - скорость атаки покемона;
- `int sp_defence` - скорость защиты покемона;
- `int speed` - скорость покемона;
- `int generation` - поколение покемона;
- `bool is_legend` - легендарный ли покемон;
- `string name` - название покемона;
- `PokemonType type1` - тип покемона;
- `PokemonType? type2` - дополнительный тип покемона;
- `float[] againstTypeTabl` - массив с коэфициентами атаки покемонов.

**Свойства**
- `isDead` - показывает мертвый ли покемон

**Методы**
- `void AttackPokemon(Pokemon target)` - метод для атаки покемона, атака считается по следующей логике: если у атакуемого покемона 2 типа, то атака покемона умножается на среднее арефметическое коэфициентов соответствующих типов, если всего 1 тип, то умнажается на коэфициент. Далее сравнивается скорость атаки атакующего покемона и скорость защиты атакуемого покемона и если скорость атаки меньше или равна, то от атаки отнимается защита. $\frac{type_multy_1 + type_multy_2}{2} * attack - defence$; 
- `object Clone()` - реализация интерфейса `IClonable`, метод для клонирования объекта;

## PokemonCollection
Хэш таблица для хранения и поиска покемонов. Ключи имена покемонов, значения покемоны.

**Конструктор**
- `PokemonCollection(string dataPath)` - конструктор принимает на вход путь к файлу для парсинга.

**Методы**
- `ParseData(string[] data)` - парсит csv файл с данными о пакемонах;
- `void Push(Pokemon pokemon)` - добавляет покемона в хэш таблицу;
- `Pokemon FindByName(string name)` - ишет покемона по имени в хэш таблице.
