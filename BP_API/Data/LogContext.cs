using BP_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BP_API.Data
{
    public class LogContext : DbContext {
        public LogContext(DbContextOptions<LogContext> options)
            :base(options) { }

        public DbSet<Measurement> measurements { get; set; }
    }
}