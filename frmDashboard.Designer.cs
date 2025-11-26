namespace TechSupportApp
{
    partial class frmDashboard
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNovoChamado = new System.Windows.Forms.Button();
            this.btnEditarChamado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TechSupportApp.Properties.Resources.LOGAN_do_sistema;
            this.pictureBox1.Location = new System.Drawing.Point(12, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(199, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(589, 438);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnNovoChamado
            // 
            this.btnNovoChamado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnNovoChamado.FlatAppearance.BorderSize = 0;
            this.btnNovoChamado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoChamado.ForeColor = System.Drawing.Color.White;
            this.btnNovoChamado.Location = new System.Drawing.Point(67, 244);
            this.btnNovoChamado.Name = "btnNovoChamado";
            this.btnNovoChamado.Size = new System.Drawing.Size(75, 23);
            this.btnNovoChamado.TabIndex = 5;
            this.btnNovoChamado.Text = "Novo";
            this.btnNovoChamado.UseVisualStyleBackColor = false;
            this.btnNovoChamado.Click += new System.EventHandler(this.btnNovoChamado_Click);
            // 
            // btnEditarChamado
            // 
            this.btnEditarChamado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnEditarChamado.FlatAppearance.BorderSize = 0;
            this.btnEditarChamado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarChamado.ForeColor = System.Drawing.Color.White;
            this.btnEditarChamado.Location = new System.Drawing.Point(67, 329);
            this.btnEditarChamado.Name = "btnEditarChamado";
            this.btnEditarChamado.Size = new System.Drawing.Size(75, 23);
            this.btnEditarChamado.TabIndex = 7;
            this.btnEditarChamado.Text = "Editar";
            this.btnEditarChamado.UseVisualStyleBackColor = false;
            this.btnEditarChamado.Click += new System.EventHandler(this.btnEditarChamado_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::TechSupportApp.Properties.Resources.icka4uoo98m4ptfybikiu_6532622b_K7b5aS77sX;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditarChamado);
            this.Controls.Add(this.btnNovoChamado);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmDashboard";
            this.Text = "TelaPrincipal";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNovoChamado;
        private System.Windows.Forms.Button btnEditarChamado;
    }
}