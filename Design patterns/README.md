# Шаблоны проектирования
Виды шаблонов проектирования
- [Порождающие](#порождающие-шаблоны-проектирования)
- [Структурные](#структурные-шаблоны-проектирования)
- [Поведенческие](#поведенческие-шаблоны-проектирования)

## Порождающие шаблоны проектирования
### Вкратце
Порождающие шаблоны описывают создание (instantiate) объекта или группы связанных объектов.
### Википедия
В программной инженерии порождающими называют шаблоны, которые используют механизмы создания объектов, чтобы создавать объекты подходящим для данной ситуации способом. Базовый способ создания может привести к проблемам в архитектуре или к её усложнению. Порождающие шаблоны пытаются решать эти проблемы, управляя способом создания объектов.
- [Простая фабрика](#простая-фабрика)
- [Фабричный метод](#фабричный-метод)
- [Абстрактная фабрика](#абстрактная-фабрика)
- [Строитель](#строитель)
- [Прототип](#прототип)
- [Одиночка](#одиночка)
____
#### Простая фабрика

##### Аналогия
Допустим, вы строите дом и вам нужны двери. Будет бардак, если каждый раз, когда вам требуется дверь, вы станете вооружаться инструментами и делать её на стройплощадке. Вместо этого вы закажете двери на фабрике.


##### Вкратце
Простая фабрика просто генерирует экземпляр для клиента без предоставления какой-либо логики экземпляра.


##### Википедия
В объектно ориентированном программировании фабрикой называется объект, создающий другие объекты. Формально фабрика — это функция или метод, возвращающая объекты разных прототипов или классов из вызова какого-то метода, который считается новым.

##### Когда использовать?
Когда создание объекта подразумевает какую-то логику, а не просто несколько присваиваний, то имеет смысл делегировать задачу выделенной фабрике, а не повторять повсюду один и тот же код.


____
#### Фабричный метод
##### Аналогия
Одна кадровичка не в силах провести собеседования со всеми кандидатами на все должности. В зависимости от вакансии она может делегировать разные этапы собеседований разным сотрудникам.


##### Вкратце
Это способ делегирования логики создания объектов (instantiation logic) дочерним классам.


##### Википедия
В классо-ориентированном программировании (class-based programming) фабричным методом называют порождающий шаблон проектирования, использующий генерирующие методы (factory method) для решения проблемы создания объектов без указания для них конкретных классов. Объекты создаются посредством вызова не конструктора, а генерирующего метода, определённого в интерфейсе и реализованного дочерними классами либо реализованного в базовом классе и, опционально, переопределённого (overridden) производными классами (derived classes).

##### Когда использовать?
Этот шаблон полезен для каких-то общих обработок в классе, но требуемые подклассы динамически определяются в ходе выполнения (runtime). То есть когда клиент не знает, какой именно подкласс может ему понадобиться.



____
#### Абстрактная фабрика
##### Аналогия
Вернёмся к примеру с дверями из «Простой фабрики». В зависимости от своих потребностей вы можете купить деревянную дверь в одном магазине, стальную — в другом, пластиковую — в третьем. Для монтажа вам понадобятся разные специалисты: деревянной двери нужен плотник, стальной — сварщик, пластиковой — спец по ПВХ-профилям.


##### Вкратце
Это фабрика фабрик. То есть фабрика, группирующая индивидуальные, но взаимосвязанные/взаимозависимые фабрики без указания для них конкретных классов.


##### Википедия
Шаблон «Абстрактная фабрика» описывает способ инкапсулирования группы индивидуальных фабрик, объединённых некой темой, без указания для них конкретных классов.

##### Когда использовать?
Когда у вас есть взаимосвязи с не самой простой логикой создания (creation logic).


____
#### Строитель
##### Аналогия
Допустим, вы пришли в забегаловку, заказали бургер дня, и вам выдали его без вопросов. Это пример «Простой фабрики». Но иногда логика создания состоит из большего количества шагов. К примеру, при заказе бургера дня есть несколько вариантов хлеба, начинки, соусов, дополнительных ингредиентов. В таких ситуациях помогает шаблон «Строитель».


##### Вкратце
Шаблон позволяет создавать разные свойства объекта, избегая загрязнения конструктора (constructor pollution). Это полезно, когда у объекта может быть несколько свойств. Или когда создание объекта состоит из большого количества этапов.


##### Википедия
Шаблон «Строитель» предназначен для поиска решения проблемы антипаттерна Telescoping constructor.

Поясню, что такое антипаттерн Telescoping constructor. Каждый из нас когда-либо сталкивался с подобным конструктором:

```php
public function __construct($size, $cheese = true, $pepperoni = true, $tomato = false, $lettuce = true)
{
}
```
Как видите, количество параметров может быстро разрастись, и станет трудно разобраться в их структуре. Кроме того, этот список параметров будет расти и дальше, если в будущем вы захотите добавить новые опции. Это и есть антипаттерн Telescoping constructor.


##### Когда использовать?
Когда у объекта может быть несколько свойств и когда нужно избежать Telescoping constructor. Ключевое отличие от шаблона «Простая фабрика»: он используется в одноэтапном создании, а «Строитель» — в многоэтапном.



____
#### Прототип
##### Аналогия
Помните клонированную овечку Долли? Так вот, этот шаблон проектирования как раз посвящён клонированию.


##### Вкратце
Объект создаётся посредством клонирования существующего объекта.


##### Википедия
Шаблон «Прототип» используется, когда типы создаваемых объектов определяются экземпляром-прототипом, клонированным для создания новых объектов.

То есть шаблон позволяет дублировать существующий объект и модифицировать копию в соответствии с потребностями. Без заморочек с созданием объекта с нуля и его настройкой.


##### Когда использовать?
Когда необходимый объект аналогичен уже существующему или когда создание с нуля дороже клонирования.


____
#### Одиночка
##### Аналогия
У страны может быть только один президент. Он должен действовать, когда того требуют обстоятельства и долг. В данном случае президент — одиночка.


##### Вкратце
Шаблон позволяет удостовериться, что создаваемый объект — единственный в своём классе.


##### Википедия
Шаблон «Одиночка» позволяет ограничивать создание класса единственным объектом. Это удобно, когда для координации действий в рамках системы требуется, чтобы объект был единственным в своём классе.

На самом деле шаблон «Одиночка» считается антипаттерном, не следует им слишком увлекаться. Он необязательно плох и иногда бывает полезен. Но применяйте его с осторожностью, потому что «Одиночка» вносит в приложение глобальное состояние, так что изменение в одном месте может повлиять на все остальные случаи использования, а отлаживать такое — не самое простое занятие. Другие недостатки шаблона: он делает ваш код сильно связанным (tightly coupled), а создание прототипа (mocking) «Одиночки» может быть затруднено.

____
## Структурные шаблоны проектирования
### Вкратце
### Википедия
- [Адаптер](#адаптер)
- [Мост](#мост)
- [Компоновщик](#компоновщик)
- [Декоратор](#декоратор)
- [Фасад](#фасад)
- [Приспособленец](#приспособленец)
- [Заместитель](#заместитель)
____

#### Адаптер
##### Аналогия
Допустим, у вас на карте памяти есть какие-то картинки. Их нужно перенести на компьютер. Нужен адаптер, совместимый с входным портом компьютера, в который можно вставить карту памяти. В данном примере адаптер — это картридер. Ещё один пример: переходник, позволяющий использовать американский блок питания с российской розеткой. Третий пример: переводчик — это адаптер, соединяющий двух людей, говорящих на разных языках.


##### Вкратце
Шаблон «Адаптер» позволяет помещать несовместимый объект в обёртку, чтобы он оказался совместимым с другим классом.


##### Википедия
Шаблон проектирования «Адаптер» позволяет использовать интерфейс существующего класса как другой интерфейс. Этот шаблон часто применяется для обеспечения работы одних классов с другими без изменения их исходного кода.

____
#### Мост
##### Аналогия
Допустим, у вас есть сайт с несколькими страницами. Вы хотите позволить пользователям менять темы оформления страниц. Как бы вы поступили? Создали множественные копии каждой страницы для каждой темы или просто сделали отдельные темы и подгружали их в соответствии с настройками пользователей? Шаблон «Мост» позволяет реализовать второй подход.


##### Вкратце
Шаблон «Мост» — это предпочтение компоновки наследованию. Подробности реализации передаются из одной иерархии другому объекту с отдельной иерархией.


##### Википедия
Шаблон «Мост» означает отделение абстракции от реализации, чтобы их обе можно было изменять независимо друг от друга.

____
#### Компоновщик
##### Аналогия
Каждая компания состоит из сотрудников. У каждого сотрудника есть одни и те же свойства: зарплата, обязанности, отчётность перед кем-то, субординация...


##### Вкратце
Шаблон «Компоновщик» позволяет клиентам обрабатывать отдельные объекты в едином порядке.


##### Википедия
Шаблон «Компоновщик» описывает общий порядок обработки группы объектов, словно это одиночный экземпляр объекта. Суть шаблона — компонование объектов в древовидную структуру для представления иерархии от частного к целому. Шаблон позволяет клиентам одинаково обращаться к отдельным объектам и к группам объектов.

____
#### Декоратор
##### Аналогия
Допустим, у вас свой автосервис, оказывающий различные услуги. Как выставлять клиентам счёт? Добавлять последовательно услуги и их стоимость — и в конце концов получится итоговая сумма к оплате. Здесь каждый тип услуги — это «декоратор».


##### Вкратце
Шаблон «Декоратор» позволяет во время выполнения динамически изменять поведение объекта, обёртывая его в объект класса «декоратора».


##### Википедия
Шаблон «Декоратор» позволяет подключать к объекту дополнительное поведение (статически или динамически), не влияя на поведение других объектов того же класса. Шаблон часто используется для соблюдения принципа единственной обязанности (Single Responsibility Principle), поскольку позволяет разделить функциональность между классами для решения конкретных задач.

____
#### Фасад
##### Аналогия
Как включить компьютер? Вы скажете: «Нажать кнопку включения». Это потому, что вы используете простой интерфейс, предоставляемый компьютером наружу. А внутри него происходит очень много процессов. Простой интерфейс для сложной подсистемы — это фасад.


##### Вкратце
Шаблон «Фасад» предоставляет упрощённый интерфейс для сложной подсистемы.


##### Википедия
«Фасад» — это объект, предоставляющий упрощённый интерфейс для более крупного тела кода, например библиотеки классов.

____
#### Приспособленец
##### Аналогия
Обычно в заведениях общепита чай заваривают не отдельно для каждого клиента, а сразу в некой крупной ёмкости. Это позволяет экономить ресурсы: газ/электричество, время и т. д. Шаблон «Приспособленец» как раз посвящён общему использованию (sharing).


##### Вкратце
Шаблон применяется для минимизирования использования памяти или вычислительной стоимости за счёт общего использования как можно большего количества одинаковых объектов.


##### Википедия
«Приспособленец» — это объект, минимизирующий использование памяти за счёт общего с другими, такими же объектами использования как можно большего объёма данных. Это способ применения многочисленных объектов, когда простое повторяющееся представление приведёт к неприемлемому потреблению памяти.

____
#### Заместитель
##### Аналогия
Открыть дверь с электронным замком можно с помощью карточки доступа (access card) или кнопки для обхода системы безопасности. То есть основная функциональность двери — открыться, а поверх неё может быть ещё какая-то функциональность — «заместитель».


##### Вкратце
С помощью шаблона «Заместитель» класс представляет функциональность другого класса.


##### Википедия
В наиболее общей форме «Заместитель» — это класс, функционирующий как интерфейс к чему-либо. Это оболочка или объект-агент, вызываемый клиентом для получения доступа к другому, «настоящему» объекту. «Заместитель» может просто переадресовывать запросы настоящему объекту, а может предоставлять дополнительную логику: кеширование данных при интенсивном выполнении операций или потреблении ресурсов настоящим объектом; проверка предварительных условий (preconditions) до вызова выполнения операций настоящим объектом.

____
## Поведенческие шаблоны проектирования
### Вкратце
Они связаны с присвоением обязанностей (responsibilities) объектам. От структурных шаблонов они отличаются тем, что не просто описывают структуру, но и очерчивают шаблоны передачи данных, обеспечения взаимодействия. То есть поведенческие шаблоны позволяют ответить на вопрос «Как реализовать поведение в программном компоненте?»


### Википедия
Поведенческие шаблоны проектирования определяют алгоритмы и способы реализации взаимодействия различных объектов и классов. Они обеспечивают гибкость взаимодействия между объектами.
- [Цепочка ответственности](#цепочка-ответственности)
- [Команда](#команда)
- [Итератор](#итератор)
- [Посредник](#посредник)
- [Хранитель](#хранитель)
- [Наблюдатель](#наблюдатель)
- [Посетитель](#посетитель)
- [Стратегия](#стратегия)
- [Состояние](#состояние)
- [Шаблонный метод](#шаблонный-метод)
____
#### Цепочка ответственности
##### Аналогия
Допустим, для вашего банковского счёта доступны три способа оплаты (A, B и C). Каждый подразумевает разные доступные суммы денег: A — 100 долларов, B — 300, C — 1000. Приоритетность способов при оплате: А, затем В, затем С. Вы пытаетесь купить что-то за 210 долларов. На основании «цепочки ответственности» система попытается оплатить способом А. Если денег хватает — то оплата проходит, а цепочка прерывается. Если денег не хватает — то система переходит к способу В, и т. д.


##### Вкратце
Шаблон «Цепочка ответственности» позволяет создавать цепочки объектов. Запрос входит с одного конца цепочки и движется от объекта к объекту, пока не будет найден подходящий обработчик.


##### Википедия
Шаблон «Цепочка ответственности» содержит исходный управляющий объект и ряд обрабатывающих объектов. Каждый обрабатывающий объект содержит логику, определяющую типы командных объектов, которые он может обрабатывать, а остальные передаются по цепочке следующему обрабатывающему объекту.

____
#### Команда
##### Аналогия
Вы пришли в ресторан. Вы (Client) просите официанта (Invoker) принести блюда (Command). Официант перенаправляет запрос шеф-повару (Receiver), который знает, что и как готовить. Другой пример: вы (Client) включаете (Command) телевизор (Receiver) с помощью пульта (Invoker).


##### Вкратце
Шаблон «Команда» позволяет инкапсулировать действия в объекты. Ключевая идея — предоставить средства отделения клиента от получателя.


##### Википедия
В шаблоне «Команда» объект используется для инкапсуляции всей информации, необходимой для выполнения действия либо для его инициирования позднее. Информация включает в себя имя метода; объект, владеющий методом; значения параметров метода.

____
#### Итератор
##### Аналогия
Хороший пример — радиоприёмник. Вы начинаете с какой-то радиостанции, а затем перемещаетесь по станциям вперёд/назад. То есть устройство предоставляет интерфейс для итерирования по каналам.


##### Вкратце
Шаблон — это способ доступа к элементам объекта без раскрытия базового представления.


##### Википедия
В этом шаблоне итератор используется для перемещения по контейнеру и обеспечения доступа к элементам контейнера. Шаблон подразумевает отделение алгоритмов от контейнера. В каких-то случаях алгоритмы, специфичные для этого контейнера, не могут быть отделены.

____
#### Посредник
##### Аналогия
Когда вы говорите с кем-то по мобильнику, то между вами и собеседником находится мобильный оператор. То есть сигнал передаётся через него, а не напрямую. В данном примере оператор — посредник.


##### Вкратце
Шаблон «Посредник» подразумевает добавление стороннего объекта («посредника») для управления взаимодействием между двумя объектами («коллегами»). Шаблон помогает уменьшить связанность (coupling) классов, общающихся друг с другом, ведь теперь они не должны знать о реализациях своих собеседников.


##### Википедия
Шаблон определяет объект, который инкапсулирует способ взаимодействия набора объектов.

____
#### Хранитель
##### Аналогия
В качестве примера можно привести калькулятор («создатель»), у которого любая последняя выполненная операция сохраняется в памяти («хранитель»), чтобы вы могли снова вызвать её с помощью каких-то кнопок («опекун»).


##### Вкратце
Шаблон «Хранитель» фиксирует и хранит текущее состояние объекта, чтобы оно легко восстанавливалось.


##### Википедия
Шаблон «Хранитель» позволяет восстанавливать объект в его предыдущем состоянии (отмена через откат — undo via rollback).

Обычно шаблон применяется, когда нужно реализовать функциональность отмены операции.


____
#### Наблюдатель
##### Аналогия
Хороший пример: люди, ищущие работу, подписываются на публикации на сайтах вакансий и получают уведомления, когда появляются вакансии, подходящие по параметрам.


##### Вкратце
Шаблон определяет зависимость между объектами, чтобы при изменении состояния одного из них его «подчинённые» узнавали об этом.


##### Википедия
В шаблоне «Наблюдатель» есть объект («субъект»), ведущий список своих «подчинённых» («наблюдателей») и автоматически уведомляющий их о любом изменении своего состояния, обычно с помощью вызова одного из их методов.

____
#### Посетитель
##### Аналогия
Туристы собрались в Дубай. Сначала им нужен способ попасть туда (виза). После прибытия они будут посещать любую часть города, не спрашивая разрешения, ходить где вздумается. Просто скажите им о каком-нибудь месте — и туристы могут там побывать. Шаблон «Посетитель» помогает добавлять места для посещения.


##### Вкратце
Шаблон «Посетитель» позволяет добавлять будущие операции для объектов без их модифицирования.


##### Википедия
Шаблон «Посетитель» — это способ отделения алгоритма от структуры объекта, в которой он оперирует. Результат отделения — возможность добавлять новые операции в существующие структуры объектов без их модифицирования. Это один из способов соблюдения принципа открытости/закрытости (open/closed principle).

____
#### Стратегия
##### Аналогия
Возьмём пример с пузырьковой сортировкой. Мы её реализовали, но с ростом объёмов данных сортировка стала выполняться очень медленно. Тогда мы сделали быструю сортировку (Quick sort). Алгоритм работает быстрее на больших объёмах, но на маленьких он очень медленный. Тогда мы реализовали стратегию, при которой для маленьких объёмов данных используется пузырьковая сортировка, а для больших — быстрая.


##### Вкратце
Шаблон «Стратегия» позволяет переключаться между алгоритмами или стратегиями в зависимости от ситуации.


##### Википедия
Шаблон «Стратегия» позволяет при выполнении выбирать поведение алгоритма.

____
#### Состояние
##### Аналогия
Допустим, в графическом редакторе вы выбрали инструмент «Кисть». Она меняет своё поведение в зависимости от настройки цвета: т. е. рисует линию выбранного цвета.


##### Вкратце
Шаблон позволяет менять поведение класса при изменении состояния.


##### Википедия
Шаблон «Состояние» реализует машину состояний объектно ориентированным способом. Это достигается с помощью:
- реализации каждого состояния в виде производного класса интерфейса шаблона «Состояние»,
- реализации переходов состояний (state transitions) посредством вызова методов, определённых вышестоящим классом (superclass).

Шаблон «Состояние» — это в некотором плане шаблон «Стратегия», при котором возможно переключение текущей стратегии с помощью вызова методов, определённых в интерфейсе шаблона.

____
#### Шаблонный метод
##### Аналогия
Допустим, вы собрались строить дома. Этапы будут такими:
+ Подготовка фундамента.
+ Возведение стен.
+ Настил крыши.
+ Настил перекрытий.  

Порядок этапов никогда не меняется. Вы не настелите крышу до возведения стен — и т. д. Но каждый этап модифицируется: стены, например, можно возвести из дерева, кирпича или газобетона.


##### Вкратце
«Шаблонный метод» определяет каркас выполнения определённого алгоритма, но реализацию самих этапов делегирует дочерним классам.


##### Википедия
«Шаблонный метод» — это поведенческий шаблон, определяющий основу алгоритма и позволяющий наследникам переопределять некоторые шаги алгоритма, не изменяя его структуру в целом.

____