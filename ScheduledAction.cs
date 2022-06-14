using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DIE.ScheduledAction
{
    public class ScheduledAction : BackgroundService
    {
        private readonly ILogger<ScheduledAction> _logger;
        private Timer _timer;

        public ScheduledAction(ILogger<ScheduledAction> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Running scheduled action loop");
            _timer = new Timer(CheckTime, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void CheckTime(object state)
        {
            _logger.LogInformation("Timed Hosted Service is working");
        }
    }
}
