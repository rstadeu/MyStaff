using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControledeEstoque.Classes;
using System.Xml.Linq;

namespace ControledeEstoque.Estoque
{
    public partial class Transferencias : Form
    {
        Classes.Estoque estoque = new Classes.Estoque();
        int quantity;
        Transferencia transferencia = new Transferencia();
        public Transferencias()
        {
            InitializeComponent();

            
            transferencia.createXMLTransferencia(Path.pathXML.XmlPath);
            XElement estoque = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Stock.xml");
            var query = from item in estoque.Descendants("Stocks")
                        select new
                        {
                            EstoqueId = item.Element("StockId").Value,
                            NomeEstoque = item.Element("StockName").Value
                        };
            cmbFromEstoque.DisplayMember = "NomeEstoque";
            cmbFromEstoque.ValueMember = "EstoqueId";
            cmbFromEstoque.DataSource = query.ToArray();

            XElement estoqueTo = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Stock.xml");
            var queryTo = from item in estoque.Descendants("Stocks")
                        select new
                        {
                            EstoqueId = item.Element("StockId").Value,
                            NomeEstoque = item.Element("StockName").Value
                        };
            cmbToEstoque.DisplayMember = "NomeEstoque";
            cmbToEstoque.ValueMember = "EstoqueId";
            cmbToEstoque.DataSource = query.ToArray();


        }

        private void Transferencias_Load(object sender, EventArgs e)
        {

        }

        private void cmbFromEstoque_SelectedIndexChanged(object sender, EventArgs e)
        {
            XElement estoque01 = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Stock.xml");
            XElement alocacao = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Allocation.xml");
            var query01 = (from item in alocacao.Descendants("Allocations")
                           where (int)item.Element("StockId") == Convert.ToInt32(cmbFromEstoque.SelectedValue)
                           select new
                           {
                               EstoqueId = item.Element("AllocationId").Value,
                               NomeEstoque = item.Element("AllocationName").Value
                           });
            cmbFromAlocacao.DisplayMember = "NomeEstoque";
            cmbFromAlocacao.ValueMember = "EstoqueId";
            cmbFromAlocacao.DataSource = query01.ToArray();
        }

        private void cmbFromAlocacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            XElement pedido = XElement.Load(Classes.Path.pathXML.XmlPath + @"\Estoque.xml");
            var queryPedido = from item in pedido.Descendants("Estoques")
                              where (int)item.Element("StockId") == Convert.ToInt32(cmbFromEstoque.SelectedValue)
                              && (int)item.Element("LocationId") == Convert.ToInt32(cmbFromAlocacao.SelectedValue)
                              select new
                              {
                                  productID = Convert.ToInt32(item.Element("ProductId").Value),
                                  ProductName = item.Element("ProductName").Value
                              };

            cmbFromProduto.DisplayMember = "ProductName";
            cmbFromProduto.ValueMember = "productID";
            cmbFromProduto.DataSource = queryPedido.ToArray();

            Transferencia tf = new Transferencia();

            tf.populaGrid(dgvFromEstoque, cmbFromEstoque, cmbFromAlocacao);





        }

        private void cmbFromProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void cmbToEstoque_SelectedIndexChanged(object sender, EventArgs e)
        {
            XElement estoque02 = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Stock.xml");
            XElement alocacao01 = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Allocation.xml");
            var query02 = (from item in alocacao01.Descendants("Allocations")
                           where (int)item.Element("StockId") == Convert.ToInt32(cmbToEstoque.SelectedValue)
                           select new
                           {
                               EstoqueId = item.Element("AllocationId").Value,
                               NomeEstoque = item.Element("AllocationName").Value
                           });
            cmbToAlocacao.DisplayMember = "NomeEstoque";
            cmbToAlocacao.ValueMember = "EstoqueId";
            cmbToAlocacao.DataSource = query02.ToArray();
        }

        private void cmbToAlocacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transferencia t = new Transferencia();
            t.populaGrid(dgvToEstoque, cmbToEstoque, cmbToAlocacao);
           
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && int.TryParse(textBox1.Text, out quantity))
            {
                Material toMaterial;
                XElement pedido = XElement.Load(Classes.Path.pathXML.XmlPath + @"\Estoque.xml");
                var queryFrom = from item in pedido.Descendants("Estoques")
                                where (int)item.Element("StockId") == Convert.ToInt32(cmbFromEstoque.SelectedValue) &&
                                (int)item.Element("LocationId") == Convert.ToInt32(cmbFromAlocacao.SelectedValue) &&
                                (int)item.Element("ProductId") == Convert.ToInt32(cmbFromProduto.SelectedValue)
                                select new Material
                                {
                                    EstoqueID = Convert.ToInt32(item.Element("EstoqueID").Value),
                                    StockID = Convert.ToInt32(item.Element("StockId").Value),
                                    LocationID = Convert.ToInt32(item.Element("LocationId").Value),
                                    ProductID = Convert.ToInt32(item.Element("ProductId").Value),
                                    ProductQtd = Convert.ToInt32(item.Element("ProductQtd").Value),
                                    ProductName = item.Element("ProductName").Value
                                };
                Material fromMaterial = queryFrom.First();

                //XElement pedido = XElement.Load(Classes.Path.pathXML.XmlPath + @"\Estoque.xml");
                try
                {
                    var queryTo = from item in pedido.Descendants("Estoques")
                                  where (int)item.Element("StockId") == Convert.ToInt32(cmbToEstoque.SelectedValue) &&
                                  (int)item.Element("LocationId") == Convert.ToInt32(cmbToAlocacao.SelectedValue) &&
                                  (int)item.Element("ProductId") == Convert.ToInt32(cmbFromProduto.SelectedValue)
                                  select new Material
                                  {
                                      EstoqueID = Convert.ToInt32(item.Element("EstoqueID").Value),
                                      StockID = Convert.ToInt32(item.Element("StockId").Value),
                                      LocationID = Convert.ToInt32(item.Element("LocationId").Value),
                                      ProductID = Convert.ToInt32(item.Element("ProductId").Value),
                                      ProductQtd = Convert.ToInt32(item.Element("ProductQtd").Value),
                                      ProductName = item.Element("ProductName").Value
                                  };

                    toMaterial = queryTo.First();

                    toMaterial.ProductQtd += quantity;

                    XDocument doc1 = XDocument.Load(Path.pathXML.XmlPath + @"\Estoque.xml");

                    var queryTo1 = from item in doc1.Descendants("Estoques")
                                   where (int)item.Element("StockId") == Convert.ToInt32(cmbToEstoque.SelectedValue) &&
                                   (int)item.Element("LocationId") == Convert.ToInt32(cmbToAlocacao.SelectedValue) &&
                                   (int)item.Element("ProductId") == Convert.ToInt32(cmbFromProduto.SelectedValue)
                                   select item;
                    int count = 0;
                    foreach (XElement itemElement in queryTo1)
                    {
                        if (count == 0)
                        {
                            itemElement.SetElementValue("EstoqueID", toMaterial.EstoqueID);
                            itemElement.SetElementValue("StockId", toMaterial.StockID);
                            itemElement.SetElementValue("LocationId", toMaterial.LocationID);
                            itemElement.SetElementValue("ProductId", toMaterial.ProductID);
                            itemElement.SetElementValue("ProductQtd", toMaterial.ProductQtd);
                            itemElement.SetElementValue("ProductName", toMaterial.ProductName);
                            itemElement.SetElementValue("Date", DateTime.Now);
                            count += 1;
                        }
                    }
                    doc1.Save(Path.pathXML.XmlPath + @"\Estoque.xml");


                    fromMaterial.ProductQtd -= quantity;
                    XDocument doc = XDocument.Load(Path.pathXML.XmlPath + @"\Estoque.xml");
                    var queryTo2 = from item in doc.Descendants("Estoques")
                                   where (int)item.Element("StockId") == Convert.ToInt32(cmbFromEstoque.SelectedValue) &&
                                   (int)item.Element("LocationId") == Convert.ToInt32(cmbFromAlocacao.SelectedValue) &&
                                   (int)item.Element("ProductId") == Convert.ToInt32(cmbFromProduto.SelectedValue)
                                   select item;
                    int count1 = 0;
                    foreach (XElement itemElement in queryTo2)
                    {
                        if (count1 == 0)
                        {
                            itemElement.SetElementValue("EstoqueID", fromMaterial.EstoqueID);
                            itemElement.SetElementValue("StockId", fromMaterial.StockID);
                            itemElement.SetElementValue("LocationId", fromMaterial.LocationID);
                            itemElement.SetElementValue("ProductId", fromMaterial.ProductID);
                            itemElement.SetElementValue("ProductQtd", fromMaterial.ProductQtd);
                            itemElement.SetElementValue("ProductName", fromMaterial.ProductName);
                            itemElement.SetElementValue("Date", DateTime.UtcNow);
                            count1 += 1;
                        }
                    }

                    //XDocument doc = XDocument.Load(Path.pathXML.XmlPath + @"\Estoque.xml
                    doc.Save(Path.pathXML.XmlPath + @"\Estoque.xml");

                }
                catch (Exception)
                {
                    /*var queryTo = from item in pedido.Descendants("Estoques")
                                  where (int)item.Element("StockId") == Convert.ToInt32(cmbToEstoque.SelectedValue) &&
                                  (int)item.Element("LocationId") == Convert.ToInt32(cmbToAlocacao.SelectedValue)
                                  select new Material
                                  {
                                      EstoqueID = Convert.ToInt32(item.Element("EstoqueID").Value),
                                      StockID = Convert.ToInt32(item.Element("StockId").Value),
                                      LocationID = Convert.ToInt32(item.Element("LocationId").Value),
                                      ProductID = fromMaterial.ProductID,
                                      ProductQtd = 0,
                                      ProductName = item.Element("ProductName").Value
                                  };

                    toMaterial = queryTo.First();*/

                    List<QuantidadeProduto> produtos = new List<QuantidadeProduto>();
                    /*
                    foreach (DataGridViewRow row in dgvEntradaDados.Rows)
                    {
                        QuantidadeProduto qtdProd = new QuantidadeProduto();
                        qtdProd.Id = Convert.ToInt32(row.Cells[0].Value);
                        qtdProd.Quantidade = Convert.ToInt32(row.Cells[1].Value);
                        qtdProd.Produto = row.Cells[2].Value.ToString();

                        produtos.Add(qtdProd);

                    }*/

                    QuantidadeProduto q = new QuantidadeProduto();

                    q.Id = fromMaterial.ProductID;
                    q.Produto = fromMaterial.ProductName;
                    q.Quantidade = quantity;

                    produtos.Add(q);

                    Classes.Estoque estoque = new Classes.Estoque();
                    estoque.EstoqueID = Convert.ToInt32(cmbToEstoque.SelectedValue);
                    // estoque.ProdutoID = cmbProduto.SelectedIndex;
                    estoque.LocationId = Convert.ToInt32(cmbToAlocacao.SelectedValue);
                    //estoque.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                    estoque.Produto = produtos;
                    estoque.Time = DateTime.UtcNow;
                    estoque.addEstoque(Classes.Path.pathXML.XmlPath, estoque);


                    fromMaterial.ProductQtd -= quantity;
                    XDocument doc = XDocument.Load(Path.pathXML.XmlPath + @"\Estoque.xml");
                    var queryTo1 = from item in doc.Descendants("Estoques")
                                   where (int)item.Element("StockId") == Convert.ToInt32(cmbFromEstoque.SelectedValue) &&
                                   (int)item.Element("LocationId") == Convert.ToInt32(cmbFromAlocacao.SelectedValue) &&
                                   (int)item.Element("ProductId") == Convert.ToInt32(cmbFromProduto.SelectedValue)
                                   select item;
                    int count = 0;
                    foreach (XElement itemElement in queryTo1)
                    {
                        if (count == 0)
                        {
                            itemElement.SetElementValue("EstoqueID", fromMaterial.EstoqueID);
                            itemElement.SetElementValue("StockId", fromMaterial.StockID);
                            itemElement.SetElementValue("LocationId", fromMaterial.LocationID);
                            itemElement.SetElementValue("ProductId", fromMaterial.ProductID);
                            itemElement.SetElementValue("ProductQtd", fromMaterial.ProductQtd);
                            itemElement.SetElementValue("ProductName", fromMaterial.ProductName);
                            itemElement.SetElementValue("Date", DateTime.UtcNow);
                            count += 1;
                        }
                    }

                    //XDocument doc = XDocument.Load(Path.pathXML.XmlPath + @"\Estoque.xml
                    doc.Save(Path.pathXML.XmlPath + @"\Estoque.xml");



                }
                

                
            }
            else
            {
                MessageBox.Show("O valor do campo quantidade tem de ser um numero inteiro");
            }

            Transferencia t = new Transferencia();
            t.populaGrid(dgvToEstoque, cmbToEstoque, cmbToAlocacao);

            Transferencia f = new Transferencia();
            f.populaGrid(dgvFromEstoque, cmbFromEstoque, cmbFromAlocacao);



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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
