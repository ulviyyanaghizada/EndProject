using EndProject.Models.Base;

namespace EndProject.Models.Gallery
{
    public class Gallery:BaseEntity
    {
        public string ImageUrl { get; set; }
        public int GalleryCategoryId { get; set; }
        public GalleryCategory? GalleryCategory { get; set; }

    }
}
