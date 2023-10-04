namespace GameHall.Security
{
    public class Settings
    {
        private static string secret = "3e5d4b83d9f23aa81ee8eb1ae342248e4f3d257284082b2db04cf05fa92029a2";

        public static string Secret { get => secret; set => secret = value; }
    }
}
