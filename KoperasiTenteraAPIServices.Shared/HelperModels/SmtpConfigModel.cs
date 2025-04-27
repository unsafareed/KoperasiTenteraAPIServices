using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraAPIServices.Shared.HelperModels
{
    public class SmtpConfigModel
    {
        public string senderAddress { get; set; } = default!;
        public string senderDisplayName { get; set; } = default!;
        public string userName { get; set; } = default!;
        public string password { get; set; } = default!;
        public string host { get; set; } = default!;
        public int port { get; set; }
        public bool enableSsl { get; set; }
        public bool useDefaultCredentials { get; set; }
        public bool isBodyHtml { get; set; }
    }
}
