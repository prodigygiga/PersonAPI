using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectory.Application.DTOs
{
    public class PhoneNumberDTO
    {
        [MaxLength(50, ErrorMessage = "ტელეფონის ნომრის სიმბოლოების მაქსიმალური რაოდენობა არ უნდა აღემატებოდეს 50-ს.")]
        [MinLength(2, ErrorMessage = "ტელეფონის ნომრის სიმბოლოების მინიმალური რაოდენობა უნდა იყოს 2.")]
        public string Number { get; set; }
        public int NumberTypeId { get; set; }
    }
}
