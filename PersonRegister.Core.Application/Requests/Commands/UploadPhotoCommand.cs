using MediatR;
using Microsoft.AspNetCore.Http;
using PersonRegister.Core.Application.Interfaces;
using PersonRegister.Core.Application.Interfaces.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.Core.Application.Requests.Commands
{
    public class UploadPhotoRequest : IRequest
    {
        public int PersonId { get; set; }
        public IFormFile File { get; set; }

    }

    public class UploadPhotoHandler : IRequestHandler<UploadPhotoRequest>
    {
        private readonly IFileService fileService;
        private readonly IUnitOfPersonRegister unit;

        public UploadPhotoHandler(IFileService fileService, IUnitOfPersonRegister unit) => (this.fileService, this.unit) = (fileService, unit);

        public Task<Unit> Handle(UploadPhotoRequest request, CancellationToken cancellationToken)
        {           
            var fileIdentifier = Guid.NewGuid();
            var fileName = $"{fileIdentifier}{fileService.GetExtension(request.File.FileName)}";

            var person = unit.PersonRepository.GetById(request.PersonId);
            person.PhotoPath = fileName;
            unit.PersonRepository.Update(person);

            fileService.UploadPhoto(request.File, fileName);

            return Unit.Task;
        }

       
    }

    


}
