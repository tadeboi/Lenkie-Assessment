using Lenkie_Assessment.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lenkie_Assessment.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _libraryService.GetAllBooks());
        }

        [HttpGet]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _libraryService.GetBook(id);
            return book != null ? Ok(book) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ReserveBook(Guid customerId, Guid bookId)
        {
            await _libraryService.ReserveBook(customerId, bookId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> BorrowBook(Guid customerId, Guid bookId, DateTime borrowedUntil)
        {
            await _libraryService.BorrowBook(customerId, bookId, borrowedUntil);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(Guid bookId)
        {
            await _libraryService.ReturnBook(bookId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> NotifyWhenAvailable(Guid customerId, Guid bookId)
        {
            await _libraryService.NotifyWhenAvailable(customerId, bookId);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> NotificationsForAvailableBooksByCustomerId(Guid customerId)
        {
            return Ok(await _libraryService.NotificationsForAvailableBooksByCustomerId(customerId));
        }
    }
}
