using BL.Clases.Metodos;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Proyecto_ArqComp.Forms
{
    public partial class SistemaGeneral : Form
    {

        Methods GetMethods = new Methods();
        string[] ItemsTemporada = new string[] { "--Seleccionar--", "Baja", "Alta" };
        //string[] ItemsRegion = new string[] { "--Seleccionar--", "Hokkaidō", "Tōhoku", "Kantō", "Chūbu", "Kansai", "Chūgoku", "Shikoku", "Kyūshū" };
        //string[] ItemsGuiasT = new string[] { "--Seleccionar--"};
        string[] ItemsTransporte = new string[] { "--Seleccionar--", "Japan Rail Pass", "Bicicleta" };
        string[] ItemsInternet = new string[] { "--Seleccionar--", "Tarjeta SIM Data", "Pocket Wifi" };
        string[] ItemsAlojamiento = new string[] { "--Seleccionar--", "Ryokan", "Shukubo", "Minshuku", "Hotel", "Apartamento", "Hostales/Albergues", "Love Hotels", "Hoteles Cápsula"};
        string[] ItemsComida = new string[] { "--Seleccionar--", "Plan Económico", "Plan Premium" };


        public SistemaGeneral()
        {
            InitializeComponent();
            CmbTemporada.Items.AddRange(ItemsTemporada);
            GetMethods.Cargar_Region(CmbRegion);
            CmbTransporte.Items.AddRange(ItemsTransporte);
            CmbInternet.Items.AddRange(ItemsInternet);
            CmbHospedaje.Items.AddRange(ItemsAlojamiento);
            CmbComida.Items.AddRange(ItemsComida);
            
            RichInfo.SelectionAlignment = HorizontalAlignment.Center;

            Titulos();

            LblTemporada.Visible = false;

            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
            int wparam, int lparam);
        public void Titulos()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 300;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.BtnExit, "Cerrar");
            toolTip.SetToolTip(this.BtnMin, "Minimizar");
            toolTip.SetToolTip(this.BtnLogOut, "Cerrar Sesión");
          
        }

        private void CmbTemporada_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMethods.SelectTemporada(CmbTemporada.Text, PicShow, RichInfo, PnlUsuario, LblTemporada, LblTransporte, LblHospedaje, LblInternet, LblComida, LblGT, LblLT, LblPresupuesto);
        }
        private void CmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMethods.SelectRegion(CmbRegion.Text, PicShow, RichInfo, PnlUsuario, CmbRegion, CmbGT, CmbLT);
        }
        private void CmbTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMethods.SelectTransporte(CmbTransporte.Text, PicShow, RichInfo, PnlUsuario);
            GetMethods.CostoTransporte(CmbTransporte.Text, LblTransporte, rd7, rdAdulto, rdOrdinario);
            GetMethods.GenerarPresupuesto(LblTransporte, LblHospedaje, LblInternet, LblComida, LblGT, LblLT, LblPresupuesto);
            //LblPresupuesto.Text = LblTransporte.Text + LblHospedaje.Text ;
        }
       
        private void CmbHospedaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMethods.SelectHospedaje(CmbHospedaje.Text, PicShow, RichInfo, PnlUsuario);
            GetMethods.CostoHospedaje(CmbHospedaje.Text, LblHospedaje, rd7, rdAdulto, CmbTemporada);
            GetMethods.GenerarPresupuesto(LblTransporte, LblHospedaje, LblInternet, LblComida, LblGT, LblLT, LblPresupuesto);
            //LblPresupuesto.Text = "";
        }
        private void CmbInternet_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMethods.SelectInternet(CmbInternet.Text, PicShow, RichInfo, PnlUsuario);
            GetMethods.CostoInternet(CmbInternet.Text, LblInternet, rd7);
            GetMethods.GenerarPresupuesto(LblTransporte, LblHospedaje, LblInternet, LblComida, LblGT, LblLT, LblPresupuesto);
        }
        private void CmbComida_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMethods.SelectComida(CmbComida.Text, PicShow, RichInfo, PnlUsuario);
            GetMethods.CostoComida(CmbComida.Text, LblComida, rd7);
            GetMethods.GenerarPresupuesto(LblTransporte, LblHospedaje, LblInternet, LblComida, LblGT, LblLT, LblPresupuesto);

        }
        private void CmbGT_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMethods.SelectGuiaTuristico(CmbGT.Text, PicShow, RichInfo, PnlUsuario, numericUpDown1, LblHrs);
        }
        private void CmbLT_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMethods.SelectLugarTuristico(CmbLT.Text, PicShow, RichInfo, PnlUsuario);
            GetMethods.CostoLugarTuristico(CmbLT.Text, LblLT, rdAdulto);
            GetMethods.GenerarPresupuesto(LblTransporte, LblHospedaje, LblInternet, LblComida, LblGT, LblLT, LblPresupuesto);
        }
       
        private void CmbRegion_DrawItem(object sender, DrawItemEventArgs e)
        {
            GetMethods.itemIcon(CmbRegion, LI_Region, e);
        }
        private void CmbTemporada_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.Graphics.FillRectangle(Brushes.Red, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            //e.Graphics.DrawString(CmbTemporada.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
           
            GetMethods.itemIcon(CmbTemporada, LI_Temporada, e);
        }
        private void CmbInternet_DrawItem(object sender, DrawItemEventArgs e)
        {
            GetMethods.itemIcon(CmbInternet, LI_Internet, e);
        }
        private void CmbTransporte_DrawItem(object sender, DrawItemEventArgs e)
        {
            GetMethods.itemIcon(CmbTransporte, LI_Transporte, e);
            
        }
        private void CmbHospedaje_DrawItem(object sender, DrawItemEventArgs e)
        {
            GetMethods.itemIcon(CmbHospedaje, LI_Hospedaje, e);
        }
        private void CmbComida_DrawItem(object sender, DrawItemEventArgs e)
        {
            GetMethods.itemIcon(CmbComida, LI_Comida, e);
        }
        private void CmbGT_DrawItem(object sender, DrawItemEventArgs e)
        {
            GetMethods.itemIcon(CmbGT, LI_Comida, e);
        }
        private void CmbRegion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void CmbTemporada_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void CmbTransporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbHospedaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbInternet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbComida_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbGT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbLT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LLTransportes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetMethods.URL("https://www.lonelyplanet.es/asia/japon/transporte");
        }

        private void LLBlogsViajes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetMethods.URL("https://comiviajeros.com/asia/japon/");
        }
        private void LLVuelos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetMethods.URL("https://www.espanol.skyscanner.com/?previousCultureSource=GEO_LOCATION&redirectedFrom=www.skyscanner.net&%3D&associateid=AFF_TRA_19354_00001&irclickid=_gbciu6vvtskf6ja0gthpmd9gbn2xv2qfw3dhnt3100&irgwc=1&utm_campaign=&utm_medium=affiliate&utm_source=2021108-Comiviajeros");
        }
        private void LLJRP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetMethods.URL("https://www.japan-experience.com/es/transporte/japan-rail-pass/nacional?click_id=edf1f01a7d16b94746cce49ecbaea123&affiliate_id=10");
        }
        private void LLExcursiones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetMethods.URL("https://www.civitatis.com/es/japon?aid=1855");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }

        private void SistemaGeneral_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PicShow_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PnlUsuario_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void CmbRegion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
        }

        private void CmbRegion_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetMethods.CostoGuiaTuristico(CmbGT.Text, LblGT, numericUpDown1);
            GetMethods.GenerarPresupuesto(LblTransporte, LblHospedaje, LblInternet, LblComida, LblGT, LblLT, LblPresupuesto);
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LblPresupuesto_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnRestablecer_Click(object sender, EventArgs e)
        {
            GetMethods.RestablecerValores(rd7, rd14, rd21, rdAdulto, rdNino, rdOrdinario, rdPrimeraClase,
                CmbRegion, CmbTemporada, CmbTransporte, CmbHospedaje, CmbInternet, CmbComida, CmbGT, CmbLT,
                LblPresupuesto, LblTransporte, LblTemporada, LblHospedaje, LblInternet, LblComida, LblGT, LblLT, LblHrs, PnlUsuario, PicShow);
        }
    }
}
