using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ControledeEstoque.Classes
{
    class vendorByProduct
    {
        #region Attributes
        private long _id;
        private long _productID;
        private long _vendorID;

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

        public long ProductID
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

        public long VendorID
        {
            get
            {
                return _vendorID;
            }

            set
            {
                _vendorID = value;
            }
        }

        #endregion


        #region Methods
        public XDocument createFile(string name)
        {
            XDocument productData = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
             new XElement(name));
            productData.Save(name + ".xml");
            return productData;

        }

        public void createXMLFile()
        {
            string name = "VendorByProducts";
            XDocument doc = createFile(name);

            string fileNameFinal = Classes.Path.pathXML.XmlPath + "\\" + name + ".xml";

            if (!Directory.Exists(Classes.Path.pathXML.XmlPath))
            {
                Directory.CreateDirectory(Classes.Path.pathXML.XmlPath);
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
                Directory.CreateDirectory(Classes.Path.pathXML.XmlPath);

            }

        }

        public int addItem( vendorByProduct p)
        {
            string name = "VendorByProducts";
            string fileNameFinal = Classes.Path.pathXML.XmlPath +"\\"+ name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("VendorByProduct") != null ? Product.Element("VendorByProduct").Element("VendorByProductsID").Value : "0");

            id += 1;
            p.Id = id;
            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("VendorByProduct",
                new XElement("VendorByProductsID", p.Id),
                new XElement("ProductID", p.ProductID),
                new XElement("SupplierID", p.VendorID)
                );
            doc.Element("VendorByProducts").Add(newElement);
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

        public List<vendorByProduct> selectData()
        {

            XElement productlist = XElement.Load(Classes.Path.pathXML.XmlPath + "\\VendorByProducts.xml");

            var query = from items in productlist.Descendants("VendorByProduct")
                        select new vendorByProduct
                        {
                            Id = Convert.ToInt32( items.Element("VendorByProductID")),
                            ProductID = Convert.ToInt32(items.Element("ProductID")),
                            VendorID = Convert.ToInt32(items.Element("SupplierID"))

                        };

            return query.ToList();


        }



        #endregion
    }
}
