namespace OrderManagement.Models
{
   public class Message<T> 
    {
        public Message()
        { 
        }
        
        public T Body { get; set; }

        public string SingularityHeader
        {

            get;

            set;
        }

        private string singularityHeader;
    }
}