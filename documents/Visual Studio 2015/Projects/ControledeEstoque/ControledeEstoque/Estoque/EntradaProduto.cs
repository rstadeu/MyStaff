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
using ControledeEstoque.DataBase;

namespace ControledeEstoque.Estoque
{
    public partial class EntradaProduto : Form
    {
        Classes.Estoque estoque = new Classes.Estoque();
        ControleEstoqueEntities1 generalContext = new ControleEstoqueEntities1();
        BindingSource bs = new BindingSource();
        int rowIndex = 0;
        int counter = 0;
        long key = 0;



        public EntradaProduto()
        {
            InitializeComponent();
            txtProduto.Enabled = false;
            //estoque.populaComboBox(cmbEstoque, Classes.Path.pathXML.XmlPath, "Stock", "Stocks", "StockId", "StockName", "EstoqueID", "EstoqueName");
            using (var element = new ControleEstoqueEntities1())
            {
                var query = from item in element.Stocks
                            select new
                            {
                                EstoqueId = item.StockID,
                                NomeEstoque = item.StockName
                            };
                cmbEstoque.DisplayMember = "NomeEstoque";
                cmbEstoque.ValueMember = "EstoqueId";
                cmbEstoque.DataSource = query.ToArray();
            }

            XElement estoque01 = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Stock.xml");
            XElement alocacao = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Allocation.xml");

            using (var context = new ControleEstoqueEntities1())
            {
                //long converted = Convert.ToInt64(cmbEstoque.SelectedValue);

                var query01 = from item in context.Stocks
                              //where item.StockID == converted
                              select new
                              {
                                  EstoqueId = item.StockID,
                                  NomeEstoque = item.StockName
                              };
                cmbEstoque.DisplayMember = "NomeEstoque";
                cmbEstoque.ValueMember = "EstoqueId";
                cmbEstoque.DataSource = query01.ToArray();
            }

            XElement pedido = XElement.Load(Classes.Path.pathXML.XmlPath + @"\order.xml");
            using (var context = new ControleEstoqueEntities1())
            {
                var queryPedido = from item in context.Orders
                                  select new
                                  {
                                      orderID = item.OrderID
                                  };

                cmbProduto.DisplayMember = "orderID";
                cmbProduto.ValueMember = "orderID";
                cmbProduto.DataSource = queryPedido.ToArray();
            }

            using (var context = new ControleEstoqueEntities1())
            {
                var queryPedido = from item in context.Orders
                                  select new
                                  {
                                      orderID = item.OrderID
                                  };

                cmbStatusPedido.DisplayMember = "orderID";
                cmbStatusPedido.ValueMember = "orderID";
                cmbStatusPedido.DataSource = queryPedido.ToArray();
            }
            // bs.DataSource = 
            populaGridView(dgvPreco);

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.AllowColumnReorder = true;
            listView1.Columns.Add("ID",-2,HorizontalAlignment.Left);
            listView1.Columns.Add("Produto", - 2, HorizontalAlignment.Left);
            listView1.Columns.Add("Quantidade", - 2, HorizontalAlignment.Left);
            listView1.Columns.Add("Preço", -2, HorizontalAlignment.Center);


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

          
        }

        private void EntradaProduto_Load(object sender, EventArgs e)
        {
            try
            {
                XElement pedido = XElement.Load(Classes.Path.pathXML.XmlPath + @"\OrderProducts.xml");
                var queryPedido = (from p in pedido.Descendants("OrderProducts")
                                   where (int)p.Element("OrderId") == Convert.ToInt32(cmbProduto.SelectedValue)
                                   select new
                                   {
                                       ID = p.Element("ProductId").Value,
                                       Quantity = Convert.ToInt32(p.Element("ProductQtd").Value),
                                       ProductName = p.Element("Products").Value

                                   });
                dgvEntradaDados.DataSource = queryPedido.ToArray();
                dgvEntradaDados.AutoSize = true;

                for(int i=0; i < dgvEntradaDados.ColumnCount; i++)
                    dgvEntradaDados.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            }
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void cmbEstoque_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void dgvEntradaDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            /*
          var list = (from row in dgvEntradaDados.Rows.Cast<DataGridViewRow>()
                      select new QuantidadeProduto
                      {
                          Id = Convert.ToInt32(row.Cells[0].ToString()),
                          Quantidade = Convert.ToInt32(row.Cells[1].ToString()),
                          Produto = row.Cells[2].ToString()

                      }).ToList();*/


            List<QuantidadeProduto> produtos = new List<QuantidadeProduto>();
            foreach (DataGridViewRow row in dgvEntradaDados.Rows)
            {
                QuantidadeProduto qtdProd = new QuantidadeProduto();
                using (var contexts = new ControleEstoqueEntities1())
                {
                    
                    qtdProd.Id = Convert.ToInt32(row.Cells[1].Value);
                    long myID = Convert.ToInt64(qtdProd.Id);
                    
                    
                    var estoques = from items in contexts.OrderProductsChecks
                                   join o in contexts.OrderProducts
                                   on
                                   items.OrderProductsID
                                   equals
                                   o.OrderProductsID
                                   join p in contexts.Produtoes
                                   on
                                   o.ProductID
                                   equals
                                   p.ProductID
                                   where o.OrderProductsID == myID
                                   select new QuantidadeProduto
                                   {
                                       
                                       Quantidade = items.Quantity
                                       
                                   };
                    QuantidadeProduto q = estoques.First();

                    qtdProd.Quantidade = Convert.ToInt32(q.Quantidade);
                    qtdProd.Produto = row.Cells[4].Value.ToString();
                    
                }


                produtos.Add(qtdProd);

            }

            foreach(QuantidadeProduto p in produtos)
            {

            }


            Classes.Estoque estoque = new Classes.Estoque();
            estoque.EstoqueID = Convert.ToInt32(cmbEstoque.SelectedValue);
            // estoque.ProdutoID = cmbProduto.SelectedIndex;
            estoque.LocationId = Convert.ToInt32(cmbAlocacao.SelectedValue);
            //estoque.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            estoque.Produto = produtos;
            estoque.Time = DateTime.UtcNow;
            int result = estoque.addEstoque(Classes.Path.pathXML.XmlPath, estoque);

            if (result == 1)
            {
                if (MessageBox.Show("Dados Salvos com sucesso! Gostaria de adicionar\n outro pedido ao estoque?", "Dados Salvos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmbAlocacao.Text = "";
                    cmbEstoque.Text = "";
                    cmbProduto.Text = "";
                    dgvEntradaDados.DataSource = null;

                }
            }
            else
            {

            }





        }

        private void cmbEstoque_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbAlocacao.Text = "";
            XElement estoque01 = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Stock.xml");
            XElement alocacao = XElement.Load(Classes.Path.pathXML.XmlPath + "\\Allocation.xml");

            long cmbEstoqueConverted = Convert.ToInt64(cmbEstoque.SelectedValue);
            using (var context = new ControleEstoqueEntities1())
            {
                var query = from item in context.Allocations
                            where item.StockID == cmbEstoqueConverted
                            select new
                            {
                                EstoqueId = item.ID,
                                NomeEstoque = item.AllocationName
                            };
                cmbAlocacao.DisplayMember = "NomeEstoque";
                cmbAlocacao.ValueMember = "EstoqueId";
                cmbAlocacao.DataSource = query.ToArray();
            };
            /* var query01 = (from item in alocacao.Descendants("Allocations")
                            where (int)item.Element("StockId") == Convert.ToInt32(cmbEstoque.SelectedValue)
                            select new
                            {
                                EstoqueId = item.Element("AllocationId").Value,
                                NomeEstoque = item.Element("AllocationName").Value
                            });
         cmbAlocacao.DisplayMember = "NomeEstoque";
         cmbAlocacao.ValueMember = "EstoqueId";
         cmbAlocacao.DataSource = query01.ToArray();*/
        }

        private void cmbProduto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            populaGridView(dgvPreco);
            try
            {
                long converted = Convert.ToInt64(cmbProduto.SelectedValue);
                using (var context = new ControleEstoqueEntities1())
                {
                    var queryPedido = (from p in context.OrderProducts
                                       join s in context.Produtoes
                                       on
                                       p.ProductID
                                       equals
                                       s.ProductID
                                       where p.OrderID == converted
                                       select new
                                       {

                                           ID_Ordem = p.OrderID,
                                           ID_Ordem_Produto = p.OrderProductsID,
                                           ID_produto = p.ProductID,
                                           Quantidade = p.Quantity,
                                           Nome_Produto = s.Product

                                       });
                    dgvEntradaDados.DataSource = queryPedido.ToArray();
                    dgvEntradaDados.AutoSize = true;
                    for (int i = 0; i < dgvEntradaDados.ColumnCount; i++)
                        dgvEntradaDados.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvEntradaDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvEntradaDados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                tabControl1.SelectTab(1);
            }

            rowIndex = e.RowIndex;

            DataGridViewRow linha = dgvEntradaDados.Rows[rowIndex];
           

                txtProduto.Text = linha.Cells[4].Value.ToString();
                txtQuantidade.Text = linha.Cells[3].Value.ToString();
            key = Convert.ToInt64(linha.Cells[1].Value.ToString());

            using (var context = new ControleEstoqueEntities1())
            {
                var myQuery = context.OrderProductsChecks.SingleOrDefault(b => b.OrderProductsID == key);
                if (myQuery != null)
                {
                    txtPrice.Text = myQuery.Price.ToString();
                }
            }


        }

        private void btnSalvarPreco_Click(object sender, EventArgs e)
        {
            
            long quantity = Convert.ToInt64(txtQuantidade.Text);
            double price = Convert.ToDouble(txtPrice.Text);
            
            using (var context = new ControleEstoqueEntities1())
            {
                try
                {
                    var myQuery = context.OrderProductsChecks.SingleOrDefault(b => b.OrderProductsID == key);
                    if(myQuery != null)
                    {
                        myQuery.Quantity = myQuery.Quantity + quantity;
                        myQuery.Price = price;
                    }
                    else
                    {
                        var query = new DataBase.OrderProductsCheck
                        {
                            OrderProductsID = key,
                            Quantity = quantity,
                            Price = price

                        };

                        
                          context.OrderProductsChecks.Add(query);                     

                        
                    }

                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    
                }


            }

                try
                {
                    rowIndex++;

                    DataGridViewRow linha = dgvEntradaDados.Rows[rowIndex];

                    txtProduto.Text = linha.Cells[4].Value.ToString();
                    txtQuantidade.Text = linha.Cells[3].Value.ToString();
                key = Convert.ToInt64(linha.Cells[1].Value.ToString());
                populaGridView(dgvPreco);
                counter++;
                }
                catch
                {
                    rowIndex -= (counter + 1);
                    counter = 0;
                    DataGridViewRow linha = dgvEntradaDados.Rows[rowIndex];

                    txtProduto.Text = linha.Cells[4].Value.ToString();
                    txtQuantidade.Text = linha.Cells[3].Value.ToString();
                key = Convert.ToInt64(linha.Cells[1].Value.ToString());
                populaGridView(dgvPreco);
            }
            finally
            {
                txtPrice.Text = "";
                txtQuantidade.Focus();
            }

            
        }


        public void populaGridView(DataGridView view)
        {
            long orderID = Convert.ToInt64(cmbProduto.SelectedValue);
            using (var context = new ControleEstoqueEntities1())
            {
                var estoques = from items in context.OrderProductsChecks
                               join o in context.OrderProducts
                               on 
                               items.OrderProductsID
                               equals
                               o.OrderProductsID
                               join p in context.Produtoes
                               on
                               o.ProductID
                               equals
                               p.ProductID
                               where o.OrderID == orderID
                               select new
                               {
                                   //ID = items.ID,
                                   ID_Produto = items.OrderProductsID,
                                   Produto = p.Product,
                                   Quantidade = items.Quantity,
                                   Preco = items.Price
                               };

                view.AutoSize = true;
                view.DataSource = estoques.ToArray();
                for (int i = 0; i < view.ColumnCount; i++)
                    view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void cmbStatusPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
