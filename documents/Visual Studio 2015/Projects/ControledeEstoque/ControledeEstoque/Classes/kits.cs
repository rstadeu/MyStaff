using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ControledeEstoque.DataBase;

namespace ControledeEstoque.Classes
{
    class kits
    {
         private long  _codigo;
        private List<orderProduct> _produtos;
        #region Encapsulated Data
        public long Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        public List<orderProduct> Produtos
        {
            get
            {
                return _produtos;
            }

            set
            {
                _produtos = value;
            }
        }





        #endregion
        #region Methods

        public kits()
        {
            Codigo = 1;
            Produtos = new List<orderProduct>();


        }
        public XDocument creatorOrderProducts(string name)
        {
            XDocument orderProducts = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
                new XElement(name));
            orderProducts.Save(name + ".xml");
            return orderProducts;
        }
        public void createXmlOrderProducts(string path)
        {
            string name = "Kits";
            XDocument doc = creatorOrderProducts(name);
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
        public XDocument createOrder(string name)
        {
            XDocument productData = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
             new XElement(name));
            productData.Save(name + ".xml");
            return productData;

        }

        public void createXMLOrderFile(string path)
        {
            string name = "Kits";
            XDocument doc = createOrder(name);

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

        public int getID(string path)
        {
            long id = 0;
            using (var context = new ControleEstoqueEntities1())
            {

                var query = from k in context.Kits                            
                            select new kits
                            {
                                Codigo = k.KitID
                            };

                //query.OrderByDescending(kit => kit.Codigo);
                try
                {
                    kits ki = query.OrderByDescending(kit => kit.Codigo).First();
                     id = ki.Codigo;
                    id += 1;
                    return Convert.ToInt32(id);
                }
                catch
                {
                    id += 1;
                    return Convert.ToInt32(id);
                }
                
                

            }
            /*
                string name = "\\Kits";
            string fileNameFinal = path + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("KitProduct").Element("KitId").Value);

            return id+1;*/
        }
        public int addOrder(string path, kits pedido)
        {

            using (var context = new ControleEstoqueEntities1())
            {
                var kit = new DataBase.Kit
                {
                    KitName = 123
                };
                context.Kits.Add(kit);
                
                foreach (orderProduct o in pedido.Produtos)
                {
                    var kits = new DataBase.KitList
                    {
                        KitID = pedido.Codigo,
                        OrderProductID = o.OrderProductID
                    };

                    context.KitLists.Add(kits);
                }

                context.SaveChanges();

                return 1;
            }

            /*
                string name = "\\Kits";
            string fileNameFinal = path + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("KitProduct").Element("KitId").Value);

            id += 1;
            pedido.Codigo = id;
            

            var docOrder = XDocument.Load(path + @"\Kits.xml");
            var query = new XElement("KitsProductDesc",
                    from order in Produtos
                    select new XElement("KitProduct",
                    new XElement("KitId", pedido.Codigo),
                    new XElement("ProductQtd", order.Quantity),
                    new XElement("ProductId", order.Produto.Key),
                    new XElement("Products", order.Produto.Product)
                    ));

            docOrder.Element("Kits").Add(query);
            try
            {
                //doc.Save(fileNameFinal);
                docOrder.Save(path + @"\Kits.xml");
                return 1;
            }
            catch
            {
                return 0;

            }

            */

        }
        #endregion
    }
}
