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
    public partial class Perfil_Usuario : Form
    {
        Usuario usuario;
        DireccionDAO direccionDAO = new DireccionDAO();
        public Perfil_Usuario(Usuario usuariolog)
        {
            InitializeComponent();
            usuario = usuariolog;
        }

        private void Perfil_Usuario_Load(object sender, EventArgs e)
        {
            lblNombre.Text = usuario.Nombre;
            lbl_Apellido.Text = usuario.Apellido;
            lblTelefono.Text = usuario.Telefono;
            lblcorreoelectronico.Text = usuario.Email;
            if (!string.IsNullOrEmpty(usuario.Foto_Perfil))
            {
                Foto_perfil.Image = Image.FromFile(usuario.Foto_Perfil);
            }
            List<Direccion> direcciones = direccionDAO.ObtenerDireccionesPorUsuario(usuario.Usuario_ID);

            Direccion direccionHogar = direcciones.FirstOrDefault(d => d.Tipo == "Hogar");
            Direccion direccionTrabajo = direcciones.FirstOrDefault(d => d.Tipo == "Trabajo");

            lbl_direccionhog.Text = direccionHogar != null ? direccionHogar.Direccion_ : "";
            lbldirecciontrab.Text = direccionTrabajo != null ? direccionTrabajo.Direccion_ : "";
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inicio_de_Sesion dev_inicio = new Inicio_de_Sesion();
            dev_inicio.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditarPerfil nav_editperfil = new EditarPerfil(usuario);
            nav_editperfil.Show();
            this.Hide();
        }
    }
}
