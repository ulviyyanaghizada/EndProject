namespace EndProject.Models.ViewModels
{
    public class UpdateGalleryVM
    {
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public int GalleryCategoryId { get; set; }
    }
}
