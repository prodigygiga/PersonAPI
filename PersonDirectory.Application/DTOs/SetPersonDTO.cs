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
        [Required(ErrorMessage = "სახელი აუცილებელი ველია.")]
        [MaxLength(50, ErrorMessage = "სიმბოლოების მაქსიმალური რაოდენობა არის 50.")]
        [MinLength(2, ErrorMessage = "სიმბოლოების მინიმალური რაოდენობა არის 2.")]
        [RegularExpression("^[ა-ჰ]*$|^[a-zA-Z]*$", ErrorMessage = "უნდა შეიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "გვარი აუცილებელი ველია.")]
        [MaxLength(50, ErrorMessage = "სიმბოლოების მაქსიმალური რაოდენობა არის 50.")]
        [MinLength(2, ErrorMessage = "სიმბოლოების მინიმალური რაოდენობა არის 2.")]
        [RegularExpression("^[ა-ჰ]*$|^[a-zA-Z]*$", ErrorMessage = "უნდა შეიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს.")]
        public string LastName { get; set; }
        public int GenderId { get; set; }

        [StringLength(11, ErrorMessage = "პირადი ნომერი უნდა შეიცავდეს 11 სიმბოლოს.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "პირადი ნომერი უნდა შედგებოდეს მხოლოდ ციფრებისაგან.")]
        public string PrivateNumber { get; set; }

        [Required(ErrorMessage = "დაბადების თარიღის შევსება აუცილებელი ველია.")]
        [MinimumAge(18, ErrorMessage = "ფიზიკური პირი უნდა იყოს მინიმუმ 18 წლის.")]
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public ICollection<PhoneNumberDTO> PhoneNumbers { get; set; }
    }
}
