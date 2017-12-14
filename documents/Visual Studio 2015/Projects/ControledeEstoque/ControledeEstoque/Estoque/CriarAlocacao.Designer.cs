namespace ControledeEstoque.Estoque
{
    partial class CriarAlocacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CriarAlocacao));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStock = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlocacao = new System.Windows.Forms.TextBox();
            this.grvStock = new System.Windows.Forms.DataGridView();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estoque:";
            // 
            // cmbStock
            // 
            this.cmbStock.FormattingEnabled = true;
            this.cmbStock.Location = new System.Drawing.Point(75, 13);
            this.cmbStock.Name = "cmbStock";
            this.cmbStock.Size = new System.Drawing.Size(522, 21);
            this.cmbStock.TabIndex = 1;
            this.cmbStock.SelectedIndexChanged += new System.EventHandler(this.cmbStock_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alocação:";
            // 
            // txtAlocacao
            // 
            this.txtAlocacao.Location = new System.Drawing.Point(75, 53);
            this.txtAlocacao.Name = "txtAlocacao";
            this.txtAlocacao.Size = new System.Drawing.Size(522, 20);
            this.txtAlocacao.TabIndex = 3;
            // 
            // grvStock
            // 
            this.grvStock.AllowUserToAddRows = false;
            this.grvStock.AllowUserToDeleteRows = false;
            this.grvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvStock.Location = new System.Drawing.Point(12, 79);
            this.grvStock.Name = "grvStock";
            this.grvStock.ReadOnly = true;
            this.grvStock.Size = new System.Drawing.Size(666, 193);
            this.grvStock.TabIndex = 4;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(603, 50);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // CriarAlocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 284);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.grvStock);
            this.Controls.Add(this.txtAlocacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStock);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CriarAlocacao";
            this.Text = "Criar Alocacao";
            this.Load += new System.EventHandler(this.CriarAlocacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlocacao;
        private System.Windows.Forms.DataGridView grvStock;
        private System.Windows.Forms.Button btnSalvar;
    }
}