using MVC_Odev.Domain.Common;

namespace MVC_Odev.Model
{
    public class Admin : IEntity
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Email { get; set; }

    }
}
