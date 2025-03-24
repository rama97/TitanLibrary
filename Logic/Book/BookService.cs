using Repository;
using Database.Model;
using Logic.Model;
using Logic.Tools;
using Helpers;

namespace Logic
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepo;
        private readonly IRepository<Borrow> borrowRepo;
        private readonly ISPRepository<GetBorrowRecordsInfoSP> getBorrowRecordsInfoSPRepo;
        private readonly ISessionService sessionService;

        public BookService(IRepository<Book> BookRepo,IRepository<Borrow> BorrowRepo,ISPRepository<GetBorrowRecordsInfoSP> GetBorrowRecordsInfoSPRepo, ISessionService sessionService )
        {
            bookRepo = BookRepo;
            borrowRepo = BorrowRepo;
            getBorrowRecordsInfoSPRepo = GetBorrowRecordsInfoSPRepo;
            this.sessionService = sessionService;
        }

        public  async Task<List<BookRowResponse>> GetAllBooks(string Search)
        {
            var match = typeof(Book).GetProperties().Where(a => a.PropertyType == typeof(string) || a.PropertyType == typeof(Guid)).Select(a => a.Name).ToArray();

            var Result = await bookRepo.GetAll(Search, match);
            var mapper = new LogicMapper();

            return Result.Select(a => mapper.BookRowResponseMapper(a)).ToList();
        }

        public async Task BorrowBook(BorrowBookRequest model)
        {
            var Result = await bookRepo.GetById(model.BookId);
            if (Result == null)
                throw new DataNotFoundException();

            if (Result.Status == BookStatus.NotAvailable)
                throw new BadRequestException("The Book you requested is not available");

             await borrowRepo.AddAsync(new Borrow
            {
                BookId = model.BookId,
                IsReturned = false,
                UserId = sessionService.GetUserId()
            });
            Result.Status = BookStatus.NotAvailable;
            await bookRepo.Update(Result);
        }

        public async Task ReturnBook(ReturnBookRequest model)
        {
            await getBorrowRecordsInfoSPRepo.ExecuteSP("ReturnBorrowedBook", new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter ("@BorrowId",model.BorrowId)
            });
           
        }
            
        public async Task<List<GetBorrowRecordsInfoSP>> GetBorrowList()
        {
            return await getBorrowRecordsInfoSPRepo.ExecuteDataReaderSP("GetBorroWithBook",new System.Data.SqlClient.SqlParameter[] { 
            new System.Data.SqlClient.SqlParameter ("@BorrowId",DBNull.Value)
            });
        }
    }
}
