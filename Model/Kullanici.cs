using MVC_Odev.Domain.Common;

namespace MVC_Odev.Model
{
    public class Kullanici : IEntity
    {
        public int KullaniciId { get; set; }
        public string Eposta { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

    }
}
