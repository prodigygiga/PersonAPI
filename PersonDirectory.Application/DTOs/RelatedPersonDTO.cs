using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;

namespace PersonDirectory.Application.DTOs
{
    public class RelatedPersonDTO
    {
        public RelatedPersonDTO()
        {
            PhoneNumbers = new HashSet<PhoneNumberDTO>();
        }
        public RelationType RelationType { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PrivateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public string PicturePath { get; set; }
        public ICollection<PhoneNumberDTO> PhoneNumbers { get; set; }

    }
}
