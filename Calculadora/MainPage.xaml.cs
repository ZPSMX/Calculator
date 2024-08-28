
using System.Diagnostics;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        string operador;
        string numeroActual = "";
        double primerNumero;
        double segundoNumero;

        public MainPage()
        {
            InitializeComponent();
            PantallaTexto= "0";

        }

        public string PantallaTexto
        {
            get => Pantalla.Text;
            set => Pantalla .Text = value;
        }
        private void NumeroPresionado(object sender, EventArgs e)
        {
            var button = sender as Button;
            numeroActual += button.Text;
            if (numeroActual.Length >= 11) {
                PantallaTexto = "SYNTAX ERROR";
            }else
           
            PantallaTexto = numeroActual;
            
            Debug.WriteLine(numeroActual);
        }

        private void OperadorSeleccionado(object sender, EventArgs e)
        {
            var button = sender as Button;
            operador = button.Text;
            primerNumero = Convert.ToDouble(numeroActual);
            numeroActual = "";
            Debug.WriteLine(operador);

        }

        private void Resultado_Clicked(object sender, EventArgs e)
        {
            segundoNumero = Convert.ToDouble(numeroActual);

            double resultado = 0;

            switch (operador)
            {
                case "+":
                    resultado = primerNumero + segundoNumero;
                    break;

                case "-":
                    resultado = primerNumero - segundoNumero;
                    break;
                case "*":
                    resultado = primerNumero * segundoNumero;
                    break;
                case "/":
                    resultado = primerNumero / segundoNumero;
                    break;
            }
            PantallaTexto = resultado.ToString();
            numeroActual = resultado.ToString();

        }

        private void BorrarTodo_Clicked(object sender, EventArgs e)
        {
            numeroActual = "";
            operador = "";
            PantallaTexto = "0";
        }

        private void BorrarUno_Clicked(object sender, EventArgs e)
        {
            if (numeroActual.Length > 0)
            {
                numeroActual = numeroActual.Remove(numeroActual.Length - 1);
                PantallaTexto = numeroActual.ToString();
            }
            if (numeroActual.Length <= 0)
            {
                PantallaTexto = "0";
            }
        }

        private async void Copiar_Clicked(object sender, EventArgs e)
        {
            string valorCopiado = Pantalla.Text;
            if (!string.IsNullOrEmpty(valorCopiado))
            {
                // Copia el texto al portapapeles
                Clipboard.SetTextAsync(valorCopiado);
                
                var toast = Toast.Make("Operacion copiada", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
                await toast.Show();

            }
        }
    }

}
