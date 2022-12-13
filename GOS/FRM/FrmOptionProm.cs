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
    public partial class FrmOptionProm : Form
    {
        //Connexion _ la base de données 
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GOS;Integrated Security=True");

        public FrmOptionProm()
        {
            InitializeComponent();
        }
        //Vider les champs 
        private void Viderchamps()
        {
            txtCodProm.Clear();
            txtCodOpti.Clear();
            txtLibProm.Clear();
            txtLibOpt.Clear();
            cmbVac.Text = "";
        }

        //Region pour la table OPTION
        #region OPTION 
        public void chargerListe()
        {

            try
            {

                SqlCommand cmd = new SqlCommand("Select * FROM T_Option", con);
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
        private void btnNouv_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = true;
            pnlNouv.Visible = false;
            btnSauv.Text = "Enregistrer";
            Viderchamps();
        }
        public void chargerCombo()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Option", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuiller selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbOpt.DataSource = dt;
            cmbOpt.DisplayMember = "LibOpt";
            cmbOpt.ValueMember = "CodOpt";
        }
        private void btnSauvOpt_Click(object sender, EventArgs e)
        {
            if (btnSauv.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Option values (@CodOpt, @LibOpt)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodOpt", txtCodOpti.Text);
                    cmd.Parameters.AddWithValue("@LibOpt", txtLibOpt.Text);

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
                    SqlCommand cmd = new SqlCommand("Update T_Option Set LibOpt = @LibOpt where CodOpt = @CodOpt", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodOpt", txtCodOpti.Text);
                    cmd.Parameters.AddWithValue("@LibOpt", txtLibOpt.Text);

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
        private void btnSuppOpt_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Option where CodOpt= @CodOpt", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodOpt", dtgliste1.CurrentRow.Cells[0].Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Suppression effectuée avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargerListe();
                pnlMaj.Visible = false;
                pnlNouv.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAnnOpt_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = false;
            pnlNouv.Visible = true;
        }
        #endregion

        //Region pour la table PROMOTION
        #region PROMOTION    
        public void chargerListe1()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Select * FROM T_Promotion", con);
                DataTable dt = new DataTable();
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                dtgliste1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de chargement suite : " + ex.Message);
            }
        }
        private void btnNouvProm_Click(object sender, EventArgs e)
        {
            pnlMaj1.Visible = true;
            pnlNouv1.Visible = false;
            btnSauvProm.Text = "Enregistrer";
            Viderchamps();
        }

        private void btnSauvProm_Click(object sender, EventArgs e)
        {
           

            if (btnSauvProm.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Promotion values (@CodProm, @LibProm, @CodOpt,@Vac)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodProm", txtCodProm.Text);
                    cmd.Parameters.AddWithValue("@LibProm", txtLibProm.Text);
                    cmd.Parameters.AddWithValue("@CodOpt", cmbOpt.SelectedValue);
                    cmd.Parameters.AddWithValue("@Vac", cmbVac.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlMaj1.Visible = false;
                    pnlNouv1.Visible = true;
                    chargerListe1();
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
                    SqlCommand cmd = new SqlCommand("Update T_Promotion Set LibProm = @LibProm, CodOpt = @CodOpt,  Vac = @Vac  where CodProm = @CodProm", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodProm", txtCodProm.Text);
                    cmd.Parameters.AddWithValue("@LibProm", txtLibProm.Text);
                    cmd.Parameters.AddWithValue("@CodOpt", cmbOpt.ValueMember);
                    cmd.Parameters.AddWithValue("@Vac", cmbVac.Text);
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

        private void btnAnnProm_Click(object sender, EventArgs e)
        {
            pnlMaj1.Visible = false;
            pnlNouv1.Visible = true;
        }

        private void btnSuppProm_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Promotion where CodProm= @CodProm", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodProm", dtgliste1.CurrentRow.Cells[0].Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Suppression effectuée avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargerListe1();
                pnlMaj1.Visible = false;
                pnlNouv1.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmOptionProm_Load(object sender, EventArgs e)
        {
            chargerListe1();
            chargerListe();
            chargerCombo(); 
        }
    }
    #endregion
}
