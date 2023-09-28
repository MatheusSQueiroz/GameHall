using FluentValidation;
using GameHall.Model;

namespace GameHall.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(255);

            RuleFor(p => p.Console)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50);

            RuleFor(p => p.Preco)
                .NotEmpty();
        }
    }
}
