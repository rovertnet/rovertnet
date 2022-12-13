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
    public partial class Frm_Enseignant : Form
    {
        //Connexion _ la base de données 
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GOS;Integrated Security=True");
        public Frm_Enseignant()
        {
            InitializeComponent();
        }
        //Vider les champs 
        private void Viderchamps()
        {
            txtCod.Clear();
            txtEmail.Clear();
            txtNom.Clear();
            txtPostn.Clear();
            txtPrenom.Clear();
            txtTel.Clear();
            cmbSexe.Text = "";
        }

        // CHARGER LES ENSEIGNANTS 
        public void chargerListe()
        {

            try
            {

                SqlCommand cmd = new SqlCommand("Select * FROM T_Enseignant", con);
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

        //Chrger Combo Fonction 
        private void ChargerCombo()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Fonction", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuiller selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbFonct.DataSource = dt;
            cmbFonct.DisplayMember = "LibFonct";
            cmbFonct.ValueMember = "CodFonct";
        }
     

        private void pnlcorps2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnSauvGrade_Click(object sender, EventArgs e)
        {
            pnlMsj.Enabled = true  ;
            pnlGrade.Visible = false;
           
            

            try
            {
                SqlCommand cmd = new SqlCommand("Insert into T_Posseder values (@CodEns, @CodGrad,@DatDeb,@DatFin)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodEns", dtgliste.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@CodGrad", cmbGrade.SelectedValue);
                cmd.Parameters.AddWithValue("@DatDeb", dtDebut.Value);
                cmd.Parameters.AddWithValue("@DatFin", dtFin.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlMsj.Enabled = true;
                pnlGrade.Visible = false;
                //pnlMaj.Visible = false;
                // pnlNouv.Visible = true;
                //chargerListe();
                txtGrad.Text = cmbGrade.Text;

            }
            catch (Exception)
            {
                MessageBox.Show("Echec de l'opération", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnulGrad_Click(object sender, EventArgs e)
        {
            pnlMsj.Enabled = true;
            pnlGrade.Visible = false;
           
            btnSauvGrade.Select();
        }

        private void btnNouv_Click(object sender, EventArgs e)
        {

            pnlcorps2.Visible = true;
            pnlNouv.Visible = false;
            btnSauv.Text = "Enregistrer";
            Viderchamps();
        }

        private void btnSauv_Click(object sender, EventArgs e)
        {
            
            if (btnSauv.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Enseignant values (@CodEns, @Nom, @Postnom, @Prenom, @Sexe, @Adresse, @Tel, @Email, @CodFonct)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodEns", txtCod.Text);
                    cmd.Parameters.AddWithValue("@Nom", txtNom.Text);
                    cmd.Parameters.AddWithValue("@Postnom", txtPostn.Text);
                    cmd.Parameters.AddWithValue("@Prenom", txtPrenom.Text);
                    cmd.Parameters.AddWithValue("@Sexe", cmbSexe.Text);
                    cmd.Parameters.AddWithValue("@Adresse", txtAdress.Text);
                    cmd.Parameters.AddWithValue("@Tel", txtTel.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@CodFonct", cmbFonct.SelectedValue);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //pnlcorps2.Visible = false;
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
                    SqlCommand cmd = new SqlCommand("Update T_Enseignant Set Nom = @Nom,Postnom = @Postnom, Prenom = @Prenom, Sexe = @Sexe, Adresse = @Adresse, Tel = @Tel, Email = @Email, CodFonct = @CodFonct  where CodEns = @CodEns", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodEns", txtCod.Text);
                    cmd.Parameters.AddWithValue("@Nom", txtNom.Text);
                    cmd.Parameters.AddWithValue("@Postnom", txtPostn.Text);
                    cmd.Parameters.AddWithValue("@Prenom", txtPrenom.Text);
                    cmd.Parameters.AddWithValue("@Sexe", cmbSexe.Text);
                    cmd.Parameters.AddWithValue("@Adresse", txtAdress.Text);
                    cmd.Parameters.AddWithValue("@Tel", txtTel.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@CodFonct", cmbFonct.Text);

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

        private void btnAnn_Click(object sender, EventArgs e)
        {
            pnlcorps2.Visible = false;
        }

        private void Frm_Enseignant_Load(object sender, EventArgs e)
        {
            chargerListe();
            ChargerCombo();
            ChargerCombo1();
        }

        #region PossederGrade
        //Chrger Combo Grade
        private void ChargerCombo1()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Grade", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuillez selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbGrade.DataSource = dt;
            cmbGrade.DisplayMember = "LibGrad";
            cmbGrade.ValueMember = "CodGrad";
        }
        private void btnNouvGrade_Click(object sender, EventArgs e)
        {
            cmbGrade.Text = "";
            cmbGrade.Focus();
            lblNomEnseignant.Text = txtNom.Text + " " + txtPostn.Text + " " + txtPrenom.Text;
            pnlGrade.Visible = true;
            pnlMsj.Enabled = false;
        }

        #endregion

        private void btnSupp_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Enseignant where CodEns= @CodEns", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodEns", dtgliste.CurrentRow.Cells[0].Value);

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
