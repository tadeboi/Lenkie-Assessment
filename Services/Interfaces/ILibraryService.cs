using Lenkie_Assessment.Domain;

namespace Lenkie_Assessment.Services.Interfaces
{
    public interface ILibraryService
    {
        Task<Book> GetBook(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task ReserveBook(Guid customerId, Guid bookId);
        Task BorrowBook(Guid customerId, Guid bookId, DateTime borrowedUntil);
        Task ReturnBook(Guid bookId);
        Task NotifyWhenAvailable(Guid customerId, Guid bookId);
        Task<IEnumerable<Notification>> NotificationsForAvailableBooksByCustomerId(Guid customerId);
    }
}
