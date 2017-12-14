namespace ControledeEstoque.Produto
{
    partial class addUnitMeasure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addUnitMeasure));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeasureUnit = new System.Windows.Forms.TextBox();
            this.dgvMeasureUnit = new System.Windows.Forms.DataGridView();
            this.btnAdcionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unidade de Medida:";
            // 
            // txtMeasureUnit
            // 
            this.txtMeasureUnit.Location = new System.Drawing.Point(113, 12);
            this.txtMeasureUnit.Name = "txtMeasureUnit";
            this.txtMeasureUnit.Size = new System.Drawing.Size(233, 20);
            this.txtMeasureUnit.TabIndex = 1;
            // 
            // dgvMeasureUnit
            // 
            this.dgvMeasureUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasureUnit.Location = new System.Drawing.Point(7, 38);
            this.dgvMeasureUnit.Name = "dgvMeasureUnit";
            this.dgvMeasureUnit.Size = new System.Drawing.Size(420, 309);
            this.dgvMeasureUnit.TabIndex = 2;
            // 
            // btnAdcionar
            // 
            this.btnAdcionar.Location = new System.Drawing.Point(352, 10);
            this.btnAdcionar.Name = "btnAdcionar";
            this.btnAdcionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdcionar.TabIndex = 3;
            this.btnAdcionar.Text = "Adicionar";
            this.btnAdcionar.UseVisualStyleBackColor = true;
            this.btnAdcionar.Click += new System.EventHandler(this.btnAdcionar_Click);
            // 
            // addUnitMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 356);
            this.Controls.Add(this.btnAdcionar);
            this.Controls.Add(this.dgvMeasureUnit);
            this.Controls.Add(this.txtMeasureUnit);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "addUnitMeasure";
            this.Text = "Unidade de Medida";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeasureUnit;
        private System.Windows.Forms.DataGridView dgvMeasureUnit;
        private System.Windows.Forms.Button btnAdcionar;
    }
}