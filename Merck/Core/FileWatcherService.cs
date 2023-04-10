using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Merck.Core
{
    public class FileWatcherService : BackgroundService
    {
        private readonly ILogger<FileWatcherService> _logger;
        private readonly string _directoryPath;
        private readonly string _fileFilter;
        private readonly Timer _timer;
        private readonly IHttpClientFactory _clientFactory;
        private List<string> _processedFiles = new List<string>();
        public FileWatcherService(ILogger<FileWatcherService> logger, IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _directoryPath = configuration.GetValue<string>("FileWatcher:DirectoryPath");
            _fileFilter = configuration.GetValue<string>("FileWatcher:FileFilter");
            _clientFactory = clientFactory;
            _timer = new Timer(OnTimerElapsed, null, Timeout.Infinite, Timeout.Infinite);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("FileWatcherService is running.");

                // Start the timer
                _timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(60));

                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
            
        }
        private async void OnTimerElapsed(object state)
        {
            // Check for new files in the directory
            string[] files = Directory.GetFiles(_directoryPath, _fileFilter);
            files = files.Where(f => !_processedFiles.Contains(f)).ToArray();
            // If there are new files, send the file data to the controller action
            if (files.Length > 0)
            {
                _logger.LogInformation("New files created: " + string.Join(",", files));

                using (var httpClient = _clientFactory.CreateClient())
                {
                    foreach (string file in files)
                    {
                        byte[] fileData = File.ReadAllBytes(file);
                        string fileName = Path.GetFileName(file);

                        var content = new MultipartFormDataContent();
                        var fileNameContent = new StringContent(fileName);
                        content.Add(fileNameContent, "fileName");
                        
                        var response = await httpClient.PostAsync("https://localhost:5001/TreatmentEvent/ProcessFile", content);

                        if (response.IsSuccessStatusCode)
                        {
                            _logger.LogInformation("File " + fileName + " sent successfully.");
                            _processedFiles.Add(file);
                        }
                        else
                        {
                            _logger.LogError("Error sending file " + fileName + ": " + response.StatusCode);
                        }
                    }
                }
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("FileWatcherService is stopping.");

            // Stop the timer
            _timer.Change(Timeout.Infinite, Timeout.Infinite);

            await base.StopAsync(cancellationToken);
        }
    }
}
