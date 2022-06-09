using System.IO;

namespace GuestManagement.Infrastructure.Services
{
    public interface ILogRemover
    {
        void RemoveIfExists(string logPath);
    }

    public class LogRemover : ILogRemover
    {
        public void RemoveIfExists(string logPath)
        {

            try
            {
                File.Delete(logPath);
            }
            catch (IOException ex)
            {
                // TODO
            }

        }
    }
}