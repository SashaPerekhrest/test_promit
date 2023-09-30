namespace TestPromIT.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(TestDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
