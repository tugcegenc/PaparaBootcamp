namespace ProductManagement.Api.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope()) 
            {
                var context = scope.ServiceProvider.GetRequiredService<ProductManagementDbContext>();

                if (context.Products.Any()) 
                {
                    return;
                }

                context.Products.AddRange(
                );

                context.SaveChanges(); 
            }
        }
    }
}