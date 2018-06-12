using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const UInt32 SPI_SETMOUSESPEED = 0x0071;

        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, UInt32 pvParam, UInt32 fWinIni);

        private const uint defaultSpeed = 4;
        private uint mouseSpeedCounter = defaultSpeed;
        public uint MouseSpeedHolder {
            get
            {
                return mouseSpeedCounter;
            }
            set
            {
                mouseSpeedCounter = value;
                SpeedLabel.Content = mouseSpeedCounter.ToString();//value changed
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            ChangeMouseSpeed(MouseSpeedHolder);
        }

        public void ChangeMouseSpeed(uint mouseSpeed)
        {
            UInt32 SPI_SETMOUSESPEED = 0x0071;
            UInt32 MOUSESPEED = mouseSpeed; // value between 1 and 20 - sets speed of mouse

            SystemParametersInfo(
                SPI_SETMOUSESPEED,
                0,
                MOUSESPEED,
                0);

            Debug.WriteLine("Actual speed of cursor: " + mouseSpeed);
        }
        private void mouseSpeedDefault(object sender, RoutedEventArgs e)
        {
            MouseSpeedHolder = defaultSpeed;
            ChangeMouseSpeed(defaultSpeed);
            Debug.WriteLine("Default speed of cursor");
        }

        private void mouseSpeedUp(object sender, RoutedEventArgs e)
        {
            if (MouseSpeedHolder < 20)
            {
                MouseSpeedHolder = MouseSpeedHolder + 1;
                ChangeMouseSpeed(MouseSpeedHolder);
            }
            else
                Debug.WriteLine("Max speed");
        }

        private void mouseSpeedDown(object sender, RoutedEventArgs e)
        {
            if (MouseSpeedHolder > 1)
            {
                MouseSpeedHolder = MouseSpeedHolder - 1;
                ChangeMouseSpeed(MouseSpeedHolder);
            }
            else
                Debug.WriteLine("Min speed");


        }
        private void mouseSpeedMax(object sender, RoutedEventArgs e)
        {
            MouseSpeedHolder = 20;
            ChangeMouseSpeed(20);
            Debug.WriteLine("ULTRA SPEED!!!");
        }
        private void mouseSpeedMin(object sender, RoutedEventArgs e)
        {
            MouseSpeedHolder = 1;
            ChangeMouseSpeed(1);
            Debug.WriteLine("Meeeeeeeegaaaaaa Slooooow...");
        }
    }
}
