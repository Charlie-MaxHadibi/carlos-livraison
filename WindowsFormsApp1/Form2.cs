using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        string adresse;
        public Form2()
        {
            InitializeComponent();
        }
        

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select top 1 adresse from commande order by id desc ";
            ReadOrderData("integrated security=true;persist security info=True;initial catalog=PPE2;data source=DESKTOP-ONCU3TD;", sql);
            //webBrowser1.Navigate("http://maps.google.com/maps?q="+adresse);
            MessageBox.Show("http://maps.google.com/maps?q=" + adresse);
        }
        public void ReadOrderData(string connectionString, string queryString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        adresse = String.Format("{0}", reader[0]);
                    }
                }
            }
        }
    }
}
