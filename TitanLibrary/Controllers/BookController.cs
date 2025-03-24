using Database.Model;
using Logic;
using Logic.Model;
using Logic.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TitanLibrary.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet(Name = "List")]
        public async Task<IActionResult> Get(string? Search = "")
        {
            var result = await bookService.GetAllBooks(Search);
            return new OkObjectResult(new Response<List<BookRowResponse>>
            {
                Data = result
            });
        }

        [HttpPost("Borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowBookRequest Model)
        {
            await bookService.BorrowBook(Model);
            return new  OkResult ();
        }


        [HttpPost("Return")]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnBookRequest Model)
        {
            await bookService.ReturnBook(Model);
            return new OkResult();
        }

        [HttpGet("Borrow/List")]
        public async Task<IActionResult> GetBorrowList()
        {
            var result = await bookService.GetBorrowList();
            return new OkObjectResult(new Response<List<GetBorrowRecordsInfoSP>>
            {
                Data = result
            });
        }
    }
}
