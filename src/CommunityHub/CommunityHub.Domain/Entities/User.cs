using CommunityHub.Domain.ValueObjects;

namespace CommunityHub.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }

        // EF Core requires a parameterless constructor for entities
        private User() { }

        public User(Guid id, string name, Email email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        /// <summary>
        /// Updates the name and email of the user.
        /// </summary>
        /// <param name="name">The new name of the user.</param>
        /// <param name="email">The new email of the user.</param>
        public void Update(string name, Email email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            Name = name;
            Email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null.");
        }
    }
}
