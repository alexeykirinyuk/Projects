namespace Projects.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonsBase",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Email = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectsBase",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CustomerCompany = c.String(),
                        ConstractorCompany = c.String(),
                        EmployeeId = c.Long(),
                        LeaderId = c.Long(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonsBase", t => t.EmployeeId)
                .ForeignKey("dbo.PersonsBase", t => t.LeaderId)
                .Index(t => t.EmployeeId)
                .Index(t => t.LeaderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectsBase", "LeaderId", "dbo.PersonsBase");
            DropForeignKey("dbo.ProjectsBase", "EmployeeId", "dbo.PersonsBase");
            DropIndex("dbo.ProjectsBase", new[] { "LeaderId" });
            DropIndex("dbo.ProjectsBase", new[] { "EmployeeId" });
            DropTable("dbo.ProjectsBase");
            DropTable("dbo.PersonsBase");
        }
    }
}
