using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC2.Models
{
    public class Exercise
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(55)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(55)]
        [Display(Name = "Exercise Language")]
        public string ExerciseLanguage { get; set; }
    }
}
