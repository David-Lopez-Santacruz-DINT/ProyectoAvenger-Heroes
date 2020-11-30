using System.Collections.Generic;
using System.Windows;

namespace ProyectoAvenger
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Superheroe> listaMarvel;
        Superheroe super {get; set;}

        public MainWindow()
        {
            InitializeComponent();

            listaMarvel = LlenaLista();

            //Mostrar total de personajes
            primerNumeroTextBlock.Text = (listaMarvel.Count + 1 - listaMarvel.Count).ToString();
            segundoNumeroTextBlock.Text = "/" + listaMarvel.Count.ToString();

            super = listaMarvel[int.Parse(primerNumeroTextBlock.Text) -1 ];

            // Mostrar Nombre Heroe o Villano
            nombreHeroeTextBlock.DataContext = super;

            // Mostrar u ocultar logo
            if (super.Vengador && super.Xmen)
            {
                logoAvenImage.Visibility = Visibility.Visible;
                logoXmenImage.Visibility = Visibility.Visible;
            }
            else if(!super.Xmen)
            {
                logoXmenImage.Visibility = Visibility.Collapsed;
            }
            else if (!super.Vengador)
            {
                logoAvenImage.Visibility = Visibility.Collapsed;
            }

            // Mostrar Imagen
            fondoImage.DataContext = super;

            // Color de fondo
            if ((bool)heroeRadioButton.IsChecked)
            {
                
            }

        }

        List<Superheroe> LlenaLista()
        {
            List<Superheroe> lista = new List<Superheroe>();

            Superheroe ironman = new Superheroe("Ironman", @"https://sm.ign.com/ign_latam/screenshot/default/ybbpqktez5whedr0-1592031889_31aa.jpg", true, false, true, false);
            Superheroe kingpin = new Superheroe("Kingpin", @"https://www.comicbasics.com/wp-content/uploads/2017/09/Kingpin.jpg", false, false, false, true);
            Superheroe spiderman = new Superheroe("Spiderman", @"https://wipy.tv/wp-content/uploads/2019/08/destino-de-%E2%80%98Spider-Man%E2%80%99-en-los-Comics.jpg", true, true, true, false);

            lista.Add(ironman);
            lista.Add(kingpin);
            lista.Add(spiderman);

            return lista;
        }

        private void villanoRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (villanoRadioButton.IsChecked == true)
            {
                vengadoresCheckBox.IsEnabled = false;
                vengadoresCheckBox.IsChecked = false;
                xmenCheckBox.IsEnabled = false;
                xmenCheckBox.IsChecked = false;
            }
            if(heroeRadioButton.IsChecked == true)
            {
                vengadoresCheckBox.IsEnabled = true;
                xmenCheckBox.IsEnabled = true;
            }
        }

        private void flechaAtrasImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int numero = int.Parse(primerNumeroTextBlock.Text);

            if (numero > 1)
            {
                numero--;
                primerNumeroTextBlock.Text = numero.ToString();
                super = listaMarvel[numero - 1];
                
            }
        }

        private void flechaAdelanteImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int numero = int.Parse(primerNumeroTextBlock.Text);
            if (numero < listaMarvel.Count)
            {
                numero++;
                primerNumeroTextBlock.Text = numero.ToString();
                super = listaMarvel[numero - 1];
            }
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            if(nombreHeroeTextBlock.Text.Length > 0 && UrlImagenTextBox.Text.Length > 0)
            {
                if((bool)heroeRadioButton.IsChecked && !(bool)vengadoresCheckBox.IsChecked && !(bool)xmenCheckBox.IsChecked)
                {
                    MessageBox.Show("Debes de elegir si el heroes es un Vengador o Xmen....");
                }
                else
                {
                    Superheroe nuevo = new Superheroe(nombreHeroeTextBlock.Text, UrlImagenTextBox.Text, (bool)vengadoresCheckBox.IsChecked, (bool)xmenCheckBox.IsChecked, (bool)heroeRadioButton.IsChecked, (bool)villanoRadioButton.IsChecked);
                    listaMarvel.Add(nuevo);
                    MessageBox.Show("Nuevo personaje añadido ");
                    segundoNumeroTextBlock.Text = "/" + listaMarvel.Count.ToString();
                }
            }
            else
            {
                MessageBox.Show("Debes de dar un nombre e imagen al personaje....");
            }
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
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
