# Отложенное и немедленное выполнение LINQ
Есть два способа выполнения запроса LINQ: отложенное (deferred) и немедленное (immediate) выполнение.

При отложенном выполнении LINQ-выражение не выполняется, пока не будет произведена итерация или перебор по выборке, например, в цикле foreach. Обычно подобные операции возвращают объект IEnumerable<T> или IOrderedEnumerable<T>.  
Полный список отложенных операций LINQ:
- AsEnumerable
- Cast
- Concat
- DefaultIfEmpty
- Distinct
- Except
- GroupBy
- GroupJoin
- Intersect
- Join
- OfType
- OrderBy
- OrderByDescending
- Range
- Repeat
- Reverse
- Select
- SelectMany
- Skip
- SkipWhile
- Take
- TakeWhile
- ThenBy
- ThenByDescending
- Union
- Where

## Немедленное выполнение запроса
С помощью ряда методов мы можем применить немедленное выполнение запроса. Это методы, которые возвращают одно атомарное значение или один элемент или данные типов Array, List и Dictionary.   
Полный список подобных операций в LINQ:
- Aggregate
- All
- Any
- Average
- Contains
- Count
- ElementAt
- ElementAtOrDefault
- Empty
- First
- FirstOrDefault
- Last
- LastOrDefault
- LongCount
- Max
- Min
- SequenceEqual
- Single
- SingleOrDefault
- Sum
- ToArray
- ToDictionary
- ToList
- ToLookup


  
