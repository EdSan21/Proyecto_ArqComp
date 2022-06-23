using BL.Clases.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BL.Clases.Metodos
{
    public class Methods
    {
        string path = @"C:\Users\Home\source\repos\Proyecto_ArqComp\Proyecto_ArqComp\Resources\";
        string formato_jpg = ".jpg";
        string formato_png = ".png";
       string SaltoLinea = Environment.NewLine;

        static int TransporteOrd7A = 253;
        static int Ryokan = 154;
        static int TotalHospedaje = Ryokan * 6;
        static int SIMIntenert = 18;
        static int PlanEconomico = 24;
        static int TotalComida = PlanEconomico * 7;
        static int MarkTarifa = 27;
        public bool ValidacionEmail(string email)
        {
            string Formato;
            Formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, Formato))
            {
                if (Regex.Replace(email, Formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        
        Connection GetConnection = new Connection();
        public void Cargar_Region(ComboBox CmbRegion)
        {
            using (SqlConnection SqlCon = new SqlConnection())
            {
                SqlCon.ConnectionString = GetConnection.ConnectionDB();
                SqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT Id_Region,Nombre FROM [SugoiJapan-DB].[dbo].[Region]",SqlCon);
                SqlDataAdapter DataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                DataAdapter.Fill(dataTable);
                SqlCon.Close();

                DataRow fila = dataTable.NewRow();
                fila["Nombre"] = "--Seleccionar--";
                dataTable.Rows.InsertAt(fila,0);

                CmbRegion.ValueMember = "Id_Region";
                CmbRegion.DisplayMember = "Nombre";
                CmbRegion.DataSource = dataTable;
            }
            
        }
        public void Cargar_GuiasTuristicos(string id_Region, ComboBox CmbGT)
        {
            //ComboBox CmbGT = new ComboBox();
            using (SqlConnection SqlCon = new SqlConnection())
            {
                SqlCon.ConnectionString = GetConnection.ConnectionDB();
                SqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT Id_GuiaTuristico, Nombre FROM GuiaTuristico WHERE Id_Region = @id_Region", SqlCon);
                command.Parameters.AddWithValue("id_Region", id_Region);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                SqlCon.Close();

                DataRow fila = dataTable.NewRow();
                fila["Nombre"] = "--Seleccionar--";
                dataTable.Rows.InsertAt(fila, 0);

                CmbGT.ValueMember = "Id_GuiaTuristico";
                CmbGT.DisplayMember = "Nombre";
                CmbGT.DataSource = dataTable;
            }
        }

        public void Cargar_LugaresTuristicos(string id_Region, ComboBox CmgLT)
        {
            using (SqlConnection SqlCon = new SqlConnection())
            {
                SqlCon.ConnectionString = GetConnection.ConnectionDB();
                SqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT Id_LugarTuristico, Nombre FROM LugarTuristico WHERE Id_Region = @id_Region", SqlCon);
                command.Parameters.AddWithValue("id_Region", id_Region);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                SqlCon.Close();

                DataRow fila = dataTable.NewRow();
                fila["Nombre"] = "--Seleccionar--";
                dataTable.Rows.InsertAt(fila, 0);

                CmgLT.ValueMember = "Id_LugarTuristico";
                CmgLT.DisplayMember = "Nombre";
                CmgLT.DataSource = dataTable;
            }
        }
        public string SelectRegion(string Seleccion, PictureBox PicShow, RichTextBox RichInfo, Panel PnlUsuario, ComboBox CmbRegion, ComboBox CmbGT, ComboBox CmbLT)
        {
            if (CmbRegion.SelectedValue.ToString() != null)
            {
                string Id_Region = CmbRegion.SelectedValue.ToString();
                Cargar_GuiasTuristicos(Id_Region, CmbGT);
                Cargar_LugaresTuristicos(Id_Region, CmbLT);

                switch (Seleccion)
                {
                    case "--Seleccionar--":
                        PicShow.ImageLocation = path + "ImageShow" + formato_png;
                        RichInfo.Text = "";
                        PnlUsuario.Visible = true;
                        break;
                    case "Hokkaido":
                        PicShow.ImageLocation = path + "hokkaido" + formato_jpg;
                        RichInfo.Text = "Es la segunda isla más grande de Japón, " +
                            "su ciudad principal es Sapporo y está formada por una serie de islas " +
                            "que son Rishiri, Rebun, Okushiri, Teuri, Yagishiri, Oshima Ōshima y Oshima Kojima.";
                        PnlUsuario.Visible = false;
                        break;
                    case "Tohoku":
                        PicShow.ImageLocation = path + "tohoku" + formato_jpg;
                        RichInfo.Text = "Es una región más que nada agrícola, hasta un 70% de sus " +
                            "tierras son fértiles, por lo que está llena de campos de arros, sumando " +
                            "la cuarta parte de los cultivos de arroz de todo Japón.";
                        PnlUsuario.Visible = false;
                        break;
                    case "Kanto":
                        PicShow.ImageLocation = path + "kanto" + formato_jpg;
                        RichInfo.Text = "Esta región a diferencia de la anterior, no tiene nadad de rural, " +
                            "es completamente urbana, tecnológica y llena de vida, es la región de la actual " +
                            "capital del país.";
                        PnlUsuario.Visible = false;
                        break;
                    case "Chubu":
                        PicShow.ImageLocation = path + "chubu" + formato_jpg;
                        RichInfo.Text = "Chūbu tiene contacto con el Mar de Japón y también con el Océano " +
                            "Pacífico, así que su clima está dividido a la mitad, la parte del Mar de Japón " +
                            "tiene muy fuertes nevadas, sin embargo la que colinda con el Océano Pacífico tiene " +
                            "un clima similiar al que tenemos en América.";
                        PnlUsuario.Visible = false;
                        break;
                    case "Kansai":
                        PicShow.ImageLocation = path + "kansai" + formato_jpg;
                        RichInfo.Text = "Es la segunda zona más importante de Japón en términos industriales, " +
                            "además es altamente turística al albergar la antigua capital del país Nipón.";
                        PnlUsuario.Visible = false;
                        break;
                    case "Chugoku":
                        PicShow.ImageLocation = path + "chugoku" + formato_jpg;
                        RichInfo.Text = "Es una zona montañosa por lo que hay mucho viento, lo que la vuelve " +
                            "un lugar ideal para apreciar el Momiji, la caída de los hojas en Otoño, además es " +
                            "una región marcada por la historia y una importante área industrial y comercial.";
                        PnlUsuario.Visible = false;
                        break;
                    case "Shikoku":
                        PicShow.ImageLocation = path + "shikoku" + formato_jpg;
                        RichInfo.Text = "Es un territorio muy poco urbano o industrial, es mas bien algo clásico, " +
                            "antiguo y tradicional. El clima de la zona es subtropical, es decir, húmedo y caliente, " +
                            "el invierno se mantiene con una mínima de 13 °C.";
                        PnlUsuario.Visible = false;
                        break;
                    case "Kyushu":
                        PicShow.ImageLocation = path + "kyushu" + formato_jpg;
                        RichInfo.Text = "Las actividades más florecientes son la agricultura, la ganadería " +
                            "y la pesca. La zona industrial Kita Kyūshū comprende una concentración de " +
                            "industrias pesadas y químicas.";
                        PnlUsuario.Visible = false;
                        break;
                    default:
                        break;
                }
            }
            return Seleccion;
        }
        public string SelectTemporada(string Seleccion, PictureBox PicShow, RichTextBox RichInfo, Panel PnlUsuario, Label LblTemporada,
            Label LblTransporte, Label LblHospedaje, Label LblInternet, Label LblComida, Label LblGuiaTuristico, Label LblLugarTuristico, Label LblPresupuesto)
        {
           
            switch (Seleccion)
            {
                
                case "--Seleccionar--":
                    PicShow.ImageLocation = path + "ImageShow" + formato_png;
                    RichInfo.Text = "";
                    PnlUsuario.Visible = true;
                    LblTemporada.Visible = false;
                    break;
                case "Baja":
                    PicShow.ImageLocation = path + "T_Baja" + formato_png;
                    RichInfo.Text = "Se considera que la temporada baja va de enero a principios de marzo y junio. " +
                        "Esto significa que los precios son más bajos y/o los precios tienen un estándar normal que, esto permite tener una experiencia única a un menor costo.";
                    PnlUsuario.Visible = false;
                    LblTemporada.Visible = true;
                    LblTemporada.Text = "1x";
                    GenerarPresupuesto(LblTransporte, LblHospedaje, LblInternet, LblComida, LblGuiaTuristico, LblLugarTuristico, LblPresupuesto);
                    break;
                case "Alta":
                    PicShow.ImageLocation = path + "T_Alta" + formato_jpg;
                    RichInfo.Text = "Por su parte, la temporada alta va de abril a mayo y agosto. " +
                        "Viajar a Japón en agosto o en los meses de primavera  es, probablemente, la opción más cara del año." + SaltoLinea + "" + SaltoLinea +
                        "Como mínimo, los precios tienden a duplicarse en comparación de los precios en temporada baja." + SaltoLinea + "" +  SaltoLinea + 
                        "Debido a esta alza de precios, las tarifas de hospedaje, comida, guías y lugares turísticos tienden a aumentar.";
                    PnlUsuario.Visible = false;
                    break;

                default:
                    break;
            }

            return Seleccion;
        }

        public string SelectTransporte(string Seleccion, PictureBox PicShow, RichTextBox RichInfo, Panel PnlUsuario)
        {
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    PicShow.ImageLocation = path + "ImageShow" + formato_png;
                    RichInfo.Text = "";
                    PnlUsuario.Visible = true;
                    break;
                case "Japan Rail Pass":
                    PicShow.ImageLocation = path + "JR_Pass" + formato_jpg;
                    RichInfo.Text = "El JR Pass es la solución ideal para viajar, y la mejor manera para desplazarse por Japón en tren. " +
                        "Con tu Japan Rail Pass, puedes viajar sin restricciones por la red de Japan Railways durante 7, 14 o 21 días. " + SaltoLinea + "" + SaltoLinea +
                        "-----------------------------Precios-----------------------------" + SaltoLinea + "" + SaltoLinea +
                        "Ordinario" + SaltoLinea +
                        "07 días | Adulto: $253" + "   --   " + "Niño: $127" + SaltoLinea +
                        "14 días | Adulto: $403" + "   --   " + "Niño: $202" + SaltoLinea +
                        "21 días | Adulto: $517" + "   --   " + "Niño: $259" + SaltoLinea + "" + SaltoLinea +

                        "1ª CLASE" + SaltoLinea +
                        "07 días | Adulto: $339" + "   --   " + "Niño: $169" + SaltoLinea +
                        "14 días | Adulto: $548" + "   --   " + "Niño: $274" + SaltoLinea +
                        "21 días | Adulto: $713" + "   --   " + "Niño: $357";
                    PnlUsuario.Visible = false;
                    break;
                case "Bicicleta":
                    PicShow.ImageLocation = path + "Alquiler_Bicicleta" + formato_jpg;
                    RichInfo.Text = "Generalmente se encuentran cerca de las estaciones de tren. Consúltese en la oficina de turismo local. " + SaltoLinea + "" + SaltoLinea + 
                        "Tarifa: $7.80 por día." + SaltoLinea + "" + SaltoLinea +
                        "Muchos albergues también tienen bicis de alquiler o de uso gratuito.";

                    PnlUsuario.Visible = false;
                    break;
                default:
                    break;
            }
            return Seleccion;
        }

        public string SelectHospedaje(string Seleccion, PictureBox PicShow, RichTextBox RichInfo, Panel PnlUsuario)
        {
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    PicShow.ImageLocation = path + "ImageShow" + formato_png;
                    RichInfo.Text = "";
                    PnlUsuario.Visible = true;
                    break;
                case "Ryokan":
                    PicShow.ImageLocation = path + "Ryokan" + formato_jpg;
                    RichInfo.Text = "Son alojamientos al más estilo japonés, tanto por su construcción, por la comida que ofrecen o por el trato que reciben los clientes." 
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: $154 en promedio, por persona y por noche." 
                        + SaltoLinea + "" + SaltoLinea +
                        "Si lo que deseas es pasar una auténtica experiencia japonesa, esta es sin duda una de las mejores opciones.";
                    PnlUsuario.Visible = false;
                    break;
                case "Shukubo":
                    PicShow.ImageLocation = path + "Shukubo" + formato_png;
                    RichInfo.Text = "Son alojamientos que se ofrecen en templos budistas. Al igual que en los Ryokan, es todo muy auténtico y tradicional, aunque un " +
                        "Shukubo es otra forma de adentrarse en la cultura japonesa, ya que dormir en un templo budista y despertarse a las 6:00 de la mañana " +
                        "escuchando los cantos budistas que entonan los monjes, no tiene precio." 
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: $92 en promedio, por persona y por noche.";
                    PnlUsuario.Visible = false;
                    break;
                case "Minshuku":
                    PicShow.ImageLocation = path + "Minshuku" + formato_jpg;
                    RichInfo.Text = "Son lo más parecido a lo que conocemos habitualmente como Bed & Breakfast (alojamiento y desayuno) pero claro, " +
                        "en una casa tradicional japonesa. Eso sí, normalmente las habitaciones son más pequeñas, pero el trato si que es " +
                        "más personal." 
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: $60 en promedio, por persona y por noche.";
                    PnlUsuario.Visible = false;
                    break;
                case "Hotel":
                    PicShow.ImageLocation = path + "Hotel" + formato_jpg;
                    RichInfo.Text = "En japón hay cientos de cadenas hoteleras extranjeras y nacionales compitiendo en el mercado, por lo que siempre podrás " +
                        "encontrar buenas ofertas de alojamiento en Japón." 
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: $46 en promedio a partir de hoteles de 3 estrellas, por persona y por noche.";
                    PnlUsuario.Visible = false;
                    break;
                case "Apartamento":
                    PicShow.ImageLocation = path + "Apartamento" + formato_jpg;
                    RichInfo.Text = "En Japón funciona bastante bien el sistema de airbnb. La famosa plataforma que pone en contacto a particulares con turistas " +
                        "para ofrecer sus viviendas como alquiler con huéspedes. Por regla general suelen ser estancias más bien cortas."
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: $116 en promedio, por persona y por noche.";
                    PnlUsuario.Visible = false;
                    break;
                case "Hostales/Albergues":
                    PicShow.ImageLocation = path + "Hostales_Albergues" + formato_jpg;
                    RichInfo.Text = "Si tu presupuesto es limitado, la opción más barata para encontrar alojamiento en Japón es hospedarse en algún hostal o albergue." 
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: $26 por persona y por noche.";
                    PnlUsuario.Visible = false;
                    break;
                case "Love Hotels":
                    PicShow.ImageLocation = path + "Love_Hotels" + formato_jpg;
                    RichInfo.Text = "Suelen estar cargados de un gran ambiente sensual y muchas veces están recreados por temáticas diferentes."
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: $62 para 2 persona y una noche noche";
                    PnlUsuario.Visible = false;
                    break;
                case "Hoteles Cápsula":
                    PicShow.ImageLocation = path + "Hoteles_Capsula" + formato_jpg;
                    RichInfo.Text = "Son establecimientos hoteleros de espacio muy reducido tipo modulares con el suficiente espacio para dormir " +
                        "incluyendo normalmente una televisión y conexión a internet." 
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: $27 por persona y por noche.";
                    PnlUsuario.Visible = false;
                    break;
                default:
                    break;
            }
            return Seleccion;
        }

        public string SelectInternet(string Seleccion, PictureBox PicShow, RichTextBox RichInfo, Panel PnlUsuario)
        {
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    PicShow.ImageLocation = path + "ImageShow" + formato_png;
                    RichInfo.Text = "";
                    PnlUsuario.Visible = true;
                    break;
                case "Tarjeta SIM Data":
                    PicShow.ImageLocation = path + "SIM_JP" + formato_jpg;
                    RichInfo.Text = "Con la tarjeta SIM de datos para Japón estarás conectado a Internet durante tu estancia, " +
                        "conservando tu teléfono personal. Gracias a la tarjeta SIM DATA para Japón, tendrás acceso ilimitado a " +
                        "Internet de banda ancha las 24 horas del día desde tu propio teléfono.Es la solución sencilla para conectarte " +
                        "a internet estés donde estés en Japón."
                        + SaltoLinea + "" + SaltoLinea +
                        "-----------------------------Precios-----------------------------" + SaltoLinea +
                        "08 días : $18" + SaltoLinea +
                        "16 días : $26" + SaltoLinea +
                        "31 días : $32";
                    PnlUsuario.Visible = false;
                    break;
                case "Pocket Wifi":
                    PicShow.ImageLocation = path + "PocketWifi" + formato_jpg;
                    RichInfo.Text = "Alquilar un pocket-wifi en Japón es ideal si deseas contar con acceso a internet rápido e ilimitado durante toda tu estancia, " +
                        "estés donde estés en Japón. Hay que tener en cuenta que todavía existen pocos puntos Wifi gratuitos."
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: a partir de $47.";
                    PnlUsuario.Visible = false;
                    break;
                default:
                    break;
            }
            return Seleccion;
        }

        public string SelectComida(string Seleccion, PictureBox PicShow, RichTextBox RichInfo, Panel PnlUsuario)
        {
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    PicShow.ImageLocation = path + "ImageShow" + formato_png;
                    RichInfo.Text = "";
                    PnlUsuario.Visible = true;
                    break;
                case "Plan Económico":
                    PicShow.ImageLocation = path + "P_Economico" + formato_jpg;
                    RichInfo.Text = "Consiste en el costo promedio más bajo y ofrece desayuno, lunch y cena. " + SaltoLinea + "" + SaltoLinea + 
                        "Tarifa: $24 por día." + SaltoLinea + "" + SaltoLinea +
                        "Puedes visitar lugares como: Tiendas de Conveniencia (Konbinis), McDonald's, Burger King, Gyudon, entre otros.";
                    PnlUsuario.Visible = false;
                    break;
                case "Plan Premium":
                    PicShow.ImageLocation = path + "P_Premium" + formato_jpg;
                    RichInfo.Text = "Por su parte, este plan ofrece desayuno, lunch y cena. " + SaltoLinea + "" + SaltoLinea + 
                        "Tarifa: $47 por día." + SaltoLinea + "" + SaltoLinea +
                        "Puedes visitar lugares como: Restaurantes de Yakiniku, de Sushi, entre otros.";
                    break;
                default:
                    break;
            }
            return Seleccion;
        }
        public string SelectGuiaTuristico(string Seleccion, PictureBox PicShow, RichTextBox RichInfo, Panel PnlUsuario, NumericUpDown upDown, Label LblHrs)
        {
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    PicShow.ImageLocation = path + "ImageShow" + formato_png;
                    RichInfo.Text = "";
                    PnlUsuario.Visible = true;
                    upDown.Value = 0;
                    upDown.Visible = false;
                    LblHrs.Visible = false;
                    break;
                case "Mark":
                    PicShow.ImageLocation = path + "Mark" + formato_png;
                    RichInfo.Text = "Konnichiwa! Soy de USA, hablo Español y Japonés, conmigo tendrás experiencias diferentes con mejor servicio, " +
                        "atención y comida, destinos alternativos, " +
                        "nuestra especialidad es la comida saludable, equipo de primera y los mejores destinos en Japón."
                        + SaltoLinea + "" + SaltoLinea + "Tarifa: $27 por hora."; 
                    PnlUsuario.Visible = false;
                    upDown.Visible = true;
                    LblHrs.Visible = true;
                    break;
                case "Kaori":
                    PicShow.ImageLocation = path + "Kaori" + formato_png;
                    RichInfo.Text = "Hey! ¿vendrás a Japón? estoy feliz por ti. Hablo Español, Inglés y Japonés, tengo experiencia con artesanos en la elaboración de pan, " +
                        "elaboración de tejidos. vivencia con familias indígenas conociendo mas su cultura."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $25 por hora."; 
                    PnlUsuario.Visible = false;
                    break;
                case "Takeshi":
                    PicShow.ImageLocation = path + "Takeshi" + formato_png;
                    RichInfo.Text = "Takeshi Tabata, soy japonés, me encanta el idioma Español, también me gusta leer, es debido a eso que he aprendido a " +
                        "redactar empíricamente ampliando mi lenguaje y escritura."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $23 por hora."; 
                    PnlUsuario.Visible = false;
                    break;
                case "Alessia":
                    PicShow.ImageLocation = path + "Alessia" + formato_png;
                    RichInfo.Text = "Yahho!! Soy una chava mexicana viviendo en Japón. Mi japonés es increíble. Te invito a ti, tus familiares y amigos a que " +
                        "disfruten junto a mi de cada aventura en el bello país del sol naciente!."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $21 por hora."; 
                    PnlUsuario.Visible = false;
                    break;
                case "Thomas":
                    PicShow.ImageLocation = path + "Thomas" + formato_png;
                    RichInfo.Text = "Ohayou! Soy de Inglaterra, hablo Español, Ingles, Francés y Japonés, me encantan comer ramen."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $28 por hora."; 
                    PnlUsuario.Visible = false;
                    break;
                case "Stephanie":
                    PicShow.ImageLocation = path + "Stephanie" + formato_png;
                    RichInfo.Text = "Amo demasiado a Japón, soy de Guatemala, mi abuelo me enseñó a hablar Japonés. ¿Vendrás a Japón?."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $26 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Hanako":
                    PicShow.ImageLocation = path + "Hanako" + formato_png;
                    RichInfo.Text = "Soy una japonésa amante de la cultura occidental, puedo hablar Español y Japonés. Los onigiris son mi comida favorita."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $24 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Joe":
                    PicShow.ImageLocation = path + "Joe" + formato_png;
                    RichInfo.Text = "Hi! Soy de Francia, me encantan los idiomas extranjeros, puedo hablar Francés, Español, Inglés, Portugés y Japonés. Me encanta visitar los onsen " +
                        "te invito a que te animes a venir a Japón."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $22 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Natsu":
                    PicShow.ImageLocation = path + "Natsu" + formato_png;
                    RichInfo.Text = "Konnichiwa! Soy de Tokio-Japón y hablo 3 idiomas (Español-Ingles-Japonés), me encanta hacer amigos extranjeros, " +
                        "te ofrezco la mejor experiencia en mi país natal, no te arrepentirás."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $20 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Yume":
                    PicShow.ImageLocation = path + "Yume" + formato_png;
                    RichInfo.Text = "Soy de Kioto, la antigua capital de Japón, estudié la carrera de relaciones exteriores, ¿te gustaría visitar mi país?, te aseguro que la pasaermos cool!. " +
                        "Un buen viajero no tiene planes fijos ni la intención de viajar."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $30 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Sachio":
                    PicShow.ImageLocation = path + "Sachio" + formato_png;
                    RichInfo.Text = "Tengo ascendencia mexicana y japonesa, amo México!! mi Español es muy bueno, me gustan los tacos. ¿Sabías que viajar es conocer el mundo con nuevos ojos? " +
                        "Ven a Japón."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $29 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Satoshi":
                    PicShow.ImageLocation = path + "Satoshi" + formato_png;
                    RichInfo.Text = "Viví 5 años en USA, estudié Inglés y Español, descubrí que a muchos extranjeros les gusta mi país así que no dudes en venir."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $28 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Luffy":
                    PicShow.ImageLocation = path + "Luffy" + formato_png;
                    RichInfo.Text = "Soy un japonés muy divertido, amo lo occidental, aprendí a hablar Español con mi amiga dominicana Jessica, a ella le gusta mucho Japón, ¿a ti también?."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $27 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Nami":
                    PicShow.ImageLocation = path + "Nami" + formato_png;
                    RichInfo.Text = "Soy de Sapporo, amo el Español, mis comidas favoritas son el ramen y el takoyaki. " +
                        "Recuerda que el único verdadero viaje de descubrimiento consiste no en buscar nuevos paisajes, sino en mirar con nuevos ojos"
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $26 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Aya":
                    PicShow.ImageLocation = path + "Aya" + formato_png;
                    RichInfo.Text = "Soy de Corea del Sur, hablo Inglés, Español y Japonés, he vivido en Japón desde los 17 años, conozco muchos templos tradicionales, " +
                        "¿Te gustaría un buen tour?."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $25 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Edo":
                    PicShow.ImageLocation = path + "Edo" + formato_png;
                    RichInfo.Text = "Mi papá es guatemalteco y mi mamá japonésa, me gustan mucho los tamales, hablo Español y Japonés, estoy seguro que Japón te sorprenderá."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $24 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Peter":
                    PicShow.ImageLocation = path + "Peter" + formato_png;
                    RichInfo.Text = "Soy de USA, Hablo Inglés, Español y Japonés, he vivido durante 10 años en Japón. Me encanta conocer los pequeños secretos que solo conocen los lugareños."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $23 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Gwen":
                    PicShow.ImageLocation = path + "Gwen" + formato_png;
                    RichInfo.Text = "Soy de Inglaterra! viví 3 años en México y después me mudé a Japón. Hay tanto alrededor de esta región, ¿quieres un grandioso tour? te ayudaré a encontrar lo que buscas."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $22 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Aoki":
                    PicShow.ImageLocation = path + "Aoki" + formato_png;
                    RichInfo.Text = "Soy japonés, estudié idiomas en la universidad, me encanta el Español. Quieres Aprender sobre la historia y el significado detrás de los edificios de esta región?" +
                        " realmente te ayudará a abrazar una nueva ciudad como si fuera la tuya."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $21 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Daichi":
                    PicShow.ImageLocation = path + "Daichi" + formato_png;
                    RichInfo.Text = "Soy de Japón, específicamente de Osaka, hablo Español y Japonés. En muchísimas ciudades de esta región, incluso en lo más remoto, se pueden admirar obras de arte."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $20 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Daiki":
                    PicShow.ImageLocation = path + "Daiki" + formato_png;
                    RichInfo.Text = "Soy de Ikebukuro y amo los tacos de México, aprendí Español viendo películas del cine mexicano, ¿vendrás a Japón? te aseguro que la pasaremos muy sugoi."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $19 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Hinata":
                    PicShow.ImageLocation = path + "Hinata" + formato_png;
                    RichInfo.Text = "Soy de Hiroshima, aprendí Español con mi maestro de España, venir a Japón te hará descansar de una frenética rutina en la ciudad, como disfrutar la tranquilidad de esta región."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $30 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Hiroshi":
                    PicShow.ImageLocation = path + "Hiroshi" + formato_png;
                    RichInfo.Text = "Soy de Dotonbori, viví 6 años en Guatemala, cuando regresé a Japón decidí trabajar como guía turístico, me encanta lo occidental."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $21 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Hotaru":
                    PicShow.ImageLocation = path + "Hotaru" + formato_png;
                    RichInfo.Text = "Soy de Colombia, vengo viviendo en Japón desde hace 12 años, puedo hablar Español y Japonés, venir a Japón será algo que nunca olvidarás en tu vida."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $28 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Bojji":
                    PicShow.ImageLocation = path + "Bojji" + formato_png;
                    RichInfo.Text = "Ohayou Bro! hablo Español y Japonés, me encanta ver anime, ¿a ti también te gusta Japón?."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $29 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Naoki":
                    PicShow.ImageLocation = path + "Naoki" + formato_png;
                    RichInfo.Text = "Yahho!! soy del norte de Japón, aprendí a hablar Español a los 10 años, puedo darte los mejores tours por los barrios de esta región."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $21 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Naruto":
                    PicShow.ImageLocation = path + "Naruto" + formato_png;
                    RichInfo.Text = "Soy de Nagasaki, amo el ramen, mi abuelo me enseñó a hablar Español, me encanta visitar los parques."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $24 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Sakura":
                    PicShow.ImageLocation = path + "Sakura" + formato_png;
                    RichInfo.Text = "Soy Sakura-chan, viví 2 años en Inglaterra y 4 en México, Japón es un páis increíble, ¿te atreves a venir?."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $31 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Jhon":
                    PicShow.ImageLocation = path + "Jhon" + formato_png;
                    RichInfo.Text = "Hi my friend! Soy de USA, vivo en Japón desde hace 4 años, amo convivir con los japoneses, hablo Inglés, Japonés y Español. " +
                        "Tu amigo Jhno te brindará grandes aventuras."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $20 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Marrie":
                    PicShow.ImageLocation = path + "Marrie" + formato_png;
                    RichInfo.Text = "Soy de Bélgica, hablo Neerlandés, Español y Japonés, ¿quieres venir a Japón? ¿Por dónde empezarás?."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $28 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Ryota":
                    PicShow.ImageLocation = path + "Ryota" + formato_png;
                    RichInfo.Text = "Soy de Osaka, me encanta comer takoyaki, mi pasatiempo favorito es aprender idiomas extranjeros, hablo Inglés, Español, Japonés e Italiano."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $32 por hora.";
                    PnlUsuario.Visible = false;
                    break;
                case "Yuki":
                    PicShow.ImageLocation = path + "Yuki" + formato_png;
                    RichInfo.Text = "Mis padres son japoneses que vivieron en Perú durante 3 años, he vivido en muchos países, me encanta charlar en Español, si vienes a Japón te sentiras en el futuro."
                         + SaltoLinea + "" + SaltoLinea + "Tarifa: $18 por hora.";
                    PnlUsuario.Visible = false;
                    break;
               
                default:
                    break;
            }
            return Seleccion;
        }
        public string SelectLugarTuristico(string Seleccion, PictureBox PicShow, RichTextBox RichInfo, Panel PnlUsuario)
        {
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    PicShow.ImageLocation = path + "ImageShow" + formato_png;
                    RichInfo.Text = "";
                    PnlUsuario.Visible = true;
                    break;
                    //1ra Región
                case "Zoo de Arashiyama":
                    PicShow.ImageLocation = path + "Zoo_Arashiyama" + formato_jpg;
                    RichInfo.Text = "Es un popular parque zoológico situado en las afueras de la ciudad de Asahikawa. El zoo exhibe varios tipos de animales, " +
                        "entre ellos la fauna autóctona de Hokkaido, como ciervos, águilas y zorros rojos."
                         + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $7 " + "  --  " + "Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;
                case "Niseko":
                    PicShow.ImageLocation = path + "Niseko" + formato_jpg;
                    RichInfo.Text = "Niseko es la estación de esquí más popular de Hokkaido. Ofrece una gran variedad de pistas de esquí con un paisaje espectacular, " +
                        "y hay muchos hoteles y restaurantes aptos para extranjeros con guías de habla en español."
                          + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $39 " + "  --  " + "Niños: $29";
                    PnlUsuario.Visible = false;
                    break;
                case "Lago Toya":
                    PicShow.ImageLocation = path + "Lago_Toya" + formato_jpg;
                    RichInfo.Text = "Es un pintoresco lago situado dentro del Parque Nacional Shikotsu-Toya (entre Niseko y Noboribetsu Onsen). " +
                        "En esta zona se puede disfrutar de actividades al aire libre como el piragüismo, la navegación, el senderismo y la acampada. " +
                        "También es uno de los destinos termales más populares de Hokkaido, y numerosos complejos onsen se encuentran cerca del lago Toya."
                          + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;

                //2da Región
                case "Aquamarine Fukushima":
                    PicShow.ImageLocation = path + "Aquamarine_Fukushima" + formato_jpg;
                    RichInfo.Text = "Es un 'acuario ambiental' que exhibe criaturas acuáticas en entornos que imitan fielmente sus hábitats naturales. Además de ser un acuario " +
                        "también alberga un centro de investigación y ofrece información educativa sobre sostenibilidad y conservación."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $15 " + "  --  " + "Niños: $7";
                    PnlUsuario.Visible = false;
                    break;
                case "Risshaku-ji Temple":
                    PicShow.ImageLocation = path + "Risshaku_Temple" + formato_jpg;
                    RichInfo.Text = "Los templos menores de Yamadera salpican las laderas del monte Hoshu, al noreste de la ciudad de Yamagata. " +
                        "Un ascenso de 1000 escalones a través de un bosque místico te lleva a lo alto de la montaña donde se erige el complejo de templos Yamadera, " +
                        "que presume de una de las mejores vistas de la región norte de Japón."
                           + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: $2";
                    PnlUsuario.Visible = false;
                    break;
                case "Senshu Park":
                    PicShow.ImageLocation = path + "Senshu_Park" + formato_jpg;
                    RichInfo.Text = "Aquí encontrarás paisajes cambiantes que reflejan las estaciones y la historia antigua y honorable del Dominio Akita de 200,000 goku. " +
                        "Incluso hoy en día las ruinas del castillo que se levantó durante el período Edo continúan existiendo, proyectándose sobre el cambio de estaciones y la elegancia del jardín japonés."
                         + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;

                //3ra Región
                case "Templo Senso-ji":
                    PicShow.ImageLocation = path + "Sensoji_Temple" + formato_jpg;
                    RichInfo.Text = "Combina arquitectura, centros de culto, jardines japoneses y mercados tradicionales para ofrecer a los visitantes una mirada moderna a la rica historia y cultura de Japón."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: Gratis"; 
                    PnlUsuario.Visible = false;
                    break;
                case "Shibuya":
                    PicShow.ImageLocation = path + "Shibuya" + formato_jpg;
                    RichInfo.Text = "El área que rodea la estación de Shibuya, famosa por sus calles concurridas, anuncios de neón destellantes, boutiques de moda y centros comerciales repletos, " +
                        "se encuentra entre los vecindarios más enérgicos de Tokio. Shibuya Crossing, una de las intersecciones peatonales más transitadas del mundo, se ha convertido en una especie de atracción turística por derecho propio."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;
                case "Torre de Tokio":
                    PicShow.ImageLocation = path + "Tokyo_Tower" + formato_jpg;
                    RichInfo.Text = "Con 333 metros (1.092 pies) de altura, la Torre de Tokio es un impresionante monumento japonés que ofrece vistas de 360 grados de la ciudad desde sus dos plataformas de observación. Construida en " +
                        "1958 con acero enrejado rojo y blanco, la estructura inspirada en la Torre Eiffel alberga un museo de cera, un santuario sintoísta, un acuario, restaurantes y otros lugares de entretenimiento."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: $22";
                    PnlUsuario.Visible = false;
                    break;

                //4ta Región
                case "Jigokudani Monkey Park":
                    PicShow.ImageLocation = path + "Monkey_Park" + formato_jpg;
                    RichInfo.Text = "El Parque de monos Jigokudani se encuentra en Yamanouchi, en la prefectura de Nagano, Japón. El mismo forma parte del parque nacional Joshinetsu Kogen, y se encuentra en el valle del río Yokoyu, " +
                        "en el sector norte de la prefectura"
                         + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $7 " + "  --  " + "Niños: $4";
                    PnlUsuario.Visible = false;
                    break;
                case "Kanazawa":
                    PicShow.ImageLocation = path + "Kanazawa" + formato_jpg;
                    RichInfo.Text = "Llamada el pequeño Kioto, Kanazawa posee la segunda comunidad de geishas del país. Sus barrios, muy antiguos, se sitúan alrededor de un monumental jardín de 11 hectáreas, Kanazawa, uno de los más bonitos del país."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;
                case "Hida-Takayama":
                    PicShow.ImageLocation = path + "Hida_Takayama" + formato_jpg;
                    RichInfo.Text = "Escondida en la montaña, Hida-Takayama desprende esa elegancia tradicional tan japonesa, un poco a la manera de Kioto. " +
                        "Lánzate a descubrir sus museos y sus mercados rurales a pie, tranquilamente, sin prisas. La ciudad es también conocida por su gran festival y su célebre carne de buey: Hida-gyu"
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;

                //5ta Región
                case "Santuario Fushimi Inari":
                    PicShow.ImageLocation = path + "Santuario_Fushimi" + formato_jpg;
                    RichInfo.Text = "Uno de los templos más sagrados de Kioto y uno de los santuarios sintoístas más antiguos de Japón. Los cinco magníficos templos del santuario se encuentran al pie de la montaña Inari," +
                        " y miles de puertas torii rojas (Senbon torii) marcan los senderos boscosos hasta la cima."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;
                case "Kinkaku-ji":
                    PicShow.ImageLocation = path + "Kinkaku_ji" + formato_jpg;
                    RichInfo.Text = "Con sus brillantes niveles dorados reflejados en el lago de abajo y un telón de fondo de bosques y pinos retorcidos  es una vista encantadora. " +
                        "Es una de las atracciones más populares de Kioto y uno de los templos más visitados de Japón."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $4 " + "  --  " + "Niños: $3";
                    PnlUsuario.Visible = false;
                    break;
                case "Castillo de Osaka":
                    PicShow.ImageLocation = path + "Castillo_Osaka" + formato_jpg;
                    RichInfo.Text = "Entre los castillos más famosos de Japón. Hoy, el castillo reconstruido alberga un museo lleno de artefactos de la historia de Japón y del creador del castillo, " +
                        "Toyotomi Hideyoshi. La torre principal ofrece una bonita vista de la ciudad de Osaka."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $5 " + "  --  " + "Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;

                //6ta Región
                case "Monumento de la Paz":
                    PicShow.ImageLocation = path + "Monumento_Hiroshima" + formato_jpg;
                    RichInfo.Text = "El Monumento Conmemorativo de la Paz de Hiroshima es un símbolo del impacto de la guerra y de la importancia de la paz. " +
                        "Lo primero que apreciarás cuando visites el Parque Conmemorativo de la Paz al otro lado del río Motoyasu."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;
                case "Tsunoshima Ohashi":
                    PicShow.ImageLocation = path + "Tsunoshima_Ohashi" + formato_jpg;
                    RichInfo.Text = "Un puente sobre un mar azul que conduce hacia un soleado complejo costero. Cruza el puente en coche y explora la isla de Tsunoshima y sus atractivos."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: Gratis"; ;
                    PnlUsuario.Visible = false;
                    break;
                case "Ohara Museum of Art":
                    PicShow.ImageLocation = path + "Ohara_Museum" + formato_jpg;
                    RichInfo.Text = "Se encuentra en la ciudad japonesa de Kurashiki y contiene una colección permanente del arte occidental en el país nipón."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $12 " + "  --  " + "Niños: $4";
                    PnlUsuario.Visible = false;
                    break;

                //7ma Región
                case "Matsuyama Castle":
                    PicShow.ImageLocation = path + "Matsuyama_Castle" + formato_jpg;
                    RichInfo.Text = "Es uno de los doce castillos originales de Japón. Se encuentra en el monte Katsuyama, una colina empinada en el centro de la ciudad que ofrece " +
                        "a los visitantes una vista panorámica de Matsuyama y el mar interior de Seto."
                          + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $4 " + "  --  " + "Niños: $2";
                    PnlUsuario.Visible = false;
                    break;
                case "Ritsurin Garden":
                    PicShow.ImageLocation = path + "Ritsurin_Garden" + formato_jpg;
                    RichInfo.Text = "Es un jardín paisajístico en la ciudad de Takamatsu, construido por los señores feudales locales durante el período Edo temprano. " +
                        "Dentro del parque hay una serie de instalaciones que incluyen un museo folclórico, tiendas y algunas casas de descanso donde puede tomar un descanso y " +
                        "disfrutar de un refrigerio en medio de la belleza del jardín."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $4 " + "  --  " + "Niños: $2";
                    PnlUsuario.Visible = false;
                    break;
                case "Kochi Castle":
                    PicShow.ImageLocation = path + "Kochi_Castle" + formato_jpg;
                    RichInfo.Text = "Es uno de los doce castillos japoneses que sobrevivieron a los incendios, las guerras y otras catástrofes de la era posfeudal."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $4 " + "  --  " + "Niños: Gratis";
                    PnlUsuario.Visible = false;
                    break;

                //8va Región
                case "Nikko Tosho-gu":
                    PicShow.ImageLocation = path + "Nikko_Tosho" + formato_jpg;
                    RichInfo.Text = "Este magnífico santuario, dedicado a un famoso señor de la guerra, dio lugar a un dicho mundialmente conocido."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos: $10 " + "  --  " + "Niños: $4";
                    PnlUsuario.Visible = false;
                    break;
                case "Sengan-en":
                    PicShow.ImageLocation = path + "Sengan_en" + formato_jpg;
                    RichInfo.Text = "Es un jardín japonés adjunto a una antigua residencia del clan Shimazu en Kagoshima, Prefectura de Kagoshima, Japón."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: $8";
                    PnlUsuario.Visible = false;
                    break;
                case "Kumamoto Castle":
                    PicShow.ImageLocation = path + "Kumamoto_Castle" + formato_jpg;
                    RichInfo.Text = "El castillo donde Japón vivió su última gran sublevación también tiene un palacio daimio."
                        + SaltoLinea + "" + SaltoLinea + "-------------------------Tarifas|Entrada-------------------------" + SaltoLinea + "" +
                         "Adultos y Niños: $4";
                    PnlUsuario.Visible = false;
                    break;

                default:
                    break;
            }
            return Seleccion;
        }
        public void itemIcon(ComboBox combo, ImageList list, DrawItemEventArgs e)
        {

            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                if (e.Index < list.Images.Count)
                {
                    System.Drawing.Image img = new Bitmap(list.Images[e.Index], new Size(18, 18));
                    e.Graphics.DrawImage(img, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(string.Format(combo.Items[e.Index].ToString(), e.Index + 1)
                 , e.Font, new SolidBrush(e.ForeColor)
                 , e.Bounds.Left + 32, e.Bounds.Top);
            }


        }
        public string URL(string enlace)
        {
            System.Diagnostics.Process.Start(enlace);
            return enlace;
        }
        
        public int CostoTransporte (string Seleccion, Label LblTransporte, RadioButton rd7, RadioButton rdAdulto, RadioButton rdOrdinario)
        {
            //Pase ordinario para adulto
          

            switch (Seleccion)
            {
                case "--Seleccionar--":
                    LblTransporte.Text = "0.00";
                    break;
                case "Japan Rail Pass":
                    if (rd7.Checked == true)
                    {
                        if (rdAdulto.Checked == true)
                        {
                            if (rdOrdinario.Checked == true)
                            {
                                LblTransporte.Text = TransporteOrd7A.ToString();
                            }
                            
                        }
                    } 
                    break;
                default:
                    break;
            }
            return TransporteOrd7A;
        }
        public int CostoHospedaje (string Seleccion, Label LblHospedaje, RadioButton rd7, RadioButton rdAdulto, ComboBox CmbTemporada)
        {
            
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    LblHospedaje.Text = "0.00";
                    break;
                case "Ryokan":
                    if (rd7.Checked == true)
                    {
                        if (rdAdulto.Checked == true)
                        {
                                LblHospedaje.Text = TotalHospedaje.ToString();                           

                        }
                    }
                    
                    break;
                default:
                    break;
            }
            return TotalHospedaje;
        }
       
        public int CostoInternet (string Seleccion, Label LblInternet, RadioButton rd7)
        {
            
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    LblInternet.Text = "0.00";
                    break;
                case "Tarjeta SIM Data":
                    if (rd7.Checked == true)
                    {
                        LblInternet.Text = SIMIntenert.ToString();   
                    }
                    break;
                default:
                    break;
            }
            return SIMIntenert;
        }
       
        public int CostoComida(string Seleccion, Label LblComida, RadioButton rd7)
        {
           
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    LblComida.Text = "0.00";
                    break;
                case "Plan Económico":
                    if (rd7.Checked == true)
                    {
                        LblComida.Text = TotalComida.ToString();   
                    }
                    break;
                default:
                    break;
            }
            return TotalComida;
        }
      
        
        static int ZooTarifa = 7;
        public int CostoGuiaTuristico(string Seleccion, Label LblGT, NumericUpDown upDown)
        {
            int TotalGuiaTuristico = MarkTarifa * Convert.ToInt32(upDown.Value);
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    LblGT.Text = "0.00";
                    break;
                case "Mark":
                    LblGT.Text = TotalGuiaTuristico.ToString();
                    break;
                default:
                    break;
            }
            return TotalGuiaTuristico;
        }
        public int CostoLugarTuristico(string Seleccion, Label LblLT, RadioButton rdAdulto)
        {
            
            switch (Seleccion)
            {
                case "--Seleccionar--":
                    LblLT.Text = "0.00";
                    break;
                case "Zoo de Arashiyama":
                    if (rdAdulto.Checked == true)
                    {
                        LblLT.Text = ZooTarifa.ToString();
                    }
                    
                    break;
                default:
                    break;
            }
            return ZooTarifa;
        }
        public string GenerarPresupuesto(Label LblTransporte, Label LblHospedaje, Label LblInternet, Label LblComida, Label LblGuiaTuristico, Label LblLugarTuristico, Label LblPresupuesto)
        {
            double Transporte;
            double Hospedaje;
            double Internet;
            double Comida; double GuiaTuristicto;
            double LugarTuristico;
            double TotalPresupuesto;
            
                Transporte = Convert.ToDouble(LblTransporte.Text);
                Hospedaje = Convert.ToDouble(LblHospedaje.Text);
                Internet = Convert.ToDouble(LblInternet.Text);
                Comida = Convert.ToDouble(LblComida.Text);
                GuiaTuristicto = Convert.ToDouble(LblGuiaTuristico.Text);
                LugarTuristico = Convert.ToDouble(LblLugarTuristico.Text);

                TotalPresupuesto = Transporte + Hospedaje + Internet + Comida + GuiaTuristicto + LugarTuristico;

                return LblPresupuesto.Text = TotalPresupuesto.ToString();
        }

        public void RestablecerValores(RadioButton rd7, RadioButton rd14, RadioButton rd21, RadioButton rdAdulto, RadioButton rdNino, RadioButton rdOrdinario, RadioButton rdPrimeraClase,
            ComboBox CmbRegion, ComboBox CmbTemporada, ComboBox CmbTransporte, ComboBox CmbHospedaje, ComboBox CmbInternet, ComboBox CmbComida, ComboBox CmbGT, ComboBox CmbLT,
            Label LblPresupuesto, Label LblTransporte, Label LblTemporada, Label LblHospedaje, Label LblInternet, Label LblComida, Label LblGT, Label LblLT, Label LblHrs,
            Panel PnlUsuario, PictureBox PicShow)
        {
            string text = "--Seleccionar--";
            rd7.Checked = false;
            rd14.Checked = false;
            rd21.Checked = false;

            rdAdulto.Checked = false;
            rdNino.Checked = false;

            rdOrdinario.Checked = false;
            rdPrimeraClase.Checked = false;

            CmbRegion.Text = text;
            CmbTemporada.Text = text;
            CmbTransporte.Text = text;
            CmbHospedaje.Text = text;
            CmbInternet.Text = text;
            CmbComida.Text = text;
            CmbGT.Text = text;
            CmbLT.Text = text;

            LblPresupuesto.Text = "0";
            LblTransporte.Text = "0.00";
            LblTemporada.Text = "0.00";
            LblTransporte.Text = "0.00";
            LblHospedaje.Text = "0.00";
            LblInternet.Text = "0.00";
            LblComida.Text = "0.00";
            LblGT.Text = "0.00";
            LblLT.Text = "0.00";

            LblHrs.Visible = false;

            PnlUsuario.Visible = true;

            PicShow.ImageLocation = path + "ImageShow" + formato_png;
        }





    }
}
