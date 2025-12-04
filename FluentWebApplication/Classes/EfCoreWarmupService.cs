using FluentWebApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace FluentWebApplication.Classes;

public class EfCoreWarmupService(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<Context>();
            _ = context.Model;

            // Execute a simple, lightweight query to warm up query compilation
            await context.Person.Take(1).AnyAsync(cancellationToken);
        }

        await Task.CompletedTask;

    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}