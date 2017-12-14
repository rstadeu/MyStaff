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
    public partial class AddSubType : Form
    {
        Classes.subType s = new Classes.subType();
       
        public AddSubType()
        {
            InitializeComponent();
            s.createXMLFile();

            Classes.addType t = new Classes.addType();
            t.populaComboBox(cmbMaterialType);

            try
            {
                s.populaGridView(dgvSubMaterial);
            }
            catch(Exception)
            {

            }
        }

        private void AddSubType_Load(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if(txtSubMaterialType.Text != "")
            {
                s.SubTypeName= txtSubMaterialType.Text.ToUpper();
                s.MaterialTypeID = Convert.ToInt32(cmbMaterialType.SelectedValue);
                s.addItem(s);

                try
                {
                    s.populaGridView(dgvSubMaterial);
                    txtSubMaterialType.Text = "";
                    cmbMaterialType.Focus();


                }
                catch(Exception)
                {
                    MessageBox.Show("Alguma coisa deu errado! Entre em contato com o desenvolvedor :(");
                }
            }
        }






    }
}
