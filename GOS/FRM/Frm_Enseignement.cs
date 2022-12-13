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
    public partial class Frm_Enseignement : Form
    {
        //Connexion _ la base de données 
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GOS;Integrated Security=True");
        public Frm_Enseignement()
        {
            InitializeComponent();
        }
        public void chargerListe()
        {

            try
            {

                SqlCommand cmd = new SqlCommand("Select * FROM T_Enseignement", con);
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
            pnlcorps2.Visible = true;
            pnlNouv.Visible = false;
            btnSauv.Text = "Enregistrer";
            ChargerComboEns();
            ChargerComboSit();
            ChargerComboProm();
            ChargerComboLoc();
            ChargerComboCours();
        }

        private void btnSauv_Click(object sender, EventArgs e)
        {

            if (btnSauv.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Enseignement values (@CodEngn, @DateEnseig, @HeureDeb, @HeureFin, @CodEns, @CodProm, @CodSit, @CodLoc, @CodCour)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodEngn", txtCod.Text);
                    cmd.Parameters.AddWithValue("@DateEnseig", dtDebut.Value);
                    cmd.Parameters.AddWithValue("@HeureDeb", cmbDtDeb.Text);
                    cmd.Parameters.AddWithValue("@HeureFin", cmbFin.Text);
                    cmd.Parameters.AddWithValue("@CodEns", cmbEns.SelectedValue);
                    cmd.Parameters.AddWithValue("@CodProm", cmbProm.SelectedValue);
                    cmd.Parameters.AddWithValue("@CodSit", cmbSit.SelectedValue);
                    cmd.Parameters.AddWithValue("@CodLoc", cmbLoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@CodCour", cmbCours.SelectedValue);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlcorps2.Visible = false;
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
                    SqlCommand cmd = new SqlCommand("Update T_Enseignant Set CodCour = @CodCour,DateEnseig = @DateEnseig, HeureDeb = @HeureDeb, HeureFin = @HeureFin, CodEns = @CodEns, CodProm = @CodProm, CodSit = @CodSit, CodLoc = @CodLoc  where CodEngn = @CodEngn", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodEngn", txtCod.Text);
                    cmd.Parameters.AddWithValue("@DateEnseig", dtDebut.Value);
                    cmd.Parameters.AddWithValue("@HeureDeb", cmbDtDeb.Text);
                    cmd.Parameters.AddWithValue("@HeureFin", cmbFin.Text);
                    cmd.Parameters.AddWithValue("@CodEns", cmbEns.SelectedValue);
                    cmd.Parameters.AddWithValue("@CodProm", cmbProm.SelectedValue);
                    cmd.Parameters.AddWithValue("@CodSit", cmbSit.SelectedValue);
                    cmd.Parameters.AddWithValue("@CodLoc", cmbLoc.SelectedValue);
                    cmd.Parameters.AddWithValue("@CodCour", cmbCours.SelectedValue);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  modifiées avec succès", "Mis à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    chargerListe();
                    pnlcorps2.Visible = false;
                    pnlNouv.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de l'opération", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChargerComboCours()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Cours", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuillez selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbCours.DataSource = dt;
            cmbCours.DisplayMember = "LibCour";
            cmbCours.ValueMember = "CodCour";
        }
        private void ChargerComboLoc()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Local", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuillez selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbLoc.DataSource = dt;
            cmbLoc.DisplayMember = "Intitul";
            cmbLoc.ValueMember = "CodLoc";
        }
        private void ChargerComboSit()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Site", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuillez selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbSit.DataSource = dt;
            cmbSit.DisplayMember = "LibSit";
            cmbSit.ValueMember = "CodSit";
        }

        private void ChargerComboProm()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Promotion", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuillez selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbProm.DataSource = dt;
            cmbProm.DisplayMember = "LibProm";
            cmbProm.ValueMember = "CodProm";
        }

        private void ChargerComboEns()
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("Select CodEns,Nom  FROM T_Enseignant", con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "Veuillez selectionner";
                dt.Rows.InsertAt(row, 0);
                cmbEns.DataSource = dt;
                cmbEns.DisplayMember = "Nom";
                cmbEns.ValueMember = "CodEns";
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez enregistrer d'abord les enseignants");
            }
        }

        private void Frm_Enseignement_Load(object sender, EventArgs e)
        {
            ChargerComboEns();
            ChargerComboSit();
            ChargerComboProm();
            ChargerComboLoc();
            ChargerComboCours();
            chargerListe();
        }

        private void btnSupp_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Enseignement where CodEngn= @CodEngn", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodEngn", dtgliste.CurrentRow.Cells[0].Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Suppression effectuée avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);

                chargerListe();
                pnlNouv.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
