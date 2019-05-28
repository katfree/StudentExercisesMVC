using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC2.Models
{
    public class Instructor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CohortId { get; set; }

        [Required]
        [StringLength(55)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(55)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [StringLength(55)]
        [Display(Name = "Slack Handle")]
        public string SlackHandle { get; set; }

        [Required]
        [StringLength(55)]
        [Display(Name = "Specialty")]

        public string Specialty { get; set; }

        public Cohort Cohort { get; set; }
    }
}
