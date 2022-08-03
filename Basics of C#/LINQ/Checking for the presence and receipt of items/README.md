# Проверка наличия и получение элементов
Ряд методов в LINQ позволяют проверить наличие элементов в коллекции и получить их.

## All
Метод All() проверяет, соответствуют ли все элементы условию. Если все элементы соответствуют условию, то возвращается true.

## Any
Метод Any() действует подобным образом, только возвращает true, если хотя бы один элемент коллекции определенному условию

## Contains
Метод Contains() возвращает true, если коллекция содержит определенный элемент.

## First
Метод First() возвращает первый элемент последовательности

## FirstOrdefault
Метод FirstOrDefault() также возвращает первый элемент и также может принимать условие, только если коллекция пуста или в коллекции не окажется элементов, которые соответствуют условию, то метод возвращает значение по умолчанию

## Last и LastOrDefault
Метод Last() аналогичен по работе методу First, только возвращает последний элемент. Если коллекция не содержит элемент, который соответствуют условию, или вообще пуста, то метод генерирует исключение.

Метод LastOrDefault() возвращает последний элемент или значение по умолчанию, если коллекция не содержит элемент, который соответствуют условию, или вообще пуста