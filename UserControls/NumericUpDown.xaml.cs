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
        private int _valueChanging;

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
            propMetadata.DefaultValue = 0;
            propMetadata.PropertyChangedCallback = ValueChangedCallback;

            ValueProprerty = DependencyProperty.Register
                         (
                             "Value",
                             typeof(int),
                             typeof(NumericUpDown),
                             propMetadata
                         );
        }

        private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (NumericUpDown)d;
            obj.tbCur_value.Text = obj.Value.ToString();
        }

        #region int PLACES
        public int int_Places
        {
            get { return (int)GetValue(int_PlacesProperty); }
            set
            {
                SetValue(int_PlacesProperty, value);
            }
        }

        public static readonly DependencyProperty int_PlacesProperty =
            DependencyProperty.Register("int_Places", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0.0)
            {
                DefaultValue = 0,
                PropertyChangedCallback = PlacesChangedCallback
            });

        private static void PlacesChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (NumericUpDown)d;
            String.Format($"N{obj.int_Places.ToString()}", obj.tbCur_value);

        }
        #endregion

        #region VALUE
        public int Value
        {
            get { return (int)GetValue(ValueProprerty); }
            set
            {
                SetValue(ValueProprerty, value);
            }
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            Value += _valueChanging;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            Value -= _valueChanging;
        }
        #endregion

        private void tbCur_value_TextChanged(object sender, TextChangedEventArgs e)
        {
            int temp = 0;
            if (Int32.TryParse(tbCur_value.Text, out temp))
            {
                Value = temp;
            }
        }
    }
}
