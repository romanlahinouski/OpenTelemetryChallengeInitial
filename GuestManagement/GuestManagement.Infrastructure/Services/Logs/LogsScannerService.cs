using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GuestManagement.Infrastructure.Services
{
    public interface ILogsScannerService
    {
        IEnumerable<LogFile> ScanDirectoryForLogs(string directory);
    }

    public class LogsScannerService : ILogsScannerService
    {
        private DateTime lastUploadTime = default;
     
        public IEnumerable<LogFile> ScanDirectoryForLogs(string directory)
        {
            var logs = new List<LogFile>();

            var files = Directory.GetFiles(directory).Where(fileName => Regex.IsMatch(fileName,".*.log$")).ToList();

            var allFiles = Directory.GetFiles(directory);
          

            foreach (var file in files)
            {
                logs.Add(new LogFile(file));
            }
          
            return logs;
        }
    }
}