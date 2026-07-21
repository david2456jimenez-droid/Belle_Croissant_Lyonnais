using MisClases;

namespace Belle_Croissant_Lyonnais
{
    public partial class Inicio_de_Sesion : Form
    {
        Usuario usuario = new Usuario();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        public Inicio_de_Sesion()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = usuarioDAO.ObtenerUsuarioPorEmail(txt_correo.Text);

            if (usuario != null && BCrypt.Net.BCrypt.Verify(txtbox_contraseña.Text, usuario.Contraseña))
            {
                MessageBox.Show("Bienvenido " + usuario.Nombre);
                Perfil_Usuario perfil = new Perfil_Usuario(usuario);
                perfil.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecto intentelo de nuevo");
            }
        }

        private void link_registrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro_Usuario opcion_register = new Registro_Usuario();
            opcion_register.Show();
            this.Hide();
        }

        private void txtbox_contraseña_TextChanged(object sender, EventArgs e)
        {
            txtbox_contraseña.PasswordChar = '*';
        }

        private void link_recuperacion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
