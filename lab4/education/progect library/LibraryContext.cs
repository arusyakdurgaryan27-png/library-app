using Microsoft.EntityFrameworkCore;// EF Core для работы с базой
using System.Collections.Generic;

public class LibraryContext : DbContext
    //используем наследование от dbcontextЮчтобы создать класс контекста бд
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options) { }
    //Конструктор, который принимает настройки бд (options) и передаёт их в базовый класс DbContext.
    public DbSet<Book> Books { get; set; }
    //DbSet<Book> таблица бд,через которую добавляем ,удаляем и получаем книжки
}
