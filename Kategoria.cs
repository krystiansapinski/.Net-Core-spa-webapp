using System.ComponentModel.DataAnnotations;

namespace ZadanieRekrutacyjne
{
    public class Kategoria
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string NazwaKategorii { get; set; } = string.Empty;
    }
}
