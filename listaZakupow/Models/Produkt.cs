namespace listaZakupow.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Opis { get; set; } = "";
        public string Rodzaj { get; set; } = "";
        public DateTime Data { get; set; } = DateTime.Now;
        public bool Zrobione { get; set; }
    }
}
