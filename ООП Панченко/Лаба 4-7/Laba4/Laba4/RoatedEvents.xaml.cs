using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laba4
{
    public partial class RoatedEvents : Page
    {
        public static readonly RoutedEvent ClickEvent;
        public RoatedEvents()
        {
            InitializeComponent();

        }
        static RoatedEvents()
        {
            RoatedEvents.ClickEvent = EventManager.RegisterRoutedEvent("Click",
                RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(RoatedEvents));
        }
        public event RoutedEventHandler Click
        {
            add
            {
                base.AddHandler(RoatedEvents.ClickEvent, value);
            }
            remove
            {
                base.RemoveHandler(RoatedEvents.ClickEvent, value);
            }
        }
        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock1.Text = textBlock1.Text + "sender: " + sender.ToString() + "\n";
            textBlock1.Text = textBlock1.Text + "source: " + e.Source.ToString() + "\n\n";
        }
    }
}
