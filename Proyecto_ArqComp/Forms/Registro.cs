using BL.Clases.Metodos;
using Modelos.Models;
using Proyecto_ArqComp.DataClass;
using Proyecto_ArqComp.Reader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_ArqComp.Forms
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            Titulos();
            Otros();
        }

        private Methods GetMethods = new Methods();
        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
            int wparam, int lparam);

        public void Otros()
        {
            if (TxtPasswordNueva.Text == "contraseña nueva")
            {
                PicEye.Visible = false;
                PicEyeN.Visible = false;
            }
        }
        public void Titulos()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 300;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.BtnExit, "Cerrar");
            toolTip.SetToolTip(this.BtnMinimizar, "Minimizar");
            toolTip.SetToolTip(this.BtnBack, "Regresar");
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            if (TxtEmail.Text == "" || TxtPasswordNueva.Text == "" || TxtPasswordVal.Text == "")
            {
                MessageBox.Show("Por favor llene los campos.", "Sugoi Japan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (TxtEmail.Text == "Ingresa tu email" || TxtPasswordNueva.Text == "contraseña nueva" || TxtPasswordVal.Text == "confirmar contraseña")
            {
                MessageBox.Show("Por favor llene los campos.", "Sugoi Japan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                bool isOk = GetMethods.ValidacionEmail(TxtEmail.Text);
                if (isOk == false)
                {
                    MessageBox.Show("Email inválido.", "Sugoi Japan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (TxtPasswordNueva.Text != TxtPasswordVal.Text)
                    {
                        MessageBox.Show("Las contraseñas no coinciden.", "Sugoi Japan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //MessageBox.Show("igual");
                        CrearUsuario usuarioModel = new CrearUsuario
                        {
                            Email = TxtEmail.Text,
                            Password = TxtPasswordNueva.Text
                        };
                        var Reader = new CrearUsuarioReader(QueriesRepo.TipoQuery.AddRow, usuarioModel);
                        var start = Reader.Execute();
                        MessageBox.Show("El usuario fue creado exitosamente.", "Sugoi Japan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Inicio Forminicio = new Inicio();
                        Forminicio.Show();
                        this.Hide();
                    }
                    
                }
            }
          
        }

        private void TxtPasswordNueva_TextChanged(object sender, EventArgs e)
        {
            if (TxtPasswordNueva.Text == "")
            {
                PicEye.Visible = false;
            }
            else
            {
                PicEye.Visible = true;
            }
        }

        private void TxtPasswordNueva_Leave(object sender, EventArgs e)
        {
            if (TxtPasswordNueva.Text == "")
            {
                TxtPasswordNueva.Text = "contraseña nueva";
                TxtPasswordNueva.UseSystemPasswordChar = false;
                PicEye.Visible = false;
            }
        }

        private void TxtPasswordVal_Enter(object sender, EventArgs e)
        {
            if (TxtPasswordVal.Text == "confirmar contraseña")
            {
                TxtPasswordVal.Text = "";
                TxtPasswordVal.UseSystemPasswordChar = true;
                PicEyeN.Visible = true;
            }
        }

        private void TxtPasswordNueva_Enter(object sender, EventArgs e)
        {
            if (TxtPasswordNueva.Text == "contraseña nueva")
            {
                TxtPasswordNueva.Text = "";
                TxtPasswordNueva.UseSystemPasswordChar = true;
                PicEye.Visible = true;
            }
        }

        private void TxtPasswordVal_Leave(object sender, EventArgs e)
        {
            if (TxtPasswordVal.Text == "")
            {
                TxtPasswordVal.Text = "confirmar contraseña";
                TxtPasswordVal.UseSystemPasswordChar = false;
                PicEyeN.Visible = false;
            }
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
            if (TxtEmail.Text == "Ingresa tu email")
            {
                TxtEmail.Text = "";
             
            }
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            if (TxtEmail.Text == "")
            {
                TxtEmail.Text = "Ingresa tu email";
                
            }
        }

        private void PicEye_MouseDown(object sender, MouseEventArgs e)
        {
            TxtPasswordNueva.UseSystemPasswordChar = false;
        }

        private void PicEyeN_MouseDown(object sender, MouseEventArgs e)
        {
            TxtPasswordVal.UseSystemPasswordChar = false;
        }

        private void Registro_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PicEye_MouseUp(object sender, MouseEventArgs e)
        {
            TxtPasswordNueva.UseSystemPasswordChar = true;
        }

        private void PicEyeN_MouseUp(object sender, MouseEventArgs e)
        {
            TxtPasswordVal.UseSystemPasswordChar = true;
        }

        private void TxtPasswordVal_TextChanged(object sender, EventArgs e)
        {
            if (TxtPasswordVal.Text == "")
            {
                PicEyeN.Visible = false;
            }
            else
            {
                PicEyeN.Visible = true;
            }
        }

     
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PicLogo_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }
    }
}
