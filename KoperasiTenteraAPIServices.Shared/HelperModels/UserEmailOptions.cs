using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraAPIServices.Shared.HelperModels
{
    public class UserEmailOptions
    {
        public string toEmail { get; set; } = default!;
        public string subject { get; set; } = default!;
        public string body { get; set; } = default!;
    }
}
