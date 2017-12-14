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
    class subType
    {
        #region Private Attributes
        private long _ID;
        private long _materialTypeID;
        private string _subTypeName;
        private string name = "MaterialSubType";
        #endregion
        #region Public Attributes
        public long ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public long MaterialTypeID
        {
            get
            {
                return _materialTypeID;
            }

            set
            {
                _materialTypeID = value;
            }
        }

        public string SubTypeName
        {
            get
            {
                return _subTypeName;
            }

            set
            {
                _subTypeName = value;
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

        public int addItem(subType p)
        {

            using (var context = new ControleEstoqueEntities1())
            {
                var sub = new DataBase.MaterialSubType
                {
                    MaterialTypeID = p.MaterialTypeID,
                    SubTypeID = p.ID,
                    SubTypeName = p.SubTypeName
                };

                context.MaterialSubTypes.Add(sub);
                context.SaveChanges();

                return 1;
            }
            /*
            //string name = "VendorByProducts";
            string fileNameFinal = Classes.Path.pathXML.XmlPath + "\\" + name + ".xml";
            long id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.Tolong32(Product.Element("SubTypeID") != null ? Product.Element("SubTypeID").Value : "0");

            id += 1;
            p.ID = id;
            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("MaterialSubTypes",
                new XElement("SubTypeID", p.ID),
                new XElement("MaterialTypeID", p.MaterialTypeID),
                new XElement("SubTypeName", p.SubTypeName)
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

            }*/

        }


        public void populaGridView(DataGridView d)
        {
            using (var context = new ControleEstoqueEntities1())
            {
                var query = from m in context.MaterialSubTypes
                            join l in context.MaterialTypes
                            on
                            m.MaterialTypeID
                            equals
                            l.TypeID
                            select new
                            {
                                ID = m.SubTypeID,
                                MaterialType = l.TypeName,
                                SubType = m.SubTypeName
                            };
               
                d.DataSource = query.ToList();
                for (int i = 0; i < d.ColumnCount; i++)
                    d.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public void populaComboBox(ComboBox cm, int MaterialID)
        {
            long converted = Convert.ToInt64(MaterialID);
            using (var context = new ControleEstoqueEntities1())
            {
                var query = from item in context.MaterialSubTypes
                            where item.MaterialTypeID == converted
                            select new
                            {
                                ID = item.SubTypeID,
                                NomeTipo = item.SubTypeName
                            };

                cm.DisplayMember = "NomeTipo";
                cm.ValueMember = "ID";
                cm.DataSource = query.ToArray();
            }
        }

        #endregion
    }
}
