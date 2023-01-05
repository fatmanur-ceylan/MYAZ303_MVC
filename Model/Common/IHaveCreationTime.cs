using System;

namespace MVC_Odev.Domain.Common
{
    public interface IHaveCreationTime
    {
        DateTime OlusturulmaTarihi { get; set; }
    }
}