using BCrypt.Net;
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
    public partial class Registro_Usuario : Form
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        PreguntasDAO preguntasDAO = new PreguntasDAO();
        Usuario usuario = new Usuario();
        public Registro_Usuario()
        {
            InitializeComponent();
        }

        private void Registro_Usuario_Load(object sender, EventArgs e)
        {
            List<Preguntas> Lista_preg = preguntasDAO.MostrarPreguntas();

            combox_preg.DataSource = Lista_preg;
            combox_preg.DisplayMember = "Pregunta";
            combox_preg.ValueMember = "Pregunta_ID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio_de_Sesion form_login = new Inicio_de_Sesion();
            form_login.Show();
            this.Hide();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            if (txtbox_nombre.Text == "" && txtbox_apellido.Text == "" && txtBox_email.Text == "" && txtBox_contraseña.Text == "" && txtBox_ConfContraseña.Text == "" && txtBox_respuesta.Text == "")
            {
                MessageBox.Show("No deje campos vacios");
            }
            else if (combox_preg.Items == null)
            {
                MessageBox.Show("Porfavor seleccione una opcion");
                txtBox_respuesta.Text = "";
                combox_preg.Focus();
                return;
            }
            else
            {
                usuario.Email = txtBox_email.Text; //para validar que el email no exista el la (BD)


                bool verificar = usuarioDAO.validacion_email(usuario);

                if (verificar)
                {
                    MessageBox.Show("El email que intentas ingresar ya esta registrado");
                    txtBox_email.Text = "";
                    return;
                }
                else
                {
                    if (txtBox_ConfContraseña.Text != txtBox_contraseña.Text)
                    {
                        MessageBox.Show("Su contraseña no coincide intentelo de nuevo");
                        txtBox_ConfContraseña.Text = "";
                        txtBox_ConfContraseña.Focus();
                        return;
                    }
                    else
                    {

                        //Primero Encriptamos informacion importante antes de seguir antes de seguir con el siguiente proceso
                        string contraseña_cript = BCrypt.Net.BCrypt.HashPassword(txtBox_contraseña.Text);
                        string respuesta_cript = BCrypt.Net.BCrypt.HashPassword(txtBox_respuesta.Text);

                        //Agregar los Datos a las propiedade de usuario
                        usuario.Pregunta_ID = Convert.ToInt32(combox_preg.SelectedValue);
                        usuario.Nombre = txtbox_nombre.Text;
                        usuario.Apellido = txtbox_apellido.Text;
                        usuario.Email = txtBox_email.Text;
                        usuario.Contraseña = contraseña_cript;
                        usuario.Respuesta_Seguridad = respuesta_cript;
                        usuario.Suscripcion = check_subsc.Checked;

                        bool registro = usuarioDAO.registrar_usuario(usuario);//para saber si el usuario fue agregado correctamente

                        if (registro)
                        {
                            //Limpiar los textbox
                            txtBox_email.Text = "";
                            txtbox_nombre.Text = "";
                            txtbox_apellido.Text = "";
                            txtBox_ConfContraseña.Text = "";
                            txtBox_contraseña.Text = "";
                            txtBox_respuesta.Text = "";
                            MessageBox.Show($"Registro de usuario exitoso Bienvenido sr/a {txtbox_nombre.Text + " " + txtbox_apellido.Text}");
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio en error al registrar");
                        }
                    }
                }
            }

        }

        private void txtBox_contraseña_TextChanged(object sender, EventArgs e)
        {
            txtBox_contraseña.PasswordChar = '*';
        }

        private void txtBox_ConfContraseña_TextChanged(object sender, EventArgs e)
        {
            txtBox_ConfContraseña.PasswordChar = '*';
        }
    }
}
