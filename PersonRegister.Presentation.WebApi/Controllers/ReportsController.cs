using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonRegister.Core.Application.Requests.Queries.Reports;

namespace PersonRegister.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly IMediator mediator;
        public ReportsController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// აბრუნებს დაკავშირებული პირების რაოდენობას ფიზიკური პირებისთვის კავშირის ტიპის მიხედვით.
        /// </summary>
        /// <returns></returns>
        [HttpGet("PeopleRelationAmounts")]
        public IActionResult GetPeopleRelations()
        {
            var request = new GetPeopleRelationAmountsRequest();
            return Ok(mediator.Send(request).Result);
        }
    }
}
