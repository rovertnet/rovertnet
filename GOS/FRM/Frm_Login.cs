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

namespace GOS.FRM
{
    public partial class Frm_Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GOS;Integrated Security=True");

        public Frm_Login()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //SQL Query pour vérifier la connexion
                SqlCommand cmd = new SqlCommand("SELECT *FROM T_Login WHERE Login=@Login AND MDP=@MDP", con);
                // SqlCommand cmd = new SqlCommand("SELECT *FROM T_Utilisateur WHERE Login=@Login AND MDP=@MDP AND Fonction=@Fonction", con);
                //Création d'une commande SQL pour transmettre la valeur
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Login", txtLogin.Text);
                cmd.Parameters.AddWithValue("@MDP", txtpass.Text);
                // cmd.Parameters.AddWithValue("@Fonction", txtpass);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                //Vérification des lignes dans datatable
                if (dt.Rows.Count > 0)
                {
                    //Connexion réussie
                    MessageBox.Show("Bienvenue", "Ouverture session", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 frm = new Form1();
                    txtLogin.Focus();
                    txtLogin.Text = "";
                    txtpass.Text = "";
                    frm.ActiverFonction();
                    frm.lblUser.Text = "( 1 User )";
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    //Echec de la connexion
                    //Connexion réussie
                    MessageBox.Show("Echec", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        
    }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            //Application.Exit();
        }
    }
}
