namespace GOS.FRM
{
    partial class Frm_PromCous
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlNouv = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMaj = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSitLib = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSitCod = new System.Windows.Forms.TextBox();
            this.btnSauvAnn = new System.Windows.Forms.Button();
            this.btnSauvSite = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgliste = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.pnlNouv.SuspendLayout();
            this.pnlMaj.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgliste)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pnlNouv);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1110, 68);
            this.panel2.TabIndex = 26;
            // 
            // pnlNouv
            // 
            this.pnlNouv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNouv.Controls.Add(this.button1);
            this.pnlNouv.Controls.Add(this.button2);
            this.pnlNouv.Location = new System.Drawing.Point(883, 12);
            this.pnlNouv.Name = "pnlNouv";
            this.pnlNouv.Size = new System.Drawing.Size(229, 55);
            this.pnlNouv.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(113, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Supprimer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(4, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 41);
            this.button2.TabIndex = 0;
            this.button2.Text = "Nouveau";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Liste et mis à jours disponible";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Interface Site";
            // 
            // pnlMaj
            // 
            this.pnlMaj.BackColor = System.Drawing.Color.White;
            this.pnlMaj.Controls.Add(this.label7);
            this.pnlMaj.Controls.Add(this.txtSitLib);
            this.pnlMaj.Controls.Add(this.label8);
            this.pnlMaj.Controls.Add(this.txtSitCod);
            this.pnlMaj.Controls.Add(this.btnSauvAnn);
            this.pnlMaj.Controls.Add(this.btnSauvSite);
            this.pnlMaj.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMaj.Location = new System.Drawing.Point(0, 68);
            this.pnlMaj.Name = "pnlMaj";
            this.pnlMaj.Size = new System.Drawing.Size(1110, 68);
            this.pnlMaj.TabIndex = 29;
            this.pnlMaj.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(246, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "Libelé Site  :";
            // 
            // txtSitLib
            // 
            this.txtSitLib.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSitLib.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSitLib.Location = new System.Drawing.Point(250, 27);
            this.txtSitLib.Name = "txtSitLib";
            this.txtSitLib.Size = new System.Drawing.Size(609, 29);
            this.txtSitLib.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 21);
            this.label8.TabIndex = 5;
            this.label8.Text = "Code site";
            // 
            // txtSitCod
            // 
            this.txtSitCod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSitCod.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSitCod.Location = new System.Drawing.Point(21, 27);
            this.txtSitCod.Name = "txtSitCod";
            this.txtSitCod.Size = new System.Drawing.Size(168, 29);
            this.txtSitCod.TabIndex = 4;
            // 
            // btnSauvAnn
            // 
            this.btnSauvAnn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSauvAnn.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSauvAnn.Location = new System.Drawing.Point(996, 22);
            this.btnSauvAnn.Name = "btnSauvAnn";
            this.btnSauvAnn.Size = new System.Drawing.Size(109, 41);
            this.btnSauvAnn.TabIndex = 1;
            this.btnSauvAnn.Text = "Annuler";
            this.btnSauvAnn.UseVisualStyleBackColor = true;
            this.btnSauvAnn.Click += new System.EventHandler(this.btnSauvAnn_Click);
            // 
            // btnSauvSite
            // 
            this.btnSauvSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSauvSite.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSauvSite.Location = new System.Drawing.Point(887, 22);
            this.btnSauvSite.Name = "btnSauvSite";
            this.btnSauvSite.Size = new System.Drawing.Size(109, 41);
            this.btnSauvSite.TabIndex = 0;
            this.btnSauvSite.Text = "Sauvegarder";
            this.btnSauvSite.UseVisualStyleBackColor = true;
            this.btnSauvSite.Click += new System.EventHandler(this.btnSauvSite_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgliste);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 511);
            this.panel1.TabIndex = 30;
            // 
            // dtgliste
            // 
            this.dtgliste.AllowUserToAddRows = false;
            this.dtgliste.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(203)))), ((int)(((byte)(124)))));
            this.dtgliste.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dtgliste.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgliste.BackgroundColor = System.Drawing.Color.White;
            this.dtgliste.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgliste.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgliste.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(203)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgliste.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dtgliste.ColumnHeadersHeight = 30;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(203)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgliste.DefaultCellStyle = dataGridViewCellStyle19;
            this.dtgliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgliste.EnableHeadersVisualStyles = false;
            this.dtgliste.GridColor = System.Drawing.SystemColors.Control;
            this.dtgliste.Location = new System.Drawing.Point(0, 0);
            this.dtgliste.Name = "dtgliste";
            this.dtgliste.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(203)))), ((int)(((byte)(124)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgliste.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dtgliste.RowHeadersVisible = false;
            this.dtgliste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgliste.Size = new System.Drawing.Size(1110, 511);
            this.dtgliste.TabIndex = 7;
            // 
            // Frm_PromCous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1110, 647);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMaj);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_PromCous";
            this.Text = "Frm_PromCous";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlNouv.ResumeLayout(false);
            this.pnlMaj.ResumeLayout(false);
            this.pnlMaj.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgliste)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlNouv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlMaj;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSitLib;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSitCod;
        private System.Windows.Forms.Button btnSauvAnn;
        private System.Windows.Forms.Button btnSauvSite;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dtgliste;
    }
}