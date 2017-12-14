using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ControledeEstoque.DataBase;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ControledeEstoque.Classes
{
    public class Produto
    {
        private long _key;
        private string _codNokia;
        private string _codPanalpina;
        private int _materialTypeID;
        private int _materialSubTypeID;
        private string _product;
        private int _unitID;
        private string _descricao;
        private string _pathImagem;

        //private int _estoqueMinimo;

        #region Encapsulated Data
        public long Key
        {
            get
            {
                return _key;
            }

            set
            {
                _key = value;
            }
        }

        public string CodNokia
        {
            get
            {
                return _codNokia;
            }

            set
            {
                _codNokia = value;
            }
        }

        public string CodPanalpina
        {
            get
            {
                return _codPanalpina;
            }

            set
            {
                _codPanalpina = value;
            }
        }

        public string PathImagem
        {
            get
            {
                return _pathImagem;
            }

            set
            {
                _pathImagem = value;
            }
        }

        public string Descricao
        {
            get
            {
                return _descricao;
            }

            set
            {
                _descricao = value;
            }
        }


        public string Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
            }
        }


        public int MaterialTypeID
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

        public int MaterialSubTypeID
        {
            get
            {
                return _materialSubTypeID;
            }

            set
            {
                _materialSubTypeID = value;
            }
        }



        public int UnitID
        {
            get
            {
                return _unitID;
            }

            set
            {
                _unitID = value;
            }
        }





        #endregion
        #region Methods
        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="name">the name of the product</param>
        /// <returns>XDcoment</returns>
        public XDocument createProduct(string name)
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
        public void createXMLProductFile(string path)
        {
            string name = "Produto";
            XDocument doc = createProduct(name);

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
        /// <summary>
        /// That method creates a new entry at product xml file
        /// </summary>
        /// <param name="path">the path to save the file</param>
        /// <param name="prod">the object created when populate the form</param>
        /// <returns>returns an integer to know the status of the file: 1 => ok, 0 => nok</returns>
        public int addProduct(string path, Produto prod)
        {
            string name = "\\Produto";
            string fileNameFinal = path + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("ProductId").Value);

            id += 1;
            prod.Key = id;
            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("Products",
                new XElement("ProductId", prod.Key),
                new XElement("CodigoCliente", prod.CodNokia),
                new XElement("CodigoPanalpina", prod.CodPanalpina),
                new XElement("MaterialType", prod.MaterialTypeID),
                new XElement("MaterialSubType", MaterialSubTypeID),
                new XElement("Produto", prod.Product),
                new XElement("Unit", UnitID),
                new XElement("Descricao", prod.Descricao),
                new XElement("CaminhoImagem", prod.PathImagem)
                );
            doc.Element("Produto").Add(newElement);
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

        public void populaGridView(DataGridView view, string xml, string xmlVendor)
        {

            using (var context = new ControleEstoqueEntities1())
            {
                var query = from items in context.Produtoes
                            select new
                            {
                                ProdutoID = items.ProductID,
                                CodigoCliente = items.CustomerCod,
                                CodigoPanalpina = items.PanalpinaCod,
                                Produto = items.Product,
                                Descricao = items.Comments
                            };

                view.AutoSize = true;
                view.DataSource = query.ToArray();
                for (int i = 0; i < view.ColumnCount; i++)
                    view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
            /*
                XElement produto = XElement.Load(xml);
            XElement MaterialType = XElement.Load(Path.pathXML.XmlPath + @"\MaterialType.xml");
            XElement fornecedor = XElement.Load(xmlVendor);
            var produtos = from items in produto.Descendants("Products")
                           join f in fornecedor.Descendants("Fornecedores")
                           on 
                           (string)items.Element("Fornecedor01") 
                           equals
                           (string)f.Element("FornecedorId")
                           join f1 in fornecedor.Descendants("Fornecedores")
                           on 
                           (string)items.Element("Fornecedor02")
                           equals
                           (string)f1.Element("FornecedorId")
                           join f2 in fornecedor.Descendants("Fornecedores")
                           on 
                           (string)items.Element("Fornecedor03")
                           equals
                           (string)f2.Element("FornecedorId")
                           select new
                           {
                               ProdutoID = items.Element("ProductId").Value,
                               CodigoCliente = items.Element("CodigoCliente").Value,
                               CodigoPanalpina = items.Element("CodigoPanalpina").Value,
                               Produto = items.Element("Produto").Value,
                               Descricao = items.Element("Descricao").Value,
                               Fornecedor_1 = f.Element("NomeFornecedor").Value,
                               Fornecedor_2 = f1.Element("NomeFornecedor").Value,
                               Fornecedor_3 = f2.Element("NomeFornecedor").Value
                           };

            view.AutoSize = true;
            view.DataSource = produtos.ToArray();*/
        }

        public void populaGridView(DataGridView view, string xml, string xmlVendor, string text)
        {
            using (var context = new ControleEstoqueEntities1())
            {
                var query = from items in context.Produtoes
                            where items.Product.StartsWith(text.ToUpper())
                            select new
                            {
                                ProdutoID = items.ProductID,
                                CodigoCliente = items.CustomerCod,
                                CodigoPanalpina = items.PanalpinaCod,
                                Produto = items.Product,
                                Descricao = items.Comments
                            };

                view.AutoSize = true;
                view.DataSource = query.ToArray();
                for (int i = 0; i < view.ColumnCount; i++)
                    view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }

            /*XElement produto = XElement.Load(xml);
            XElement fornecedor = XElement.Load(xmlVendor);
            var produtos = from items in produto.Descendants("Products")
                           join f in fornecedor.Descendants("Fornecedores")
                           on
                           (string)items.Element("Fornecedor01")
                           equals
                           (string)f.Element("FornecedorId")
                           join f1 in fornecedor.Descendants("Fornecedores")
                           on
                           (string)items.Element("Fornecedor02")
                           equals
                           (string)f1.Element("FornecedorId")
                           join f2 in fornecedor.Descendants("Fornecedores")
                           on
                           (string)items.Element("Fornecedor03")
                           equals
                           (string)f2.Element("FornecedorId")
                           where ((string)items.Element("Produto")).StartsWith(text.ToUpper())
                           select new
                           {
                               ProdutoID = items.Element("ProductId").Value,
                               CodigoCliente = items.Element("CodigoCliente").Value,
                               CodigoPanalpina = items.Element("CodigoPanalpina").Value,
                               Produto = items.Element("Produto").Value,
                               Descricao = items.Element("Descricao") == null ? "": items.Element("Descricao").Value,
                               Fornecedor_1 = f.Element("NomeFornecedor").Value,
                               Fornecedor_2 = f1.Element("NomeFornecedor").Value,
                               Fornecedor_3 = f2.Element("NomeFornecedor").Value
                           };

           

            view.AutoSize = true;
            view.DataSource = produtos.ToArray();*/
        }



        public class produtoParaExcel
        {
            private string _produtoID;
            private string _codigoCliente;
            private string _codigoPanalpina;
            private string _produto;
            private string _descricao;
            private string _fornecedor_1;
            private string _fornecedor_2;
            private string _fornecedor_3;

            public string ProdutoID
            {
                get
                {
                    return _produtoID;
                }

                set
                {
                    _produtoID = value;
                }
            }

            public string CodigoCliente
            {
                get
                {
                    return _codigoCliente;
                }

                set
                {
                    _codigoCliente = value;
                }
            }

            public string CodigoPanalpina
            {
                get
                {
                    return _codigoPanalpina;
                }

                set
                {
                    _codigoPanalpina = value;
                }
            }

            public string Produto
            {
                get
                {
                    return _produto;
                }

                set
                {
                    _produto = value;
                }
            }

            public string Descricao
            {
                get
                {
                    return _descricao;
                }

                set
                {
                    _descricao = value;
                }
            }

            public string Fornecedor_1
            {
                get
                {
                    return _fornecedor_1;
                }

                set
                {
                    _fornecedor_1 = value;
                }
            }

            public string Fornecedor_2
            {
                get
                {
                    return _fornecedor_2;
                }

                set
                {
                    _fornecedor_2 = value;
                }
            }

            public string Fornecedor_3
            {
                get
                {
                    return _fornecedor_3;
                }

                set
                {
                    _fornecedor_3 = value;
                }
            }


            public List<produtoParaExcel> queryProduto(string text, string xml, string xmlVendor)
            {
                if (text != "")
                {

                    XElement produto = XElement.Load(xml);
                    XElement fornecedor = XElement.Load(xmlVendor);
                    var produtos = from items in produto.Descendants("Products")
                                   join f in fornecedor.Descendants("Fornecedores")
                                   on
                                   (string)items.Element("Fornecedor01")
                                   equals
                                   (string)f.Element("FornecedorId")
                                   join f1 in fornecedor.Descendants("Fornecedores")
                                   on
                                   (string)items.Element("Fornecedor02")
                                   equals
                                   (string)f1.Element("FornecedorId")
                                   join f2 in fornecedor.Descendants("Fornecedores")
                                   on
                                   (string)items.Element("Fornecedor03")
                                   equals
                                   (string)f2.Element("FornecedorId")
                                   where ((string)items.Element("Produto")).StartsWith(text.ToUpper())
                                   select new produtoParaExcel
                                   {
                                       ProdutoID = items.Element("ProductId").Value,
                                       CodigoCliente = items.Element("CodigoCliente").Value,
                                       CodigoPanalpina = items.Element("CodigoPanalpina").Value,
                                       Produto = items.Element("Produto").Value,
                                       Descricao = items.Element("Descricao") == null ? "" : items.Element("Descricao").Value,
                                       Fornecedor_1 = f.Element("NomeFornecedor").Value,
                                       Fornecedor_2 = f1.Element("NomeFornecedor").Value,
                                       Fornecedor_3 = f2.Element("NomeFornecedor").Value
                                   };


                    List<produtoParaExcel> listaProduto = produtos.ToList();
                    return listaProduto;

                }
                else
                {

                    XElement produto = XElement.Load(xml);
                    XElement fornecedor = XElement.Load(xmlVendor);
                    var produtos = from items in produto.Descendants("Products")
                                   join f in fornecedor.Descendants("Fornecedores")
                                   on
                                   (string)items.Element("Fornecedor01")
                                   equals
                                   (string)f.Element("FornecedorId")
                                   join f1 in fornecedor.Descendants("Fornecedores")
                                   on
                                   (string)items.Element("Fornecedor02")
                                   equals
                                   (string)f1.Element("FornecedorId")
                                   join f2 in fornecedor.Descendants("Fornecedores")
                                   on
                                   (string)items.Element("Fornecedor03")
                                   equals
                                   (string)f2.Element("FornecedorId")
                                   select new produtoParaExcel
                                   {
                                       ProdutoID = items.Element("ProductId").Value,
                                       CodigoCliente = items.Element("CodigoCliente").Value,
                                       CodigoPanalpina = items.Element("CodigoPanalpina").Value,
                                       Produto = items.Element("Produto").Value,
                                       Descricao = items.Element("Descricao") == null ? "" : items.Element("Descricao").Value,
                                       Fornecedor_1 = f.Element("NomeFornecedor").Value,
                                       Fornecedor_2 = f1.Element("NomeFornecedor").Value,
                                       Fornecedor_3 = f2.Element("NomeFornecedor").Value
                                   };

                    List<produtoParaExcel> listaProduto = produtos.ToList();
                    return listaProduto;

                }
            }





        }

        public void addProduto(Produto p)
        {
            using (var context = new ControleEstoqueEntities1())
            {
                var product = new DataBase.Produto
                {
                    CustomerCod = p.CodNokia,
                    PanalpinaCod = p.CodPanalpina,
                    MaterialType = p.MaterialTypeID,
                    MaterialSubType = p.MaterialSubTypeID,
                    Product = p.Product,
                    MeasureUnit = p.UnitID,
                    Comments = p.Descricao,
                    ImagePath = p.PathImagem,
                    CreateDate = Convert.ToString(DateTime.UtcNow)


                };

                context.Produtoes.Add(product);
                context.SaveChanges();
            }
        }

        #endregion
        public long getID()
        {
            long id = 0;
            using (var context = new ControleEstoqueEntities1())
            {

                var query = from k in context.Produtoes
                            select new Produto
                            {
                                Key = k.ProductID
                            };

                //query.OrderByDescending(kit => kit.Codigo);
                try
                {
                    Produto pro = query.OrderByDescending(p => p.Key).First();
                    id = pro.Key;
                    return id;
                }
                catch
                {
                    return id;
                }



            }

        }
    }
}
