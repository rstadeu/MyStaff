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
    class MeasureUnit
    {
        #region Private Attributes
        private long _ID;
        private string _UnitName;

        private string name = "MeasureUnit";

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

        public string UnitName
        {
            get
            {
                return _UnitName;
            }

            set
            {
                _UnitName = value;
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

        public int addItem(MeasureUnit p)
        {
            //string name = "VendorByProducts";

            using (var context = new ControleEstoqueEntities1())
            {
                var mu = new DataBase.MeasureUnit
                {
                    UnitType = p.UnitName

                };

                context.MeasureUnits.Add(mu);
                context.SaveChanges();

                return 1;
            }

            /*
                string fileNameFinal = Classes.Path.pathXML.XmlPath + "\\" + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("UnityID") != null ? Product.Element("UnitID").Value : "0");

            id += 1;
            p.ID = id;
            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("MeasureUnits",
                new XElement("UnitID", p.ID),
                new XElement("UnitType", p.UnitName)
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

            using(var context = new ControleEstoqueEntities1())
            {
                var query = from m in context.MeasureUnits
                            select new addType
                            {
                                ID = m.MeasureUnitID,
                                Type = m.UnitType
                            };

                d.DataSource = query.ToList();
                for (int i = 0; i < d.ColumnCount; i++)
                    d.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            } 
            /*
            XElement data = XElement.Load(Path.pathXML.XmlPath + @"\" + name + ".xml");

            var query = from m in data.Descendants("MeasureUnits")
                        select new addType
                        {
                            ID = Convert.ToInt32(m.Element("UnitID").Value),
                            Type = m.Element("UnitType").Value
                        };

            d.DataSource = query.ToList();
            for (int i = 0; i < d.ColumnCount; i++)
                d.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;*/
        }


        public void populaComboBox(ComboBox cb)
        {

            using (var context = new ControleEstoqueEntities1())
            {
                var query = from item in context.MeasureUnits
                            select new
                            {
                                ID = item.MeasureUnitID,
                                NomeTipo = item.UnitType
                            };

                cb.DisplayMember = "NomeTipo";
                cb.ValueMember = "ID";
                cb.DataSource = query.ToArray();
            }
               /* XElement fornecedor01 = XElement.Load(Path.pathXML.XmlPath + @"\" + name + ".xml");
            var query = from item in fornecedor01.Descendants("MeasureUnits")
                        select new
                        {
                            ID = item.Element("UnitID").Value,
                            NomeTipo = item.Element("UnitType").Value
                        };

            cb.DisplayMember = "NomeTipo";
            cb.ValueMember = "ID";
            cb.DataSource = query.ToArray();*/

        }


        #endregion

    }
}
