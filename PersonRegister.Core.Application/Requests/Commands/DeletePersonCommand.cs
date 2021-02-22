using MediatR;
using PersonRegister.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Commands
{
    public class DeletePersonRequest : IRequest
    {
        public DeletePersonRequest(int id) => this.Id = id;
        public int Id { get; set; }
    }

    public class DeletePersonHandler : IRequestHandler<DeletePersonRequest>
    {
        IUnitOfPersonRegister unit;

        public DeletePersonHandler(IUnitOfPersonRegister unit) => this.unit = unit;

        public Task<Unit> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            unit.PersonRepository.Delete(request.Id);
            return Unit.Task;
        }
    }
}
