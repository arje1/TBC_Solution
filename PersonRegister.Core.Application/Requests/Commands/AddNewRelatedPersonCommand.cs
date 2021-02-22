using AutoMapper;
using FluentValidation;
using MediatR;
using PersonRegister.Core.Application.Interfaces;
using PersonRegister.Core.Application.RequestsHelper.DTOs;
using PersonRegister.Core.Domain.Enums;
using PersonRegister.Core.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Commands
{
    public class AddNewRelatedPersonRequest : IRequest
    {
        public int PersonId { get; set; }
        public PersonRelationType RelationType { get; set; }
        public SetPersonDTO RelatedPerson { get; set; }

    }

    public class AddNewRelatedPersonHandler : IRequestHandler<AddNewRelatedPersonRequest>
    {
        IUnitOfPersonRegister unit;
        IMapper mapper;

        public AddNewRelatedPersonHandler(IUnitOfPersonRegister unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
        public Task<Unit> Handle(AddNewRelatedPersonRequest request, CancellationToken cancellationToken)
        {
            var newRelatedPerson = mapper.Map<Person>(request);
            unit.PersonRepository.AddRelatedPerson(request.PersonId, newRelatedPerson, request.RelationType);
            return Unit.Task;
        }
    }

    public class AddNewRelatedPersonValidator : AbstractValidator<AddNewRelatedPersonRequest>
    {
        IUnitOfPersonRegister unit;
        public AddNewRelatedPersonValidator(IUnitOfPersonRegister unit)
        {
            this.unit = unit;
            RuleFor(x => x.PersonId).Must(x => unit.PersonRepository.Exists(x)).WithMessage("მოცემული Person.Id არ არსებობს");
            RuleFor(x => x.RelatedPerson.Pn).Must(x => unit.PersonRepository.IsValidPn(0, x)).WithMessage("დაკავშირებული პირის პირადი ნომერი არ არის უნიკალური");
            RuleFor(x => x.RelatedPerson.CityId).Must(x => unit.CityRepository.Exists(x)).WithMessage("მოცემული RelatedPerson.CityId არ არსებობს");
        }
    }


}
