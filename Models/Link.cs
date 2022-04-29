using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        [Required]
        public string Link_ { get; set; }

        public virtual ICollection<LinkInterest> LinkInterests { get; set; }
        public virtual ICollection<PersonLinks> PersonLinks { get; set; }
    }
}
