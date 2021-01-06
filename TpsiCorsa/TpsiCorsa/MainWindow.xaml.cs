using System;
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
using System.Threading;

namespace TpsiCorsa
{
   
    public partial class MainWindow : Window
    {
        Thread t1;
        Thread t2;
        Thread t3;
        Random r;
        Thickness navicella1Partenza;
        Thickness navicella2Partenza;
        Thickness navicella3Partenza;

        public MainWindow()
        {
            InitializeComponent();
            r = new Random();
            navicella1Partenza = imgMacchina1.Margin;
            navicella2Partenza = imgMacchina2.Margin;
            navicella3Partenza = imgMacchina3.Margin;
        }
        public void MetodoMovimento(Image img)
        {
            try
            {
                int marginLeft = 0;
                int marginTop = 0;
                int marginBottom = 0;
                int marginRight = 0;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    marginLeft = (int)img.Margin.Left;
                    marginTop = (int)img.Margin.Top;
                    marginBottom = (int)img.Margin.Bottom;
                    marginRight = (int)img.Margin.Right;
                }));
                while (marginLeft < 700)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 751)));
                    marginLeft += 50;
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        img.Margin = new Thickness(marginLeft, marginTop, marginBottom, marginRight);
                    }));
                }
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (img.Name.Contains("1"))
                    {
                        lstPodio.Items.Add("Macchina arancione");
                    }
                    else if (img.Name.Contains("2"))
                    {
                        lstPodio.Items.Add("Macchina verde");
                    }
                    else if (img.Name.Contains("3"))
                    {
                        lstPodio.Items.Add("Macchina rossa");
                    }
                    if (lstPodio.Items.Count == 3)
                    {
                        btnInizia.IsEnabled = true;
                    }
                }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MovimentoMacchina1()
        {
            try
            {
                MetodoMovimento(imgMacchina1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MovimentoMacchina2()
        {
            try
            {
                MetodoMovimento(imgMacchina2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MovimentoMacchina3()
        {
            try
            {
                MetodoMovimento(imgMacchina3);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnInizia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnInizia.IsEnabled = false;

                lstPodio.Items.Clear();
                imgMacchina1.Margin = navicella1Partenza;
                imgMacchina2.Margin = navicella2Partenza;
                imgMacchina3.Margin = navicella3Partenza;
                t1 = new Thread(new ThreadStart(MovimentoMacchina1));
                t2 = new Thread(new ThreadStart(MovimentoMacchina2));
                t3 = new Thread(new ThreadStart(MovimentoMacchina3));
                t1.Start();
                t2.Start();
                t3.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
