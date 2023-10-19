using Lenkie_Assessment.Domain;
using Lenkie_Assessment.Infrastructure;
using Lenkie_Assessment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lenkie_Assessment.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBook(Guid id)
        {
            var result = await _context.Books.FindAsync(id);
            if (result == null) throw new Exception($"Book with id: {id} does not exist");
            return result;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task ReserveBook(Guid bookId, Guid customerId, DateTime reservedUntil)
        {
            var book = await _context.Books.FindAsync(bookId);
            book.IsReserved = true;
            book.ReservedUntil = reservedUntil;
            book.ReservedByCustomerId = customerId;

            await _context.SaveChangesAsync();
        }

        public async Task BorrowBook(Guid bookId, Guid customerId, DateTime borrowedUntil)
        {
            var book = await _context.Books.FindAsync(bookId);

            book.IsReserved = false;
            book.ReservedUntil = null;
            book.ReservedByCustomerId = null;

            book.BorrowedByCustomerId = customerId;
            book.BorrowedUntil = borrowedUntil;

            await _context.SaveChangesAsync();
        }

        public async Task ReturnBook(Guid bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            book.BorrowedByCustomerId = null;
            book.BorrowedUntil = null;

            await _context.SaveChangesAsync();
        }

    }

}
