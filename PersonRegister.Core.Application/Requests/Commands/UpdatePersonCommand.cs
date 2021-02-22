using AutoMapper;
using FluentValidation;
using MediatR;
using PersonRegister.Core.Application.Interfaces;
using PersonRegister.Core.Application.RequestsHelper.Attributes;
using PersonRegister.Core.Application.RequestsHelper.DTOs;
using PersonRegister.Core.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Commands
{
    public class UpdatePersonRequest : SetPersonDTO, IRequest
    {
        public int Id { get; set; }

    }

    public class UpdatePersonHandler : IRequestHandler<UpdatePersonRequest>
    {
        private readonly IUnitOfPersonRegister unit;
        private readonly IMapper mapper;

        public UpdatePersonHandler(IUnitOfPersonRegister unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
        public Task<Unit> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            var person = mapper.Map<Person>(request);
            unit.PersonRepository.Update(person);
            return Unit.Task;
        }
    }

    public class UpdatePersonValidator : AbstractValidator<UpdatePersonRequest>
    {
        IUnitOfPersonRegister unit;
        public UpdatePersonValidator(IUnitOfPersonRegister unit)
        {
            this.unit = unit;
            RuleFor(x => x.Id).Must(x => unit.PersonRepository.Exists(x)).WithMessage("მოცემული Id-ით არ არსებობს ფიზიკური პირი.");
            RuleFor(x => x).Must(x => unit.PersonRepository.IsValidPn(x.Id, x.Pn)).WithMessage("ფიზიკური პირის პირადი ნომერი არ არის უნიკალური.");
            RuleFor(x => x.CityId).Must(x => unit.CityRepository.Exists(x)).WithMessage("მოცემული CityId არ არსებობს");
        }
    }
}
