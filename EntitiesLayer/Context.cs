namespace EntitiesLayer
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

        public virtual DbSet<Matriz> Matriz { get; set; }
        public virtual DbSet<Row> Row { get; set; }
        public virtual DbSet<TestCase> TestCases { get; set; }
        public virtual DbSet<CustomException> CustomExceptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
