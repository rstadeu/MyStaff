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
    class stock
    {
        private long _stockId;
        private string _stockName;

        public long StockId
        {
            get
            {
                return _stockId;
            }

            set
            {
                _stockId = value;
            }
        }

        public string StockName
        {
            get
            {
                return _stockName;
            }

            set
            {
                _stockName = value;
            }
        }

        public XDocument createStock(string name)
        {
            XDocument productData = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
             new XElement(name));
            productData.Save(name + ".xml");
            return productData;

        }
        
        public void createXMLProductFile(string path)
        {
            string name = "Stock";
            XDocument doc = createStock(name);

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
        
        public int addStock(string path, stock estoque)
        {

            using (var context = new ControleEstoqueEntities1())
            {
                var stock = new DataBase.Stock
                {
                    StockID = estoque.StockId,
                    StockName = estoque.StockName
                };

                context.Stocks.Add(stock);
                context.SaveChanges();

                return 1;
            }
            /*
                string name = "\\Stock";
            string fileNameFinal = path + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("StockId").Value);

            id += 1;
            estoque.StockId = id;
            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("Stocks",
                new XElement("StockId", estoque.StockId),
                new XElement("StockName", estoque.StockName)
                );
            doc.Element("Stock").Add(newElement);
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
                var estoque = from items in context.Stocks
                              select new
                              {
                                  EstoqueID = items.StockID,
                                  EstoqueName = items.StockName
                              };

                view.AutoSize = true;
                view.DataSource = estoque.ToArray();
            }
        }

        public List<stock> getDataForTreeView()
        {
            using (var context = new ControleEstoqueEntities1())
            {
                var estoques = from items in context.Stocks
                               select new stock
                               {
                                   StockId = items.StockID,
                                   StockName = items.StockName
                               };

                return estoques.ToList();
            }
        }

    }
}
