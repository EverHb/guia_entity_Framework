using Microsoft.EntityFrameworkCore;
public class Context : DbContext
{
    public DbSet<Student> Estudiante { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-H8P0V0H\\SQLEXPRESS;Database=Programacion2; Trusted_Connection = true; ");
    }
}