using AutoMapper;
using FluentValidation;
using MediatR;
using PersonRegister.Core.Application.Interfaces;
using PersonRegister.Core.Application.RequestsHelper.DTOs;
using PersonRegister.Core.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Commands
{
    public class AddPersonRequest : SetPersonDTO, IRequest
    {

    }
    public class AddPersonHandler : IRequestHandler<AddPersonRequest>
    {
        private readonly IUnitOfPersonRegister unit;
        private readonly IMapper mapper;

        public AddPersonHandler(IUnitOfPersonRegister unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);

        public Task<Unit> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            var person = mapper.Map<Person>(request);
            unit.PersonRepository.Create(person);
            return Unit.Task;
        }
    }

    public class AddPersonValidator : AbstractValidator<AddPersonRequest>
    {
        IUnitOfPersonRegister unit;
        public AddPersonValidator(IUnitOfPersonRegister unit)
        {
            this.unit = unit;
            RuleFor(x => x.Pn).Must(x => unit.PersonRepository.IsValidPn(0, x)).WithMessage("ფიზიკური პირის პირადი ნომერი არ არის უნიკალური.");
            RuleFor(x => x.CityId).Must(x => unit.CityRepository.Exists(x)).WithMessage("მოცემული CityId არ არსებობს");
        }
    }


}
