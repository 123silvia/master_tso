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
    public partial class static_service : Form
    {
        Mysql mysql = new Mysql();
        string name_s = "";
        public static_service(string name)
        {
            InitializeComponent();
            this.Text = name;
            name_s = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            int i = dateTimePicker2.Value.CompareTo(dateTimePicker1.Value);
            if (i<0)
            {
                MessageBox.Show("Ошибка", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (name_s== "Самая популярная услуга СТО за период")
                {
                    str = mysql.max_service_date_between(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    MessageBox.Show("Самая популярная услуга: " + "\"" + str + "\"", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                if (name_s== "Самая часто обслуживаемая марка автомобиля за период")
                {
                    str = mysql.max_auto_date_between(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    MessageBox.Show("Самая часто обслуживаемая марка автомобиля: " + "\"" + str + "\"", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
