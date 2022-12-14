# Исследование методов и конструкторов с помощью рефлексии
## Получение информации о методах
Для получения получении информации отдельно о методах применяется метод GetMethods(). Этот метод возвращает все методы типа в виде массива объектов MethodInfo. Его свойства предоставляют информацию о методе. Отметим некоторые из его свойств:

- **IsAbstract**: возвращает true, если метод абстрактный
- **IsFamily**: возвращает true, если метод имеет модификатор доступа protected
- **IsFamilyAndAssembly**: возвращает true, если метод имеет модификатор доступа private protected
- **IsFamilyOrAssembly**: возвращает true, если метод имеет модификатор доступа protected internal
- **IsAssembly**: возвращает true, если метод имеет модификатор доступа internal
- **IsPrivate**: возвращает true, если метод имеет модификатор доступа private
- **IsPublic**: возвращает true, если метод имеет модификатор доступа public
- **IsConstructor**: возвращает true, если метод предоставляет конструктор
- **IsStatic**: возвращает true, если метод статический
- **IsVirtual**: возвращает true, если метод виртуальный
- **ReturnType**: возвращает тип возвращаемого значения

Некоторые из методов MethodInfo:
- **GetMethodBody()**: возвращает тело метода в виде объекта MethodBody
- **GetParameters()**: возвращает массив параметров, где каждый параметр представлен объектом типа ParameterInfo
- **Invoke()**: вызывает метод

## BindingFlags
В примере выше использовалась простая форма метода GetMethods(), которая извлекает все общедоступные публичные методы. Но мы можем использовать и другую форму метода: MethodInfo[] GetMethods(BindingFlags). Объединяя значения BindingFlags можно комбинировать вывод. Например, получим только методы самого класса без унаследованных, как публичные, так и все остальные:

Для получения всех непубличных методов в метод GetMethods() передается набор флагов BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, то есть получаем все методы экземпляра, как публичные, так и непубличные, но исключаем статические

## Исследование параметров
С помощью метода GetParameters() можно получить все параметры метода в виде массива объектов ParameterInfo. Отметим некоторые из свойств ParameterInfo, которые позволяют получить информацию о параметрах:

- **Attributes**: возвращает атрибуты параметра
- **DefaultValue**: возвращает значение параметра по умолчанию
- **HasDefaultValue**: возвращает true, если параметр имеет значение по умолчанию
- **IsIn**: возвращает true, если параметр имеет модификатор in
- **IsOptional**: возвращает true, если параметр является необязательным
- **IsOut**: возвращает true, если параметр является выходным, то есть имеет модификатор out
- **Name**: возвращает имя параметра
- **ParameterType**: возвращает тип параметра

## Вызов методов
С помощью метода Invoke() можно вызвать метод:

``` public object? Invoke (object? obj, object?[]? parameters); ```

Первый параметр представляет объект, для которого вызывается метод. Второй объект представляет массив значений, которые передаются параметрам метода. И также метод может возвращать результат в виде значения object?.

Метод GetMethod() возвращает метод, который имеет определенное имя - в данном случае метод Print. Далее используя полученный метод, его можно вызвать. Здесь при вызове в качестве первого параметра передается объект, для которого вызывается метод Print - объект myPrinter. И поскольку метод Print не принимает параметров, параметру parameters передается значение null.

## Получение конструкторов
Для получения конструкторов применяется метод GetConstructors(), который возвращает массив объектов класса ConstructorInfo. Этот класс во многом похож на MethodInfo и имеет ряд общей функциональности. Некоторые основные свойства и методы:
- **Свойство IsFamily**: возвращает true, если конструктор имеет модификатор доступа protected
- **Свойство IsFamilyAndAssembly**: возвращает true, если конструктор имеет модификатор доступа private protected
- **Свойство IsFamilyOrAssembly**: возвращает true, если конструктор имеет модификатор доступа protected internal
- **Свойство IsAssembly**: возвращает true, если конструктор имеет модификатор доступа internal
- **Свойство IsPrivate**: возвращает true, если конструктор имеет модификатор доступа private
- **Свойство IsPublic**: возвращает true, если конструктор имеет модификатор доступа public
- **Метод GetMethodBody()**: возвращает тело конструктора в виде объекта MethodBody
- **Метод GetParameters()**: возвращает массив параметров, где каждый параметр представлен объектом типа ParameterInfo
- **Метод Invoke()**: вызывает конструктор






