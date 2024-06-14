using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public int BookId { get; set; }
    [ForeignKey("BookId")]
    [ValidateNever]
    public Book Book { get; set; }
    public int Count { get; set; }
    public string ApplicationUserId { get; set; }
    [ForeignKey("ApplicationUserId")]
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }
    [NotMapped]
    public double Price { get; set; }
}
