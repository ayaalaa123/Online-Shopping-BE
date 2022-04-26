using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Domain.DTO
{
   public class AddUserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
    }
}
