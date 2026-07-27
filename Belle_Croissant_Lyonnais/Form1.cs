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
    public partial class Form1 : Form
    {
        Usuario usuario;
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        PreguntasDAO PreguntasDAO = new PreguntasDAO();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            usuario = usuarioDAO.ObtenerUsuarioPorEmail(txt_email.Text);

            if (txt_email.Text == "")
            {
                MessageBox.Show("Favor no dejar el campo vacio");
                return;
            }
            if (usuario == null)
            {
                MessageBox.Show("Ese email no esta registrado");
                lbl_pregunta.Text = "";
                return;
            }
            lbl_pregunta.Text = PreguntasDAO.ObtenerTextoPregunta(usuario.Pregunta_ID);
            txtbox_respuesta.Enabled = true;
        }

        private void btn_verificar_Click(object sender, EventArgs e)
        {
            bool respuestaCorrecta = BCrypt.Net.BCrypt.Verify(txtbox_respuesta.Text, usuario.Respuesta_Seguridad);

            if (respuestaCorrecta)
            {
                MessageBox.Show("Respuesta correcta. Ya pueded cambiar tu contraseña");

                txtbox_contraseña.Enabled = true;
                txtbox_reestcontraseña.Enabled = true;
                btn_reestablecer.Enabled = true;
            }
            else
            {
                MessageBox.Show("La respuesta de seguridad es incorrecta");
            }
        }

        private void btn_reestablecer_Click(object sender, EventArgs e)
        {
            if (txtbox_contraseña.Text != txtbox_reestcontraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }

            if (string.IsNullOrEmpty(txtbox_contraseña.Text))
            {
                MessageBox.Show("La contraseña no puede estar vacía");
                return;
            }

            string nuevaContraseñaHash = BCrypt.Net.BCrypt.HashPassword(txtbox_contraseña.Text);
            bool actualizado = usuarioDAO.ActualizarContraseña(usuario.Usuario_ID, nuevaContraseñaHash);

            if (actualizado)
            {
                MessageBox.Show("Contraseña actualizada correctamente");
                Inicio_de_Sesion regresar = new Inicio_de_Sesion();
                regresar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar la contraseña");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Inicio_de_Sesion regresar = new Inicio_de_Sesion();
            regresar.Show();
            this.Hide();
        }

        private void txtbox_contraseña_TextChanged(object sender, EventArgs e)
        {
            txtbox_contraseña.PasswordChar = '#';
        }

        private void txtbox_reestcontraseña_TextChanged(object sender, EventArgs e)
        {
            txtbox_contraseña.PasswordChar = '#';
        }
    }
}
