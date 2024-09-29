using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeague.Application.Commands.Draws.Validators
{
    /// <summary>
    /// CreateDrawCommand için validasyon sınıfı
    /// </summary>
    public class CreateDrawCommandValidator : AbstractValidator<CreateDrawCommand>
    {
        public CreateDrawCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Kura çeken kişinin adı boş olamaz.")
                .MaximumLength(50).WithMessage("Kura çeken kişinin adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Kura çeken kişinin soyadı boş olamaz.")
                .MaximumLength(50).WithMessage("Kura çeken kişinin soyadı en fazla 50 karakter olabilir.");

            RuleFor(x => x.NumberOfGroups)
                .Must(x => x == 4 || x == 8).WithMessage("Grup sayısı 4 veya 8 olmalıdır.");
        }
    }
}
