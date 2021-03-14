using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace master_tso
{
    public partial class list_act_work : Form
    {
        public list_act_work()
        {
            InitializeComponent();
        }

        private void list_act_work_Load(object sender, EventArgs e)
        {
            string query = "SELECT a.id, a.id_registration, a.master_text, a.date_act, m.name, (SELECT GROUP_CONCAT(se.name SEPARATOR '; ') FROM after_list_service s inner join service se on s.id_service = se.id WHERE s.id_act_reg = a.id) FROM act_check_work a INNER JOIN master_sto m on a.master_sto = m.id";
            using (MySqlConnection conn = new MySqlConnection(Mysql.connection))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].HeaderText = "ID_акта";
                    dataGridView1.Columns[1].HeaderText = "ID_обращения клиента";
                    dataGridView1.Columns[2].HeaderText = "Рекомендации мастера";
                    dataGridView1.Columns[3].HeaderText = "Дата и время передаи автомобиля клиенту";
                    dataGridView1.Columns[4].HeaderText = "Мастер-приемщик";
                    dataGridView1.Columns[5].HeaderText = "Перечень выполненных работ";
                }
            }
        }
    }
}
