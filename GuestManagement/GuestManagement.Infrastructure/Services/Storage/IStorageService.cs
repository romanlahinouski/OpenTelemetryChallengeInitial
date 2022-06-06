
using GuestManagement.Infrastructure.Base;

namespace GuestManagement.Infrastructure.Services
{
    public interface IStorageService
    {
        void UploadFile(StorageFile file);

    }
}