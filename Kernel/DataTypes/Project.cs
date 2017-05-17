using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projects.DataTypes
{
    public class Project
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string CustomerCompany { get; set; }
        public string ConstractorCompany { get; set; }

        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }
        public virtual Person Employee { get; set; }

        [ForeignKey("Leader")]
        public long LeaderId { get; set; }
        public virtual Person Leader { get; set; }

        public virtual IEnumerable<Person> Contractors { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Priority { get; set; }

        public string Comment { get; set; }

        public Project()
        {
            Name = string.Empty;
            CustomerCompany = string.Empty;
            ConstractorCompany = string.Empty;

            Start = DateTime.Now;
            End = DateTime.Now;
            Priority = 0;

            Comment = string.Empty;
        }
    }
}
