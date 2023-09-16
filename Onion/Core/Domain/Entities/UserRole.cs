using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<User>? Users { get; set; }
    }
}
