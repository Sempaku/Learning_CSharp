# Основы валидации модели
Фреймворк .NET предлагает гораздо более удобный функционал в виде атрибутов из пространства имен System.ComponentModel.DataAnnotations.
Итак, изменим касс User следующим образом
```C#
using System.ComponentModel.DataAnnotations;
 
public class User
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }
 
    [Range(1, 100)]
    public int Age { get; set; }
 
    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

Все правила валидации модели в System.ComponentModel.DataAnnotations определяются в виде атрибутов. В данном случае используются три атрибута: классы RequiredAttribute, StringLengthAttribute и RangeAttribute. В коде необязательно использовать суффикс Attribute, поэтому он, как правило, отбрасывается. Атрибут Required требует обзательного наличия значения. Атрибут StringLength устанавливает максимальную и минимальную длину строки, а атрибут Range устанавливает диапазон приемлемых значений
