# Порождающие паттерны

Паттерны которые создают новые объекты, или позволяют получить доступ к уже существующим. То есть те шаблоны, по которым можно создать новый автомобиль и как это лучше сделать.

## [Singleton (одиночка)](https://github.com/Sempaku/Learning_CSharp/tree/master/Design%20patterns/Generating%20patterns/Одиночка%20(Singleton))

Один из самых известных и, пожалуй, самых спорных паттернов.
Представьте, что в городе требуется организовать связь между жителями. С одной стороны мы можем связать всех жителей между собой протянув между ними кабели телефонных линий, но полагаю вы понимаете насколько такая система неверна. Например, как затратно будет добавить еще одного жителя в связи (протянуть по еще одной линии к каждому жителю). Чтобы этого избежать, мы создаем телефонную станцию, которая и будет нашим «одиночкой». Она одна, всегда, и если кому-то потребуется связаться с кем-то, то он может это сделать через данную телефонную станцию, потому что все обращаются только к ней. Соответственно для добавления нового жителя нужно будет изменить только записи на самой телефонной станции. Один раз создав телефонную станцию все могут пользоваться ей и только ей одной, в свою очередь эта станция помнит всё что с ней происходило с момента ее создания и каждый может воспользоваться этой информацией, даже если он только приехал в город.
Основной смысл «одиночки» в том, чтобы когда вы говорите «Мне нужна телефонная станция», вам бы говорили «Она уже построена там-то», а не «Давай ее сделаем заново». «Одиночка» всегда один.

Примечание:
Несмотря на удобство применения данного паттерна, он является одним из самых спорных при разработке и рекомендуется его применять только если нет никакого другого способа решения, потому как это создает значительные сложности при тестировании кода, однако это уже отдельная тема.

## Registry (реестр, журнал записей)

Как следует из названия, данный паттерн предназначен для хранения записей которые в него помещают и соответственно возвращения этих записей (по имени) если они потребуются. В примере с телефонной станцией, она является реестром по отношению к телефонным номерам жителей.

Паттерны «одиночка» и «реестр» постоянно встречаются нам в повседневной жизни. Например бухгалтерия в фирме является «одиночкой», потому как она всегда одна и помнит что с ней происходило с момента ее начала работы. Фирма не создает каждый раз новую бухгалтерию когда ей требуется выдать зарплату. В свою очередь бухгалтерия является и «реестром», потому как в ней есть записи о каждом работнике фирмы.

Примечание:
«Реестр» нередко является «одиночкой», однако это не всегда должно быть именно так. Например мы можем заводить в бухгалтерии несколько журналов, в одном работники от «А» до «М», в другом от «Н» до «Я». Каждый такой журнал будет «реестром», но не «одиночкой», потому как журналов уже 2. Хотя нередко «реестр» служит именно для хранения «одиночек».
Сам паттерн «реестр» не являтся «порождающим паттерном» в полном смысле этого термина, однако его удобно рассматривать именно во взаимосвязи с ними.

## Multiton (пул «одиночек»)

Как понятно из названия паттерна, это по своей сути «реестр» содержащий несколько «одиночек», каждый из которых имеет своё «имя» по которому к нему можно получить доступ.

## Object pool (пул объектов)

По аналогии с «пулом одиночек» данный паттерн также позволяет хранить уже готовые объекты, однако они не обязаны быть «одиночками».

## Factory (фабрика)

Суть паттерна практически полностью описывается его названием. Когда вам требуется получать какие-то объекты, например пакеты сока, вам совершенно не нужно знать как их делают на фабрике. Вы просто говорите «сделайте мне пакет апельсинового сока», а «фабрика» возвращает вам требуемый пакет. Как? Всё это решает сама фабрика, например «копирует» уже существующий эталон. Основное предназначение «фабрики» в том, чтобы можно было при необходимости изменять процесс «появления» пакета сока, а самому потребителю ничего об этом не нужно было сообщать, чтобы он запрашивал его как и прежде.
Как правило, одна фабрика занимается «производством» только одного рода «продуктов». Не рекомендуется «фабрику соков» создавать с учетом производства автомобильных покрышек. Как и в жизни, паттерн «фабрика» часто создается «одиночкой».

## [Builder (строитель)](https://github.com/Sempaku/Learning_CSharp/tree/master/Design%20patterns/Generating%20patterns/Строитель%20(Builder))

Данный паттерн очень тесно переплетается с паттерном «фабрики». Основное различие заключается в том, что «строитель» внутри себя, как правило, содержит все сложные операции по созданию объекта (пакета сока). Вы говорите «хочу сока», а строитель запускает уже целую цепочку различных операций (создание пакета, печать на нем изображений, заправка в него сока, учет того сколько пакетов было создано и т.п.). Если вам потребуется другой сок, например ананасовый, вы точно также говорите только то, что вам нужно, а «строитель» уже позаботится обо всем остальном (какие-то процессы повторит, какие-то сделает заново и т.п.). В свою очередь процессы в «строителе» можно легко менять (например изменить рисунок на упаковке), однако потребителю сока этого знать не требуется, он также будет легко получать требуемый ему пакет сока по тому же запросу.

Примечание:
Чтобы лучше понять разницу между фабрикой и строителем, можно использовать следующую метафору.
«Фабрика» — это автомат по продаже напитков, в нем уже есть всё готовое (или «осталось разогреть»), а вы только говорите что вам нужно (нажимаете кнопку). «Строитель» — это завод, который производит эти напитки и содержит в себе все сложные операции и может собирать сложные объекты из более простых (упаковка, этикетка, вода, ароматизаторы и т.п.) в зависимости от запроса.

## [Prototype (прототип)](https://github.com/Sempaku/Learning_CSharp/tree/master/Design%20patterns/Generating%20patterns/Прототип%20(Prototype))

Данный паттерн чем-то напоминает «фабрику», он также служит для создания объектов, однако с немного другим подходом. Представьте что у вас есть пустой пакет (из под сока), а вам нужен полный с апельсиновым соком. Вы «говорите» пакету «Хочу пакет апельсинового сока», он в свою очередь создает свою копию и заполняет ее соком, который вы попросили. Немного «сказочный пример», но в программировании часто так и бывает. В данном случае пустой пакет и является «прототипом», и в зависимости от того что вам требуется, он создает на своей основе требуемые вами объекты (пакеты сока).
Клонирование не обязательно должно производится на самом «пакете», это может быть и какой-то другой «объект», главное лишь что данный «прототип» позволяет получать его экземпляры.

## [Factory method (фабричный метод)](https://github.com/Sempaku/Learning_CSharp/tree/master/Design%20patterns/Generating%20patterns/Фабричный%20метод%20(Factory%20Method))

Данный паттерн довольно сложно объяснить в метафорах, но всё же попробую.
Ключевой сложностью объяснения данного паттерна является то, что это «метод», поэтому метафора метода будет использовано как действие, то есть например слово «Хочу!». Соответственно, паттерн описывает то, как должно выполнятся это «Хочу!».
Допустим ваша фабрика производит пакеты с разными соками. Теоретически мы можем на каждый вид сока делать свою производственную линию, но это не эффективно. Удобнее сделать одну линию по производству пакетов-основ, а разделение ввести только на этапе заливки сока, который мы можем определять просто по названию сока. Однако откуда взять название?
Для этого мы создаем основной отдел по производству пакетов-основ и предупреждаем все под-отделы, что они должны производить нужный пакет с соком про простому «Хочу!» (т.е. каждый под-отдел должен реализовать паттерн «фабричный метод»). Поэтому каждый под-отдел заведует только своим типом сока и реагирует на слово «Хочу!».
Таким образом если нам потребуется пакет апельсинового сока, то мы просто скажем отделу по производству апельсинового сока «Хочу!», а он в свою очередь скажет основному отделу по созданию пакетов сока, «Сделай ка свой обычный пакет и вот сок, который туда нужно залить».

Примечание:
Как вы могли уже заметить, «фабричный метод» является как бы основой для «фабрики», «строителя» и «прототипа». В разработке часто именно так и получается, сперва реализуют фабричный метод, а по мере усложнения кода выбирают во что именно его преобразовать, в какой из перечисленных паттернов. При использовании «фабричного метода» каждый объект как бы сам является «фабрикой».

## Lazy initialization (отложенная инициализация)

Иногда требуется что-то иметь под рукой, на всякий случай, но не всегда хочется прилагать каждый раз усилия, чтобы это каждый раз получать/создавать. Для таких случаев используется паттерн «отложенная инициализация». Допустим вы работаете в бухгалтерии и для каждого сотрудника вы должны подготавливать «отчет о выплатах». Вы можете в начале каждого месяца делать этот отчет на всех сотрудников, но некоторые отчеты могут не понадобиться, и тогда скорее всего вы примените «отложенную инициализацию», то есть вы будете подготавливать этот отчет только тогда, когда он будет запрошен начальством (вышестоящим объектом), однако начальство по сути в каждый момент времени может сказать что у него этот отчет уже есть, однако готов он уже или нет, оно не знает и знать не должно. Как вы уже поняли, данный паттерн служит для оптимизации ресурсов.

## Dependency injection (внедрение зависимости)

Внедрение зависимости позволяет переложить часть ответственности за какой-то функционал на другие объекты. Например если нам требуется нанять новый персонал, то мы можем не создавать свой отдел кадров, а внедрить зависимость от компании по подбору персонала, которая свою очередь по первому нашему требованию «нам нужен человек», будет либо сама работать как отдел кадров, либо же найдет другую компанию (при помощи «локатора служб»), которая предоставит данные услуги.
«Внедрение зависимости» позволяет перекладывать и взаимозаменять отдельные части компании без потери общей функциональности.

## Service Locator (локатор служб)

«Локатор служб» является методом реализации «внедрения зависимости». Он возвращает разные типы объектов (компаний) в зависимости от кода инициализации. Пускай задача стоит доставить наш пакет сока, созданный строителем, фабрикой или ещё чем, куда захотел покупатель. Мы спрашиваем у локатора «дай нам службу доставки», и он нам соединяет на со службой доставки по номеру телефона, который директор ему дал (потому что получает откат они нам дают скидку как постоянным клиентам), а мы уже просим службу доставить сок по нужному адресу. Сегодня одна служба, а завтра может быть другая. Нам без разницы какая это конкретно служба, решение принимает директор и сообщает об этом локатору служб, нам важно знать лишь что они могут доставлять то, что мы им скажем туда, куда скажем, то есть службы реализуют интерфейс «Доставить <предмет> на <адрес>».
