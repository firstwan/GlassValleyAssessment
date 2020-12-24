using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlassValley.Model
{
    public class ItemCreateModel
    {
        [Required]
        public string key { get; set; }
        public string value { get; set; }
    }
}
