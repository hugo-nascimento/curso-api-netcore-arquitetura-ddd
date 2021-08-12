using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext> 
    {
        public MyContext CreateDbContext(string[] args)
        {
            //var connectionString = "Server=localhost;Port=3306;Database=Course;Uid=developer;Pwd=castle123";
            var connectionString = "Server=.\\SQLEXPRESS;Initial Catalog=Course;MultipleActiveResultSets=true;User ID=sa;Password=castle123";

            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionBuilder.UseMySql(connectionString);
            optionBuilder.UseSqlServer(connectionString);
            return new MyContext(optionBuilder.Options);
        }
    }
}
