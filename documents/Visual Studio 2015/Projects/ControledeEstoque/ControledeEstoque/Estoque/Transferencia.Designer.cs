namespace ControledeEstoque.Estoque
{
    partial class Transferencias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transferencias));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFromEstoque = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFromAlocacao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFromProduto = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbToAlocacao = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbToEstoque = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvFromEstoque = new System.Windows.Forms.DataGridView();
            this.dgvToEstoque = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFromEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estoque:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbFromEstoque
            // 
            this.cmbFromEstoque.FormattingEnabled = true;
            this.cmbFromEstoque.Location = new System.Drawing.Point(89, 16);
            this.cmbFromEstoque.Name = "cmbFromEstoque";
            this.cmbFromEstoque.Size = new System.Drawing.Size(480, 21);
            this.cmbFromEstoque.TabIndex = 1;
            this.cmbFromEstoque.SelectedIndexChanged += new System.EventHandler(this.cmbFromEstoque_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alocação:";
            // 
            // cmbFromAlocacao
            // 
            this.cmbFromAlocacao.FormattingEnabled = true;
            this.cmbFromAlocacao.Location = new System.Drawing.Point(89, 44);
            this.cmbFromAlocacao.Name = "cmbFromAlocacao";
            this.cmbFromAlocacao.Size = new System.Drawing.Size(480, 21);
            this.cmbFromAlocacao.TabIndex = 3;
            this.cmbFromAlocacao.SelectedIndexChanged += new System.EventHandler(this.cmbFromAlocacao_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Produto:";
            // 
            // cmbFromProduto
            // 
            this.cmbFromProduto.FormattingEnabled = true;
            this.cmbFromProduto.Location = new System.Drawing.Point(89, 72);
            this.cmbFromProduto.Name = "cmbFromProduto";
            this.cmbFromProduto.Size = new System.Drawing.Size(480, 21);
            this.cmbFromProduto.TabIndex = 5;
            this.cmbFromProduto.SelectedIndexChanged += new System.EventHandler(this.cmbFromProduto_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbFromAlocacao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbFromEstoque);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbFromProduto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 137);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "De";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbToAlocacao);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbToEstoque);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(604, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 93);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Para";
            // 
            // cmbToAlocacao
            // 
            this.cmbToAlocacao.FormattingEnabled = true;
            this.cmbToAlocacao.Location = new System.Drawing.Point(89, 44);
            this.cmbToAlocacao.Name = "cmbToAlocacao";
            this.cmbToAlocacao.Size = new System.Drawing.Size(439, 21);
            this.cmbToAlocacao.TabIndex = 3;
            this.cmbToAlocacao.SelectedIndexChanged += new System.EventHandler(this.cmbToAlocacao_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Estoque:";
            // 
            // cmbToEstoque
            // 
            this.cmbToEstoque.FormattingEnabled = true;
            this.cmbToEstoque.Location = new System.Drawing.Point(89, 16);
            this.cmbToEstoque.Name = "cmbToEstoque";
            this.cmbToEstoque.Size = new System.Drawing.Size(439, 21);
            this.cmbToEstoque.TabIndex = 1;
            this.cmbToEstoque.SelectedIndexChanged += new System.EventHandler(this.cmbToEstoque_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Alocação:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quantidade:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(480, 20);
            this.textBox1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvFromEstoque);
            this.panel1.Location = new System.Drawing.Point(12, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 256);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvToEstoque);
            this.panel2.Location = new System.Drawing.Point(620, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 256);
            this.panel2.TabIndex = 15;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(1069, 122);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 27);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Transferir";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvFromEstoque
            // 
            this.dgvFromEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFromEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFromEstoque.Location = new System.Drawing.Point(3, 3);
            this.dgvFromEstoque.Name = "dgvFromEstoque";
            this.dgvFromEstoque.Size = new System.Drawing.Size(599, 250);
            this.dgvFromEstoque.TabIndex = 0;
            // 
            // dgvToEstoque
            // 
            this.dgvToEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvToEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToEstoque.Location = new System.Drawing.Point(3, 3);
            this.dgvToEstoque.Name = "dgvToEstoque";
            this.dgvToEstoque.Size = new System.Drawing.Size(529, 250);
            this.dgvToEstoque.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Transferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 424);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transferencias";
            this.Text = "Tranferencia de Material";
            this.Load += new System.EventHandler(this.Transferencias_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFromEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToEstoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFromEstoque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFromAlocacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFromProduto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbToAlocacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbToEstoque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFromEstoque;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvToEstoque;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Timer timer1;
    }
}