using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Book : BaseEntity
    {
        public  long Id { set; get; }

        [MaxLength(100)]
        public  string title { set; get; }

        [MaxLength(100)]
        public string author { set; get; }
        public  Guid ISBN { set; get; }
        public BookStatus Status{ set; get; }
    }
}
