namespace Database.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { set; get; }


        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
