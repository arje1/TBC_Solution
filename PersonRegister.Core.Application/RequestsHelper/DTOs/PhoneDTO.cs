using PersonRegister.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonRegister.Core.Application.RequestsHelper.DTOs
{
    public class PhoneDTO
    {
        [MaxLength(50, ErrorMessage = "სიმბოლოების მაქსიმალური რაოდენობა არის 50.")]
        [MinLength(2, ErrorMessage = "სიმბოლოების მინიმალური რაოდენობა არის 2.")]
        public string Number { get; set; }
        public PhoneNumberType NumberType { get; set; }
    }
}
