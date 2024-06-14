using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTLogin.DTO.Dtos
{
    public class ConfirmMailDto
    {
        public string Email { get; set; }
        public int ConfirmCode { get; set; }
    }
}
