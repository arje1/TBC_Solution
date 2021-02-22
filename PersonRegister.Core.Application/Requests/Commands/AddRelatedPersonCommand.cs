using FluentValidation;
using MediatR;
using PersonRegister.Core.Application.Interfaces;
using PersonRegister.Core.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Commands
{
    public class AddRelatedPersonRequest : IRequest
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public PersonRelationType RelationType { get; set; }
    }

    public class AddRelatedPersonCommand : IRequestHandler<AddRelatedPersonRequest>
    {
        IUnitOfPersonRegister unit;
        public AddRelatedPersonCommand(IUnitOfPersonRegister unit) => this.unit = unit;

        public Task<Unit> Handle(AddRelatedPersonRequest request, CancellationToken cancellationToken)
        {
            unit.PersonRepository.AddRelatedPerson(request.PersonId, request.RelatedPersonId, request.RelationType);
            return Unit.Task;
        }
    }

    public class AddRelatedPersonValidator : AbstractValidator<AddRelatedPersonRequest>
    {
        IUnitOfPersonRegister unit;
        public AddRelatedPersonValidator(IUnitOfPersonRegister unit)
        {
            this.unit = unit;
            RuleFor(x => x.PersonId).Must(x => unit.PersonRepository.Exists(x)).WithMessage("მოცემული PersonId არ არსებობს.");
            RuleFor(x => x.RelatedPersonId).Must(x => unit.PersonRepository.Exists(x)).WithMessage("მოცემული RelatedPersonId არ არსებობს.");

        }
    }
}
