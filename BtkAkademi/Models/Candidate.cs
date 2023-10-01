using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BtkAkademi.Models
{
    public class Candidate
    {
        [Required(ErrorMessage = "Email alan�n� bo� b�rakmay�n�z.")]
        public String? Email { get; set; } = String.Empty;
        [Required(ErrorMessage = "First Name alan�n� bo� b�rakmay�n�z.")]
        public String? FirstName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Last Name alan�n� bo� b�rakmay�n�z.")]
        public String? LastName { get; set; } = String.Empty; 
        public String? FullName => $"{FirstName} {LastName?.ToUpper()}";
        public int? Age { get; set; }
        public String? SelectedCourse { get; set; } = String.Empty;
        public DateTime ApplyAt { get; set; }
        public Candidate()
        {
            ApplyAt = DateTime.Now;
        }
    }
}