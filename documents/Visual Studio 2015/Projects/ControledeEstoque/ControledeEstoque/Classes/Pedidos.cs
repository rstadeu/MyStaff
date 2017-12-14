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
    class Pedidos
    {
        private long _codigo;
        private string _description;
        private string _invoice;
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

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string Invoice
        {
            get
            {
                return _invoice;
            }

            set
            {
                _invoice = value;
            }
        }





        #endregion
        #region Methods

        public Pedidos()
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
            string name = "OrderProducts";
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
            string name = "Order";
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

        public long getID(string path)
        {
            long id = 0;
            using (var context = new ControleEstoqueEntities1())
            {
                var query = from p in context.Orders
                            select new Pedidos
                            {
                                Codigo = p.OrderID
                            };

                try
                {
                    Pedidos order = query.OrderByDescending(o => o.Codigo).First();
                    id = order.Codigo;
                    return id + 1;
                }
                catch
                {
                    return id + 1;
                }
            }
            /*
            string name = "\\Order";
            string fileNameFinal = path + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("OrderId").Value);

            return id+1;*/
        }
        public int addOrder(string path, Pedidos pedido)
        {
            
            
            using (var context = new ControleEstoqueEntities1())
            {
                var pedidoes = new DataBase.Order
                {
                    //OrderID = pedido.Codigo,
                    Invoice = "",
                    OrderDescription = ""
                };
                context.Orders.Add(pedidoes);
                context.SaveChanges();

                foreach (Classes.orderProduct o in pedido.Produtos)
                {
                    var orderProduto = new DataBase.OrderProduct
                    {
                        OrderProductsID = o.OrderProductID,
                        OrderID = pedido.Codigo,
                        ProductID = o.Produto.Key,
                        Quantity = o.Quantity
                    };

                    context.OrderProducts.Add(orderProduto);
                }

                context.SaveChanges();

                return 1;
            }
            /*
            string name = "\\Order";
            string fileNameFinal = path + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("OrderId").Value);

            id += 1;
            pedido.Codigo = id;
            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("Orders",
                new XElement("OrderId", pedido.Codigo)
                );
            doc.Element("Order").Add(newElement);

            var docOrder = XDocument.Load(path + @"\OrderProducts.xml");
            var query = new XElement("OrderProductDesc",
                    from order in Produtos
                    select new XElement("OrderProduct",
                    new XElement("OrderId", pedido.Codigo),
                    new XElement("ProductQtd", order.Quantity),
                    new XElement("ProductId", order.Produto.Key),
                    new XElement("Products", order.Produto.Product)
                    ));

            docOrder.Element("OrderProducts").Add(query);
            try
            {
                doc.Save(fileNameFinal);
                docOrder.Save(path + @"\OrderProducts.xml");
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
