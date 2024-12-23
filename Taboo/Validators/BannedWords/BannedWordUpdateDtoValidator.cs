using FluentValidation;
using Taboo.DTOs.BannedWordDTO;

namespace Taboo.Validators.BannedWords
{
    public class BannedWordUpdateDtoValidator : AbstractValidator<BannedWordUpdateDto>
    {
        public BannedWordUpdateDtoValidator()
        {
            RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Text Bos Ola Bilmez")
            .NotNull()
            .WithMessage("Text Null Ola Bilmez")
            .MaximumLength(32);
            RuleFor(x => x.WordId)
                .NotEmpty()
                .WithMessage("WordId Bos Ola Bilmez")
                .NotNull()
                .WithMessage("WordId Null Ola Bilmez");
        }
    }
}
