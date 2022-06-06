using GuestManagement.Infrastructure.Base;

namespace GuestManagement.Infrastructure.Services
{
    public class LogProcessor : ILogProcessor
    {
        private readonly IStorageService _storageService;
        private readonly ILogRemover _logRemover;

        public LogProcessor(IStorageService storageService, ILogRemover logRemover)
        {
            _logRemover = logRemover;
            _storageService = storageService;

        }
        public void Process(string logPath)
        {
            if (!(_storageService is null))
                _storageService.UploadFile(new StorageFile(logPath));
                _logRemover.RemoveIfExists(logPath);
        }
    }
}