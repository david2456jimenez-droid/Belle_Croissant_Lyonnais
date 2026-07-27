namespace Belle_Croissant_Lyonnais
{
    partial class Registro_Usuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro_Usuario));
            panel1 = new Panel();
            txtBox_email = new TextBox();
            label4 = new Label();
            btn_cancelar = new Button();
            check_subsc = new CheckBox();
            txtBox_respuesta = new TextBox();
            label8 = new Label();
            btn_registrar = new Button();
            combox_preg = new ComboBox();
            label7 = new Label();
            txtBox_ConfContraseña = new TextBox();
            label5 = new Label();
            txtBox_contraseña = new TextBox();
            label6 = new Label();
            txtbox_apellido = new TextBox();
            label3 = new Label();
            txtbox_nombre = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(txtBox_email);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btn_cancelar);
            panel1.Controls.Add(check_subsc);
            panel1.Controls.Add(txtBox_respuesta);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btn_registrar);
            panel1.Controls.Add(combox_preg);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtBox_ConfContraseña);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtBox_contraseña);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtbox_apellido);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtbox_nombre);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(200, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 804);
            panel1.TabIndex = 1;
            // 
            // txtBox_email
            // 
            txtBox_email.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBox_email.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBox_email.ForeColor = SystemColors.ControlText;
            txtBox_email.Location = new Point(17, 339);
            txtBox_email.Multiline = true;
            txtBox_email.Name = "txtBox_email";
            txtBox_email.Size = new Size(361, 38);
            txtBox_email.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 313);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 17;
            label4.Text = "Correo electronico";
            // 
            // btn_cancelar
            // 
            btn_cancelar.BackColor = Color.White;
            btn_cancelar.FlatStyle = FlatStyle.Flat;
            btn_cancelar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancelar.ForeColor = Color.Black;
            btn_cancelar.Location = new Point(213, 748);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(166, 40);
            btn_cancelar.TabIndex = 16;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = false;
            btn_cancelar.Click += button1_Click;
            // 
            // check_subsc
            // 
            check_subsc.AutoSize = true;
            check_subsc.Location = new Point(18, 676);
            check_subsc.Name = "check_subsc";
            check_subsc.Size = new Size(187, 19);
            check_subsc.TabIndex = 15;
            check_subsc.Text = "Subscribirse a la lista de correo";
            check_subsc.UseVisualStyleBackColor = true;
            // 
            // txtBox_respuesta
            // 
            txtBox_respuesta.Location = new Point(150, 629);
            txtBox_respuesta.Name = "txtBox_respuesta";
            txtBox_respuesta.Size = new Size(229, 23);
            txtBox_respuesta.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(18, 629);
            label8.Name = "label8";
            label8.Size = new Size(126, 15);
            label8.TabIndex = 13;
            label8.Text = "Pregunta de seguridad";
            // 
            // btn_registrar
            // 
            btn_registrar.BackColor = Color.OrangeRed;
            btn_registrar.FlatStyle = FlatStyle.Flat;
            btn_registrar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_registrar.ForeColor = Color.White;
            btn_registrar.Location = new Point(17, 748);
            btn_registrar.Name = "btn_registrar";
            btn_registrar.Size = new Size(167, 40);
            btn_registrar.TabIndex = 8;
            btn_registrar.Text = "Registrarse";
            btn_registrar.UseVisualStyleBackColor = false;
            btn_registrar.Click += btn_ingresar_Click;
            // 
            // combox_preg
            // 
            combox_preg.DropDownStyle = ComboBoxStyle.DropDownList;
            combox_preg.FormattingEnabled = true;
            combox_preg.Location = new Point(150, 574);
            combox_preg.Name = "combox_preg";
            combox_preg.Size = new Size(229, 23);
            combox_preg.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(18, 574);
            label7.Name = "label7";
            label7.Size = new Size(126, 15);
            label7.TabIndex = 11;
            label7.Text = "Pregunta de seguridad";
            // 
            // txtBox_ConfContraseña
            // 
            txtBox_ConfContraseña.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBox_ConfContraseña.Location = new Point(18, 513);
            txtBox_ConfContraseña.Multiline = true;
            txtBox_ConfContraseña.Name = "txtBox_ConfContraseña";
            txtBox_ConfContraseña.Size = new Size(361, 38);
            txtBox_ConfContraseña.TabIndex = 10;
            txtBox_ConfContraseña.TextChanged += txtBox_ConfContraseña_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 487);
            label5.Name = "label5";
            label5.Size = new Size(122, 15);
            label5.TabIndex = 9;
            label5.Text = "Confirmar Contraseña";
            // 
            // txtBox_contraseña
            // 
            txtBox_contraseña.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBox_contraseña.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBox_contraseña.ForeColor = SystemColors.InfoText;
            txtBox_contraseña.Location = new Point(18, 421);
            txtBox_contraseña.Multiline = true;
            txtBox_contraseña.Name = "txtBox_contraseña";
            txtBox_contraseña.Size = new Size(361, 38);
            txtBox_contraseña.TabIndex = 8;
            txtBox_contraseña.TextChanged += txtBox_contraseña_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 395);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 7;
            label6.Text = "Contraseña";
            // 
            // txtbox_apellido
            // 
            txtbox_apellido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtbox_apellido.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_apellido.ForeColor = Color.Black;
            txtbox_apellido.Location = new Point(17, 264);
            txtbox_apellido.Multiline = true;
            txtbox_apellido.Name = "txtbox_apellido";
            txtbox_apellido.Size = new Size(361, 38);
            txtbox_apellido.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 238);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 5;
            label3.Text = "Apellido";
            // 
            // txtbox_nombre
            // 
            txtbox_nombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtbox_nombre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_nombre.ForeColor = SystemColors.InfoText;
            txtbox_nombre.Location = new Point(17, 164);
            txtbox_nombre.Multiline = true;
            txtbox_nombre.Name = "txtbox_nombre";
            txtbox_nombre.Size = new Size(361, 38);
            txtbox_nombre.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 146);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(130, 104);
            label1.Name = "label1";
            label1.Size = new Size(176, 25);
            label1.TabIndex = 2;
            label1.Text = "Registro de Sesion";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(160, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(90, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Registro_Usuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 924);
            Controls.Add(panel1);
            Name = "Registro_Usuario";
            Text = "Registro_Usuario";
            Load += Registro_Usuario_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_registrar;
        private TextBox txtbox_apellido;
        private Label label3;
        private TextBox txtbox_nombre;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txtBox_ConfContraseña;
        private Label label5;
        private TextBox txtBox_contraseña;
        private Label label6;
        private CheckBox check_subsc;
        private TextBox txtBox_respuesta;
        private Label label8;
        private ComboBox combox_preg;
        private Label label7;
        private Button btn_cancelar;
        private TextBox txtBox_email;
        private Label label4;
    }
}