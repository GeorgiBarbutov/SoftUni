﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.App.Dtos.ImportDtos
{
    public class PassportDto
    {
        [RegularExpression("^[a-zA-Z]{7}[0-9]{3}$")]
        [Key]
        public string SerialNumber { get; set; }

        [Required]
        [RegularExpression(@"^\+359[0-9]{9}$|^0[0-9]{9}$")]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string OwnerName { get; set; }

        [Required]
        public string RegistrationDate { get; set; }
    }
}
