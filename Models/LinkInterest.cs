using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Models
{
    public class LinkInterest
    {
        [Key]
        public int LinkInterestId { get; set; }

        public int LinkId { get; set; }
        public Link Link { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
