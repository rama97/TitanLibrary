using Database.Model;
using Logic.Model;


namespace Logic
{
    public interface IBookService
    {
        Task<List<BookRowResponse>> GetAllBooks(string Search);

        Task BorrowBook(BorrowBookRequest model);

        Task ReturnBook(ReturnBookRequest model);

        Task<List<GetBorrowRecordsInfoSP>> GetBorrowList();

    }
}
