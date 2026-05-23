using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace SistemaInventario_EquipoA
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProbarConexionDB(); // Llamamos a la prueba al iniciar
        }

        private void ProbarConexionDB()
        {
            // 1. Instanciamos la clase que creaste
            ConexionDB db = new ConexionDB();
            OleDbConnection conexion = db.AbrirConexion();

            if (conexion != null)
            {
                // Mensaje de éxito
                MessageBox.Show("¡Conexión Exitosa con InventarioDB1!\nLos datos se cargarán ahora.",
                                "Prueba Superada", MessageBoxButton.OK, MessageBoxImage.Information);

                // 2. Extraemos los datos de la tabla Productos de Miguel
                string query = "SELECT * FROM Productos";
                OleDbDataAdapter adaptador = new OleDbDataAdapter(query, conexion);
                DataTable tabla = new DataTable();

                // 3. Llenamos la tabla y la mostramos en tu DataGrid
                adaptador.Fill(tabla);
                dgDatosActivos.ItemsSource = tabla.DefaultView;

                // 4. Cerramos conexión
                db.CerrarConexion();
            }
        }
    }
}