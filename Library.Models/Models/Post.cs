using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<PostCategory> Category { get; set; }
        public int MyProperty { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
