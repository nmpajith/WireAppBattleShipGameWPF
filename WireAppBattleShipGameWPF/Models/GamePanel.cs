using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireAppBattleShipGameWPF.Models
{
    public class GamePanel
    {
        public ObservableCollection<Panel> Panels { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}
