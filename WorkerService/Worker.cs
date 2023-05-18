using Business.Concrete;
using Entities.Concrete;
using WorkerService.Data;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
            while (!stoppingToken.IsCancellationRequested)
            {
                var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var emailService = scope.ServiceProvider.GetRequiredService<EmailService>();
                try
                {
                    var data = dbContext.Reminders.ToList();
                    foreach (var reminder in data)
                    {
                        var currentTime = DateTime.UtcNow;

                        if (currentTime >= reminder.SendAt && reminder.IsSent == false)
                        {
                            emailService.SendReminderEmail(reminder);
                            reminder.IsSent = true;
                            
                        }
                    }
                    dbContext.SaveChanges();
                }

                catch (Exception ex)    
                {
                    _logger.LogError(ex, "Error occurred while reading from database and sending emails.");
                }

                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
            }

        }
    }
}