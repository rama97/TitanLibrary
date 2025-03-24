namespace Database.Model
{
    public class GetBorrowRecordsInfoSP
    {
        public long Id { set; get; }
        public bool IsReturned { set; get; }
        public DateTime? ReturnDate { set; get; }
        public string Author { set; get; }
        public long BookId { set; get; }
        public string Title { set; get; }
        public int BookStatus { set; get; }
        public long UserId { set; get; }
        public string username { set; get; }
        public DateTime CreatedAt { set; get; }


    }
}