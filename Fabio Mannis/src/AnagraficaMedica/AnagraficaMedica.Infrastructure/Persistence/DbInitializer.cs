using AnagraficaMedica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagraficaMedica.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Patients.Any())
            {
                context.Patients.AddRange(new List<Patient>
                {
                    new Patient { FirstName = "Mario", LastName = "Rossi", DateOfBirth = new DateTime(1985, 6, 15), FiscalCode = "RSSMRA85H15L219K", Address = "Via Roma 10, Milano", PhoneNumber = "1234567890" },
                    new Patient { FirstName = "Luca", LastName = "Bianchi", DateOfBirth = new DateTime(1990, 4, 22), FiscalCode = "BNCLCU90D22F205Z", Address = "Via Torino 5, Roma", PhoneNumber = "0987654321" },
                    new Patient { FirstName = "Giulia", LastName = "Verdi", DateOfBirth = new DateTime(1995, 12, 10), FiscalCode = "VRDGLL95T50H501X", Address = "Piazza Duomo 1, Napoli", PhoneNumber = "1122334455" }
                });
                context.SaveChanges();
            }

            if (!context.Doctors.Any())
            {
                var doctors = new[]
                {
                    new Doctor { FirstName = "Mario", LastName = "Rossi",Email = "m.rossi@gmail.com",PhoneNumber = "34567890789",Specialization = "Cardiologia" },
                    new Doctor { FirstName = "Anna", LastName = "Bianchi",Email = "a.bianchi@gmail.com",PhoneNumber = "34567890791", Specialization = "Pediatria" },
                    new Doctor { FirstName = "Luca", LastName = "Verdi", Specialization = "Neurologia",Email = "l.verdi@gmail.com",PhoneNumber = "34567890790",}
                };

                context.Doctors.AddRange(doctors);
                context.SaveChanges();
            }
        }
    }
}
