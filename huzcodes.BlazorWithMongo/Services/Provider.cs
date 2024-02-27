using huzcodes.BlazorWithMongo.Models;

namespace huzcodes.BlazorWithMongo.Services
{
    public class Provider(BooksService booksService) : IProvider
    {
        private readonly BooksService _booksService = booksService;
        public async ValueTask Create(int currentCount)
        {
            var oBook = new Book();
            oBook.Author = $"Author {currentCount}";
            oBook.Price = currentCount * 10;
            oBook.Category = $"Category {currentCount}";
            oBook.BookName = $"BookName {currentCount}";
            await _booksService.CreateAsync(oBook);
        }
    }
}
