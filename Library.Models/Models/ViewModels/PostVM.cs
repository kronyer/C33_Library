using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Models.Models.ViewModels;

public class PostVM
{
    public Post Post { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CategoriesList { get; set; }
}
