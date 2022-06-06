using System;

namespace GuestManagement.Infrastructure.Services
{
    public class LogFile
    {

        public LogFile(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }


    }
}