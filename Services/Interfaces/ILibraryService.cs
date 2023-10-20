using Lenkie_Assessment.Domain;

namespace Lenkie_Assessment.Services.Interfaces
{
    public interface ILibraryService
    {
        Task<Book> GetBook(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<string> ReserveBook(Guid customerId, Guid bookId);
        Task<string> BorrowBook(Guid customerId, Guid bookId, DateTime borrowedUntil);
        Task<string> ReturnBook(Guid bookId);
        Task<string> NotifyWhenAvailable(Guid customerId, Guid bookId);
        Task<IEnumerable<Notification>> NotificationsForAvailableBooksByCustomerId(Guid customerId);
    }
}
