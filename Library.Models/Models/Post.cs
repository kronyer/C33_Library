using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    [ValidateNever]
    public PostCategory Category { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime LastEdited { get; set; }
}
