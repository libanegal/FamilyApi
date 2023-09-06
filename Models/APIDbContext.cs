using Microsoft.EntityFrameworkCore;

namespace using_DB.Models
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(){ }
        public APIDbContext(DbContextOptions option) : base(option) 
        {

        }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=desktop-ru2qnri\\sqlexpress; database=Connection; Integrated Security=true;TrustServerCertificate=True;MultipleActiveResultSets=True;");
            }
        }
    }
}
