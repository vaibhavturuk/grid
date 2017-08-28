using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vaibhavgrid.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public String BookName { get; set; }
        public int AuthorId { get; set; }
    }
}