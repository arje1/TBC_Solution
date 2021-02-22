using PersonRegister.Core.Application.RequestsHelper.DTOs.Reports;
using System.Collections.Generic;

namespace PersonRegister.Core.Application.Interfaces.Reports
{
    public interface IPersonReport
    {
        IEnumerable<PersonRelationAmountsDTO> GetPersonRelationAmounts();

    }
}
