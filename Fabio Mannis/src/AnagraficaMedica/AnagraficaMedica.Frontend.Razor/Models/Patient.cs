using System;

namespace AnagraficaMedica.Frontend.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FiscalCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}