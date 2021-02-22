using AutoMapper;
using MediatR;
using PersonRegister.Core.Application.Interfaces;
using PersonRegister.Core.Application.RequestsHelper.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Queries
{
    public class GetPersonByIdRequest : IRequest<GetPersonDTO>
    {
        public int Id { get; set; }
        public GetPersonByIdRequest(int id) => this.Id = id;
    }

    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdRequest, GetPersonDTO>
    {
        IUnitOfPersonRegister unit;
        IMapper mapper;

        public GetPersonByIdHandler(IUnitOfPersonRegister unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
        public Task<GetPersonDTO> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
        {
            var person = unit.PersonRepository.GetById(request.Id);
            var personDto = mapper.Map<GetPersonDTO>(person);
            return Task.Run(() => personDto);
        }
    }
}
