using Microsoft.EntityFrameworkCore;

namespace EfCoreDockerCompose;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }
    public DbSet<SomeRecord> SomeRecords { get; set; }
}

public class SomeRecord
{
    public int Id { get; set; }
    public string Descritpion { get; set; }
}