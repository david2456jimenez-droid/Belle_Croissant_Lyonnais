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
            ConfigurarColumnaGrid();
            CargadataDireccion();
            lbl_UsuarioPerfil.Text = usuario.Nombre + " " + usuario.Apellido;
            lblNombre.Text = usuario.Nombre;
            lbl_Apellido.Text = usuario.Apellido;
            lblTelefono.Text = usuario.Telefono;
            lblcorreoelectronico.Text = usuario.Email;
            if (usuario.Metodo_Entrega)
            {
                radiobtn_domicilio.Checked = true;
            }
            else
            {
                radiobtn_recoger.Checked = true;
            }
            if (!string.IsNullOrEmpty(usuario.Foto_Perfil))
            {
                Foto_perfil.Image = Image.FromFile(usuario.Foto_Perfil);
            }
        }

        private void ConfigurarColumnaGrid()
        {
            dataG_direcciones.AutoGenerateColumns = false;
            dataG_direcciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Direccion_ID",
                Name = "DireccionID",
                Visible = false
            });

            dataG_direcciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Lugar",
                HeaderText = "Lugar",
                Name = "colLugar"
            });

            dataG_direcciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Direccion_",
                HeaderText = "Direccion",
                Name = "colDireccion"
            });

            dataG_direcciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Preferencia",
                HeaderText = "Favorita",
                Name = "Preferencia",
                Visible = false
            });
        }
        private void CargadataDireccion()
        {
            List<Direccion> direcciones = direccionDAO.ObtenerDireccionesPorUsuario(usuario.Usuario_ID);
            dataG_direcciones.DataSource = null;
            dataG_direcciones.DataSource = direcciones;

            foreach (DataGridViewRow fila in dataG_direcciones.Rows)
            {
                bool Preferida = Convert.ToBoolean(fila.Cells["Preferencia"].Value);

                if (Preferida)
                {
                    fila.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
            }
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Historial_Pedidos historial = new Historial_Pedidos(usuario);
            historial.Show();
            this.Hide();
        }
    }
}
