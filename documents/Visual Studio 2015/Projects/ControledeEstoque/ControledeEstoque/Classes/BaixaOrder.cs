using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ControledeEstoque.Classes
{
    class BaixaOrder
    {
        private long _id;
        private List<Estoque> _estoque;
        private long _quantidade;
        private DateTime _date;
        private string name = "BaixaOrdem";

        public long Id
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

        public List<Estoque> Estoque
        {
            get
            {
                return _estoque;
            }

            set
            {
                _estoque = value;
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

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public BaixaOrder()
        {
            Estoque = new List<Estoque>();
        }

        public XDocument createBaixaOrdem(string name)
        {
            XDocument orderProducts = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
                new XElement(name));
            orderProducts.Save(name + ".xml");
            return orderProducts;
        }
        public void createXmlOrderProducts(string path)
        {
            
            XDocument doc = createBaixaOrdem(name);
            string fileFinalName = path + @"\" + name + ".xml";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                if (!File.Exists(fileFinalName))
                {
                    doc.Save(fileFinalName);
                }
            }
            catch
            {
                Directory.CreateDirectory(path);

            }
        }

        public int addBaixaOrdem(string path, BaixaOrder order)
        {
            string finalString = path + "\\" + name + ".xml";
            int id = 0;
            XElement xelement = XElement.Load(finalString);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("OrderId").Value);

            id += 1;

            order.Id = id;

            var doc = XDocument.Load(finalString);

            return 1;

        }

    }
}
