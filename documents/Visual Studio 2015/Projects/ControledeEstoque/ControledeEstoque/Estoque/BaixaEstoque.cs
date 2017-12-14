using ControledeEstoque.Classes;
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

namespace ControledeEstoque.Estoque
{
    public partial class BaixaEstoque : Form
    {
        int quantity;
        public BaixaEstoque()
        {
            InitializeComponent();

            XElement estoque = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Stock.xml");
            var query = from item in estoque.Descendants("Stocks")
                        select new
                        {
                            EstoqueId = item.Element("StockId").Value,
                            NomeEstoque = item.Element("StockName").Value
                        };
            cmbEstoque.DisplayMember = "NomeEstoque";
            cmbEstoque.ValueMember = "EstoqueId";
            cmbEstoque.DataSource = query.ToArray();
        }

        private void BaixaEstoque_Load(object sender, EventArgs e)
        {

        }

        private void cmbAlocacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            XElement pedido = XElement.Load(Classes.Path.pathXML.XmlPath + @"\Estoque.xml");
            var queryPedido = from item in pedido.Descendants("Estoques")
                              where (int)item.Element("StockId") == Convert.ToInt32(cmbEstoque.SelectedValue)
                              && (int)item.Element("LocationId") == Convert.ToInt32(cmbAlocacao.SelectedValue)
                              select new
                              {
                                  productID = Convert.ToInt32(item.Element("ProductId").Value),
                                  ProductName = item.Element("ProductName").Value
                              };

            cmbProduto.DisplayMember = "ProductName";
            cmbProduto.ValueMember = "productID";
            cmbProduto.DataSource = queryPedido.ToArray();
            Classes.Transferencia tf = new Transferencia();

            tf.populaGrid(dgvEstoque, cmbEstoque, cmbAlocacao);
        }

        private void cmbEstoque_SelectedIndexChanged(object sender, EventArgs e)
        {
            XElement estoque01 = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Stock.xml");
            XElement alocacao = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Allocation.xml");
            var query01 = (from item in alocacao.Descendants("Allocations")
                           where (int)item.Element("StockId") == Convert.ToInt32(cmbEstoque.SelectedValue)
                           select new
                           {
                               EstoqueId = item.Element("AllocationId").Value,
                               NomeEstoque = item.Element("AllocationName").Value
                           });
            cmbAlocacao.DisplayMember = "NomeEstoque";
            cmbAlocacao.ValueMember = "EstoqueId";
            cmbAlocacao.DataSource = query01.ToArray();
        }

        private void btnDarBaixa_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != null && int.TryParse(txtQuantidade.Text, out quantity))
            {
                Material material = new Material();
                XElement pedido = XElement.Load(Classes.Path.pathXML.XmlPath + @"\Estoque.xml");
                var queryFrom = from item in pedido.Descendants("Estoques")
                                where (int)item.Element("StockId") == Convert.ToInt32(cmbEstoque.SelectedValue) &&
                                (int)item.Element("LocationId") == Convert.ToInt32(cmbAlocacao.SelectedValue) &&
                                (int)item.Element("ProductId") == Convert.ToInt32(cmbProduto.SelectedValue)
                                select new Material
                                {
                                    EstoqueID = Convert.ToInt32(item.Element("EstoqueID").Value),
                                    StockID = Convert.ToInt32(item.Element("StockId").Value),
                                    LocationID = Convert.ToInt32(item.Element("LocationId").Value),
                                    ProductID = Convert.ToInt32(item.Element("ProductId").Value),
                                    ProductQtd = Convert.ToInt32(item.Element("ProductQtd").Value),
                                    ProductName = item.Element("ProductName").Value
                                };

                //XElement pedido = XElement.Load(Classes.Path.pathXML.XmlPath + @"\Estoque.xml");

                material = queryFrom.First();



                material.ProductQtd -= quantity;
                XDocument doc = XDocument.Load(Path.pathXML.XmlPath + @"\Estoque.xml");
                var queryTo2 = from item in doc.Descendants("Estoques")
                               where (int)item.Element("StockId") == Convert.ToInt32(cmbEstoque.SelectedValue) &&
                               (int)item.Element("LocationId") == Convert.ToInt32(cmbAlocacao.SelectedValue) &&
                               (int)item.Element("ProductId") == Convert.ToInt32(cmbProduto.SelectedValue)
                               select item;
                int count = 0;
                foreach (XElement itemElement in queryTo2)
                {
                    if (count == 0)
                    {
                        itemElement.SetElementValue("EstoqueID", material.EstoqueID);
                        itemElement.SetElementValue("StockId", material.StockID);
                        itemElement.SetElementValue("LocationId", material.LocationID);
                        itemElement.SetElementValue("ProductId", material.ProductID);
                        itemElement.SetElementValue("ProductQtd", material.ProductQtd);
                        itemElement.SetElementValue("ProductName", material.ProductName);
                        itemElement.SetElementValue("Date", DateTime.UtcNow);
                        count += 1;
                    }
                }

                //XDocument doc = XDocument.Load(Path.pathXML.XmlPath + @"\Estoque.xml
                doc.Save(Path.pathXML.XmlPath + @"\Estoque.xml");

                Classes.Transferencia tf = new Transferencia();

                tf.populaGrid(dgvEstoque, cmbEstoque, cmbAlocacao);

            }
            else
            {
                MessageBox.Show("O valor do campo quantidade tem de ser um numero inteiro");
            }
        }
        

             private class Material
        {

            private int _estoqueID;
            private int _stockID;
            private int _locationID;
            private int _productID;
            private int _productQtd;
            private string _productName;

            public int EstoqueID
            {
                get
                {
                    return _estoqueID;
                }

                set
                {
                    _estoqueID = value;
                }
            }

            public int StockID
            {
                get
                {
                    return _stockID;
                }

                set
                {
                    _stockID = value;
                }
            }

            public int LocationID
            {
                get
                {
                    return _locationID;
                }

                set
                {
                    _locationID = value;
                }
            }

            public int ProductID
            {
                get
                {
                    return _productID;
                }

                set
                {
                    _productID = value;
                }
            }

            public int ProductQtd
            {
                get
                {
                    return _productQtd;
                }

                set
                {
                    _productQtd = value;
                }
            }

            public string ProductName
            {
                get
                {
                    return _productName;
                }

                set
                {
                    _productName = value;
                }
            }
        }

    }

 }