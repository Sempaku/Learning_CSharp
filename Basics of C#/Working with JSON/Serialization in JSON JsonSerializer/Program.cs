using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
//Основная функциональность по работе с JSON сосредоточена в пространстве имен System.Text.Json.
//Ключевым типом является класс JsonSerializer, который и позволяет сериализовать объект в json и,
//наоборот, десериализовать код json в объект C#.

//Для сохранения объекта в json в классе JsonSerializer определен статический метод Serialize()
//и его асинхронный двойник SerializeAsyc(), которые имеют ряд перегруженных версий. 

namespace Сериализация_в_JSON_JsonSerializer
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Person tom = new Person("Tom", 33);
            string json = JsonSerializer.Serialize(tom);

            Console.WriteLine(json);
            Person restoredPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(restoredPerson?.Name);

            //_______________________________________________________________

            //Запись и чтение файла json

            using (FileStream fs = new FileStream(@"C:\Users\79172\Desktop\user.json", FileMode.OpenOrCreate))
            {
                Person pers = new Person("Semyon", 19);
                await JsonSerializer.SerializeAsync<Person>(fs, pers);
                Console.WriteLine($"Data has been saved to file {fs.Name}");
            }
            using (FileStream fs = new FileStream(@"C:\Users\79172\Desktop\user.json", FileMode.OpenOrCreate))
            {
                Person? pers = await JsonSerializer.DeserializeAsync<Person>(fs);
                Console.WriteLine($"{pers?.Name} - {pers?.Age}");
            }

            Console.WriteLine("______________________");

            //_________________________________________________________________

            //Настройка сериализации с помощью JsonSerializerOptions

            Person kate = new Person("Kate", 23);

            var optionsJSON = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string kateJson = JsonSerializer.Serialize<Person>(kate, optionsJSON);
            Console.WriteLine(kateJson);
            Person? restoredKateFromJson = JsonSerializer.Deserialize<Person>(kateJson);
            Console.WriteLine(restoredKateFromJson.Name);

            Console.WriteLine("_________________________________");
            //______________________________________________________________________
            //
            //Настройка сериализации с помощью атрибутов

            PersonWithAttribute ignHarry = new PersonWithAttribute("Harry", 66);
            string jsonHarry = JsonSerializer.Serialize(ignHarry);
            Console.WriteLine(jsonHarry);
            PersonWithAttribute? restoreHarry = JsonSerializer.Deserialize<PersonWithAttribute>(jsonHarry);
            Console.WriteLine($"{restoreHarry?.Name} - {restoreHarry?.Age}");

        }//______________________________________________________________________


    }
    class PersonWithAttribute
    {
        [JsonPropertyName("FirstName")]
        public string Name { get; set; }
        [JsonIgnore]
        public int Age { get; set; }
        public PersonWithAttribute(string name, int age)
        {
            Name = name; Age = age;
        }
        public PersonWithAttribute()
        {

        }

    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(  string name, int age)
        {
            Name = name; Age = age;
        }
        public Person()
        {

        }
        
        
    }
}
