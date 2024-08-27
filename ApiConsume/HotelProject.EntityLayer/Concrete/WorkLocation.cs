namespace HotelProject.EntityLayer.Concrete
{
    public class WorkLocation
    {
        public int WorkLocationID { get; set; }
        public string? WorkLocationName { get; set; }
        public string? WorkLocationCity { get; set; }
        public List<AppUser>? AppUsers { get; set; }
    }
}
