using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        [Required]
        public string InterestTitle { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PersonInterests> PersonInterests { get; set; }

        public virtual ICollection<LinkInterest> LinkInterests { get; set; }
    }
}
