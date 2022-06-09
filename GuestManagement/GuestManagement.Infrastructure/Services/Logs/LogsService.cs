using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;


namespace GuestManagement.Infrastructure.Services
{
    public class LogsService : BackgroundService
    {

        private DateTime lastUploadTime = default;
        private string currentDirectory => Directory.GetCurrentDirectory();

        private List<LogFile> logs = new List<LogFile>();
        private readonly ILogProcessor _logProcessor;
        private readonly ILogsScannerService _logsScannerService;

        private TimeSpan Interval = TimeSpan.FromSeconds(10);
        public LogsService(ILogProcessor logProcessor,
        ILogsScannerService logsScannerService)
        {
            _logsScannerService = logsScannerService;
            _logProcessor = logProcessor;
        }

        ///1) Find all files with .log extension
        ///2) Compare modification time with upload time if bigger then add to upload list

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {      
             while (!stoppingToken.IsCancellationRequested)
            {
                var logs = _logsScannerService.ScanDirectoryForLogs(currentDirectory);

                foreach (var log in logs)
                {
                    _logProcessor.Process(log.Name);
                }

                await Task.Delay(TimeSpan.FromSeconds(20));
            }

        }
    }
}