using A.CMD;
using A.CMD.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var service = ConfigurateDependencies();

     
        using (var scope = service.CreateScope())
        {
            CodeFirstDbContext context = scope.ServiceProvider.GetRequiredService<CodeFirstDbContext>();        
            context.Database.Migrate();

           
            Booking booking = new Booking();


            Customer customer = context.Customers.Find(1);
            if(customer == null)
            {
                Customer customerNew = new Customer();
                customerNew.FirstName = "German";
                customerNew.LastName = "Monti Rubio";
                customerNew.Age = 30;
                Console.WriteLine("Creando nuevo usuario");
                context.Add(customerNew);
                booking.customer = customerNew;
            }
            else
            {
                booking.customer = customer;
            }
            Destination destination = context.Destination.Find(1);

            if (destination == null)
            {
                Destination destinationNew = new Destination();
                destinationNew.city = "Cordoba";
                context.Add(destinationNew);
                booking.destination = destinationNew;
            }
            else
            {
                booking.destination = destination;
            }


            booking.ReservationDate = new DateTime(2004, 6, 15);
            booking.ReservatedDate = DateTime.Now;

            context.Add(booking);
            context.SaveChanges();
        
        }
       

    }

    private static IServiceProvider ConfigurateDependencies()
    {
        IConfiguration config = SetConfigurationRoot();
        IServiceCollection services = new ServiceCollection();

        services.AddDbContext<CodeFirstDbContext>(option =>
        {
            option.UseMySQL(config.GetConnectionString("DbContext"));
        }, ServiceLifetime.Scoped);
        return services.BuildServiceProvider();
    }

    private static IConfiguration SetConfigurationRoot()
    {
        string directory = Directory.GetCurrentDirectory();
        return new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile("appsettings.json", true, true)
            .Build();
    }

}