using PersonRegister.Core.Application.RequestsParameter.Filtering;
using PersonRegister.Core.Application.RequestsParameter.Paging;
using PersonRegister.Core.Domain.Models;
using System.Linq;

namespace PersonRegister.Infrastructure.Database.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> TakePage<T>(this IQueryable<T> source, PageRequest pageRequest, out PageResponse pageResponse)
        {
            if (pageRequest == null)
            {
                pageRequest = new PageRequest();
            }

            var ResultQuerable = source.Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize)
                                       .Take(pageRequest.PageSize);

            pageResponse = new PageResponse
            {
                CurrentPage = pageRequest.PageNumber,
                PageSize = pageRequest.PageSize,
                TotalCount = source.Count()
            };

            return ResultQuerable;
        }


        public static IQueryable<Person> ApplyFilterParameters(this IQueryable<Person> source, PeopleFilter peopleFilter)
        {

            if (peopleFilter == null)
            {
                return source;
            }

            if (!string.IsNullOrEmpty(peopleFilter.FirstName?.Trim()))
            {
                source = source.Where(x => x.FirstName.StartsWith(peopleFilter.FirstName));
            }

            if (!string.IsNullOrEmpty(peopleFilter.LastName?.Trim()))
            {
                source = source.Where(x => x.LastName.StartsWith(peopleFilter.LastName));
            }

            if (!string.IsNullOrEmpty(peopleFilter.Pn?.Trim()))
            {
                source = source.Where(x => x.Pn.StartsWith(peopleFilter.Pn));
            }

            if (peopleFilter.BirthDate.HasValue)
            {
                source = source.Where(x => x.BirthDate.Date == peopleFilter.BirthDate.Value.Date);
            }

            if (peopleFilter.CityId > 0)
            {
                source = source.Where(x => x.CityId == peopleFilter.CityId);
            }

            if (peopleFilter.HasPhoto.HasValue)
            {
                if (peopleFilter.HasPhoto.Value)
                {
                    source = source.Where(x => (x.PhotoPath == null || x.PhotoPath == ""));
                }
                else
                {
                    source = source.Where(x => !(x.PhotoPath == null || x.PhotoPath == ""));
                }

            }

            if (!string.IsNullOrEmpty(peopleFilter.City?.Trim()))
            {
                source = source
                    .Where(x => x.City.Name.StartsWith(peopleFilter.City));
            }

            if (!string.IsNullOrEmpty(peopleFilter.RelatedPersonFirstName?.Trim()))
            {
                source = source
                    .Where(r => r.RelatedPeople.Any(x => x.RelatedPerson.FirstName.StartsWith(peopleFilter.RelatedPersonFirstName)));
            }

            if (!string.IsNullOrEmpty(peopleFilter.RelatedPersonLastName?.Trim()))
            {
                source = source
                    .Where(r => r.RelatedPeople.Any(x => x.RelatedPerson.LastName.StartsWith(peopleFilter.RelatedPersonLastName)));
            }

            if (!string.IsNullOrEmpty(peopleFilter.RelatedPersonPn?.Trim()))
            {
                source = source
                    .Where(r => r.RelatedPeople.Any(x => x.RelatedPerson.Pn.StartsWith(peopleFilter.RelatedPersonPn)));
            }

            return source;
        }
    }
}
