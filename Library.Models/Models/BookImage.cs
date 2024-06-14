using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Models;

public class BookImage
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public int BookId { get; set; }
    [ForeignKey("BookId")]
    public Book Book { get; set; }
}
