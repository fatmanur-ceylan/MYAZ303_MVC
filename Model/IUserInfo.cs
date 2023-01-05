namespace MVC_Odev.Domain
{
    public interface IUserInfo
    {
        public int KullaniciId { get; }
        public bool ActiveTenant { get; }
    }
}