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
    class alocacao
    {
        private long _allocationId;
        private long _stockId;
        private string _allocationName;

        public long AllocationId
        {
            get
            {
                return _allocationId;
            }

            set
            {
                _allocationId = value;
            }
        }

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

        public string AllocationName
        {
            get
            {
                return _allocationName;
            }

            set
            {
                _allocationName = value;
            }
        }

        public XDocument createAllocation(string name)
        {
            XDocument productData = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
             new XElement(name));
            productData.Save(name + ".xml");
            return productData;

        }

        public void createXMLAllocationFile(string path)
        {
            string name = "Allocation";
            XDocument doc = createAllocation(name);

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

        public int addAllocation(string path, alocacao alocacao)
        {
            using (var context = new ControleEstoqueEntities1())
            {
                var alocation = new DataBase.Allocation
                {
                    ID = alocacao.AllocationId,
                    StockID = alocacao.StockId,
                    AllocationName = alocacao.AllocationName


                };

                try
                {
                    context.Allocations.Add(alocation);
                    context.SaveChanges();

                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            /*

                string name = "\\Allocation";
            string fileNameFinal = path + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("AllocationId").Value);

            id += 1;
            alocacao.AllocationId = id;
            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("Allocations",
                new XElement("AllocationId", alocacao.AllocationId),
                new XElement("StockId", alocacao.StockId),
                new XElement("AllocationName", alocacao.AllocationName)
                );
            doc.Element("Allocation").Add(newElement);
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

        public void populaGridView(DataGridView view, string xmlPath, ComboBox cmb)
        {
            try
            {

                using (var context = new ControleEstoqueEntities1())
                {
                    long control = Convert.ToInt64(cmb.SelectedValue);
                    var estoque = from items in context.Allocations
                                  join s in context.Stocks
                                  on
                                  items.StockID
                                  equals
                                  s.StockID
                                  where items.StockID == control
                                  select new
                                  {
                                      ID_Alocacao = items.ID,
                                      Estoque = s.StockName,
                                      Alocacao = items.AllocationName
                                  };
                    view.AutoSize = true;
                    view.DataSource = estoque.ToArray();
                }
                /*
                    XElement allocation = XElement.Load(xmlPath + "\\Allocation.xml");
                XElement stock = XElement.Load(xmlPath + "\\Stock.xml");
                var estoque = from items in allocation.Descendants("Allocations")
                              join s in stock.Descendants("Stocks")
                              on
                              (string)items.Element("StockId")
                              equals
                              (string)s.Element("StockId")
                              where (int)items.Element("StockId") == Convert.ToInt32(cmb.SelectedValue)
                              select new
                              {
                                  ID_Alocacao = items.Element("AllocationId").Value,
                                  Estoque = s.Element("StockName").Value,
                                  Alocacao = items.Element("AllocationName").Value
                              };*/

                
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }

        }




        public List<alocacao> getDataForTreeview(int id)
        {
            using (var context = new ControleEstoqueEntities1())
            {
                long control = Convert.ToInt64(id);
                var locacao = from items in context.Allocations
                              join s in context.Stocks
                              on
                              items.StockID
                              equals
                              s.StockID
                              where items.StockID == control
                              select new alocacao
                              {
                                  AllocationId = items.ID,
                                  StockId = items.StockID,
                                  AllocationName = items.AllocationName
                              };

                return locacao.ToList();
            }
        }


        

    }
}
