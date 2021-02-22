using PersonRegister.Core.Application.Interfaces.Reports;
using PersonRegister.Core.Application.RequestsHelper.DTOs.Reports;
using System.Collections.Generic;
using System.Linq;

namespace PersonRegister.Infrastructure.Database.Implementations.Reports
{
    internal class PersonReport : IPersonReport
    {
        private readonly PersonRegister_DbContext context;
        public PersonReport(PersonRegister_DbContext context) => this.context = context;
        public IEnumerable<PersonRelationAmountsDTO> GetPersonRelationAmounts() =>
                (from p in context.People
                 join r in context.PersonRelations
                 on p.Id equals r.PersonId
                 group r by new { p.Id, p.FirstName, p.LastName, p.Pn, r.RelationType }
                into gr
                 select new PersonRelationAmountsDTO
                 {
                     Id = gr.Key.Id,
                     FirstName = gr.Key.FirstName,
                     LastName = gr.Key.LastName,
                     Pn = gr.Key.Pn,
                     RelationType = gr.Key.RelationType,
                     RelatedPeopleAmount = gr.Count()
                 }).ToList();




    }
}
