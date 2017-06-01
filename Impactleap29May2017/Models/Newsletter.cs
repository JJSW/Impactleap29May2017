using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Impactleap29May2017.Models
{
    public class Newsletter
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "The email address is invalid.")]
        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; }

        public string Company { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SignUpDate { get; set; }
    }
}
