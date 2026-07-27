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
            perfil.Show();
            this.Hide();
        }

        private void linkEditar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditarPerfil editar = new EditarPerfil(usuario);
            editar.Show();
            this.Hide();
        }

        private void Historial_Pedidos_Load(object sender, EventArgs e)
        {
            lbl_UsuarioPerfil.Text = usuario.Nombre + " " + usuario.Apellido;
            if (!string.IsNullOrEmpty(usuario.Foto_Perfil))
            {
                Foto_perfil.Image = Image.FromFile(usuario.Foto_Perfil);
            }
        }
    }
}
