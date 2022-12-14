# Принцип разделения интерфейсов

Принцип разделения интерфейсов (Interface Segregation Principle) относится к тем случаям, 
когда классы имеют "жирный интерфейс", то есть слишком раздутый интерфейс, не все методы и 
свойства которого используются и могут быть востребованы. Таким образом, интерфейс получатся
слишком избыточен или "жирным".

Принцип разделения интерфейсов можно сформулировать так:  
***Клиенты не должны вынужденно зависеть от методов, которыми не пользуются.***

При нарушении этого принципа клиент, использующий некоторый интерфейс со всеми его методами,
зависит от методов, которыми не пользуется, и поэтому оказывается восприимчив к изменениям в 
этих методах. В итоге мы приходим к жесткой зависимости между различными частями интерфейса, 
которые могут быть не связаны при его реализации.

Техники для выявления нарушения этого принципа:
* Слишком большие интерфейсы
* Компоненты в интерфейсах слабо согласованы (перекликается с принципом единой ответственности)
* Методы без реализации (перекликается с принципом Лисков)

В этом случае интерфейс класса разделяется на отдельные части, которые составляют раздельные 
интерфейсы. Затем эти интерфейсы независимо друг от друга могут применяться и изменяться. 
В итоге применение принципа разделения интерфейсов делает систему слабосвязанной, и тем самым
ее легче модифицировать и обновлять.

Рассмотрим на примере. Допустим у нас есть интерфейс отправки сообщения:
`-->ProblemSendMsgInterfaceExample.cs`

Интерфейс определяет все основное, что нужно для отправки сообщения: само сообщение, его тему,
адрес отправителя и получателя и, конечно, сам метод отправки. И пусть есть класс EmailMessage,
который реализует этот интерфейс:

Надо отметить, что класс EmailMessage выглядит целостно, вполне удовлетворяя принципу
единственной ответственности. То есть с точки зрения связности (cohesion) здесь проблем нет.

Теперь определим класс, который бы отправлял данные по смс:

Здесь мы уже сталкиваемся с небольшой проблемой: свойство Subject, которое определяет тему 
сообщения, при отправке смс не указывается, поэтому оно в данном классе не нужно. Таким образом,
в классе SmsMessage появляется избыточная функциональность, от которой класс SmsMessage начинает
зависеть.

Это не очень хорошо, но посмотрим дальше. Допустим, нам надо создать класс для отправки 
голосовых сообщений.

Класс голосовой почты также имеет отправителя и получателя, только само сообщение передается в 
виде звука, что на уровне C# можно выразить в виде массива байтов. И в этом случае было бы 
неплохо, если бы интерфейс IMessage включал бы в себя дополнительные свойства и методы для 
этого, например:

И здесь опять же мы сталкиваемся с ненужными свойствами. Плюс нам надо добавить новое свойство 
в предыдущие классы SmsMessage и EmailMessage, причем этим классам свойство Voice в принципе то 
не нужно. В итоге здесь мы сталкиваемся с явным нарушением принципа разделения интерфейсов.

Для решения возникшей проблемы нам надо выделить из классов группы связанных методов и свойств
и определить для каждой группы свой интерфейс:
`--> NormalSendMsgExample.cs`

Теперь классы больше не содержат неиспользуемые методы. Чтобы избежать дублирование кода, 
применяется наследование интерфейсов. В итоге структра классов получается проще, чище и яснее.

____
## Пустые методы
Одним из типичных нарушений данного принципа являются нереализованные методы.
Подобные методы обычно говорят о том, что в проектировании системы есть недостатки и упущения. 
Кроме того, нереализованные методы нередко также нарушают принцип Лисков.

Рассмотрим пример:
`--> ProblemEmptyMethodsExample.cs`

В наше время телефоны могут если не все, то очень многое, и представленный выше класс 
определяет ряд задач, которые выполняются стандартным телефоном: звонки, фото, видео, интернет.

Но пусть у нас есть также класс клиента, который использует объект Phone для фотографирования:

Объект Photograph, который представляет фотографа, теперь может фотографировать, используя 
объект Phone. Однако более для фотосъемки можно использовать также и обычную фотокамеру, 
которая не обладает множеством возможностей телефона. И мы хотели бы, чтобы фотограф мог бы 
также использовать и фотокамеру для фотосъемки. В этом случае мы могли взять общий интерфейс 
IPhone и реализовать его метод TakePhoto в классе фотокамеры:

Однако здесь мы опять сталкиваемся с тем, что клиент - класс Camera зависит от методов,
которые он не использует - то есть методов Call, MakeVideo, BrowseInternet.

Для решения возникшей задачи мы можем воспользоваться принципом разделения интерфейсов:
`--> NormalEmptyMethodsExample.cs`

Для применения принципа разделения интерфейсов опять же интерфейс класса Phone разделяется на 
группы связанных методов (в данном случае получается 4 группы, в каждой по одному методу).
Затем каждая группа обертывается в отдельный интерфейс и используется самостоятельно.

