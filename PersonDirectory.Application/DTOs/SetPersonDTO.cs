using PersonDirectory.Application.DTOs.Attributes;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectory.Application.DTOs
{
    public class SetPersonDTO
    {
        public SetPersonDTO()
        {
            PhoneNumbers = new HashSet<PhoneNumberDTO>();
        }
        [Required(ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "NameRequired")]
        [MaxLength(50, ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "NameSymbolMaxCount")]
        [MinLength(2, ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "NameSymbolMinCount")]
        [RegularExpression("^[ა-ჰ]*$|^[a-zA-Z]*$", ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "NameOnlyGeorgianLatin")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "LastNameRequired")]
        [MaxLength(50, ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "NameSymbolMaxCount")]
        [MinLength(2, ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "NameSymbolMinCount")]
        [RegularExpression("^[ა-ჰ]*$|^[a-zA-Z]*$", ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "NameOnlyGeorgianLatin")]
        public string LastName { get; set; }
        public int GenderId { get; set; }

        [StringLength(11, ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "PrivateNumberLength")]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "PrivateNumberOnlyIntegers")]
        public string PrivateNumber { get; set; }

        [Required(ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "BirthDateRequired")]
        [MinimumAge(18, ErrorMessageResourceType = (typeof(Resources.ErrorTexts)), ErrorMessageResourceName = "PersonAgeMustBeGreater18")]
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public ICollection<PhoneNumberDTO> PhoneNumbers { get; set; }
    }
}
