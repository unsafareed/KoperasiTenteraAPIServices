using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraAPIServices.Shared.HelperModels
{
    public class SmsDto
    {
        public string MobileNo { get; set; } = default!;
        public string Message { get; set; } = default!;
    }
}
