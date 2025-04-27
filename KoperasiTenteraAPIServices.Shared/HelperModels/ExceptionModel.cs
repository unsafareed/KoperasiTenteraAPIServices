using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraAPIServices.Shared.HelperModels
{
    public class ExceptionModel
    {
        public string Title { get; set; } = default!;
        public string Message { get; set; } = default!;
        public int StatusCode { get; set; } = default!;
    }
}
