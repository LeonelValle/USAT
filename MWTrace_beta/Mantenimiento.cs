using System;
using System.Configuration;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Mantenimiento : Form
    {
        public Mantenimiento()
        {
            InitializeComponent();
        }

        //
        private readonly Operador operador = new Operador();
        private readonly Modelo model = new Modelo();
        private readonly PCB pcb = new PCB();
        private readonly PCBModelo pm = new PCBModelo();
        private readonly ModeloModem mm = new ModeloModem();
        private readonly Sim sim = new Sim();
        //private readonly Conexion con = new Conexion();

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            #region Llenar los ComboBox
            cb_pcb.DataSource = pcb.LlenarComboBox("select * from tb_PCB");
            cb_pcb.DisplayMember = "pcb";
            cb_pcb.ValueMember = "id_pcb";
            this.cb_pcb.SelectedItem = null;

            cb_pcbBajas.DataSource = pcb.LlenarComboBox("select * from tb_PCB");
            cb_pcbBajas.DisplayMember = "pcb";
            cb_pcbBajas.ValueMember = "id_pcb";
            this.cb_pcbBajas.SelectedItem = null;

            cb_pcbCambiar.DataSource = pcb.LlenarComboBox("select * from tb_PCB");
            cb_pcbCambiar.DisplayMember = "pcb";
            cb_pcbCambiar.ValueMember = "id_pcb";
            this.cb_pcbCambiar.SelectedItem = null;

            cb_NempladoBajas.DataSource = pcb.LlenarComboBox("select * from tb_Operador");
            cb_NempladoBajas.DisplayMember = "numeroempleado";
            cb_NempladoBajas.ValueMember = "id_operador";
            this.cb_NempladoBajas.SelectedItem = null;

            cb_NempleadoCambiar.DataSource = pcb.LlenarComboBox("select * from tb_Operador");
            cb_NempleadoCambiar.DisplayMember = "numeroempleado";
            cb_NempleadoCambiar.ValueMember = "id_operador";
            this.cb_NempleadoCambiar.SelectedItem = null;

            cb_SimBorrar.DataSource = pcb.LlenarComboBox("select * from tb_SIM");
            cb_SimBorrar.DisplayMember = "sim";
            cb_SimBorrar.ValueMember = "id_sim";
            this.cb_SimBorrar.SelectedItem = null;

            cb_pcbCambiar.DataSource = pcb.LlenarComboBox("select * from tb_SIM");
            cb_pcbCambiar.DisplayMember = "sim";
            cb_pcbCambiar.ValueMember = "id_sim";
            this.cb_pcbCambiar.SelectedItem = null;


            cb_pcbCambiar.DataSource = pcb.LlenarComboBox("select * from tb_ModeloModem");
            cb_pcbCambiar.DisplayMember = "modelo";
            cb_pcbCambiar.ValueMember = "id_mm";
            this.cb_pcbCambiar.SelectedItem = null;

            cb_pcbCambiar.DataSource = pcb.LlenarComboBox("select * from tb_ModeloModem");
            cb_pcbCambiar.DisplayMember = "modelo";
            cb_pcbCambiar.ValueMember = "id_mm";
            this.cb_pcbCambiar.SelectedItem = null;

            #endregion

            try
            {
                //select p.pcb, m.modelo, pm.descripcion from tb_PCBModelo pm, tb_PCB p, tb_Modelo m where pm.id_pcb = p.id_pcb and pm.id_modelo = m.id_modelo
                dg_modeloModem.DataSource = pm.LlenarDG("select modelo, numero from tb_ModeloModem").Tables[0];
                dg_Operador.DataSource = pm.LlenarDG("select nombre, numeroempleado from tb_Operador").Tables[0];
                dataGridView3.DataSource = sim.LlenarDG("select sim,digitos from tb_SIM").Tables[0];
                //dataGridView4.DataSource = con.LlenarDG("select conexion from ConfiguracionSistema where id_cs = 7").Tables[0];
                dg_PCB.DataSource = pcb.LlenarDG("select * from tb_PCB").Tables[0];
                dg_modelosPCB.DataSource = pm.LlenarDG("  select p.pcb, m.modelo, pm.descripcion, pm.nomenclatura from tb_PCBModelo pm, tb_Modelo m, tb_PCB p where pm.id_pcb = p.id_pcb and pm.id_modelo = m.id_modelo").Tables[0];

            }
            catch { MessageBox.Show("ERROR!", "no se encontro la base de datos!"); }
            //Server
            //Add server name to combobox
            cboServer.Items.Add(".");
            cboServer.Items.Add("(local)");
            cboServer.Items.Add(@".\SQLEXPRESS");
            cboServer.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboServer.SelectedIndex = 3;

        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            //pcb.Id_pcb = int.Parse(pcb.returnValue("insert into tb_pcb values('" + txt_pcb.Text + "') SELECT @@IDENTITY as ID"));
            if (!(string.IsNullOrEmpty(txt_pcb.Text)))
            {
                pcb.Crud("insert into tb_pcb values('" + txt_pcb.Text + "')");
                Mantenimiento_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Llenar toda la informacion!", "ERROR!");
            }
        }

        private void Btn_guardar_operador_Click(object sender, EventArgs e)
        {
            try
            {
                operador.Crud("insert into tb_Operador values('" + txt_nombre.Text + "', " + txt_nEmpledo.Text + ")");
                Mantenimiento_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Inserte el nombre y el numero de empleado");
            }
        }

        private void Btn_modelomodem_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txt_modelomodem.Text)) && !(string.IsNullOrEmpty(txt_indice.Text)))
            {
                mm.Crud("insert into tb_ModeloModem values('" + txt_modelomodem.Text + "', " + txt_indice.Text + ")");
                Mantenimiento_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Llenar toda la informacion!", "ERROR!");
            }

        }

        private void Btn_guardarSim_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txt_sim.Text)))
            {
                sim.Crud("insert into tb_SIM values('" + txt_sim.Text + "', '" + txt_digitos.Text + "')");
                Mantenimiento_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Llenar toda la informacion!", "ERROR!");
            }
        }

        private void Btn_agregar_Click_1(object sender, EventArgs e)
        {
            if (cb_pcb.SelectedItem != null)
            {
                if (!(string.IsNullOrEmpty(txt_modelo.Text)) && !(string.IsNullOrEmpty(txt_descripcion.Text)) && !(string.IsNullOrEmpty(txt_nomenclatura.Text)))
                {
                    if (!model.Existe("select COUNT(*) from tb_Modelo where modelo = '" + txt_modelo.Text + "'"))

                        model.Id_modelo = int.Parse(pcb.ReturnValue("insert into tb_Modelo values('" + txt_modelo.Text + "'); SELECT SCOPE_IDENTITY();"));
                    else
                        model.Id_modelo = int.Parse(model.ReturnValue("select TOP 1 id_modelo from tb_Modelo where modelo = '" + txt_modelo.Text + "'"));
                    if (!pm.Existe("select count(*) from tb_PCBModelo where id_pcb = " + cb_pcb.SelectedValue + " and id_modelo = " + model.Id_modelo))
                        pm.Crud("insert into tb_PCBModelo values(" + cb_pcb.SelectedValue + "," + model.Id_modelo + ", '" + txt_descripcion.Text + "','" + txt_nomenclatura.Text + "')");
                    else
                        MessageBox.Show("El modelo de PCB ya existe!");

                    Mantenimiento_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Llenar toda la informacion!", "ERROR!");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un PCB!", "ERROR!");
            }
        }

        private void Btn_borrarPCB_Click(object sender, EventArgs e)
        {
            if (cb_pcbBajas.SelectedItem != null)
            {
                pcb.Crud("delete from tb_PCB where id_pcb = " + cb_pcbBajas.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Seleccione un PCB para borrar", "ERROR!");

        }

        private void Btn_cambiarPCB_Click(object sender, EventArgs e)
        {
            if (cb_pcbCambiar.SelectedItem != null && !(string.IsNullOrEmpty(txt_nuevoPCB.Text)))
            {
                pcb.Crud("update tb_PCB set pcb = '" + txt_nuevoPCB.Text + "' where id_pcb = " + cb_pcbCambiar.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Llene todos los campos!", "ERROR!");

        }

        private void Btn_empleadoCambiar_Click(object sender, EventArgs e)
        {
            if (cb_NempleadoCambiar.SelectedItem != null && !(string.IsNullOrEmpty(txt_nombreCambiar.Text)) && !(string.IsNullOrEmpty(txt_NempleadoCambiar.Text)))
            {
                pcb.Crud("update tb_Operador set nombre = '" + txt_nombreCambiar.Text + "', numeroempleado = " + txt_NempleadoCambiar.Text + " where id_operador = " + cb_NempleadoCambiar.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Llene todos los campos!", "ERROR!");
        }

        private void Btn_empleadoBorrar_Click(object sender, EventArgs e)
        {
            if (cb_NempladoBajas.SelectedItem != null)
            {
                pcb.Crud("delete from tb_Operador where id_operador = " + cb_NempladoBajas.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Seleccione un PCB para borrar", "ERROR!");
        }

        private void Btn_ModeloModemBorrar_Click(object sender, EventArgs e)
        {
            if (cb_modeloModemBorrar.SelectedItem != null)
            {
                pcb.Crud("delete from tb_ModeloModem where id_mm = " + cb_modeloModemBorrar.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Seleccione un PCB para borrar", "ERROR!");
        }

        private void Btn_ModeloPCBCambiar_Click(object sender, EventArgs e)
        {
            if (cb_pcb.SelectedItem != null && !(string.IsNullOrEmpty(txt_modeloModemCambiar.Text)) && !(string.IsNullOrEmpty(txt_indiceCambiar.Text)))
            {
                pcb.Crud("update tb_PCBModelo set modelo = '" + txt_modeloModemCambiar.Text + "', indice = " + txt_indiceCambiar.Text + " where id_PM = " + cb_pcb.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Llene todos los campos!", "ERROR!");
        }

        private void Btn_modeloModemCambiar_Click(object sender, EventArgs e)
        {
            if (cb_modeloModeloCambiar.SelectedItem != null && !(string.IsNullOrEmpty(txt_modeloModemCambiar.Text)) && !(string.IsNullOrEmpty(txt_indiceCambiar.Text)))
            {
                pcb.Crud("update tb_ModeloModem set modelo = '" + txt_modeloModemCambiar.Text + "', indice = " + txt_indiceCambiar.Text + " where id_mm = " + cb_modeloModeloCambiar.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Llene todos los campos!", "ERROR!");
        }

        private void Btn_SimBorrar_Click(object sender, EventArgs e)
        {
            if (cb_SimBorrar.SelectedItem != null)
            {
                pcb.Crud("delete from tb_SIM where id_sim = " + cb_SimBorrar.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Seleccione un Sim para borrar", "ERROR!");
        }

        private void Btn_SimCambiar_Click(object sender, EventArgs e)
        {
            if (cb_SimCambiar.SelectedItem != null && !(string.IsNullOrEmpty(txt_nuevoPCB.Text)))
            {
                pcb.Crud("update tb_SIM set sim = '" + txt_SimCambiar.Text + "' where id_sim = " + cb_SimCambiar.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Llene todos los campos!", "ERROR!");
        }


        public void CambiarDatosServer(string localhost, string user, string pass)
        {
            String cadenaNueva = "Data Source=" + localhost + "\\SQLEXPRESS;Initial Catalog=MWTrace;user id=" + user + ";password=" + pass + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //abrimos la configuración de nuestro proyecto
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //hacemos la modificacion de la cadena de conexion (ServerDb es el atributo que tengo en app.config) 
            config.ConnectionStrings.ConnectionStrings["ServerDb"].ConnectionString = cadenaNueva;
            //Cambiamos el modo de guardado
            config.Save(ConfigurationSaveMode.Modified, true);
            // modificamos el guardado 
            Properties.Settings.Default.Save();
            //Podemos revisar en la consola que configuraciones quedaron despues del comando
            //aqui en adelante es opcional        
            ConnectionStringSettingsCollection settings =
            ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    Console.WriteLine(cs.Name);
                    Console.WriteLine(cs.ProviderName);
                    Console.WriteLine(cs.ConnectionString);
                }
            }
        }

        private void Btn_connect_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", cboServer.Text, txt_localhost.Text, txt_user.Text, txt_password.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test connection succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            //Set connection string
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", cboServer.Text, txt_localhost.Text, txt_user.Text, txt_password.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("ServerDb", connectionString);

                    MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboServer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label27_Click(object sender, EventArgs e)
        {

        }

        private void Label28_Click(object sender, EventArgs e)
        {

        }

        private void Txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void Txt_localhost_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }
    }
}
