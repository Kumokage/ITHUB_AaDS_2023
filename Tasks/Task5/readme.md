# КТ5

## Описание
В рамках данного задания вам необходимо будет реализовать хэш таблицу содержащию в качестве ключей названия карт из MTG, а в качестве значений класс Card сожержащий информацию о данной карте.

## Структура классов 

### Card

#### Артибуты
- id - int 
- colors - enum with one of five colors
- manaCost - string
- name - string
- number - int
- originalText - string
- power - int
- rarity - enum with rarity
- subtypes - enum with subtype
- text - string
- types - enum with type

#### Методы
- ToString()

#### Свойства
Свойства для каждого атрибута на чтение.

### CardCollection

#### Методы
- Add(string key, Card value) - добавляет значение в коллекцию;
- Clear() - очищает коллекцию;
- Remove(string key) - удаляет значение с переданным ключом;
- Remove(string key, Card value) - удаляет значение с выбраным ключом и заменяет его переданным значением.

#### Свойства
- Count - возвращает колличество элементов в хэш таблице;
- Item[string key] - Возвращает или задает значение, связанное с указанным ключом;
- Keys - возвращает массив из всех ключей хэш таблицы;
- Values - возвращает массив из всех значений хэш таблиц.
