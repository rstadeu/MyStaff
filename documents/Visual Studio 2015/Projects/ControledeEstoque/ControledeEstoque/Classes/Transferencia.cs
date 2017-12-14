using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControledeEstoque.DataBase;
using System.Xml.Linq;

namespace ControledeEstoque.Classes
{
    class Transferencia
    {


        private int _iD;
        private int _fromEstoqueID;
        private int _toEstoqueID;
        private DateTime _timeToTransfer;

        #region Encapsulated data
        public int ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public int FromEstoqueID
        {
            get
            {
                return _fromEstoqueID;
            }

            set
            {
                _fromEstoqueID = value;
            }
        }

        public int ToEstoqueID
        {
            get
            {
                return _toEstoqueID;
            }

            set
            {
                _toEstoqueID = value;
            }
        }

        public DateTime TimeToTransfer
        {
            get
            {
                return _timeToTransfer;
            }

            set
            {
                _timeToTransfer = value;
            }
        }

        #endregion


        public XDocument createTransferencia(string name)
        {
            XDocument productData = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
             new XElement(name));
            productData.Save(name + ".xml");
            return productData;

        }

        public void createXMLTransferencia(string path)
        {
            string name = "Transferencia";
            XDocument doc = createTransferencia(name);

            string fileNameFinal = path + "\\" + name + ".xml";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                if (!File.Exists(fileNameFinal))
                {
                    doc.Save(fileNameFinal);
                }
            }
            catch
            {
                Directory.CreateDirectory(path);

            }

        }

        public int addTransferencia(string path, Transferencia estoque)
        {
            string name = "\\Transferencia";
            string fileNameFinal = path + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("Transfer") != null ? Product.Element("Transfer").Value : "0");

            id += 1;
            estoque.ID = id;
            var doc = XDocument.Load(fileNameFinal);


            var newElement = new XElement("Transfer",
                new XElement("TransferID", estoque.ID),
                new XElement("FromEstoqueID", estoque.FromEstoqueID),
                new XElement("ToEstoqueID", estoque.ToEstoqueID),
                new XElement("TimeTotransfer", estoque.TimeToTransfer)
                );



            doc.Element("Transferencia").Add(newElement);
            try
            {
                doc.Save(fileNameFinal);
                return 1;
            }
            catch
            {
                return 0;

            }

        }


        public void populaGrid(DataGridView v, ComboBox cb1, ComboBox cb2)
        {
            long cb1Converted = Convert.ToInt64(cb1.SelectedValue);
            long cb2Converted = Convert.ToInt64(cb2.SelectedValue);
            using (var context = new ControledeEstoque.DataBase.ControleEstoqueEntities1())
            {
                var estoques = from items in context.Estoques
                               join s in context.Stocks
                               on
                               items.StockID
                               equals
                               s.StockID
                               join a in context.Allocations
                               on items.LocationID
                               equals
                               a.ID
                               join p in context.Produtoes
                               on items.ProductID
                               equals
                               p.ProductID
                               where items.StockID == cb1Converted
                               &&
                               items.LocationID == cb2Converted
                               select new
                               {
                                   ID_Estoque = items.EstoqueID,
                                   Estoque = s.StockName,
                                   Alocacao = a.AllocationName,
                                   Produto = p.Product,
                                   Quantidade = items.ProductQtd
                               };
                v.DataSource = estoques.ToArray();
                for (int i = 0; i < v.ColumnCount; i++)
                    v.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
            /*
                XElement allocation = XElement.Load(Path.pathXML.XmlPath + "\\Allocation.xml");
            XElement stock = XElement.Load(Path.pathXML.XmlPath + "\\Stock.xml");
            XElement estoqueXml = XElement.Load(Path.pathXML.XmlPath + @"\Estoque.xml");
            var estoque = from items in estoqueXml.Descendants("Estoques")
                          join s in stock.Descendants("Stocks")
                          on
                          (string)items.Element("StockId")
                          equals
                          (string)s.Element("StockId")
                          join a in allocation.Descendants("Allocations")
                          on
                          (string)items.Element("LocationId")
                          equals
                          (string)a.Element("AllocationId")
                          where (int)items.Element("StockId") == Convert.ToInt32(cb1.SelectedValue)
                          &&
                          (int)items.Element("LocationId") == Convert.ToInt32(cb2.SelectedValue)
                          select new
                          {
                              ID_Estoque = items.Element("EstoqueID").Value,
                              Estoque = s.Element("StockName").Value,
                              Alocacao = a.Element("AllocationName").Value,
                              Produto = items.Element("ProductName").Value,
                              Quantidade = items.Element("ProductQtd").Value
                          };
            //dgvToEstoque.Rows.Clear();
            
            v.DataSource = estoque.ToArray();
            for (int i = 0; i < v.ColumnCount; i++)
                v.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;*/
        }

        /// <summary>
        /// Populate the dataGridView with information from the database
        /// </summary>
        /// <param name="v">The dataGridView</param>
        public void populaGrid(DataGridView v)
        {
            using (var context = new ControledeEstoque.DataBase.ControleEstoqueEntities1())
            {
                var estoques = from items in context.Estoques
                               join s in context.Stocks
                               on
                               items.StockID
                               equals
                               s.StockID
                               join a in context.Allocations
                               on items.LocationID
                               equals
                               a.ID
                               join p in context.Produtoes
                               on items.ProductID
                               equals
                               p.ProductID
                               select new
                               {
                                   ID_Estoque = items.EstoqueID,
                                   Estoque = s.StockName,
                                   Alocacao = a.AllocationName,
                                   Produto = p.Product,
                                   Quantidade = items.ProductQtd
                               };
                v.DataSource = estoques.ToArray();
                for (int i = 0; i < v.ColumnCount; i++)
                    v.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
          /*  XElement allocation = XElement.Load(Path.pathXML.XmlPath + "\\Allocation.xml");
            XElement stock = XElement.Load(Path.pathXML.XmlPath + "\\Stock.xml");
            XElement estoqueXml = XElement.Load(Path.pathXML.XmlPath + @"\Estoque.xml");
            var estoque = from items in estoqueXml.Descendants("Estoques")
                          join s in stock.Descendants("Stocks")
                          on
                          (string)items.Element("StockId")
                          equals
                          (string)s.Element("StockId")
                          join a in allocation.Descendants("Allocations")
                          on
                          (string)items.Element("LocationId")
                          equals
                          (string)a.Element("AllocationId")
                          select new
                          {
                              ID_Estoque = items.Element("EstoqueID").Value,
                              Estoque = s.Element("StockName").Value,
                              Alocacao = a.Element("AllocationName").Value,
                              Produto = items.Element("ProductName").Value,
                              Quantidade = items.Element("ProductQtd").Value
                          };
            //dgvToEstoque.Rows.Clear();

            v.DataSource = estoque.ToArray();
            for (int i = 0; i < v.ColumnCount; i++)
                v.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;*/
        }

        /// <summary>
        /// Populate the dataGridView with information from the database
        /// </summary>
        /// <param name="v">The DataGridView</param>
        /// <param name="st">The Stock Parameter</param>
        public void populaGrid(DataGridView v, string st)
        {
            using (var context = new ControledeEstoque.DataBase.ControleEstoqueEntities1())
            {
                var estoques = from items in context.Estoques
                               join s in context.Stocks
                               on
                               items.StockID
                               equals
                               s.StockID
                               join a in context.Allocations
                               on items.LocationID
                               equals
                               a.ID
                               join p in context.Produtoes
                               on items.ProductID
                               equals
                               p.ProductID
                               where s.StockName == st
                               select new
                               {
                                   ID_Estoque = items.EstoqueID,
                                   Estoque = s.StockName,
                                   Alocacao = a.AllocationName,
                                   Produto = p.Product,
                                   Quantidade = items.ProductQtd
                               };
                v.DataSource = estoques.ToArray();
                for (int i = 0; i < v.ColumnCount; i++)
                    v.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
            /*XElement allocation = XElement.Load(Path.pathXML.XmlPath + "\\Allocation.xml");
            XElement stock = XElement.Load(Path.pathXML.XmlPath + "\\Stock.xml");
            XElement estoqueXml = XElement.Load(Path.pathXML.XmlPath + @"\Estoque.xml");
            var estoque = from items in estoqueXml.Descendants("Estoques")
                          join s in stock.Descendants("Stocks")
                          on
                          (string)items.Element("StockId")
                          equals
                          (string)s.Element("StockId")
                          join a in allocation.Descendants("Allocations")
                          on
                          (string)items.Element("LocationId")
                          equals
                          (string)a.Element("AllocationId")
                          where (string)s.Element("StockName") == st
                          select new 
                          {
                              ID_Estoque = items.Element("EstoqueID").Value,
                              Estoque = s.Element("StockName").Value,
                              Alocacao = a.Element("AllocationName").Value,
                              Produto = items.Element("ProductName").Value,
                              Quantidade = items.Element("ProductQtd").Value
                          };
            //dgvToEstoque.Rows.Clear();

            v.DataSource = estoque.ToArray();
            for (int i = 0; i < v.ColumnCount; i++)
                v.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;*/
        }

        /// <summary>
        /// Populate the dataGridView with information from the database
        /// </summary>
        /// <param name="v">The DataGridView</param>
        /// <param name="st">The Stock Parameter</param>
        /// <param name="all">The Location parameter</param>
        public void populaGrid(DataGridView v, string st, string all)
        {
            using (var context = new ControledeEstoque.DataBase.ControleEstoqueEntities1())
            {
                var estoques = from items in context.Estoques
                               join s in context.Stocks
                               on
                               items.StockID
                               equals
                               s.StockID
                               join a in context.Allocations
                               on items.LocationID
                               equals
                               a.ID
                               join p in context.Produtoes
                               on items.ProductID
                               equals
                               p.ProductID
                               where s.StockName == st
                               && a.AllocationName == all
                               select new
                               {
                                   ID_Estoque = items.EstoqueID,
                                   Estoque = s.StockName,
                                   Alocacao = a.AllocationName,
                                   Produto = p.Product,
                                   Quantidade = items.ProductQtd
                               };
                v.DataSource = estoques.ToArray();
                for (int i = 0; i < v.ColumnCount; i++)
                    v.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
            /*XElement allocation = XElement.Load(Path.pathXML.XmlPath + "\\Allocation.xml");
            XElement stock = XElement.Load(Path.pathXML.XmlPath + "\\Stock.xml");
            XElement estoqueXml = XElement.Load(Path.pathXML.XmlPath + @"\Estoque.xml");
            var estoque = from items in estoqueXml.Descendants("Estoques")
                          join s in stock.Descendants("Stocks")
                          on
                          (string)items.Element("StockId")
                          equals
                          (string)s.Element("StockId")
                          join a in allocation.Descendants("Allocations")
                          on
                          (string)items.Element("LocationId")
                          equals
                          (string)a.Element("AllocationId")
                          where (string)s.Element("StockName") == st &&
                          (string)a.Element("AllocationName") == all
                          select new
                          {
                              ID_Estoque = items.Element("EstoqueID").Value,
                              Estoque = s.Element("StockName").Value,
                              Alocacao = a.Element("AllocationName").Value,
                              Produto = items.Element("ProductName").Value,
                              Quantidade = items.Element("ProductQtd").Value
                          };
            //dgvToEstoque.Rows.Clear();

            v.DataSource = estoque.ToArray();
            for (int i = 0; i < v.ColumnCount; i++)
                v.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;*/
        }

        public List<ExcelData> getDataExcel()
        {
            using (var context = new ControledeEstoque.DataBase.ControleEstoqueEntities1())
            {
                var estoques = from items in context.Estoques
                               join s in context.Stocks
                               on
                               items.StockID
                               equals
                               s.StockID
                               join a in context.Allocations
                               on items.LocationID
                               equals
                               a.ID
                               join p in context.Produtoes
                               on items.ProductID
                               equals
                               p.ProductID
                               select new ExcelData
                               {
                                   ID_Estoque = items.EstoqueID,
                                   Estoque = s.StockName,
                                   Alocacao = a.AllocationName,
                                   Produto = p.Product,
                                   Quantidade = items.ProductQtd
                               };

                return estoques.ToList();
            }
            /*XElement allocation = XElement.Load(Path.pathXML.XmlPath + "\\Allocation.xml");
            XElement stock = XElement.Load(Path.pathXML.XmlPath + "\\Stock.xml");
            XElement estoqueXml = XElement.Load(Path.pathXML.XmlPath + @"\Estoque.xml");
            var estoque = from items in estoqueXml.Descendants("Estoques")
                          join s in stock.Descendants("Stocks")
                          on
                          (string)items.Element("StockId")
                          equals
                          (string)s.Element("StockId")
                          join a in allocation.Descendants("Allocations")
                          on
                          (string)items.Element("LocationId")
                          equals
                          (string)a.Element("AllocationId")
                          select new ExcelData
                          {
                              ID_Estoque = items.Element("EstoqueID").Value,
                              Estoque = s.Element("StockName").Value,
                              Alocacao = a.Element("AllocationName").Value,
                              Produto = items.Element("ProductName").Value,
                              Quantidade = items.Element("ProductQtd").Value
                          };*/


            
        }
        public class ExcelData
        {
            private long _ID_Estoque;
            private string _Estoque;
            private string _Alocacao;
            private string _produto;
            private long _quantidade;

            public long ID_Estoque
            {
                get
                {
                    return _ID_Estoque;
                }

                set
                {
                    _ID_Estoque = value;
                }
            }

            public string Estoque
            {
                get
                {
                    return _Estoque;
                }

                set
                {
                    _Estoque = value;
                }
            }

            public string Alocacao
            {
                get
                {
                    return _Alocacao;
                }

                set
                {
                    _Alocacao = value;
                }
            }

            public string Produto
            {
                get
                {
                    return _produto;
                }

                set
                {
                    _produto = value;
                }
            }

            public long Quantidade
            {
                get
                {
                    return _quantidade;
                }

                set
                {
                    _quantidade = value;
                }
            }
        }



    }
}
