using AutoMapper;
using MediatR;
using PersonRegister.Core.Application.Interfaces;
using PersonRegister.Core.Application.RequestsHelper.DTOs;
using PersonRegister.Core.Application.RequestsParameter.Filtering;
using PersonRegister.Core.Application.RequestsParameter.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Queries
{
    public class GetPeopleRequest : IRequest<(IEnumerable<GetPersonDTO> people, PageResponse pageResponse)>
    {
        public PageRequest PageRequest;
        public PeopleFilter PeopleFilter;


        public GetPeopleRequest(PageRequest pageRequest, PeopleFilter peopleFilter) =>
                                (this.PageRequest, this.PeopleFilter) = (pageRequest, peopleFilter);

    }

    public class GetPeopleHandler : IRequestHandler<GetPeopleRequest, (IEnumerable<GetPersonDTO> people, PageResponse pageResponse)>
    {
        IUnitOfPersonRegister unit;
        IMapper mapper;
        public GetPeopleHandler(IUnitOfPersonRegister unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
        Task<(IEnumerable<GetPersonDTO> people, PageResponse pageResponse)> IRequestHandler<GetPeopleRequest, (IEnumerable<GetPersonDTO> people, PageResponse pageResponse)>.Handle(GetPeopleRequest request, CancellationToken cancellationToken)
        {
            var people = unit.PersonRepository.GetAll(request.PageRequest, out PageResponse pageResponse, request.PeopleFilter);
            var peopleDto = (IEnumerable<GetPersonDTO>)people.Select(x => mapper.Map<GetPersonDTO>(x)).ToList();
            return Task.Run(() => (peopleDto, pageResponse));
        }
    }
}
