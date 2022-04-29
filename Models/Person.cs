using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string PersonName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<PersonInterests> PersonInterests { get; set; }
        public virtual ICollection<PersonLinks> PersonLinks { get; set; }

    }
}
