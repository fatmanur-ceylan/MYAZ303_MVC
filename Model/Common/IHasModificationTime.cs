using System;

namespace MVC_Odev.Domain.Common
{
    public interface IHasModificationTime
    {
        DateTime? DegistirilmeTarihi { get; set; }
    }
}