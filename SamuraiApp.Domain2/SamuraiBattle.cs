using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain2
{
    public class SamuraiBattle
    {
        public int SamuariId { get; set; }
        public Samurai Samurai { get; set; }
        public int BattleId { get; set; }
        public Battle Battle { get; set; }
    }
}
