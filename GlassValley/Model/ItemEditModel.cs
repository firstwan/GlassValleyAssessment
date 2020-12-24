using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlassValley.Model
{
    public class ItemEditModel
    {
        [Required]
        public string value { get; set; }

    }
}
