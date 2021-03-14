using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

namespace master_tso
{
    class Mysql
    {
        static public string connection = "server=127.0.0.1;port=3306;user=root;password=root;database=tso";

        public Dictionary<int, string> select_clients()
        {
            Dictionary<int, string> clients = new Dictionary<int, string>();
            using (MySqlConnection sql_connection = new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "SELECT id, name FROM client";
                using (var command = new MySqlCommand(command_string, sql_connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(reader.GetInt32("id"), reader.GetString("name"));
                        }
                    }
                }
            }
            return clients;
        }
        public Dictionary<int, string> select_auto(int id_client)
        {
            Dictionary<int, string> autos = new Dictionary<int, string>();
            using (MySqlConnection sql_connection = new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "SELECT a.id, a.name FROM buff_client_auto b INNER JOIN auto a on b.id_auto=a.id WHERE b.id_client=@idclient";
                using (var command = new MySqlCommand(command_string, sql_connection))
                {
                    command.Parameters.Add("@idclient", MySqlDbType.Int32).Value = id_client;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            autos.Add(reader.GetInt32("id"), reader.GetString("name"));
                        }
                    }
                }
            }
            return autos;
        }
        public Dictionary<int, string> select_services()
        {
            Dictionary<int, string> services = new Dictionary<int, string>();
            using (MySqlConnection sql_connection = new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "SELECT id, name FROM service";
                using (var command = new MySqlCommand(command_string, sql_connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            services.Add(reader.GetInt32("id"), reader.GetString("name"));
                        }
                    }
                }
            }
            return services;
        }
        public Dictionary<int, string> select_masters()
        {
            Dictionary<int, string> masters = new Dictionary<int, string>();
            using (MySqlConnection sql_connection = new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "SELECT id, name FROM master_sto";
                using (var command = new MySqlCommand(command_string, sql_connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            masters.Add(reader.GetInt32("id"), reader.GetString("name"));
                        }
                    }
                }
            }
            return masters;
        }
        public void add_new_registration_clients(int id_client, int id_auto, string data_new, string client_text, List<int> list_services, int id_master_sto)
        {
            using (MySqlConnection sql_connection = new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "INSERT INTO registration_new_client(id_client_n, id_auto_n, data_new, client_text, master_tso) VALUE(@idclient,@idauto,@datanew,@clienttext,@idmastersto);" + "SELECT LAST_INSERT_ID()";
                var command = new MySqlCommand(command_string, sql_connection);
                command.Parameters.Add("@idclient", MySqlDbType.Int32).Value = id_client;
                command.Parameters.Add("@idauto", MySqlDbType.Int32).Value = id_auto;
                command.Parameters.Add("@datanew", MySqlDbType.DateTime).Value = data_new;
                command.Parameters.Add("@clienttext", MySqlDbType.Text).Value = client_text;
                command.Parameters.Add("@idmastersto", MySqlDbType.Int32).Value = id_master_sto;
                int lastID = Convert.ToInt32(command.ExecuteScalar());
                foreach (int item in list_services)
                {
                    command_string = "INSERT INTO before_list_service(id_reg_client, id_service) VALUE(@idregclient,@idservice)";
                    command = new MySqlCommand(command_string, sql_connection);
                    command.Parameters.Add("@idregclient", MySqlDbType.Int32).Value = lastID;
                    command.Parameters.Add("@idservice", MySqlDbType.Int32).Value = item;
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<int> asct_number_registration_client()
        {
            List<int> act_number = new List<int>();
            using (MySqlConnection sql_connection = new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "SELECT id FROM registration_new_client";
                using (var command = new MySqlCommand(command_string, sql_connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            act_number.Add(reader.GetInt32("id"));
                        }
                    }
                }
            }
            return act_number;
        }
        public void add_new_act(int id_registration, string date_act, string master_text, List<int> list_services, int id_master_sto)
        {
            using (MySqlConnection sql_connection = new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "INSERT INTO act_check_work(id_registration, master_text, date_act, master_sto) VALUE(@idregistration,@mastertext,@dateact,@idmastersto);" + "SELECT LAST_INSERT_ID()";
                var command = new MySqlCommand(command_string, sql_connection);
                command.Parameters.Add("@idregistration", MySqlDbType.Int32).Value = id_registration;
                command.Parameters.Add("@mastertext", MySqlDbType.Text).Value = master_text;
                command.Parameters.Add("@dateact", MySqlDbType.DateTime).Value = date_act;
                command.Parameters.Add("@idmastersto", MySqlDbType.Int32).Value = id_master_sto;
                int lastID = Convert.ToInt32(command.ExecuteScalar());
                foreach (int item in list_services)
                {
                    command_string = "INSERT INTO after_list_service(id_act_reg, id_service) VALUE(@idactreg,@idservice)";
                    command = new MySqlCommand(command_string, sql_connection);
                    command.Parameters.Add("@idactreg", MySqlDbType.Int32).Value = lastID;
                    command.Parameters.Add("@idservice", MySqlDbType.Int32).Value = item;
                    command.ExecuteNonQuery();
                }
            }
        }
        public string max_service_date_between(string date1, string date2)
        {
            string res = "";
            using (MySqlConnection sql_connection=new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "SELECT s.name, count(s.id) FROM act_check_work a inner join after_list_service asi on a.id = asi.id_act_reg inner join service s on s.id = asi.id_service where date_act>=@date1 and date_act<=@date2 group by s.name ORDER BY COUNT(s.id) DESC LIMIT 1";
                using (var command = new MySqlCommand(command_string, sql_connection))
                {
                    command.Parameters.Add("@date1", MySqlDbType.DateTime).Value = date1;
                    command.Parameters.Add("@date2", MySqlDbType.DateTime).Value = date2;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res=reader.GetString("name");
                        }
                    }
                }
            }
            return res;
        }
        public string max_auto_date_between(string date1, string date2)
        {
            string res = "";
            using (MySqlConnection sql_connection = new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "SELECT a.name, count(a.id) FROM registration_new_client r inner join auto a on a.id = r.id_auto_n where data_new>=@date1 and data_new<=@date2 group by a.name ORDER BY COUNT(a.id) DESC LIMIT 1";
                using (var command = new MySqlCommand(command_string, sql_connection))
                {
                    command.Parameters.Add("@date1", MySqlDbType.DateTime).Value = date1;
                    command.Parameters.Add("@date2", MySqlDbType.DateTime).Value = date2;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res = reader.GetString("name");
                        }
                    }
                }
            }
            return res;
        }
        public string select_client_date_between()
        {
            string res = "";
            using (MySqlConnection sql_connection = new MySqlConnection(connection))
            {
                sql_connection.Open();
                string command_string = "SELECT GROUP_CONCAT(c.name SEPARATOR ', ') as name from client c where c.id not in (select s.id_client_n from registration_new_client s)";
                using (var command = new MySqlCommand(command_string, sql_connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res = reader.GetString("name");
                        }
                    }
                }
            }
            return res;
        }
    }
}

