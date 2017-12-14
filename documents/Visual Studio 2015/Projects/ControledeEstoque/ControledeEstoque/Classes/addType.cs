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
    class addType
    {
        private long _iD;
        private string _type;
        private string name = "MaterialType";
        public long ID
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

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }


        public XDocument createFile(string name)
        {
            XDocument productData = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
             new XElement(name));
            productData.Save(name + ".xml");
            return productData;

        }

        public void createXMLFile()
        {
            
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

        public int addItem(addType p)
        {

            using (var context = new ControleEstoqueEntities1())
            {
                var addItem = new DataBase.MaterialType
                {
                    TypeID = p.ID,
                    TypeName = p.Type
                };

                try
                {
                    context.MaterialTypes.Add(addItem);
                    context.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }

            }

            /*
            //string name = "VendorByProducts";
            string fileNameFinal = Classes.Path.pathXML.XmlPath + "\\" + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("TypeID") != null ? Product.Element("TypeID").Value : "0");

            id += 1;
            p.ID = id;
            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("MaterialTypes",
                new XElement("TypeID", p.ID),
                new XElement("TypeName", p.Type)
                );
            doc.Element(name).Add(newElement);
            try
            {
                doc.Save(fileNameFinal);
                return 1;
            }
            catch
            {
                return 0;

            }
            */
        }


        public void populaGridView(DataGridView d)
        {

            using (var context = new ControleEstoqueEntities1())
            {
                var query = from m in context.MaterialTypes
                            select new addType
                            {
                                ID = m.TypeID,
                                Type = m.TypeName
                            };

                d.DataSource = query.ToList();
                for (int i = 0; i < d.ColumnCount; i++)
                    d.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            /*
                XElement data = XElement.Load(Path.pathXML.XmlPath + @"\" + name + ".xml");

            var query = from m in data.Descendants("MaterialTypes")
                        select new addType
                        {
                            ID = Convert.ToInt32(m.Element("TypeID").Value),
                            Type = m.Element("TypeName").Value
                        };

            d.DataSource = query.ToList();
            for (int i = 0; i < d.ColumnCount; i++)
                d.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;*/
        }


        public void populaComboBox(ComboBox cb)
        {

            using (var context = new ControleEstoqueEntities1())
            {
                var query = from item in context.MaterialTypes
                            select new
                            {
                                ID = item.TypeID,
                                NomeTipo = item.TypeName
                            };
                cb.DisplayMember = "NomeTipo";
                cb.ValueMember = "ID";
                cb.DataSource = query.ToArray();
            }
               /* XElement fornecedor01 = XElement.Load(Path.pathXML.XmlPath + @"\MaterialType.xml");
            var query = from item in fornecedor01.Descendants("MaterialTypes")
                        select new
                        {
                            ID = item.Element("TypeID").Value,
                            NomeTipo = item.Element("TypeName").Value
                        };
                        */
            

        }

    }
}
