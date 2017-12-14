using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ControledeEstoque.Classes
{
    class caminho
    {
        private string _path;
        private string _xmlPath;
        private string _imagePath;


        public caminho()
        {
            _path = null;
        }

        public string Path
        {
            get
            {
                return _path;
            }

            set
            {
                _path = value;
            }
        }

        public string XmlPath
        {
            get
            {
                return _xmlPath;
            }

            set
            {
                _xmlPath = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return _imagePath;
            }

            set
            {
                _imagePath = value;
            }
        }

        public void definePath(string p)
        {
            _path = p;

        }


        /// <summary>
        /// Creates a new path
        /// </summary>
        /// <param name="name">The new path</param>
        /// <returns>XDcoment</returns>
        public XDocument createPath(string name)
        {
            XDocument productData = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
             new XElement(name));
            productData.Save(name + ".xml");
            return productData;

        }
        /// <summary>
        /// Creates a XMLFile for Product
        /// </summary>
        /// <param name="path">the path that the file will be saved</param>
        /// <param name="name">the name of the file</param>
        public void createXMLPathFile()
        {
            string name = "Path";
            XDocument doc = createPath("Path");

            string fileNameFinal = Directory.GetCurrentDirectory()+ "\\AppData" + "\\" + name + ".xml";

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\AppData"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AppData");
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
                Directory.CreateDirectory(Path);

            }

        }

        public int addPath(caminho caminho)
        {
            string name = "\\Path";
            string fileNameFinal = Directory.GetCurrentDirectory() + "\\AppData\\" + name + ".xml";

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> paths = xelement.Elements();

            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("Caminho",
                new XElement("Path", Path),
                new XElement("XMLPath", XmlPath),
                new XElement("ImagePath", ImagePath)
                );
            doc.Element("Path").Add(newElement);
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

        public bool verifyData()
        {
            
            XElement caminhos = XElement.Load(Directory.GetCurrentDirectory() + "\\AppData" + "\\Path.xml");
            try
            {
                var query = from item in caminhos.Descendants("Caminho")
                            select new caminho
                            {
                                Path = item.Element("Path").Value,
                                XmlPath = item.Element("XMLPath").Value,
                                ImagePath = item.Element("ImagePath").Value
                            };

                caminho c = query.First();
                Path = c.Path;
                XmlPath = c.XmlPath;
                ImagePath = c.ImagePath;
                return true;
            }
            catch
            {
                return false;
            }

           

          
        }

        public bool update()
        {
            XDocument caminhos = XDocument.Load(Directory.GetCurrentDirectory() + "\\AppData" + "\\Path.xml");
            try
            {
                var items = from item in caminhos.Descendants("Caminho")
                            select item;
                foreach(XElement itemElement in items)
                {
                    itemElement.SetElementValue("Path", Path);
                    itemElement.SetElementValue("XMLPath", XmlPath);
                    itemElement.SetElementValue("ImagePath", ImagePath);
                }

                caminhos.Save(Directory.GetCurrentDirectory() + "\\AppData\\Path.xml");

                return true;
                
            }
            catch
            {
                return false;
            }
        }

    }

}

