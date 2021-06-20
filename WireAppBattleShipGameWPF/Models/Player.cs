using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireAppBattleShipGameWPF.Models
{
    public class Player
    {
        public string Name { get; set; }
        public GamePanel GamePanel { get; set; }
        public ObservableCollection<Ship> Ships { get; set; }
        public string HitResult { get; set; }
        public int Points { get; set; }
    }
}
