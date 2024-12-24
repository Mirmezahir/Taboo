using FluentValidation;
using Taboo.DTOs.WordDTO;

namespace Taboo.Validators.Word
{
    public class WordCreateDtoValidator:AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
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
            RuleForEach(x => x.BannedWords)
                .Length(2);
            RuleFor(x => x.BannedWords)
                .Must(x=> x.Count==6)
                .WithMessage("There is must be 6 Banned Word");    
        }
    }
}
