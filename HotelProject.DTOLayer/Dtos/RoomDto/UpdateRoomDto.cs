using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DTOLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Lütfen oda numarasını giriniz.")]
        public string? RoomNumber { get; set; }

        [Required(ErrorMessage = "Lütfen oda görselini ekleyiniz.")]
        public string? RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisinı giriniz.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen oda başlığını giriniz.")]
        [StringLength(100, ErrorMessage = "Karakter girişi 100'den fazla olamaz.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısını giriniz.")]
        public string? BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen banyo sayısını giriniz.")]
        public string? BathCount { get; set; }

        public string? Wifi { get; set; }

        [Required(ErrorMessage = "Lütfen açıklama giriniz.")]
        public string? Description { get; set; }
    }
}
