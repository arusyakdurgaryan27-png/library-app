using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis; // пространство имён для атрибутов валидации
//Нужно для [Required] и других атрибутов, которые проверяют корректность данных.
//класс для модели книги
public class Book
{
    public int Id { get; set; }// читать и записывать
    [Required(ErrorMessage="enter the book title")]//поле обязательно для заполнения
    //ErrorMessage-сообщение, которое увидит пользователь, если не заполнить поле.
    public string Title { get; set; }
    [Required(ErrorMessage = "enter the author's name")]
    public string Author { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
}
