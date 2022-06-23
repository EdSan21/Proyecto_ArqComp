using Proyecto_ArqComp.Otros;
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
    public partial class Inicio : Form
    {
        private UsuarioDAL userDal = new UsuarioDAL();

        public Inicio()
        {
            InitializeComponent();
            Titulos();
            Otros();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
            int wparam, int lparam);
        public void Otros()
        {
            if (TxtPassword.Text == "contraseña")
            {
                PicEye.Visible = false;
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
        }


        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtPassword_TextChanged_1(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "")
            {
                PicEye.Visible = false;
            }
            else
            {
                PicEye.Visible = true;
            }
        }

        private void BtnAcceso_Click_1(object sender, EventArgs e)
        {
            if (TxtUser.Text == "" || TxtPassword.Text == "")
            {
                MessageBox.Show("Por favor llene los campos.", "Sugoi Japan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (TxtUser.Text == "email" || TxtPassword.Text == "contraseña")
            {
                MessageBox.Show("Por favor llene los campos.", "Sugoi Japan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataSet Sesion = new DataSet();
                string email = TxtUser.Text;
                string password = TxtPassword.Text;
                bool verificador = false;
                Sesion = userDal.Log(email, password);
                foreach (DataRow fila in Sesion.Tables[0].Rows)
                {
                    userDal.Email = fila["Email"].ToString();
                    userDal.Password = fila["Password"].ToString();
                    userDal.Email = email;
                    verificador = true;
                }
                if (verificador == true)
                {
                    BtnAcceso.Enabled = false;
                    SistemaGeneral SG = new SistemaGeneral();
                    SG.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Verifique sus datos", "Sugoi Japan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void TxtPassword_Leave_1(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "")
            {
                TxtPassword.Text = "contraseña";
                TxtPassword.UseSystemPasswordChar = false;
                PicEye.Visible = false;
            }
        }

        private void TxtPassword_Enter_1(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "contraseña")
            {
                TxtPassword.Text = "";
                TxtPassword.UseSystemPasswordChar = true;
                PicEye.Visible = true;

            }
        }

        private void TxtUser_Leave_1(object sender, EventArgs e)
        {
            if (TxtUser.Text == "")
            {
                TxtUser.Text = "email";
                
            }
        }

        private void TxtUser_Enter_1(object sender, EventArgs e)
        {
            if (TxtUser.Text == "email")
            {
                TxtUser.Text = "";
              
            }
        }

        private void PicEye_MouseDown_1(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = false;
        }

        private void PicEye_MouseUp_1(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;
        }

        private void Inicio_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

      
        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Hide();
        }

        
    }
}

