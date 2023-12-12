using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingEFCore.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
