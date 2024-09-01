using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laba4
{
    public partial class UserControl2 : UserControl
    {
        public double RotationAngle
        {
            get { return (double)GetValue(RotationAngleProperty); }
            set { SetValue(RotationAngleProperty, value); }
        }

        public static readonly DependencyProperty RotationAngleProperty = DependencyProperty.Register
        (
            "RotationAngle",                 
            typeof(double),                 
            typeof(UserControl2),         
            new FrameworkPropertyMetadata(0.0, null, new CoerceValueCallback(CorrectValue))
        );

        public UserControl2()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            if (!double.TryParse(baseValue.ToString(), out double value))
            {
                return 0.0;
            }
            else if (value >= 180 || value <= 0)
            {
                return 0.0;
            }
            else
            {
                return value;
            }
        }

    }
}