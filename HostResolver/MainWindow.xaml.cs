using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace HostResolver
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string MENSAGEM = "O campo 'IP/Hostname' não pode ser vazio..!!!";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertToIP(object sender, RoutedEventArgs e)
        {
            ConvertHostToIP();
        }

        private void ConvertToHost(object sender, RoutedEventArgs e)
        {
            ConvertIPToHost();
        }

        private void ConvertIPToHost()
        {
            string texto = txtInput.Text;

            if (string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show(MENSAGEM);
                txtResult.Text = string.Empty;
            }
            else
            {
                var iphost = Dns.GetHostEntry(texto);
                string host = iphost.ToString();

                if (string.IsNullOrEmpty(host))
                {
                    MessageBox.Show(MENSAGEM);
                    txtResult.Text = string.Empty;
                }
                else
                    txtResult.Text = iphost.HostName;
            }
        }

        private void ConvertHostToIP()
        {
            string texto = txtInput.Text;

            if (string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show(MENSAGEM);
                txtResult.Text = string.Empty;
            }
            else
            {
                var iphost = Dns.GetHostAddresses(texto);

                foreach (IPAddress endereco in iphost)
                {
                    txtResult.Text = endereco.ToString();
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }
    }
}