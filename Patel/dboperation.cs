using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Patel
{
    class dboperation
    {
        public void doLogin(string username,string password)
        {
            dbconnection c = new dbconnection();
            MySqlConnection con = new MySqlConnection(@c.getconnection());
            MySqlCommand cmd = new MySqlCommand("select_user", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username",username);
            cmd.Parameters.AddWithValue("@pass", password);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MySqlDataAdapter md = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            md.Fill(dt);
            
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Welcome User !");
            }
            else
            {
                MessageBox.Show("Invalid User !!");
            }








            //m = cmd.ExecuteReader();
            //int i = 0;
            //while (m.Read())
            //{
            //    i++;
            //}

            //if (i>0)
            //{

            //    MessageBox.Show("Welcome");
            //}
            //else
            //{
            //    MessageBox.Show("Invalid username or password");
            //}
        }
    }
}
