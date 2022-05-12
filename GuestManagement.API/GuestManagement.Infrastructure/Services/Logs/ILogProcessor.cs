namespace GuestManagement.Infrastructure.Services
{
    public interface ILogProcessor
    {
        void Process(string logPath);
    }
}