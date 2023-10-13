using Common.Domain.Validators;
using ESCMB.Domain.Entities;
using FluentValidation;

namespace ESCMB.Domain.Validators
{
    public class ClientValidator : EntityValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Apellido).NotEmpty().NotNull().Matches(@"^[a-zA-Z]+$").WithMessage("El Apellido no puede ser nulo o vacio y solo puede contener letras");
            RuleFor(x => x.Nombre).NotEmpty().NotNull().Matches(@"^[a-zA-Z]+$").WithMessage("El Nombre no puede ser nulo o vacio y solo puede contener letras");
            RuleFor(x => x.Email).NotEmpty().NotNull().Matches(@"^(([^<>()\[\]\.,;:\s@\”]+(\.[^<>()\[\]\.,;:\s@\”]+)*)|(\”.+\”))@(([^<>()[\]\.,;:\s@\”]+\.)+[^<>()[\]\.,;:\s@\”]{2,})$").WithMessage("El correo no puede ser nulo o vacio");
            RuleFor(x=>x.CuitCuil.ToString()).Length(11).WithMessage("La longitud del número de cuil/cuit debe tener 11 caracteres.");
        }
    }
}
