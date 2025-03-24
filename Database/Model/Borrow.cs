using Database.Models;


namespace Database.Model
{
    public class Borrow : BaseEntity
    {
        public long Id{ set; get; }
        public long UserId { set; get; }
        public long BookId { set; get; }
        public DateTime? ReturnDate{ set; get; }
        public bool IsReturned{ set; get; }
    }
}
