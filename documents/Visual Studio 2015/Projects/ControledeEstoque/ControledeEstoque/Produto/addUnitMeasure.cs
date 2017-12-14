using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControledeEstoque.Produto
{
    public partial class addUnitMeasure : Form
    {
        Classes.MeasureUnit mu = new Classes.MeasureUnit();
        public addUnitMeasure()
        {
            InitializeComponent();

            mu.createXMLFile();

            mu.populaGridView(dgvMeasureUnit);
        }

        private void btnAdcionar_Click(object sender, EventArgs e)
        {
            if(txtMeasureUnit.Text != "")
            {
                mu.UnitName = txtMeasureUnit.Text.ToUpper();
                mu.addItem(mu);

                try
                {
                    mu.populaGridView(dgvMeasureUnit);
                    txtMeasureUnit.Text = "";
                    txtMeasureUnit.Focus();

                }
                catch(Exception)
                {
                    MessageBox.Show("Alguma coisa deu errado!:( Contate o desenvolvedor para solucionar o problema");
                }
            }
        }



    }
}
