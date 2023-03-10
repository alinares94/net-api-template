using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$.Context;
public class TemplateContext : DbContext
{
    public TemplateContext(DbContextOptions<TemplateContext> options)
        : base(options)
    {
    }
}
