using Lenkie_Assessment.Domain;

namespace Lenkie_Assessment.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBook(Guid id);
        Task<IEnumerable<Book>> GetBooks();
        Task ReserveBook(Guid bookId, Guid customerId, DateTime reservedUntil);
        Task BorrowBook(Guid bookId, Guid customerId, DateTime borrowedUntil);
        Task ReturnBook(Guid bookId);
    }
}
