using CryptoMeta.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMeta.Validators
{
    public class BlogValidator : AbstractValidator<BlogModel>
    {
        public BlogValidator()
        {
            RuleFor(c => c.BlogDescription).NotEmpty().WithMessage("Lütfen Açıklama kısmını boş geçmeyiniz.");
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage("Lütfen Kategori kısmını boş geçmeyiniz.");
            RuleFor(c => c.Title).NotEmpty().WithMessage("Lütfen Başlık kısmını boş geçmeyiniz.");
        }
    }

}
   