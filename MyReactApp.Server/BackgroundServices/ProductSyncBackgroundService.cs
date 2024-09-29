using MyReactApp.Server.Services;

namespace MyReactApp.Server.BackgroundServices;

public class ProductSyncBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public ProductSyncBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var syncService = scope.ServiceProvider.GetRequiredService<ProductSyncService>();

                    // Sync products
                    await syncService.SyncProducts();
                }

                // Wait for 1 day before syncing again (adjust as needed)
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error syncing data: {ex.Message}");
                throw;
            }

        }
    }
}
