using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ProyectoAvenger
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Superheroe> listaMarvel;

        public MainWindow()
        {
            InitializeComponent();
            listaMarvel = Superheroe.GetSamples();

            // Numeros del pie de página
            primerNumeroTextBlock.Text = ((listaMarvel.Count() + 1) - listaMarvel.Count()).ToString();
            segundoNumeroTextBlock.Text = " / " + listaMarvel.Count().ToString();

            // El resto
            fondoDockPanel.DataContext = listaMarvel.First();
        }

        private void villanoRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            vengadoresCheckBox.IsEnabled = false;
            vengadoresCheckBox.IsChecked = false;
            xmenCheckBox.IsEnabled = false;
            xmenCheckBox.IsChecked = false;
        }

        private void villanoRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            vengadoresCheckBox.IsEnabled = true;
            xmenCheckBox.IsEnabled = true;
        }

        private void flechaAtrasImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int numero = int.Parse(primerNumeroTextBlock.Text);

            if(numero > 1)
            {
                numero--;
                primerNumeroTextBlock.Text = numero.ToString();
                fondoDockPanel.DataContext = listaMarvel[numero -1];
            }
        }

        private void flechaAdelanteImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int numero = int.Parse(primerNumeroTextBlock.Text);

            if (numero < listaMarvel.Count())
            {
                numero++;
                primerNumeroTextBlock.Text = numero.ToString();
                fondoDockPanel.DataContext = listaMarvel[numero -1];
            }
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            if(EscribirNombreTextBox.Text.Length > 0 && UrlImagenTextBox.Text.Length > 0)
            {
                if((bool)heroeRadioButton.IsChecked && !(bool)vengadoresCheckBox.IsChecked && !(bool)xmenCheckBox.IsChecked)
                {
                    MessageBox.Show("Debes de elegir si el heroes es un Vengador o Xmen....");
                }
                else
                {
                    Superheroe nuevo = new Superheroe(EscribirNombreTextBox.Text, UrlImagenTextBox.Text, (bool)vengadoresCheckBox.IsChecked, (bool)xmenCheckBox.IsChecked, (bool)heroeRadioButton.IsChecked, (bool)villanoRadioButton.IsChecked);
                    listaMarvel.Add(nuevo);
                    MessageBox.Show("Nuevo personaje añadido ");
                    segundoNumeroTextBlock.Text = " / "  + listaMarvel.Count().ToString();
                    limpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Debes de dar un nombre e imagen al personaje....");
            }
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
        }

        private void segundaPestañaDockPanel_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Escape)
            {
                limpiarCampos();
            }
            
        }

        private void limpiarCampos()
        {
            EscribirNombreTextBox.Text = "";
            UrlImagenTextBox.Text = "";
            heroeRadioButton.IsChecked = true;

            vengadoresCheckBox.IsEnabled = true;
            vengadoresCheckBox.IsChecked = false;

            xmenCheckBox.IsEnabled = true;
            xmenCheckBox.IsChecked = false;
        }
    }
}