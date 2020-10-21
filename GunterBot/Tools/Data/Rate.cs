using System.Collections.Generic;

namespace GunterBot.Tools.Data
{
    public class Rate
    {
        public string Disclaimer { get; set; }
        public string License { get; set; }
        public string TimeStamp { get; set; }
        public string Base { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
