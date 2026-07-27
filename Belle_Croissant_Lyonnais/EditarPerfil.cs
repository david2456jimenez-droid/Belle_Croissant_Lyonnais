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
        }

        private void linkInfo_usuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Perfil_Usuario PerfilUsuario = new Perfil_Usuario(usuario);
            PerfilUsuario.Show();
            this.Show();
            this.Close();
        }

        private void EditarPerfil_Load(object sender, EventArgs e)
        {
            CargarDatosEnPantalla();
        }

        private void CargarDatosEnPantalla()
        {
            lbl_UsuarioPerfil.Text = usuario.Nombre + usuario.Apellido;
            txt_correo.Text = usuario.Email;
            txt_nombre.Text = usuario.Nombre;
            txt_apellido.Text = usuario.Apellido;
            if (!string.IsNullOrEmpty(usuario.Foto_Perfil))
            {
                Foto_perfil.Image = Image.FromFile(usuario.Foto_Perfil);
            }
            txt_telefono.Text = usuario.Telefono ?? ""; //por si viene null, usar vacio
            if (usuario.Metodo_Entrega)
            {
                radiobtn_Domicilio.Checked = true;
            }
            else
            {
                radiobtn_Recoger.Checked = true;
            }

            // Para "Eliminar dirección" -> todas las direcciones
            List<Direccion> todasLasDirecciones = direccionDAO.ObtenerDireccionesPorUsuario(usuario.Usuario_ID);
            combox_elimidirec.DataSource = null;
            combox_elimidirec.DataSource = todasLasDirecciones;
            combox_elimidirec.DisplayMember = "Direccion_";
            combox_elimidirec.ValueMember = "Direccion_ID";
            combox_elimidirec.SelectedIndex = -1;

            // Para "Agregar Favoritos" -> solo las que NO son favoritas
            List<Direccion> noFavoritas = direccionDAO.ObtenerDireccionesPorUsuario(usuario.Usuario_ID, false);
            combox_FavoritoDirec.DataSource = null;
            combox_FavoritoDirec.DataSource = noFavoritas;
            combox_FavoritoDirec.DisplayMember = "Direccion_";
            combox_FavoritoDirec.ValueMember = "Direccion_ID";
            combox_FavoritoDirec.SelectedIndex = -1;

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

        private void btn_cancelElim_Click(object sender, EventArgs e)
        {
            combox_elimidirec.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtbox_Lugar.Text = "";
            txt_direccion.Text = "";
            txt_direccion.Enabled = false;
            checkpreferencia.Enabled = false;
        }

        private void btn_cancelAgreg_Click(object sender, EventArgs e)
        {
            combox_FavoritoDirec.SelectedIndex = -1;
        }

        private void btn_cancelElimFav_Click(object sender, EventArgs e)
        {
            combox_eliminFavorit.SelectedIndex = -1;
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
            if (txt_correo.Text != "")
            {
                if (txt_correo.Text.EndsWith("@gmail.com") || txt_correo.Text.EndsWith("@hotmail.com"))
                {
                    usuario.Email = txt_correo.Text;
                }
                else
                {
                    MessageBox.Show("Correo ingresado no valido");
                    return;
                }
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
            if (radiobtn_Domicilio.Checked)
            {
                usuario.Metodo_Entrega = true;
            }
            if (radiobtn_Recoger.Checked)
            {
                usuario.Metodo_Entrega = false;
            }

            if (txtbox_Lugar.Text == "")
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
                direccion.Lugar = txtbox_Lugar.Text;
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
                int direccionIdFavorito = Convert.ToInt32(combox_FavoritoDirec.SelectedValue);
                direccionDAO.MarcarComoFavorita(direccionIdFavorito, usuario.Usuario_ID);
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
            {
                MessageBox.Show("Perfil actualizado correctamente");

                //refrescar pantalla
                usuario = usuarioDAO.ObtenerUsuarioPorEmail(usuario.Email);
                CargarDatosEnPantalla();
            }

            else
            {
                MessageBox.Show("No se pudo actualizar el perfil");
            }

        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {

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

        private void txtbox_Lugar_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_Lugar.Text != "")
            {
                txt_direccion.Enabled = true;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Historial_Pedidos historial = new Historial_Pedidos(usuario);
            historial.Show();
            this.Hide();
        }
    }
}
