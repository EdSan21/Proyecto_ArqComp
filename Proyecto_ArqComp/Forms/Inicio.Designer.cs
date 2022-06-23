
namespace Proyecto_ArqComp.Forms
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.BtnAcceso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnMinimizar = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnRegistro = new System.Windows.Forms.Button();
            this.PicEye = new System.Windows.Forms.PictureBox();
            this.PicEmail = new System.Windows.Forms.PictureBox();
            this.PicPass = new System.Windows.Forms.PictureBox();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAcceso
            // 
            this.BtnAcceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(195)))), ((int)(((byte)(117)))));
            this.BtnAcceso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAcceso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(208)))), ((int)(((byte)(127)))));
            this.BtnAcceso.FlatAppearance.BorderSize = 3;
            this.BtnAcceso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(208)))), ((int)(((byte)(127)))));
            this.BtnAcceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAcceso.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAcceso.ForeColor = System.Drawing.Color.White;
            this.BtnAcceso.Location = new System.Drawing.Point(391, 310);
            this.BtnAcceso.Name = "BtnAcceso";
            this.BtnAcceso.Size = new System.Drawing.Size(189, 43);
            this.BtnAcceso.TabIndex = 26;
            this.BtnAcceso.Text = "Iniciar sesión";
            this.BtnAcceso.UseVisualStyleBackColor = false;
            this.BtnAcceso.Click += new System.EventHandler(this.BtnAcceso_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(348, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 41);
            this.label1.TabIndex = 28;
            this.label1.Text = "Login";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.ForeColor = System.Drawing.Color.Gray;
            this.TxtPassword.HideSelection = false;
            this.TxtPassword.Location = new System.Drawing.Point(355, 233);
            this.TxtPassword.MaxLength = 10;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(270, 27);
            this.TxtPassword.TabIndex = 33;
            this.TxtPassword.Text = "contraseña";
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged_1);
            this.TxtPassword.Enter += new System.EventHandler(this.TxtPassword_Enter_1);
            this.TxtPassword.Leave += new System.EventHandler(this.TxtPassword_Leave_1);
            // 
            // TxtUser
            // 
            this.TxtUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUser.ForeColor = System.Drawing.Color.Gray;
            this.TxtUser.HideSelection = false;
            this.TxtUser.Location = new System.Drawing.Point(355, 161);
            this.TxtUser.MaxLength = 100;
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.Size = new System.Drawing.Size(270, 27);
            this.TxtUser.TabIndex = 32;
            this.TxtUser.Text = "email";
            this.TxtUser.Enter += new System.EventHandler(this.TxtUser_Enter_1);
            this.TxtUser.Leave += new System.EventHandler(this.TxtUser_Leave_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(26)))), ((int)(((byte)(12)))));
            this.panel1.Location = new System.Drawing.Point(0, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 29);
            this.panel1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.panel2.Location = new System.Drawing.Point(0, 407);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 21);
            this.panel2.TabIndex = 37;
            // 
            // BtnMinimizar
            // 
            this.BtnMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.BtnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMinimizar.FlatAppearance.BorderSize = 0;
            this.BtnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(36)))), ((int)(((byte)(16)))));
            this.BtnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(36)))), ((int)(((byte)(16)))));
            this.BtnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("BtnMinimizar.Image")));
            this.BtnMinimizar.Location = new System.Drawing.Point(707, 1);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(47, 36);
            this.BtnMinimizar.TabIndex = 38;
            this.BtnMinimizar.UseVisualStyleBackColor = false;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.FlatAppearance.BorderSize = 0;
            this.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(36)))), ((int)(((byte)(16)))));
            this.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(36)))), ((int)(((byte)(16)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Image = global::Proyecto_ArqComp.Properties.Resources.Exit;
            this.BtnExit.Location = new System.Drawing.Point(751, 1);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(47, 36);
            this.BtnExit.TabIndex = 35;
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click_1);
            // 
            // BtnRegistro
            // 
            this.BtnRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(195)))), ((int)(((byte)(117)))));
            this.BtnRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRegistro.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(208)))), ((int)(((byte)(127)))));
            this.BtnRegistro.FlatAppearance.BorderSize = 3;
            this.BtnRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(208)))), ((int)(((byte)(127)))));
            this.BtnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegistro.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistro.ForeColor = System.Drawing.Color.White;
            this.BtnRegistro.Image = ((System.Drawing.Image)(resources.GetObject("BtnRegistro.Image")));
            this.BtnRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistro.Location = new System.Drawing.Point(0, 12);
            this.BtnRegistro.Name = "BtnRegistro";
            this.BtnRegistro.Size = new System.Drawing.Size(189, 43);
            this.BtnRegistro.TabIndex = 34;
            this.BtnRegistro.Text = "   Registrarse";
            this.BtnRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRegistro.UseVisualStyleBackColor = false;
            this.BtnRegistro.Click += new System.EventHandler(this.BtnRegistro_Click);
            // 
            // PicEye
            // 
            this.PicEye.BackColor = System.Drawing.Color.White;
            this.PicEye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicEye.Image = global::Proyecto_ArqComp.Properties.Resources.ver;
            this.PicEye.Location = new System.Drawing.Point(600, 235);
            this.PicEye.Name = "PicEye";
            this.PicEye.Size = new System.Drawing.Size(23, 23);
            this.PicEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicEye.TabIndex = 31;
            this.PicEye.TabStop = false;
            this.PicEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicEye_MouseDown_1);
            this.PicEye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicEye_MouseUp_1);
            // 
            // PicEmail
            // 
            this.PicEmail.BackColor = System.Drawing.Color.Transparent;
            this.PicEmail.Image = global::Proyecto_ArqComp.Properties.Resources.email;
            this.PicEmail.Location = new System.Drawing.Point(317, 161);
            this.PicEmail.Name = "PicEmail";
            this.PicEmail.Size = new System.Drawing.Size(32, 32);
            this.PicEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicEmail.TabIndex = 30;
            this.PicEmail.TabStop = false;
            // 
            // PicPass
            // 
            this.PicPass.Image = global::Proyecto_ArqComp.Properties.Resources.pass;
            this.PicPass.Location = new System.Drawing.Point(317, 233);
            this.PicPass.Name = "PicPass";
            this.PicPass.Size = new System.Drawing.Size(32, 32);
            this.PicPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicPass.TabIndex = 29;
            this.PicPass.TabStop = false;
            // 
            // PicLogo
            // 
            this.PicLogo.BackColor = System.Drawing.Color.Transparent;
            this.PicLogo.Image = global::Proyecto_ArqComp.Properties.Resources.Logo_Proyecto;
            this.PicLogo.Location = new System.Drawing.Point(12, 101);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(270, 252);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLogo.TabIndex = 27;
            this.PicLogo.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(30)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnMinimizar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnRegistro);
            this.Controls.Add(this.PicEye);
            this.Controls.Add(this.PicEmail);
            this.Controls.Add(this.PicPass);
            this.Controls.Add(this.BtnAcceso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUser);
            this.Controls.Add(this.PicLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Inicio_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.PicEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnRegistro;
        private System.Windows.Forms.PictureBox PicEye;
        private System.Windows.Forms.PictureBox PicEmail;
        private System.Windows.Forms.PictureBox PicPass;
        private System.Windows.Forms.Button BtnAcceso;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TxtPassword;
        public System.Windows.Forms.TextBox TxtUser;
        private System.Windows.Forms.PictureBox PicLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnMinimizar;
    }
}