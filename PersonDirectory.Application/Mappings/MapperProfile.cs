using AutoMapper;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.Features.People.Commands;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;

namespace PersonDirectory.Application.Mappings
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<PhoneNumberDTO, PhoneNumber>();

            CreateMap<AddPersonCommand, Person>();

            //CreateMap<UpdatePersonRequest, Person>();

            //CreateMap<AddNewRelatedPersonRequest, Person>()
            //    .ForMember(entity => entity.FirstName, opt => opt.MapFrom(dto => dto.RelatedPerson.FirstName))
            //    .ForMember(entity => entity.LastName, opt => opt.MapFrom(dto => dto.RelatedPerson.LastName))
            //    .ForMember(entity => entity.Gender, opt => opt.MapFrom(dto => dto.RelatedPerson.Gender))
            //    .ForMember(entity => entity.PrivateNumber, opt => opt.MapFrom(dto => dto.RelatedPerson.PrivateNumber))
            //    .ForMember(entity => entity.BirthDate, opt => opt.MapFrom(dto => dto.RelatedPerson.BirthDate))
            //    .ForMember(entity => entity.CityId, opt => opt.MapFrom(dto => dto.RelatedPerson.CityId))
            //    .ForMember(entity => entity.PhoneNumbers, opt => opt.MapFrom(dto => dto.RelatedPerson.PhoneNumbers))
            //    .ForMember(entity => entity.Id, opt => opt.Ignore())
            //    .ForMember(entity => entity.RelatedPeople, opt => opt.Ignore())
            //    .ForMember(entity => entity.City, opt => opt.Ignore())
            //    .ForMember(entity => entity.PhotoPath, opt => opt.Ignore());

            CreateMap<Person, GetPersonDTO>()
                .ForMember(dto => dto.City, opt => opt.MapFrom(entity => entity.City.Name))
                .ForMember(dto => dto.RelatedPeople, opt => opt.MapFrom(entity => entity.Relations));

            CreateMap<PhoneNumber, PhoneNumberDTO>();

            CreateMap<PersonRelation, RelatedPersonDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.RelatedPerson.Id))
                .ForMember(dto => dto.PrivateNumber, opt => opt.MapFrom(entity => entity.RelatedPerson.PrivateNumber))
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(entity => entity.RelatedPerson.FirstName))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(entity => entity.RelatedPerson.LastName))
                .ForMember(dto => dto.Gender, opt => opt.MapFrom(entity => entity.RelatedPerson.Gender))
                .ForMember(dto => dto.CityId, opt => opt.MapFrom(entity => entity.RelatedPerson.CityId))
                .ForMember(dto => dto.City, opt => opt.MapFrom(entity => entity.RelatedPerson.City.Name))
                .ForMember(dto => dto.BirthDate, opt => opt.MapFrom(entity => entity.RelatedPerson.BirthDate))
                .ForMember(dto => dto.PicturePath, opt => opt.MapFrom(entity => entity.RelatedPerson.PicturePath))
                .ForMember(dto => dto.PhoneNumbers, opt => opt.MapFrom(entity => entity.RelatedPerson.PhoneNumbers));


        }
    }
}
