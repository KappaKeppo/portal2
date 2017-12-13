namespace Portal3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<cmnUser> cmnUser { get; set; }
        public virtual DbSet<drkpBudget> drkpBudget { get; set; }
        public virtual DbSet<drkpDepartment> drkpDepartment { get; set; }
        public virtual DbSet<drkpStaffList> drkpStaffList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cmnUser>()
                .HasMany(e => e.drkpStaffList)
                .WithOptional(e => e.cmnUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<drkpBudget>()
                .HasMany(e => e.drkpStaffList)
                .WithOptional(e => e.drkpBudget)
                .HasForeignKey(e => e.BudgetID);

            modelBuilder.Entity<drkpDepartment>()
                .HasMany(e => e.drkpDepartment1)
                .WithOptional(e => e.drkpDepartment2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<drkpStaffList>()
                .HasMany(e => e.drkpStaffList1)
                .WithOptional(e => e.drkpStaffList2)
                .HasForeignKey(e => e.ParentID);
        }
    }
}
