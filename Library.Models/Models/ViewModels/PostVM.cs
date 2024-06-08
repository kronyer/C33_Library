﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Models.ViewModels
{
    public class PostVM
    {
        public Post Post { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoriesList { get; set; }
    }
}