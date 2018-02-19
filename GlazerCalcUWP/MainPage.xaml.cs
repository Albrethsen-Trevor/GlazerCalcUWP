using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalcUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double width, height, woodLength, glassArea;
            string widthString, heightString;

            widthString = widthBox.Text;
            heightString = heightBox.Text;

            if ((widthString == "") || (heightString == ""))
            {
                var dialog = new MessageDialog(
                    "Please enter width or height.", "Width and/or Height Missing");
                var reponse = await dialog.ShowAsync();
            }
            else
            {
                widthString = widthBox.Text;
                heightString = heightBox.Text;

                width = double.Parse(widthString);
                height = double.Parse(heightString);
                woodLength = 2 * (width + height) * 3.25;
                glassArea = 2 * (width * height);

                var ouputCalc = new MessageDialog(
                "Width: " + width + "\n" + "\n" +
                "Height: " + height + "\n" + "\n" +
                "The length of woodframe is " + woodLength + " feet" + "\n" + "\n" +
                "The area of the glass is " + glassArea + " square meteres" + "\n" + "\n" +
                "Date Ordered: " + DateTime.Now);
                var result = await ouputCalc.ShowAsync();
            }

            //if (widthString == "")
            //{
            //    var dialog = new MessageDialog("Please enter width.", "Enter Width");
            //    var result = await dialog.ShowAsync();
            //}

            //if (heightString == "")
            //{
            //    var dialog = new MessageDialog("Please enter height.", "Enter Height");
            //    var result = await dialog.ShowAsync();
            //}
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }


        // Took me forever to find this...
        //Link---https://social.msdn.microsoft.com/Forums/en-US/47355657-6e48-4952-8fae-da84960f5fe0/checking-if-textbox-input-is-a-number-or-not?forum=csharplanguage
        private async void widthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tString = widthBox.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    var wrongWidth = new MessageDialog("Please enter a number for width.");
                    widthBox.Text = "";
                    var enterWidth = await wrongWidth.ShowAsync();
                    return;
                }
            }
        }

        private async void heightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tString = heightBox.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    var wrongHeight = new MessageDialog("Please enter a number for height.");
                    heightBox.Text = "";
                    var enterHeight = await wrongHeight.ShowAsync();
                    return;
                }
            }
        }

        //private void widthBox_KeyDown(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
