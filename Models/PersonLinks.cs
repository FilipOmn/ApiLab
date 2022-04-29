using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Models
{
    public class PersonLinks
    {
        [Key]
        public int PersonLinksId { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int LinkId { get; set; }
        public Link Link { get; set; }
    }
}
