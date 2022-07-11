using System.ComponentModel.DataAnnotations;

namespace ZadanieRekrutacyjne
{
    public class ZadanieRekrutacyjne
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Imie { get; set; } = string.Empty;

        [StringLength(20)]
        public string Nazwisko { get; set; } = string.Empty;

        [StringLength(30)]
        public string Email { get; set; } = string.Empty;

        public int IdKategorii { get; set; }

        public Kategoria? Kategoria { get; set; }

        [StringLength(9)]
        public string Telefon { get; set; } = string.Empty;

        public DateTime Data { get; set; }
    }
}
