using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC2.Models
{
    public class Cohort
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(55)]
        [Display(Name = "Cohort Name")]
        public string CohortName { get; set; }
    }
}
