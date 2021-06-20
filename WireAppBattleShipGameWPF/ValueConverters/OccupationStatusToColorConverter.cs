using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using WireAppBattleShipGameWPF.Enums;

namespace WireAppBattleShipGameWPF.ValueConverters
{
    public class OccupationStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var occupationStatus = (OccupationStatus)value;
            return  occupationStatus switch
            {
                OccupationStatus.Empty => new SolidColorBrush(Color.FromArgb(255, 51, 153, 255)),
                OccupationStatus.Hit => new SolidColorBrush(Color.FromArgb(255, 204, 0, 102)),
                OccupationStatus.Miss => new SolidColorBrush(Color.FromArgb(255, 102, 204, 0)),
                OccupationStatus.Sunk => new SolidColorBrush(Color.FromArgb(255, 0, 51, 102)),
                OccupationStatus.Battleship => new SolidColorBrush(Color.FromArgb(255, 204, 204, 0)),
                OccupationStatus.Destroyer => new SolidColorBrush(Color.FromArgb(255, 204, 102, 0)),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(occupationStatus)),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
