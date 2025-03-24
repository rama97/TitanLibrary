using Database.Model;

namespace Logic.Model
{
    public class BookRowResponse
    {
        public long Id { set; get; }

        public string title { set; get; }

        public string author { set; get; }
        public BookStatus Status { set; get; }
    }
}
