using MediatR;
using PersonRegister.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Commands
{
    public class DeleteRelatedPersonRequest : IRequest
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
    }

    public class DeleteRelatedPersonHandler : IRequestHandler<DeleteRelatedPersonRequest>
    {
        IUnitOfPersonRegister unit;
        public DeleteRelatedPersonHandler(IUnitOfPersonRegister unit) => this.unit = unit;
        public Task<Unit> Handle(DeleteRelatedPersonRequest request, CancellationToken cancellationToken)
        {
            unit.PersonRepository.DeleteRelatedPerson(request.PersonId, request.RelatedPersonId);
            return Unit.Task;
        }
    }
}
