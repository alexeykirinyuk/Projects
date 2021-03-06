//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projects.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CustomerCompany { get; set; }
        public string ConstractorCompany { get; set; }
        public Nullable<long> EmployeeId { get; set; }
        public Nullable<long> LeaderId { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime End { get; set; }
        public int Priority { get; set; }
        public string Comment { get; set; }
    
        public virtual Worker Employee { get; set; }
        public virtual Worker Leader { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Worker> Workers { get; set; }
        public virtual List<long> WorkerIds { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.Workers = new HashSet<Worker>();

            Name = string.Empty;
            CustomerCompany = string.Empty;
            ConstractorCompany = string.Empty;
            Start = DateTime.Now;
            End = DateTime.Now;
            Priority = 1;
            Comment = string.Empty;
            WorkerIds = new List<long>();
        }
        public Project(string name, string customer, string constructor) : this()
        {
            Name = name;
            CustomerCompany = customer;
            ConstractorCompany = constructor;
        }

        public Project Update(Project project)
        {
            Name = project.Name;
            CustomerCompany = project.CustomerCompany;
            ConstractorCompany = project.ConstractorCompany;
            Start = project.Start;
            End = project.End;
            Priority = project.Priority;
            Comment = project.Comment;

            return this;
        }
        public void ClearWorkers()
        {
            Workers = new HashSet<Worker>();
        }
        public Project AddWorkers(params Worker[] workers)
        {
            foreach (var worker in workers)
            {
                Workers.Add(worker);
            }

            return this;
        }
    }
}
