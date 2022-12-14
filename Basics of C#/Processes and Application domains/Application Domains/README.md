# Домены приложений
При запуске приложения, написанного на C#, операционная система создает процесс, а среда CLR создает внутри этого процесса логический контейнер, который называется доменом приложения и внутри которого работает запущенное приложение.

Для управления домена платформа .NET предоставляет класс AppDomain. Рассмотрим некоторые основные методы и свойства данного класса:
- Свойство BaseDirectory: базовый каталог, который используется для получения сборок (как правило, каталог самого приложения)
- Свойство CurrentDomain: домен текущего приложения
- Свойство FriendlyName: имя домена приложения
- Свойство SetupInformation: представляет объект AppDomainSetup и хранит конфигурацию домена приложения
- Метод ExecuteAssembly(): запускает сборку exe в рамках текущего домена приложения
- Метод GetAssemblies(): получает набор сборок .NET, загруженных в домен приложения

