using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagraficaMedica.Domain.Entities
{
    public class HealthcareFacility
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Relazione con i medici
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
