namespace GuestManagement.Infrastructure.Base
{
    public class StorageFile
    {
        public string Name
        {
            get { 
                
                var segments = PathWithName.Split(new char [] {'\\','/'});
                string fileNameWithExtension = segments[segments.Length - 1];
                string fileName = fileNameWithExtension.Split('.')[0];
                return fileName;             
            }   
        }
        
        public StorageFile(string pathWithName)
        {
            PathWithName = pathWithName;
        }
        public string PathWithName { get; set; }
        
        
    }
}