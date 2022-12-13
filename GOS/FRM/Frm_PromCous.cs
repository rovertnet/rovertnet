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
    public partial class Frm_PromCous : Form
    {
        //Connexion _ la base de données 
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GOS;Integrated Security=True");
        public Frm_PromCous()
        {
            InitializeComponent();
        }
        private void Viderchamps()
        {
            txtSitCod.Clear();
            txtSitLib.Clear();
        }
        public void chargerListe()
        {

            try
            {

                SqlCommand cmd = new SqlCommand("Select * FROM T_Site", con);
                DataTable dt = new DataTable();
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                dtgliste.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de chargement suite : " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = true;
            pnlNouv.Visible = false;
            btnSauvSite.Text = "Enregistrer";
            Viderchamps();
        }

        private void btnSauvSite_Click(object sender, EventArgs e)
        {
            if (btnSauvSite.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Site values (@CodSit, @LibSit)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodSit", txtSitCod.Text);
                    cmd.Parameters.AddWithValue("@LibSit", txtSitLib.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlMaj.Visible = false;
                    pnlNouv.Visible = true;
                    chargerListe();
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de l'opération", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update T_Site Set LibSit = @LibSit where CodSit = @CodSit", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodSit", txtSitCod.Text);
                    cmd.Parameters.AddWithValue("@LibSit", txtSitLib.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  modifiées avec succès", "Mis à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    chargerListe();
                    pnlMaj.Visible = false;
                    pnlNouv.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de l'opération", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSauvAnn_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = false;
            pnlNouv.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Site where CodSit= @CodSit", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodSit", dtgliste.CurrentRow.Cells[0].Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Suppression effectuée avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);

                chargerListe();
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
