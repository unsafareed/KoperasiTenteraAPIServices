using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraAPIServices.Application.DTOs.Customers
{
    public class SetCustomerBiometric
    {
        public string CustomerId { get; set; } = default!;
        public byte[] Biometric { get; set; } = default!;
    }
}
