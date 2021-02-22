using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonRegister.Core.Application.Requests.Commands;
using PersonRegister.Core.Application.Requests.Queries;
using PersonRegister.Core.Application.RequestsParameter.Filtering;
using PersonRegister.Core.Application.RequestsParameter.Paging;
using PersonRegister.Presentation.WebApi.ActionFilters;

namespace PersonRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class PeopleController : Controller
    {
        private readonly IMediator mediator;
        public PeopleController(IMediator mediator) => this.mediator = mediator;

        /// <summary>
        /// ამატებს ახალ ფიზიკურ პირს.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] AddPersonRequest request)
        {

            mediator.Send(request);
            return Created("", request);
        }

        /// <summary>
        /// ანახლებს ფიზიკური პირის მონაცემებს.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePersonRequest request)
        {
            mediator.Send(request);
            return Ok();
        }

        /// <summary>
        /// შლის ფიზიკურ პირს.
        /// </summary>
        /// <param name="id">ფიზიკური პირის Id.</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var request = new DeletePersonRequest(id);
            mediator.Send(request);
            return NoContent();
        }

        /// <summary>
        /// ფიზიკური პირზე ამატებს დაკავშირებულ (ბაზაში უკვე არსებულ) პირს .
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("RelatedPerson")]
        public IActionResult AddRelatedPerson([FromBody] AddRelatedPersonRequest request)
        {
            mediator.Send(request);
            return Ok();
        }

        /// <summary>
        /// ფიზიკური პირზე ამატებს დაკავშირებულ (ახალ) პირს. მას შემდეგ რაც შექმნის ამ პირს ბაზაში.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("RelatedPerson")]
        public IActionResult AddNewRelatedPerson([FromBody] AddNewRelatedPersonRequest request)
        {
            mediator.Send(request);
            return Ok();
        }

        /// <summary>
        /// შლის დაკავშირებულ პირთან კავშირს.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("RelatedPerson")]
        public IActionResult DeleteRelatedPerson(DeleteRelatedPersonRequest request)
        {
            mediator.Send(request);
            return NoContent();
        }

        /// <summary>
        /// აბრუნებს ფიზიკურ პირს.
        /// </summary>
        /// <param name="id">ფიზიკური პირის Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var request = new GetPersonByIdRequest(id);
            return Ok(mediator.Send(request).Result);
        }

        /// <summary>
        /// აბრუნებს ფიზიკურ პირებს.
        /// </summary>
        /// <param name="peopleFilter">ფიზიკური პირის გასაფილტრი ველები</param>
        /// <param name="pageRequest">დასაბრუნებელი სიის გვერის ნომერი და გვერდის ზომა</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery] PeopleFilter peopleFilter = null,
            [FromQuery] PageRequest pageRequest = null)
        {
            var result = mediator.Send(new GetPeopleRequest(pageRequest, peopleFilter)).Result;

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.pageResponse));

            return Ok(result.people);
        }

        /// <summary>
        /// ინახავს ფიზიკური პირის ფოტოს.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UploadPhoto")]
        public IActionResult AddPhoto([FromForm] UploadPhotoRequest request)
        {
            return Ok(mediator.Send(request));
        }

    }
}
