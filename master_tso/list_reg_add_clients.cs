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
    public partial class list_reg_add_clients : Form
    {
        public list_reg_add_clients()
        {
            InitializeComponent();
        }

        private void list_reg_add_clients_Load(object sender, EventArgs e)
        {
            string query = "SELECT r.id, c.name, a.name, r.data_new, r.client_text, m.name, (SELECT GROUP_CONCAT(se.name SEPARATOR '; ') FROM before_list_service s inner join service se on s.id_service = se.id WHERE s.id_reg_client = r.id) FROM registration_new_client r inner join client c on r.id_client_n = c.id inner join auto a on a.id = r.id_auto_n inner join master_sto m on m.id = r.master_tso";
            using (MySqlConnection conn = new MySqlConnection(Mysql.connection))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].HeaderText = "ID_обращения";
                    dataGridView1.Columns[1].HeaderText = "Клиент";
                    dataGridView1.Columns[2].HeaderText = "Автомобиль";
                    dataGridView1.Columns[3].HeaderText = "Дата обращения";
                    dataGridView1.Columns[4].HeaderText = "Замечания клиента";
                    dataGridView1.Columns[5].HeaderText = "Мастер-приемщик";
                    dataGridView1.Columns[6].HeaderText = "Предварительный перечень работ";
                }
            }
        }
    }
}
