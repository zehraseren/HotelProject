using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Hizmet simgesi linkini giriniz.")]
        public string? ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığını giriniz.")]
        [StringLength(100, ErrorMessage = "Karakter girişi 100'den fazla olamaz.")]
        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
