using System;
using System.Data.OleDb;
using System.Windows;

namespace SistemaInventario_EquipoA
{
    public class ConexionDB
    {
        // La ruta apunta exactamente al archivo que subió Miguel
        private string cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=InventarioDB1.accdb;";
        private OleDbConnection conexion;

        public ConexionDB()
        {
            conexion = new OleDbConnection(cadenaConexion);
        }

        public OleDbConnection AbrirConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar la BD: " + ex.Message, "Error Crítico", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}