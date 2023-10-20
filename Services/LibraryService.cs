using Lenkie_Assessment.Domain;
using Lenkie_Assessment.Repositories.Interfaces;
using Lenkie_Assessment.Services.Interfaces;

namespace Lenkie_Assessment.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IBookRepository _bookRepository;
        private readonly INotificationRepository _notificationRepository;

        public LibraryService(
            IBookRepository bookRepository,
            INotificationRepository notificationRepository)
        {
            _bookRepository = bookRepository;
            _notificationRepository = notificationRepository;
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await _bookRepository.GetBook(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetBooks();
        }

        public async Task<string> ReserveBook(Guid customerId, Guid bookId)
        {
            var book = await _bookRepository.GetBook(bookId);

            if (book.IsReserved)
                throw new Exception("Book is already reserved");

            if (book.BorrowedByCustomerId != null)
            {
                var returnDate = book.BorrowedUntil;
                throw new Exception($"Book is borrowed until {returnDate}");
            }

            var result = await _bookRepository.ReserveBook(bookId, customerId, DateTime.Now.AddHours(24));
            return result;
        }

        public async Task<string> BorrowBook(Guid customerId, Guid bookId, DateTime borrowedUntil)
        {
            var book = await _bookRepository.GetBook(bookId);

            if (book.IsReserved &&
                book.ReservedUntil > DateTime.Now &&
                book.ReservedByCustomerId != customerId)
            {
                throw new Exception("Book is already reserved by someone else");
            }

            var result = await _bookRepository.BorrowBook(bookId, customerId, borrowedUntil);
            await _notificationRepository.NotCurrentlyAvailable(bookId);

            return result;
        }

        public async Task<string> ReturnBook(Guid bookId)
        {
            var result = await _bookRepository.ReturnBook(bookId);
            await _notificationRepository.IsAvailable(bookId);

            return result;
        }

        public async Task<string> NotifyWhenAvailable(Guid customerId, Guid bookId)
        {
            var notification = new Notification()
            {
                BookId = bookId,
                CustomerId = customerId,
                IsAvailable = false
            };

            var result = await _notificationRepository.AddNotification(notification);

            return result;
        }

        public async Task<IEnumerable<Notification>> NotificationsForAvailableBooksByCustomerId(Guid customerId)
        {
            var notifications = await _notificationRepository.NotificationsForAvailableBooksByCustomerId(customerId);
            return notifications;
        }
    }

}
