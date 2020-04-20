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
    public partial class Form1 : Form
    {
        public int nbfajitas;
        public int nbchilli;
        public int nbnachos;
        public int nbsoda;
        public int nbbiere;
        public string adresse;
        public Form1()
        {
            InitializeComponent();
            

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        public static void NonQuery(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
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
                        string nom = String.Format("{0}", reader[0]);
                        string date = String.Format("{0}", reader[6]);
                        adresse = String.Format("{0}", reader[7]);
                        nbfajitas = Int32.Parse(String.Format("{0}", reader[1]));
                        nbchilli = Int32.Parse(String.Format("{0}", reader[2]));
                        nbnachos = Int32.Parse(String.Format("{0}", reader[3]));
                        nbsoda = Int32.Parse(String.Format("{0}", reader[4]));
                        nbbiere = Int32.Parse(String.Format("{0}", reader[5]));
                        int prix = GetMontant(nbfajitas, nbchilli, nbnachos, nbsoda, nbbiere);
                        dataGridView1.Rows.Add(prix+"€", nom, date, adresse);
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisire une methode de classement");
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Montant", "Montant");
                dataGridView1.Columns.Add("Nom", "Nom");
                dataGridView1.Columns.Add("date", "Date");
                dataGridView1.Columns.Add("adresse", "adresse");
                string sql = "SELECT nom, nbfajitas, nbchilli, nbnachos, nbsoda, nbbiere, date, adresse FROM commande ORDER BY " + listBox1.SelectedItem.ToString() + " DESC";
                ReadOrderData("integrated security=true;persist security info=True;initial catalog=PPE2;data source=DESKTOP-ONCU3TD;", sql);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Commande formCommande = new Commande();
            formCommande.ShowDialog();
        }
        public int GetMontant(int nbfajitas, int nbchilli, int nbnachos, int nbbiere, int nbsoda)
        {
            int prixfajitas = 10;
            int prixnachos = 7;
            int prixchilli = 10;
            int prixsoda = 2;
            int prixbiere = 4;
            int montant = nbfajitas * prixfajitas + nbchilli * prixchilli + nbnachos * prixnachos + nbsoda * prixsoda + nbbiere * prixbiere;
            return montant;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 formMaps = new Form2();
            formMaps.ShowDialog();
        }
    }

}
