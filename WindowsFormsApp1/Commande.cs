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
    public partial class Commande : Form
    {
        string sql = "";
        public int nbchilli = 0;
        public int nbfajitas = 0;
        public int nbnachos = 0;
        public int nbsoda = 0;
        public int nbbiere = 0;
        public Commande()
        {
            InitializeComponent();
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

        private void Commande_Load(object sender, EventArgs e)
        {

        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            nbchilli += 1; 
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            nbfajitas += 1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            nbnachos += 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            nbsoda += 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            nbbiere += 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string br = Environment.NewLine;
            if (textBox2.Text == "") {
                MessageBox.Show("veuillez entrer un nom");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("veuillez entrer une adresse");
            }
            else
            {
                int prix = GetMontant(nbfajitas, nbchilli, nbnachos, nbsoda, nbbiere);
                string sql = "INSERT INTO commande (nbfajitas, nbchilli, nbnachos, nbsoda, nbbiere, date, nom, montant, adresse) VALUES ('" + nbfajitas + "', '" + nbchilli + "', '" + nbnachos + "', '" + nbsoda + "', '" + nbbiere + "', '" + dateTimePicker1.Value + "', '" + textBox2.Text + "', "+prix+", '"+ textBox1.Text +"')";
                MessageBox.Show("INSERT INTO commande  VALUES ('" + nbfajitas + "', '" + nbchilli + "', '" + nbnachos + "', '" + nbsoda + "', '" + nbbiere + "', '" + dateTimePicker1.Value + "', '" + textBox2.Text + "')");
                Commande.NonQuery(sql, "integrated security=true;persist security info=True;initial catalog=PPE2;data source=DESKTOP-ONCU3TD;");
            }
            
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
