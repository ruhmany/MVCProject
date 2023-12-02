using CloudinaryDotNet.Actions;

namespace Booking.com.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletionPhotoAsync(string publicid);
    }
}
