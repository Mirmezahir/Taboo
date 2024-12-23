using FluentValidation;
using Taboo.DTOs;

namespace Taboo.Validators.Language
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Code Bos Ola Bilmez")
                .NotNull()
                  .WithMessage("Code Null Ola Bilmez")
                .Length(2);
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ad Bos Ola Bilmez")
                 .NotNull()
                  .WithMessage("Ad Null Ola Bilmez")
                  .MaximumLength(32);
            RuleFor(x => x.Icon)
                    .NotEmpty()
            .WithMessage("Icon Bos Ola Bilmez")
             .NotNull()
              .WithMessage("Icon Null Ola Bilmez")
              .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
              .WithMessage("Icon link olmalidir");




        }
    }
}
