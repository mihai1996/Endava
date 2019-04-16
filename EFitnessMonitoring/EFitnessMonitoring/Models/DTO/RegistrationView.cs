using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFitnessMonitoring.Models.DTO
{
    public class RegistrationView
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gen { get; set; }
        public int Virsta { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [Required]
        [Compare("Parola", ErrorMessage = "Parola nu coincide")]
        public string ConfirmParola { get; set; }
    }
}