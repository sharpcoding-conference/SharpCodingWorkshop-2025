namespace MedicalSystem.Domain.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid MedicalFacilityId { get; set; }
        public MedicalFacility MedicalFacility { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}