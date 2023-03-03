# КТ 2

## Описание
В данном задание вам необходимо реализовать методы сортировки массива строк и сравнить время работы различных алгоритмов сортировки. Результаты сравнения необходимо сохранить в csv файл. Далее вам необходимо будет открыть получившийся csv файл в excel и построить графики зависимости времени работы алгоритмов от размера входных данных.

## Методы сортировки

- `BubleSort` - сортировка пузырьком;
- `SelectSort` - соритировка вставками
- `InsertSort` - сортировка выбором
- `MergeSort` - сортировка слияниями
- `QuickSort` - быстрая сортировка 

### Параметры метода
В качестве параметров в метод передается массив по ссылке `arr` и `enum` параметр `Order`. `Order` задает порядок сортировки: по убыванию `Order.DESC` или по возрастанию `Order.ASC`.

### Пример работы Enum
Код:
```C#
Order test = Order.ASC;
if (test == Order.ASC)
    Console.WriteLine($"Test is ABS, can be represent as {(int) test}");

if (test != Order.DESC)
    Console.WriteLine($"Test is not DESC: test is {test}");

test = Order.DESC;
if (test != Order.ASC)
    Console.WriteLine($"Test is not ABS: test is {test}");

if (test == Order.DESC)
    Console.WriteLine($"Test is DESC: can be repesent as {(int) test}");
```
Вывод:
```
> Test is ABS, can be represent as 0
> Test is not DESC: test is ABS
> Test is not ABS: test is DESC
> Test is DESC: can be repesent as 1 
```

## Результат и критерии оценивания
В качестве результата вами должен быть отправлен pull request с реализованым классом `Sortings`, кодом для подсчета времени работы алгоритмов и записи результатов в файл AlgoTimeResults.csv и файл AlgoTimeResultsWithGraphs. 

**Важно:** для проверки ваших алгоритмов были написаны unit тесты, запустите их перед отправкой, проверьте свои результаты.

**Будут оцениваться:**
- Качество кода
- Корректность реализованных алгоритмов
- Соответствие графиков аналитическим оценкам
