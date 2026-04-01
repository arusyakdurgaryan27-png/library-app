using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
//пространство имён для контроллеров и работы с бд
public class BooksController : Controller
{ //контроллер для работы с книгами,наследуя от контролле
    private readonly LibraryContext _context;
    //не будет отображаться,лишь нужен для хранения контекста ,чтобы было удобно работать с книгами
    public BooksController(LibraryContext context)
    {
        _context = context;
    }
    //Конструктор контроллера.EF Core автоматически передаст контекст базы при создании контроллера
    public async Task<IActionResult> Index()//асинхронный метод, возвращает страницу (View)
    {//берём все книги из базы в виде списка
        return View(await _context.Books.ToListAsync());
    }//передаём список книг в Razor Page Index.cshtml
    public IActionResult Create() => View();//+новая книга
    //метод гет,который показывает пустую форму для добавления
    //обработка формы
    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        if (ModelState.IsValid)//проверка,что обязательные поля заполнены
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));//Перенаправляем на список книг
        }
        return View(book);//если данные некорректны, возвращаем форму с введёнными данными
    }
    public async Task<IActionResult> Edit(int id)//форма редактирования книги
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();
        return View(book);//передаем книгу в форму редактриования
    }
    //обработка изменений
    public async Task<IActionResult> Edit(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));//перенаправление на список
        }
        return View(book);
    }
    //удаление книги
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);//ищем книгу по ацди
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));// к списку
    }
}
    