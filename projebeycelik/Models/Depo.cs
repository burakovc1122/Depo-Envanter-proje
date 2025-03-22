using System.ComponentModel.DataAnnotations;

namespace projebeycelik.Models
{
    public class Depo
    {
        [Key]
        public int Id { get; set; }
        public string? Marka { get; set; }
        public string? Product { get; set; }
        public string? AssetState { get; set; }
        public string? OrgSerialNumber { get; set; }
        public string? ProductType { get; set; }
        public string? Site { get; set; }
        public string? UrunTipi { get; set; }
    }
}
