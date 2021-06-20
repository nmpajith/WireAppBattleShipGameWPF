using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireAppBattleShipGameWPF.Enums;

namespace WireAppBattleShipGameWPF.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Hits { get; set; }
        public OccupationStatus OccupationStatus { get; set; }
        public ObservableCollection<Panel> Panels { get; set; }
    }
}
