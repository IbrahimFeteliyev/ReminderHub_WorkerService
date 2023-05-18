using Business.Abstract;
using Business.Concrete;
using Microsoft.EntityFrameworkCore;
using WorkerService;
using WorkerService.Data;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false);
    })
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddScoped<EmailService>();
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddHostedService<Worker>();


    })
    .Build();

host.Run();
