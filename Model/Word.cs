using MVC_Odev.Domain.Admins;
using MVC_Odev.Domain.Common;

namespace MVC_Odev.Model
{
    public class Word : IEntity
    {
        public int WordId { get; set; }
        public string Wordname { get; set; }
        public string WordTitle { get; set; }

    }
}
