using Database.Models;
using System.ComponentModel.DataAnnotations;


namespace Database.Model
{
    public class User : BaseEntity
    { 
        [Key]
        public long Id { set; get; }

        [MaxLength(10)]
        public string username { set; get; }
    }
}
