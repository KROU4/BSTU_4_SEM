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
    public partial class UserControl3 : UserControl
    {
        public static RoutedUICommand IncreaseCommand = new("Increase", "Increase", typeof(UserControl3), 
            new InputGestureCollection() { new KeyGesture(Key.Add) } );
        public static RoutedUICommand DecreaseCommand = new("Decrease", "Decrease", typeof(UserControl3),
            new InputGestureCollection() { new KeyGesture(Key.Subtract) } );

        public static readonly DependencyProperty CurrentTicketsAmountProperty =
            DependencyProperty.Register(
                "CurrentTicketsAmount",
                typeof(string),
                typeof(UserControl3),
                new FrameworkPropertyMetadata("0", null, new CoerceValueCallback(CorrectValue))
            );

        public static readonly DependencyProperty MaxTicketsAmountProperty =
            DependencyProperty.Register(
                "MaxTicketsAmount",
                typeof(string),
                typeof(UserControl3),
                new FrameworkPropertyMetadata("100", FrameworkPropertyMetadataOptions.None, null, null)
            );


        public UserControl3()
        {
            InitializeComponent();
            this.DataContext = this;

            CommandBindings.Add(new CommandBinding(IncreaseCommand, IncreaseCommand_Executed));
            CommandBindings.Add(new CommandBinding(DecreaseCommand, DecreaseCommand_Executed));

            ticket_amount_up_btn.Command = IncreaseCommand;
            ticket_amount_down_btn.Command = DecreaseCommand;
        }

        public string CurrentTicketsAmount
        {
            get
            {
                if (!string.IsNullOrEmpty((string)GetValue(CurrentTicketsAmountProperty)))
                {
                    return (string)GetValue(CurrentTicketsAmountProperty);
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                SetValue(CurrentTicketsAmountProperty, value);
            }
        }

        public string MaxTicketsAmount
        {
            get
            {
                if (!string.IsNullOrEmpty((string)GetValue(MaxTicketsAmountProperty)))
                {
                    return (string)GetValue(MaxTicketsAmountProperty);
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                SetValue(MaxTicketsAmountProperty, value);
            }
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            UserControl3 control = d as UserControl3;
            if (!int.TryParse(control.MaxTicketsAmount, out int maxValue))
            {
                return "0";
            }
            if (!int.TryParse((string)baseValue, out int currentValue))
            {
                return "0";
            }

            if (currentValue > maxValue)  
                return maxValue.ToString();
            if (currentValue < 0)
                return "0";
            return currentValue.ToString(); 
        }


        private void IncreaseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (int.TryParse(NumberTextBox.Text, out int currentValue))
            {
                NumberTextBox.Text = (currentValue + 1).ToString();
            }
        }

        private void DecreaseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (int.TryParse(NumberTextBox.Text, out int currentValue))
            {
                NumberTextBox.Text = (currentValue - 1).ToString();
            }
        }
        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            eventTextBox.Text = eventTextBox.Text + "sender: " + sender.ToString() + "\n";
            eventTextBox.Text = eventTextBox.Text + "source: " + e.Source.ToString() + "\n\n";
        }
        private static bool ValidateValue(object value)
        {
            if (int.TryParse((string)value, out int result) && result >= 0)
            {
                return true;
            }
            return false;
        }


    }
}