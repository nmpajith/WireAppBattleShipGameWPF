using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireAppBattleShipGameWPF.Enums;
using WireAppBattleShipGameWPF.Extentions;

namespace WireAppBattleShipGameWPF.Models
{
    public class Panel
    {
        public OccupationStatus OccupationStatus { get; set; }
        public Coordinates Coordinates { get; set; }

        public string OccupationStatusDescription => OccupationStatus.GetAttributeOfType<DescriptionAttribute>().Description;
    }
}
