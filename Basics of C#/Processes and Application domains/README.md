# Процессы и домены приложения
При запуске приложения операционная система создает для него отдельный процесс, которому выделяется определённое адресное пространство в памяти и который изолирован от других процессов. Процесс может иметь несколько потоков. Как минимум, процесс содержит один - главный поток. В приложении на C# точкой входа в программу является метод Main. Вызов этого метода автоматически создает главный поток. А из главного потока могут запускаться вторичные потоки.

В .NET процесс представлен классом Process из пространства имен System.Diagnostics. Этот класс позволяет управлять уже запущенными процессами, а также запускать новые. В данном классе определено ряд свойств и методов, позволяющих получать информацию о процессах и управлять ими:
+ Свойство Handle: возвращает дескриптор процесса
+ Свойство Id: получает уникальный идентификатор процесса в рамках текущего сеанса ОС
+ Свойство MachineName: возвращает имя компьютера, на котором запущен процесс
+ Свойство MainModule: представляет основной модуль - исполняемый файл программы, представлен объектом типа ProcessModule
+ Свойство Modules: получает доступ к коллекции ProcessModuleCollection, которая в виде объектов ProcessModule хранит набор модулей (например, файлов dll и exe), загруженных в рамках данного процесса
+ Свойство ProcessName: возвращает имя процесса, которое нередко совпадает с именем приложения
+ Свойство StartTime: возвращает время, когда процесс был запущен
+ Свойство PageMemorySize64: возвращает объем памяти, который выделен для данного процесса
+ Свойство VirtualMemorySize64: возвращает объем виртуальной памяти, который выделен для данного процесса
+ Метод CloseMainWindow(): закрывает окно процесса, который имеет графический интерфейс
+ Метод GetProcesses(): возвращает массив всех запущенных процессов
+ Метод GetProcessesByName(): возвращает процессы по его имени. Так как можно запустить несколько копий одного приложения, то возвращает массив
+ Метод GetProcessById(): возвращает процесс по Id. Так как можно запустить несколько копий одного приложения, то возвращает массив
+ Метод Kill(): останавливает процесс
+ Метод Start(): запускает новый процесс
