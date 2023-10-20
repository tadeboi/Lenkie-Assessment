using Lenkie_Assessment.Domain;

namespace Lenkie_Assessment.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Task<string> AddNotification(Notification notification);
        Task<IEnumerable<Notification>> GetNotificationsForBook(Guid bookId);
        Task IsAvailable(Guid bookId);
        Task NotCurrentlyAvailable(Guid bookId);
        Task<IEnumerable<Notification>> NotificationsForAvailableBooksByCustomerId(Guid customerId);
    }
}
