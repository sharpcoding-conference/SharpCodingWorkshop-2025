namespace MedicalSystem.Domain.Entities
{
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public string Description { get; set; }
        public List<Report> Reports { get; set; } = new List<Report>();
    }
}