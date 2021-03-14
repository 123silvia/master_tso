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
    public partial class Add_act : Form
    {
        Mysql mysql = new Mysql();
        List<int> list_services = new List<int>();
        string flag_ok = "";
        string flag_cancel = "";
        public Add_act()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.comboBox2.Enabled = false;
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.textBox1.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.comboBox3.Enabled = false;
            this.button3.Enabled = false;
            Dictionary<int, string> services = mysql.select_services();
            comboBox2.DataSource = new BindingSource(services, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
            Dictionary<int, string> masters = mysql.select_masters();
            comboBox3.DataSource = new BindingSource(masters, null);
            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";
        }

        private void Add_act_Load(object sender, EventArgs e)
        {
            List<int> number_reg_client = mysql.asct_number_registration_client();
            comboBox1.DataSource = new BindingSource(number_reg_client, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox2.Enabled = true;
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.textBox1.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.comboBox3.Enabled = true;
            this.button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!listBox1.Items.Contains(comboBox2.SelectedItem)) listBox1.Items.Add(comboBox2.SelectedItem);
            listBox1.DisplayMember = "Value";
            listBox1.ValueMember = "Key";
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items) list_services.Add(((KeyValuePair<int, string>)item).Key);
            mysql.add_new_act(System.Convert.ToInt32(comboBox1.SelectedItem.ToString()), dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), textBox1.Text, list_services, ((KeyValuePair<int, string>)comboBox3.SelectedItem).Key);
            if (MessageBox.Show("Регистрация акта выполненных работ прошла успешно!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                flag_ok = "OK";
                this.Close();
                list_act_work list_Act_Work = new list_act_work();
                list_Act_Work.ShowDialog();
            }
            flag_ok = "OK";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения", "Уведомление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                flag_cancel = "CANCEL";
                mysql.add_new_act(System.Convert.ToInt32(comboBox1.SelectedItem.ToString()), dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), textBox1.Text, list_services, ((KeyValuePair<int, string>)comboBox3.SelectedItem).Key);
                this.Close();
                list_act_work list_Act_Work = new list_act_work();
                list_Act_Work.ShowDialog();
            }
            else
            {
                flag_cancel = "CANCEL";
                this.Close();
            }
        }

        private void Add_act_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag_ok != "OK" && flag_cancel != "CANCEL")
            {
                if (MessageBox.Show("Сохранить изменения", "Уведомление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    mysql.add_new_act(System.Convert.ToInt32(comboBox1.SelectedItem.ToString()), dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), textBox1.Text, list_services, ((KeyValuePair<int, string>)comboBox3.SelectedItem).Key);
                    Dispose();
                    list_act_work list_Act_Work = new list_act_work();
                    list_Act_Work.ShowDialog();
                }
            }
        }
    }
}
