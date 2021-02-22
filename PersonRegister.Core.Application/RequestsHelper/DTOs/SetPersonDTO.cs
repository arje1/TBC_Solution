using PersonRegister.Core.Application.RequestsHelper.Attributes;
using PersonRegister.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonRegister.Core.Application.RequestsHelper.DTOs
{
    public class SetPersonDTO
    {
        [Required(ErrorMessage = "სახელი აუცილებელი ველია.")]
        [MaxLength(50, ErrorMessage = "სიმბოლოების მაქსიმალური რაოდენობა არის 50.")]
        [MinLength(2, ErrorMessage = "სიმბოლოების მინიმალური რაოდენობა არის 2.")]
        [RegularExpression("^[ა-ჰ]*$|^[a-zA-Z]*$", ErrorMessage = "უნდა მოიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "გვარი აუცილებელი ველია.")]
        [MaxLength(50, ErrorMessage = "სიმბოლოების მაქსიმალური რაოდენობა არის 50.")]
        [MinLength(2, ErrorMessage = "სიმბოლოების მინიმალური რაოდენობა არის 2.")]
        [RegularExpression("^[ა-ჰ]*$|^[a-zA-Z]*$", ErrorMessage = "უნდა მოიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს.")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        [StringLength(11, ErrorMessage = "უნდა შეიცავდეს 11 სიმბოლოს.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "უნდა შედგებოდეს მხოლოდ ციფრებისაგან.")]
        public string Pn { get; set; }

        [Required(ErrorMessage = "დაბადების თარიღი აუცილებელი ველია.")]
        [MinAgeAttribute(18, ErrorMessage = "ფიზიკური პირი უნდა იყოს მინიმუმ 18 წლის.")]
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public IEnumerable<PhoneDTO> Phones { get; set; }
    }
}
