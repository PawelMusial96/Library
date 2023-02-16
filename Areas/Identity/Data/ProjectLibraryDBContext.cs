using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectLibrary.Areas.Identity.Data;
using ProjectLibrary.Models;

namespace ProjectLibrary.Areas.Identity.Data;

public class ProjectLibraryDBContext : IdentityDbContext<ProjectLibraryUser>
{
    public ProjectLibraryDBContext(DbContextOptions<ProjectLibraryDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<ProjectLibrary.Models.Book> Book { get; set; }

    public DbSet<ProjectLibrary.Models.AdminBook> AdminBook { get; set; }

    public DbSet<ProjectLibrary.Models.AdminAuthor> AdminAuthor { get; set; }

    public DbSet<ProjectLibrary.Models.AdminGenre> AdminGenre { get; set; }


}
