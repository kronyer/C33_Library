using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Models
{
    public class Book
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public List<BookCategory> Category { get; set; }
        [ValidateNever]
        public List<BookImage> BookImages { get; set; }

    }
}
