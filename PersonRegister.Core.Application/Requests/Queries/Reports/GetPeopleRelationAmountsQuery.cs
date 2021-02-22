using MediatR;
using PersonRegister.Core.Application.Interfaces;
using PersonRegister.Core.Application.RequestsHelper.DTOs.Reports;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Queries.Reports
{
    public class GetPeopleRelationAmountsRequest : IRequest<IEnumerable<PersonRelationAmountsDTO>>
    {
        public GetPeopleRelationAmountsRequest()
        {

        }
    }

    public class GetPeopleRelationAmountsHandler : IRequestHandler<GetPeopleRelationAmountsRequest, IEnumerable<PersonRelationAmountsDTO>>
    {
        IUnitOfPersonRegister unit;
        public GetPeopleRelationAmountsHandler(IUnitOfPersonRegister unit) => this.unit = unit;

        public Task<IEnumerable<PersonRelationAmountsDTO>> Handle(GetPeopleRelationAmountsRequest request, CancellationToken cancellationToken)
        {
            var result = unit.PersonReport.GetPersonRelationAmounts();
            return Task.Run(() => result);
        }

     
    }
}
