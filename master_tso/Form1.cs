using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace master_tso
{
    public partial class Form1 : Form
    {
        Mysql mysql = new Mysql();
        public Form1()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void регистрацияОбращенияКлиентаНаТСОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_client add_client = new Add_client();
            add_client.MdiParent = this;
            add_client.Show();
        }

        private void регистрацияАктаВыполенныхРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_act add_act = new Add_act();
            add_act.MdiParent = this;
            add_act.Show();
        }

        private void самаяПопулярнаяУслугаНаСТОЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            static_service static_Service = new static_service("Самая популярная услуга СТО за период");
            static_Service.MdiParent = this;
            static_Service.Show();
        }

        private void самаяЧастоОбслуживаемаяМаркаАвтомобиляЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            static_service static_Service = new static_service("Самая часто обслуживаемая марка автомобиля за период");
            static_Service.MdiParent = this;
            static_Service.Show();
        }

        private void клиентКоторыйНиРазуНеВоспользовалсяУслугамиСТОЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = mysql.select_client_date_between();
            MessageBox.Show("Клиент(ы), который(е) ни разу не воспользовались услугами СТО: " + str, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
