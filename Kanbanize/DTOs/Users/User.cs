using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanbanize.DTOs.Users
{
    public class User
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string RealName { get; set; }
        public string CompanyName { get; set; }
        public string apiKey { get; set; }
    }
}
