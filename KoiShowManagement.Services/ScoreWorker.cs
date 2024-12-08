using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace KoiShowManagement.Service
{
    public class ScoreWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ScoreWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var scoreService = scope.ServiceProvider.GetRequiredService<IScoreService>();
                    bool allScoresUpdated = await scoreService.StartCalculatingScoresAsync();

                    if (allScoresUpdated)
                    {
                        // Stop the worker if all scores are updated
                        break; // Exit the loop
                    }
                }
                await Task.Delay(1000, stoppingToken); // Delay for demonstration
            }
        }
    }
}
