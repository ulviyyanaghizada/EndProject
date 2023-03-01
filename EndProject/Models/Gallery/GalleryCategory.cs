using EndProject.Models.Base;

namespace EndProject.Models.Gallery
{
    public class GalleryCategory:BaseNameEntity
    {
        public ICollection<Gallery>? Galleries { get;}
    }
}
