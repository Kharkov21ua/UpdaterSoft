using System.Net;


namespace Updater_Csharp
{
    internal class Internet
    {
        public static bool OK()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    Dns.GetHostEntry("google.com");
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
