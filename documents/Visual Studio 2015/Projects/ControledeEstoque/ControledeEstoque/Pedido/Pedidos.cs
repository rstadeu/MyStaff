using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControledeEstoque.Classes;
using ControledeEstoque.Pedido;
using System.Windows.Forms;
using System.Xml.Linq;
using ControledeEstoque.DataBase;

namespace ControledeEstoque.Pedido
{
    public partial class FrmPedidos : Form
    {
        Classes.Pedidos order = new Classes.Pedidos();
        BindingSource bs = new BindingSource();

        
        Classes.subType subType = new Classes.subType();
        
        public FrmPedidos()
        {
            InitializeComponent();
            Classes.addType addType = new addType();
            order.createXMLOrderFile(Path.pathXML.XmlPath);

            order.Codigo = order.getID(Path.pathXML.XmlPath);
            lblOrderNumber.Text = Convert.ToString(order.Codigo);
             populaComboBox();
            //populaCmbMaterial();

        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            btnLoadExcel.Enabled = false;
            


        }

        public void populaComboBox()
        {
            using (var context = new ControleEstoqueEntities1())
            { 
                var query = from item in context.Produtoes
                            select new
                            {
                                fornecedor01Id = item.ProductID,
                                nomeFornecedor01 = item.Product
                            };

                cmbProduct.DisplayMember = "NomeFornecedor01";
                cmbProduct.ValueMember = "Fornecedor01Id";
                cmbProduct.DataSource = query.ToArray();
            }
        }
        public void populaCmbMaterial()
        {
            using (var context = new ControleEstoqueEntities1())
            {
                var query = from item in context.MaterialTypes
                            select new
                            {
                                ID = item.TypeID,
                                NomeTipo = item.TypeName
                            };

                cmbTipoMaterial.ValueMember = "ID";
                cmbTipoMaterial.DisplayMember = "NomeTipo";                
                cmbTipoMaterial.DataSource = query.ToArray();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            int parsedValue;
            orderProduct info = new orderProduct();
            Classes.Produto produto = new Classes.Produto();
            if (txtQuantity.Text != "" && int.TryParse(txtQuantity.Text, out parsedValue))
            {

                using (var context = new ControleEstoqueEntities1())
                {
                    long control = Convert.ToInt64(cmbProduct.SelectedValue);

                    var query = from prod in context.Produtoes
                                where prod.ProductID == control
                                select new Classes.Produto
                                {
                                    Key = prod.ProductID,
                                    CodNokia = prod.CustomerCod,
                                    CodPanalpina = prod.PanalpinaCod,
                                    Product = prod.Product,
                                    Descricao = prod.Comments,
                                    PathImagem = prod.ImagePath

                                };
                    produto = query.First();
                    info.Produto = produto;
                    info.Quantity = parsedValue;
                    order.Codigo = Convert.ToInt32(lblOrderNumber.Text);

                    order.Produtos.Add(info);
                    toBeBind bind = new toBeBind(info);
                    bs.DataSource = typeof(toBeBind);
                    bs.Add(bind);
                    dgvOrder.DataSource = bs;
                    dgvOrder.AutoGenerateColumns = true;
                    for (int i = 0; i < dgvOrder.ColumnCount; i++)
                        dgvOrder.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    txtQuantity.Text = "";
                    cmbProduct.Focus();

                }
                /*
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
                                    PathImagem = prod.Element("CaminhoImagem").Value

                                };
                produto = query.First();
                info.Produto = produto;
                info.Quantity = parsedValue;
                order.Description = txtDescription.Text;
                order.Invoice = txtInvoice.Text;
                order.Codigo = Convert.ToInt32(lblOrderNumber.Text);

                order.Produtos.Add(info);
                toBeBind bind = new toBeBind(info);
                bs.DataSource = typeof(toBeBind);
                bs.Add(bind);
                dgvOrder.DataSource = bs;
                dgvOrder.AutoGenerateColumns = true;
                for (int i = 0; i < dgvOrder.ColumnCount; i++)
                    dgvOrder.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                txtQuantity.Text = "";
                cmbProduct.Focus();*/

            }
            else
            {
                if (MessageBox.Show("Este campo nao pode estar vazio nem conter valores diferentes de numeros inteiros!","ERRO DE ENTRADA",MessageBoxButtons.OK,MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    txtQuantity.Text = "";
                    txtQuantity.Focus();
                }
            }


        }

        private void populaGridView()
        {
            using (var context = new ControleEstoqueEntities1())
            {
                var estoque = from items in context.Allocations
                              join s in context.Stocks
                              on
                              items.StockID
                              equals
                              s.StockID
                              select new
                              {
                                  ID_Alocacao = items.ID,
                                  Estoque = s.StockName,
                                  Alocacao = items.AllocationName
                              };

                dgvOrder.AutoSize = true;
                dgvOrder.DataSource = estoque.ToArray();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dgvOrder.Rows.Count == 0)
                btnSalvar.Enabled = false;
            else
                btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int itsSaved = order.addOrder(Path.pathXML.XmlPath, order);
            if(itsSaved == 1)
            {
                if (MessageBox.Show("Dados Salvos com Sucesso no Banco de Dados.\nDeseja adicionar outro pedido?", "Dados do pedido " + lblOrderNumber.Text + " salvos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvOrder.Rows.Clear();
                    dgvOrder.Refresh();
                    txtQuantity.Text = "";
                    cmbProduct.SelectedItem = null;
                    cmbProduct.Focus();
                    order.Codigo = order.getID(Path.pathXML.XmlPath);
                    lblOrderNumber.Text = Convert.ToString(order.Codigo);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            subType.populaComboBox(cmbSubType, (int)cmbTipoMaterial.SelectedValue);

        }

        private void cmbSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
