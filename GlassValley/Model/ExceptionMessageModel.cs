using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GlassValley.Model
{
    public class ExceptionMessageModel
    {
        public string ErrorCode;
        public string ErrorMessage;


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
