using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompEd
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection coneccion = new SqlConnection("server=JORGEHDZ\\SQLEXPRESS ; database = SISTEMA ; INTEGRATED SECURITY = true");

        private void button1_Click(object sender, EventArgs e)
        {
            
            coneccion.Open();
            SqlCommand comando = new SqlCommand("SELECT USUARIO, CONTRASEÑA FROM PERSONA WHERE USUARIO = @vusuario AND CONTRASEÑA = @vcontraseña", coneccion);
            comando.Parameters.AddWithValue("@vusuario", txtUsuario.Text);
            comando.Parameters.AddWithValue("@vcontraseña", txtContraseña.Text);

            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                coneccion.Close();
                ini pantalla = new ini();
                pantalla.Show();
            }
        }
    }
}
