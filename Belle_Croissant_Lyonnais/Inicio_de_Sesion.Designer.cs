namespace Belle_Croissant_Lyonnais
{
    partial class Inicio_de_Sesion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio_de_Sesion));
            panel1 = new Panel();
            link_registrarse = new LinkLabel();
            label4 = new Label();
            btn_ingresar = new Button();
            link_recuperacion = new LinkLabel();
            txtbox_contraseña = new TextBox();
            label3 = new Label();
            txt_correo = new TextBox();
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
            panel1.Controls.Add(link_registrarse);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btn_ingresar);
            panel1.Controls.Add(link_recuperacion);
            panel1.Controls.Add(txtbox_contraseña);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txt_correo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(217, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 459);
            panel1.TabIndex = 0;
            // 
            // link_registrarse
            // 
            link_registrarse.AutoSize = true;
            link_registrarse.LinkColor = Color.FromArgb(255, 128, 0);
            link_registrarse.Location = new Point(229, 394);
            link_registrarse.Name = "link_registrarse";
            link_registrarse.Size = new Size(59, 15);
            link_registrarse.TabIndex = 10;
            link_registrarse.TabStop = true;
            link_registrarse.Text = "Registrate";
            link_registrarse.LinkClicked += link_registrarse_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(116, 394);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 9;
            label4.Text = "¿No tienes Cuenta?";
            // 
            // btn_ingresar
            // 
            btn_ingresar.BackColor = Color.OrangeRed;
            btn_ingresar.FlatStyle = FlatStyle.Flat;
            btn_ingresar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_ingresar.ForeColor = Color.White;
            btn_ingresar.Location = new Point(62, 342);
            btn_ingresar.Name = "btn_ingresar";
            btn_ingresar.Size = new Size(285, 40);
            btn_ingresar.TabIndex = 8;
            btn_ingresar.Text = "Ingresar";
            btn_ingresar.UseVisualStyleBackColor = false;
            btn_ingresar.Click += btn_ingresar_Click;
            // 
            // link_recuperacion
            // 
            link_recuperacion.AutoSize = true;
            link_recuperacion.LinkColor = Color.Red;
            link_recuperacion.Location = new Point(19, 305);
            link_recuperacion.Name = "link_recuperacion";
            link_recuperacion.Size = new Size(143, 15);
            link_recuperacion.TabIndex = 7;
            link_recuperacion.TabStop = true;
            link_recuperacion.Text = "¿Olvidaste tu Contraseña?";
            // 
            // txtbox_contraseña
            // 
            txtbox_contraseña.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtbox_contraseña.Location = new Point(17, 264);
            txtbox_contraseña.Multiline = true;
            txtbox_contraseña.Name = "txtbox_contraseña";
            txtbox_contraseña.Size = new Size(355, 35);
            txtbox_contraseña.TabIndex = 6;
            txtbox_contraseña.TextChanged += txtbox_contraseña_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 238);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 5;
            label3.Text = "Contraseña";
            // 
            // txt_correo
            // 
            txt_correo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_correo.Location = new Point(17, 172);
            txt_correo.Multiline = true;
            txt_correo.Name = "txt_correo";
            txt_correo.Size = new Size(355, 35);
            txt_correo.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 146);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 3;
            label2.Text = "Correo Electronico";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(130, 104);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 2;
            label1.Text = "Inicio de Sesion";
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
            // Inicio_de_Sesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(800, 523);
            Controls.Add(panel1);
            Name = "Inicio_de_Sesion";
            Text = "Inicio de Sesion";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txt_correo;
        private TextBox txtbox_contraseña;
        private Label label3;
        private LinkLabel link_recuperacion;
        private LinkLabel link_registrarse;
        private Label label4;
        private Button btn_ingresar;
    }
}
