using FluentValidation;
using GameHall.Model;

namespace GameHall.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Tipo)
                .NotEmpty();
        }
    }
}
