using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControledeEstoque.Classes;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ControledeEstoque.Kits
{
    public partial class AddKits : Form
    {
        Classes.kits order = new Classes.kits();
        BindingSource bs = new BindingSource();
        public AddKits()
        {
            InitializeComponent();
            order.createXMLOrderFile(Path.pathXML.XmlPath);
            order.Codigo = order.getID(Path.pathXML.XmlPath);
            lblKitId.Text = Convert.ToString(order.Codigo);
            populaComboBox();
        }
        public void populaComboBox()
        {
            XElement fornecedor01 = XElement.Load(Path.pathXML.XmlPath + "\\Produto.xml");
            var query = from item in fornecedor01.Descendants("Products")
                        select new
                        {
                            fornecedor01Id = item.Element("ProductId").Value,
                            nomeFornecedor01 = item.Element("Produto").Value
                        };

            cmbProduct.DisplayMember = "NomeFornecedor01";
            cmbProduct.ValueMember = "Fornecedor01Id";
            cmbProduct.DataSource = query.ToArray();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dgvKits.Rows.Count == 0)
                btnSalvar.Enabled = false;
            else
                btnSalvar.Enabled = true;
        }

        private void AddKits_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (textBox1.Text != "" && int.TryParse(textBox1.Text, out parsedValue))
            {
                orderProduct info = new orderProduct();
                Classes.Produto produto = new Classes.Produto();
                XElement product = XElement.Load(Path.pathXML.XmlPath + @"\Produto.xml");

                var query = from prod in product.Descendants("Products")
                            where (int)(prod.Element("ProductId")) == Convert.ToInt32(cmbProduct.SelectedValue)
                            select new Classes.Produto
                            {
                                Key = Convert.ToInt32(prod.Element("ProductId").Value),
                                CodNokia = (prod.Element("CodigoCliente").Value),
                                CodPanalpina = (prod.Element("CodigoPanalpina").Value),
                                Product = Convert.ToString(prod.Element("Produto").Value),
                                Descricao = prod.Element("Descricao").Value,
                                PathImagem = prod.Element("CaminhoImagem").Value,
                                

                            };
                produto = query.First();
                info.Produto = produto;
                info.Quantity = parsedValue;
                order.Codigo = Convert.ToInt32(lblKitId.Text);

                order.Produtos.Add(info);
                toBeBind bind = new toBeBind(info);
                bs.DataSource = typeof(toBeBind);
                bs.Add(bind);
                dgvKits.DataSource = bs;
                dgvKits.AutoGenerateColumns = true;

                for (int i = 0; i < dgvKits.ColumnCount; i++)
                dgvKits.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                

                textBox1.Text = "";
                cmbProduct.Focus();



            }
            else
            {
                if (MessageBox.Show("Este campo nao pode estar vazio nem conter valores diferentes de numeros inteiros!", "ERRO DE ENTRADA", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
        }


        class toBeBind
        {
            private int _qtd;
            private string _ProductName;

            public int Qtd
            {
                get
                {
                    return _qtd;
                }

                set
                {
                    _qtd = value;
                }
            }

            public string ProductName
            {
                get
                {
                    return _ProductName;
                }

                set
                {
                    _ProductName = value;
                }
            }

            public toBeBind(orderProduct o)
            {
                Qtd = o.Quantity;
                ProductName = o.Produto.Product;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            int itsSaved = order.addOrder(Path.pathXML.XmlPath, order);
            if (itsSaved == 1)
            {
                if (MessageBox.Show("Dados Salvos com Sucesso no Banco de Dados.\nDeseja adicionar outro pedido?", "Dados do pedido " + lblKitId.Text + " salvos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvKits.Rows.Clear();
                    dgvKits.Refresh();
                    textBox1.Text = "";
                    cmbProduct.SelectedItem = null;
                    cmbProduct.Focus();
                    order.Codigo = order.getID(Path.pathXML.XmlPath);
                    lblKitId.Text = Convert.ToString(order.Codigo);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
