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
    public partial class EditarPerfil : Form
    {
        Usuario usuario;
        Direccion direccion = new Direccion();
        DireccionDAO direccionDAO = new DireccionDAO();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        bool Foto = false;
        public EditarPerfil(Usuario usuarioedit)
        {
            InitializeComponent();
            usuario = usuarioedit;
            combox_TipoDirec.Items.Add("Hogar");
            combox_TipoDirec.Items.Add("Trabajo");
        }

        private void linkInfo_usuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Perfil_Usuario PerfilUsuario = new Perfil_Usuario(usuario);
            PerfilUsuario.Show();
            this.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void EditarPerfil_Load(object sender, EventArgs e)
        {
            txt_correo.Text = usuario.Email;
            txt_nombre.Text = usuario.Nombre;
            txt_apellido.Text = usuario.Apellido;
            txt_telefono.Text = usuario.Telefono ?? ""; //por si viene null, usar vacio

            // Para "Eliminar dirección" -> todas las direcciones
            List<Direccion> todasLasDirecciones = direccionDAO.ObtenerDireccionesPorUsuario(usuario.Usuario_ID);
            combox_elimidirec.DataSource = null;
            combox_elimidirec.DataSource = todasLasDirecciones;
            combox_elimidirec.DisplayMember = "Direccion_";
            combox_elimidirec.ValueMember = "Direccion_ID";
            combox_eliminFavorit.SelectedIndex = -1;

            // Para "Agregar Favoritos" -> solo las que NO son favoritas
            List<Direccion> noFavoritas = direccionDAO.ObtenerDireccionesPorUsuario(usuario.Usuario_ID, false);
            combox_FavoritoDirec.DataSource = null;
            combox_FavoritoDirec.DataSource = noFavoritas;
            combox_FavoritoDirec.DisplayMember = "Direccion_";
            combox_FavoritoDirec.ValueMember = "Direccion_ID";
            combox_eliminFavorit.SelectedIndex = -1;

            // Para "Eliminar de Favoritos" -> solo las que SÍ son favoritas
            List<Direccion> siFavoritas = direccionDAO.ObtenerDireccionesPorUsuario(usuario.Usuario_ID, true);
            combox_eliminFavorit.DataSource = null;
            combox_eliminFavorit.DataSource = siFavoritas;
            combox_eliminFavorit.DisplayMember = "Direccion_";
            combox_eliminFavorit.ValueMember = "Direccion_ID";
            combox_eliminFavorit.SelectedIndex = -1;

            usuario.Nombre = txt_nombre.Text;
            usuario.Apellido = txt_apellido.Text;
            usuario.Email = txt_correo.Text;

            checksubs.Checked = usuario.Suscripcion;

            if (usuario.Telefono != null)
            {
                usuario.Telefono = txt_telefono.Text;
            }

        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            usuario.Nombre = txt_nombre.Text;
            usuario.Apellido = txt_apellido.Text;
        }

        private void btn_cancelElim_Click(object sender, EventArgs e)
        {
            combox_elimidirec.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            combox_TipoDirec.Text = "";
            txt_direccion.Enabled = false;
            checkpreferencia.Enabled = false;
        }

        private void btn_cancelAgreg_Click(object sender, EventArgs e)
        {
            combox_FavoritoDirec.Text = "";
        }

        private void btn_cancelElimFav_Click(object sender, EventArgs e)
        {
            combox_eliminFavorit.Text = "";
        }

        private void btn_Guardar_Click_1(object sender, EventArgs e)
        {
            if (txt_telefono.Text != "")
            {
                usuario.Telefono = txt_telefono.Text;
            }
            if (txt_nombre.Text != "")
            {
                usuario.Nombre = txt_nombre.Text;
            }
            if (txt_apellido.Text != "")
            {
                usuario.Apellido = txt_apellido.Text;
            }
            if (checksubs.Checked)
            {
                usuario.Suscripcion = true;
            }
            else
            {
                usuario.Suscripcion = false;
            }

            if (combox_TipoDirec.SelectedItem == null)
            {

            }
            else
            {
                if (checkpreferencia.Checked)
                {
                    direccion.Preferencia = true;
                }
                else
                {
                    direccion.Preferencia = false;
                }
                direccion.Tipo = combox_TipoDirec.SelectedItem.ToString();
                direccion.Direccion_ = txt_direccion.Text;


                DireccionDAO direccionDAO = new DireccionDAO();
                direccionDAO.AgregarDireccion(direccion, usuario.Usuario_ID);
            }
            if (combox_elimidirec.SelectedItem == null)
            {

            }
            else
            {
                direccion.eliminardireccion = combox_elimidirec.SelectedItem.ToString();
            }
            if (combox_FavoritoDirec.SelectedItem == null)
            {

            }
            else
            {
                direccion.favoritos = combox_FavoritoDirec.SelectedItem.ToString();
            }
            if (combox_eliminFavorit.SelectedItem == null)
            {

            }
            else
            {
                direccion.eliminar_fav = combox_eliminFavorit.SelectedItem.ToString();
            }

            //---------------------------------------------------------------------------------------------//
            bool actualizado = usuarioDAO.ActualizarUsuario(usuario);

            if (actualizado)
                MessageBox.Show("Perfil actualizado correctamente");
            else
                MessageBox.Show("No se pudo actualizar el perfil");

        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void combox_TipoDirec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combox_TipoDirec.SelectedItem == null)
            {
                txt_direccion.Enabled = false;
                checkpreferencia.Enabled = false;
            }
            else
            {
                txt_direccion.Enabled = true;
                checkpreferencia.Enabled = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog cargarimg = new OpenFileDialog();
            cargarimg.Filter = "Imágenes|*.jpg;*.jpeg;*.png";

            if (cargarimg.ShowDialog() == DialogResult.OK)
            {
                Foto_perfil.Image = Image.FromFile(cargarimg.FileName);
                usuario.Foto_Perfil = cargarimg.FileName; //guardar la rura en el objeto
                Foto = true;
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inicio_de_Sesion cerrasesion = new Inicio_de_Sesion();
            cerrasesion.Show();
            this.Hide();
            this.Close();
        }
    }
}
