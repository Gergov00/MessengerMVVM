

namespace MessengerMVVM.DB
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string passwordhash { get; set; } = string.Empty;
    }

}
