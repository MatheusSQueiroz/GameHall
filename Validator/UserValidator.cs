using FluentValidation;
using GameHall.Model;

namespace GameHall.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(u => u.Nome)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(u => u.Usuario)
               .NotEmpty()
               .MaximumLength(255)
               .EmailAddress();

            RuleFor(u => u.Senha)
               .NotEmpty()
               .MinimumLength(8);

            RuleFor(u => u.DataNascimento)
                 .NotEmpty()
                 .Must(BeMaiorDeIdade)
                 .WithMessage("O usuário deve ter mais de 18 anos para se cadastrar.");
        }

        private bool BeMaiorDeIdade(DateOnly? dataNascimento)
        {
            // Se a data de nascimento não foi fornecida, o usuário não é maior de idade
            if (!dataNascimento.HasValue)
            {
                return false;
            }

            // Calcula a data para 18 anos atrás a partir de hoje
            var dataDezoitoAnosAtras = DateOnly.FromDateTime(DateTime.Today.AddYears(-18));

            // Se a data de nascimento é anterior a 18 anos atrás, o usuário é maior de idade
            return dataNascimento.Value <= dataDezoitoAnosAtras;
        }

    }
}
