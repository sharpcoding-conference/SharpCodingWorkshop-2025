namespace MedicalSystem.Domain.Entities
{
    public class MedicalFacility
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}