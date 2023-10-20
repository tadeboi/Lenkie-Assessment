using Lenkie_Assessment.Domain;
using Lenkie_Assessment.Infrastructure;
using Lenkie_Assessment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lenkie_Assessment.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly LibraryDbContext _context;

        public NotificationRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddNotification(Notification notification)
        {
            try
            {
                _context.Notifications.Add(notification);
                await _context.SaveChangesAsync();
                return "We would Notify you when the Book is Available";
            }
            catch (Exception ex)
            {

                return $"Unable to add book for Notification: {ex.Message}";
            }
        }

        public async Task<IEnumerable<Notification>> GetNotificationsForBook(Guid bookId)
        {
            return await _context.Notifications.Where(n => n.BookId == bookId).ToListAsync();
        }

        public async Task IsAvailable(Guid bookId)
        {
            var notifications = await _context.Notifications.Where(n => n.BookId == bookId).ToListAsync();

            foreach(var notification in notifications)
            {
                notification.IsAvailable = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task NotCurrentlyAvailable(Guid bookId)
        {
            var notifications = await _context.Notifications.Where(n => n.BookId == bookId).ToListAsync();

            foreach (var notification in notifications)
            {
                notification.IsAvailable = false;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notification>> NotificationsForAvailableBooksByCustomerId(Guid customerId)
        {
            var notifications = await _context.Notifications.Where(n => n.CustomerId == customerId && n.IsAvailable == true).ToListAsync();
            return notifications;
        }
    }
}
