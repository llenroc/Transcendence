using System.Threading.Tasks;

namespace TranscendenceChat
{
    public interface IPhotoGalleryService
    {
        Task<OriginalAndThumbnail> PickAsync(bool directlyFromCamera, int maxWidth, int maxHeight, int maxThumbnailWidth, int maxThumbnailHeight);
    }
}
