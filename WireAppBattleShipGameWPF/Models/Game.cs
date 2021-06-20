using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireAppBattleShipGameWPF.Models
{
    public class Game
    {
        public Player RealPlayer { get; set; }
        public Player AutoPlayer { get; set; }
        public Coordinates ManualShotCoordinates { get; set; }
    }
}
