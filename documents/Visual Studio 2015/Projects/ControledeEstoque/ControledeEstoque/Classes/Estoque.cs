using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ControledeEstoque.DataBase;

namespace ControledeEstoque.Classes
{
    class Estoque
    {

        #region Attributes
        private int _id;
        private int _estoqueID;
        private List<QuantidadeProduto> _produto;
        private int _locationId;
        private DateTime _time;
        
        #endregion
        #region Encapsulated Attributes
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

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

       
        public int LocationId
        {
            get
            {
                return _locationId;
            }

            set
            {
                _locationId = value;
            }
        }

        internal List<QuantidadeProduto> Produto
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

        public DateTime Time
        {
            get
            {
                return _time;
            }

            set
            {
                _time = value;
            }
        }

        #endregion

        public XDocument createEstoque(string name)
        {
            XDocument productData = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
             new XElement(name));
            productData.Save(name + ".xml");
            return productData;

        }

        public void createXMLEstoqueFile(string path)
        {
            string name = "Estoque";
            XDocument doc = createEstoque(name);

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

        public int addEstoque(string path, Estoque estoque)
        {
            
           using (var context = new ControleEstoqueEntities1())
           {
                foreach(QuantidadeProduto p in estoque.Produto )
                {

                    var query = from P in context.Produtoes
                                where P.Product == p.Produto
                                select new Classes.Produto
                                {
                                    Key = P.ProductID

                                };

                    Classes.Produto prod = query.First();
                    string now = Convert.ToString(DateTime.Now);
                    var estoques = new DataBase.Estoque
                    {
                        EstoqueID = estoque.Id,
                        StockID = estoque.EstoqueID,
                        LocationID = estoque.LocationId,
                        ProductID = prod.Key,
                        ProductQtd = p.Quantidade,
                        Date = now


                    };

                    context.Estoques.Add(estoques);
                }

                context.SaveChanges();

                return 1;
                

                

           }

            

            /*
            string name = "\\Estoque";
           string fileNameFinal = path + name + ".xml";
           int id = 0;

           XElement xelement = XElement.Load(fileNameFinal);
           IEnumerable<XElement> product = xelement.Elements();

           foreach (var Product in product)
               id = Convert.ToInt32(Product.Element("Estoques") != null ? Product.Element("Estoques").Element("EstoqueID").Value: "0");

           id += 1;
           estoque.Id = id;
           var doc = XDocument.Load(fileNameFinal);


           var newElement = new XElement("Produtos",
               from p in Produto
               select new XElement("Estoques",
               new XElement("EstoqueID", estoque.Id),
               new XElement("StockId", estoque.EstoqueID),
               new XElement("LocationId", estoque.LocationId),
               new XElement("ProductId", p.Id),
               new XElement("ProductQtd", p.Quantidade),
               new XElement("ProductName", p.Produto),
               new XElement("Date", estoque.Time)
               ));



           doc.Element("Estoque").Add(newElement);
           try
           {
               doc.Save(fileNameFinal);
               return 1;
           }
           catch
           {
               return 0;

           }*/

        }

        public void populaGridView(DataGridView view, string xmlPath)
        {
            using (var context = new ControleEstoqueEntities1())
            {
                var estoques = from items in context.Estoques
                              join s in context.Stocks
                              on
                              items.StockID
                              equals
                              s.StockID
                              select new
                              {
                                  ID_Alocacao = items.LocationID,
                                  Estoque = s.StockName,
                                  Alocacao = s.StockName
                              };

                view.AutoSize = true;
                view.DataSource = estoques.ToArray();
                for (int i = 0; i < view.ColumnCount; i++)
                    view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            /*
                XElement allocation = XElement.Load(xmlPath + "\\Estoque.xml");
            XElement stock = XElement.Load(xmlPath + "\\Stock.xml");
            var estoque = from items in allocation.Descendants("Allocations")
                          join s in stock.Descendants("Stocks")
                          on
                          (string)items.Element("StockId")
                          equals
                          (string)s.Element("StockId")
                          select new
                          {
                              ID_Alocacao = items.Element("AllocationId").Value,
                              Estoque = s.Element("StockName").Value,
                              Alocacao = items.Element("AllocationName").Value
                          };

            view.AutoSize = true;
            view.DataSource = estoque.ToArray();*/

        }

        public void populaComboBox(ComboBox cmb, string xmlPath, string databaseName, string descendants, string ID, string name, string idToshow, string nameToShow)
        {
            /*
                XElement Produto = XElement.Load(xmlPath + "\\" + databaseName + ".xml");
            var query = from item in Produto.Descendants(descendants)
                        select new
                        {
                            idToshow = item.Element(ID).Value,
                            nameToShow = item.Element(name).Value

                        };

            cmb.DisplayMember = nameToShow;
            cmb.ValueMember = idToshow;
            cmb.DataSource = query.ToArray();*/



        }




    }
}
