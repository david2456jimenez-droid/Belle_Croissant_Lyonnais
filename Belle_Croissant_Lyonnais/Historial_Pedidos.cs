using MisClases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Belle_Croissant_Lyonnais
{
    public partial class Historial_Pedidos : Form
    {
        Usuario usuario;
        public Historial_Pedidos(Usuario usuarioRecibido)
        {
            InitializeComponent();
            usuario = usuarioRecibido;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inicio_de_Sesion regresar = new Inicio_de_Sesion();
            regresar.Show();
            this.Hide();
        }
        private void linkInfo_usuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Perfil_Usuario perfil = new Perfil_Usuario(usuario);
        }
    }
}
