using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using System.Collections;

namespace master_tso
{
    public partial class Add_client : Form
    {
        Mysql mysql = new Mysql();
        List<int> list_services = new List<int>();
        string flag_ok = "";
        string flag_cancel = "";
        public Add_client()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.comboBox2.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.textBox1.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.comboBox4.Enabled = false;
            this.button1.Enabled = false;
            Dictionary<int,string> services = mysql.select_services();
            comboBox3.DataSource = new BindingSource(services, null);
            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";
            Dictionary<int, string> masters = mysql.select_masters();
            comboBox4.DataSource = new BindingSource(masters, null);
            comboBox4.DisplayMember = "Value";
            comboBox4.ValueMember = "Key";
        }

        private void Add_client_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> clients = mysql.select_clients();
            comboBox1.DataSource = new BindingSource(clients, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count != 0) { comboBox2.Text= ""; }
            Dictionary<int,string> autos = mysql.select_auto(((KeyValuePair<int, string>)comboBox1.SelectedItem).Key);
            if (autos.Count != 0)
            {
                this.button2.Enabled = true;
                this.dateTimePicker1.Enabled = true;
                this.textBox1.Enabled = true;
                this.button2.Enabled = true;
                this.button3.Enabled = true;
                this.comboBox4.Enabled = true;
                this.button1.Enabled = true;
                this.comboBox2.Enabled = true;
                comboBox2.DataSource = new BindingSource(autos, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
            }
            else { 
                comboBox2.DataSource = null;
                this.comboBox2.Enabled = false;
                this.dateTimePicker1.Enabled = false;
                this.textBox1.Enabled = false;
                this.button2.Enabled = false;
                this.button3.Enabled = false;
                this.comboBox4.Enabled = false;
                this.button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items) list_services.Add(((KeyValuePair<int, string>)item).Key);
            mysql.add_new_registration_clients(((KeyValuePair<int, string>)comboBox1.SelectedItem).Key, ((KeyValuePair<int, string>)comboBox2.SelectedItem).Key, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), textBox1.Text, list_services, ((KeyValuePair<int, string>)comboBox4.SelectedItem).Key);
            if (MessageBox.Show("Регистрация обращения клиента на СТО прошла успешно!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                flag_ok = "OK";
                this.Close();
                list_reg_add_clients list_Reg_Add_Clients = new list_reg_add_clients();
                list_Reg_Add_Clients.ShowDialog();
            }
            flag_ok = "OK";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.Contains(comboBox3.SelectedItem)) listBox1.Items.Add(comboBox3.SelectedItem);
            listBox1.DisplayMember = "Value";
            listBox1.ValueMember = "Key";
            comboBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения", "Уведомление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                flag_cancel = "CANCEL";
                mysql.add_new_registration_clients(((KeyValuePair<int, string>)comboBox1.SelectedItem).Key, ((KeyValuePair<int, string>)comboBox2.SelectedItem).Key, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), textBox1.Text, list_services, ((KeyValuePair<int, string>)comboBox4.SelectedItem).Key);
                this.Close();
                list_reg_add_clients list_Reg_Add_Clients = new list_reg_add_clients();
                list_Reg_Add_Clients.ShowDialog();
            }
            else
            {
                flag_cancel = "CANCEL";
                this.Close();
            }
        }

        private void Add_client_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (flag_ok != "OK" && flag_cancel != "CANCEL")
            {
                if (MessageBox.Show("Сохранить изменения", "Уведомление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    mysql.add_new_registration_clients(((KeyValuePair<int, string>)comboBox1.SelectedItem).Key, ((KeyValuePair<int, string>)comboBox2.SelectedItem).Key, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), textBox1.Text, list_services, ((KeyValuePair<int, string>)comboBox4.SelectedItem).Key);
                    Dispose();
                    list_reg_add_clients list_Reg_Add_Clients = new list_reg_add_clients();
                    list_Reg_Add_Clients.ShowDialog();
                }
            }
        }
    }
}
