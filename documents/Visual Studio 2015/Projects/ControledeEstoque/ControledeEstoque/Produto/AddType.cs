using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ControledeEstoque.Produto
{
    public partial class AddType : Form
    {
        BindingSource bs = new BindingSource();
        Classes.addType t = new Classes.addType();
        public AddType()
        {
            InitializeComponent();

            
            t.createXMLFile();

            try
            {
                t.populaGridView(dgvMaterialType);
            }
            catch(Exception)
            {

            }
        }

        private void AddType_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Classes.addType addType = new Classes.addType();
            string text = txtMaterialType.Text.ToUpper();

            if (txtMaterialType.Text != "")
            {

                addType.Type = txtMaterialType.Text.ToUpper();
                addType.addItem(addType);
            }
            /*
            XElement t = XElement.Load(Classes.Path.pathXML.XmlPath + @"\MaterialType.xml");

            var queryMaterial = from m in t.Descendants("MaterialTypes")
                                //where Convert.ToString(m.Descendants("TypeName")) == txtMaterialType.Text
                                select new Classes.addType
                                {
                                    ID = Convert.ToInt32(m.Element("TypeID").Value),
                                    Type = m.Element("TypeName").Value
                                };

            addType = queryMaterial.Last();
            bs.DataSource = typeof(Classes.addType);
            bs.Add(addType);
            dgvMaterialType.DataSource = bs;

            for (int i = 0; i < dgvMaterialType.ColumnCount; i++)
                dgvMaterialType.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                */

            try
            {
                t.populaGridView(dgvMaterialType);
                txtMaterialType.Text = "";
                txtMaterialType.Focus();
            }
            catch (Exception)
            {

            }

        }




    }
}
