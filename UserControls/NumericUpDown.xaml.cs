using System;
using System.Windows;
using System.Windows.Controls;

namespace UserControls
{
    /// <summary>
    /// Логика взаимодействия для NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {

        private decimal _valueChanging;

        public NumericUpDown()
        {
            InitializeComponent();
            tbCur_value.Text = Value.ToString();
            Value = 10;
            _valueChanging = 1;
        }

        public static DependencyProperty ValueProprerty;

        static NumericUpDown()
        {
            FrameworkPropertyMetadata propMetadata = new FrameworkPropertyMetadata();
            propMetadata.DefaultValue = 0m;
            propMetadata.PropertyChangedCallback = ValueChangedCallback;

            ValueProprerty = DependencyProperty.Register
                         (
                             "Value",
                             typeof(decimal),
                             typeof(NumericUpDown),
                             propMetadata
                         );
        }

        private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (NumericUpDown)d;
            obj.tbCur_value.Text = obj.Value.ToString();
        }

        #region DECIMAL PLACES
        public decimal Decimal_Places
        {
            get { return (decimal)GetValue(Decimal_PlacesProperty); }
            set
            {
                if (value != 0m) _valueChanging = 0.33m;
                else _valueChanging = 1m;
                SetValue(Decimal_PlacesProperty, value);
            }
        }

        public static readonly DependencyProperty Decimal_PlacesProperty =
            DependencyProperty.Register("Decimal_Places", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(0.0)
            {
                DefaultValue = 0m,
                PropertyChangedCallback = PlacesChangedCallback
            });

        private static void PlacesChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (NumericUpDown)d;
            String.Format($"N{obj.Decimal_Places.ToString()}", obj.tbCur_value);

        }
        #endregion

        #region VALUE
        public decimal Value
        {
            get { return (decimal)GetValue(ValueProprerty); }
            set
            {
                SetValue(ValueProprerty, value);
            }
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
                Value -= _valueChanging;
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
                Value += _valueChanging;
        }
        #endregion

    }
}
