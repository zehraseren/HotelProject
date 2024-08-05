using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet simgesi linkini giriniz.")]
        public string? ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığını giriniz.")]
        [StringLength(100, ErrorMessage = "Karakter girişi 100'den fazla olamaz.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Hizmet açıklamasını giriniz.")]
        [StringLength(500, ErrorMessage = "Karakter girişi 500'den fazla olamaz.")]
        public string? Description { get; set; }
    }
}
