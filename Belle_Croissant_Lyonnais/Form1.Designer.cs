namespace Belle_Croissant_Lyonnais
{
    partial class Form1
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
            label1 = new Label();
            txtbox_respuesta = new TextBox();
            lbl_pregunta = new Label();
            label3 = new Label();
            txtbox_contraseña = new TextBox();
            txtbox_reestcontraseña = new TextBox();
            label4 = new Label();
            label5 = new Label();
            btn_reestablecer = new Button();
            btn_cancelar = new Button();
            label2 = new Label();
            txt_email = new TextBox();
            button1 = new Button();
            btn_verificar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 106);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 0;
            label1.Text = "Pregunta de Seguridad";
            // 
            // txtbox_respuesta
            // 
            txtbox_respuesta.Enabled = false;
            txtbox_respuesta.Location = new Point(148, 147);
            txtbox_respuesta.Name = "txtbox_respuesta";
            txtbox_respuesta.Size = new Size(221, 23);
            txtbox_respuesta.TabIndex = 1;
            // 
            // lbl_pregunta
            // 
            lbl_pregunta.BackColor = SystemColors.ButtonHighlight;
            lbl_pregunta.BorderStyle = BorderStyle.FixedSingle;
            lbl_pregunta.Location = new Point(148, 104);
            lbl_pregunta.Name = "lbl_pregunta";
            lbl_pregunta.Size = new Size(221, 23);
            lbl_pregunta.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 150);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 3;
            label3.Text = "Respuesta";
            // 
            // txtbox_contraseña
            // 
            txtbox_contraseña.Enabled = false;
            txtbox_contraseña.Location = new Point(148, 224);
            txtbox_contraseña.Name = "txtbox_contraseña";
            txtbox_contraseña.Size = new Size(221, 23);
            txtbox_contraseña.TabIndex = 4;
            txtbox_contraseña.TextChanged += txtbox_contraseña_TextChanged;
            // 
            // txtbox_reestcontraseña
            // 
            txtbox_reestcontraseña.Enabled = false;
            txtbox_reestcontraseña.Location = new Point(148, 269);
            txtbox_reestcontraseña.Name = "txtbox_reestcontraseña";
            txtbox_reestcontraseña.Size = new Size(221, 23);
            txtbox_reestcontraseña.TabIndex = 5;
            txtbox_reestcontraseña.TextChanged += txtbox_reestcontraseña_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 227);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 6;
            label4.Text = "Nueva Contraseña";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 272);
            label5.Name = "label5";
            label5.Size = new Size(124, 15);
            label5.TabIndex = 7;
            label5.Text = "Confirmar Contraseña";
            // 
            // btn_reestablecer
            // 
            btn_reestablecer.BackColor = Color.FromArgb(0, 192, 0);
            btn_reestablecer.Enabled = false;
            btn_reestablecer.FlatStyle = FlatStyle.Flat;
            btn_reestablecer.ForeColor = SystemColors.ButtonHighlight;
            btn_reestablecer.Location = new Point(120, 319);
            btn_reestablecer.Name = "btn_reestablecer";
            btn_reestablecer.Size = new Size(84, 30);
            btn_reestablecer.TabIndex = 8;
            btn_reestablecer.Text = "Reestablecer";
            btn_reestablecer.UseVisualStyleBackColor = false;
            btn_reestablecer.Click += btn_reestablecer_Click;
            // 
            // btn_cancelar
            // 
            btn_cancelar.BackColor = Color.FromArgb(192, 0, 0);
            btn_cancelar.FlatStyle = FlatStyle.Flat;
            btn_cancelar.ForeColor = SystemColors.ButtonHighlight;
            btn_cancelar.Location = new Point(225, 319);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(89, 30);
            btn_cancelar.TabIndex = 9;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = false;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 25);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 11;
            label2.Text = "Correo electronico";
            // 
            // txt_email
            // 
            txt_email.Location = new Point(148, 22);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(221, 23);
            txt_email.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(161, 60);
            button1.Name = "button1";
            button1.Size = new Size(208, 23);
            button1.TabIndex = 12;
            button1.Text = "Verificar email";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btn_verificar
            // 
            btn_verificar.BackColor = Color.Green;
            btn_verificar.FlatStyle = FlatStyle.Flat;
            btn_verificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_verificar.ForeColor = SystemColors.ButtonHighlight;
            btn_verificar.Location = new Point(148, 184);
            btn_verificar.Name = "btn_verificar";
            btn_verificar.Size = new Size(221, 23);
            btn_verificar.TabIndex = 13;
            btn_verificar.Text = "Verificar";
            btn_verificar.UseVisualStyleBackColor = false;
            btn_verificar.Click += btn_verificar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 353);
            Controls.Add(btn_verificar);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(txt_email);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_reestablecer);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtbox_reestcontraseña);
            Controls.Add(txtbox_contraseña);
            Controls.Add(label3);
            Controls.Add(lbl_pregunta);
            Controls.Add(txtbox_respuesta);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtbox_respuesta;
        private Label lbl_pregunta;
        private Label label3;
        private TextBox txtbox_contraseña;
        private TextBox txtbox_reestcontraseña;
        private Label label4;
        private Label label5;
        private Button btn_reestablecer;
        private Button btn_cancelar;
        private Label label2;
        private TextBox txt_email;
        private Button button1;
        private Button btn_verificar;
    }
}