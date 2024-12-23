using FluentValidation;
using Taboo.DTOs.WordDTO;

namespace Taboo.Validators.Word
{
    public class WordUpdateDtoValidator:AbstractValidator<WordCreateDto>
    {
        public WordUpdateDtoValidator() {
            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Text Bos Ola Bilmez")
                .NotNull()
                .WithMessage("Text Null Ola Bilmez")
                .MaximumLength(32);
            RuleFor(x => x.LanguageCode)
                .NotEmpty()
                .WithMessage("LanguageCode Bos Ola Bilmez")
                .NotNull()
                .WithMessage("LanguageCode Null Ola Bilmez")
                .Length(2);
        }
    }
}
