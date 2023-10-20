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
            var response = await _libraryService.GetAllBooks();

            try
            {
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }  
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
            var response = await _libraryService.ReserveBook(customerId, bookId);

            try
            {
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> BorrowBook(Guid customerId, Guid bookId, DateTime borrowedUntil)
        {
            var response = await _libraryService.BorrowBook(customerId, bookId, borrowedUntil);

            try
            {
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(Guid bookId)
        {
            var response = await _libraryService.ReturnBook(bookId);

            try
            {
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> NotifyWhenAvailable(Guid customerId, Guid bookId)
        {
            var response = await _libraryService.NotifyWhenAvailable(customerId, bookId);

            try
            {
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> NotificationsForAvailableBooksByCustomerId(Guid customerId)
        {
            var response = await _libraryService.NotificationsForAvailableBooksByCustomerId(customerId);

            try
            {
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }
    }
}
