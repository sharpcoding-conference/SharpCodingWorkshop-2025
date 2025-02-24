using MedicalSystem.Domain.Entities;

namespace MedicalSystem.Domain.Interfaces
{
    public interface IMedicalFacilityRepository : IRepository<MedicalFacility>
    {
        /// <summary>
        /// Retrieves a medical facility by its name.
        /// </summary>
        /// <param name="name">The name of the medical facility.</param>
        /// <returns>The medical facility that matches the given name.</returns>
        Task<MedicalFacility> GetByNameAsync(string name);

        /// <summary>
        /// Retrieves all doctors working in a specific medical facility.
        /// </summary>
        /// <param name="facilityId">The ID of the medical facility.</param>
        /// <returns>A list of doctors associated with the given facility.</returns>
        Task<IEnumerable<Doctor>> GetDoctorsByFacilityIdAsync(Guid facilityId);

        /// <summary>
        /// Checks if a medical facility exists based on its name.
        /// </summary>
        /// <param name="name">The name of the medical facility.</param>
        /// <returns>True if the facility exists, otherwise false.</returns>
        Task<bool> ExistsByNameAsync(string name);
    }
}