namespace ControledeEstoque
{
    partial class BancoDeDados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoDeDados));
            this.fbdDataBase = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBancoDeDados = new System.Windows.Forms.TextBox();
            this.btnMudarBanco = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta banco de dados:";
            // 
            // txtBancoDeDados
            // 
            this.txtBancoDeDados.Location = new System.Drawing.Point(127, 5);
            this.txtBancoDeDados.Name = "txtBancoDeDados";
            this.txtBancoDeDados.Size = new System.Drawing.Size(381, 20);
            this.txtBancoDeDados.TabIndex = 1;
            // 
            // btnMudarBanco
            // 
            this.btnMudarBanco.Location = new System.Drawing.Point(514, 5);
            this.btnMudarBanco.Name = "btnMudarBanco";
            this.btnMudarBanco.Size = new System.Drawing.Size(84, 23);
            this.btnMudarBanco.TabIndex = 2;
            this.btnMudarBanco.Text = "Mudar";
            this.btnMudarBanco.UseVisualStyleBackColor = true;
            this.btnMudarBanco.Click += new System.EventHandler(this.btnMudarBanco_Click);
            // 
            // BancoDeDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 37);
            this.Controls.Add(this.btnMudarBanco);
            this.Controls.Add(this.txtBancoDeDados);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BancoDeDados";
            this.Text = "BancoDeDados";
            this.Load += new System.EventHandler(this.BancoDeDados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBancoDeDados;
        private System.Windows.Forms.Button btnMudarBanco;
    }
}