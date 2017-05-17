using System.ComponentModel.DataAnnotations;

namespace Projects.DataTypes
{
    public class Person
    {
        [Key]
        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }

        public Person()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            MiddleName = string.Empty;
            Email = string.Empty;

            Role = Role.Contractor;
        }
    }
}
