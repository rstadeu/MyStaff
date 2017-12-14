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
    class Supplier
    {
        #region Attributes
        private int _id;
        private string _supplierName;
        private string _cep;
        private string _endereco;
        private int _numero;
        private string _complemento;
        private string _uf;
        private string _cidade;
        private string _telefone;
        private string _ramal;
        private string _email;
        private string _website;
        private Int64 _isActive;

        public int Id
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

        public string SupplierName
        {
            get
            {
                return _supplierName;
            }

            set
            {
                _supplierName = value;
            }
        }

        public string Cep
        {
            get
            {
                return _cep;
            }

            set
            {
                _cep = value;
            }
        }

        public string Endereco
        {
            get
            {
                return _endereco;
            }

            set
            {
                _endereco = value;
            }
        }

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public string Complemento
        {
            get
            {
                return _complemento;
            }

            set
            {
                _complemento = value;
            }
        }

        public string Uf
        {
            get
            {
                return _uf;
            }

            set
            {
                _uf = value;
            }
        }

        public string Cidade
        {
            get
            {
                return _cidade;
            }

            set
            {
                _cidade = value;
            }
        }

        public string Telefone
        {
            get
            {
                return _telefone;
            }

            set
            {
                _telefone = value;
            }
        }

        public string Ramal
        {
            get
            {
                return _ramal;
            }

            set
            {
                _ramal = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Website
        {
            get
            {
                return _website;
            }

            set
            {
                _website = value;
            }
        }

        public Int64 IsActive
        {
            get
            {
                return _isActive;
            }

            set
            {
                _isActive = value;
            }
        }
        #endregion


        #region Encapsulated Attributes


        #endregion

        #region Methods

        public XDocument createSupplier(string name)
        {
            XDocument productData = new XDocument(new XDeclaration("1.0", "utf8", "yes"),
             new XElement(name));
            productData.Save(name + ".xml");
            return productData;

        }
       
        public void createXMLSupplierFile(string path)
        {
            string name = "Fornecedor";
            XDocument doc = createSupplier(name);

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
        
        public int addSupplier(string path, Supplier fornecedor)
        {
            using (var context = new ControleEstoqueEntities1())
            {
                var supplier = new DataBase.Fornecedor
                {
                    FornecedorID = fornecedor.Id,
                    NomeFornecedor = fornecedor.SupplierName,
                    CEP = fornecedor.Cep,
                    Logradouro = fornecedor.Endereco,
                    Numero = fornecedor.Numero,
                    Complemento = fornecedor.Complemento,
                    UF = fornecedor.Uf,
                    Cidade = fornecedor.Cidade,
                    Telefone = fornecedor.Telefone,
                    Ramal = fornecedor.Ramal,
                    Email = fornecedor.Email,
                    Website = fornecedor.Website,
                    IsActive = Convert.ToInt64(true)
                };

                context.Fornecedors.Add(supplier);
                context.SaveChanges();
                return 1;
            }
            return 0;
            /*
            string name = "\\Fornecedor";
            string fileNameFinal = path + name + ".xml";
            int id = 0;

            XElement xelement = XElement.Load(fileNameFinal);
            IEnumerable<XElement> product = xelement.Elements();

            foreach (var Product in product)
                id = Convert.ToInt32(Product.Element("FornecedorId").Value);

            id += 1;
            fornecedor.Id = id;
            var doc = XDocument.Load(fileNameFinal);

            var newElement = new XElement("Fornecedores",
                new XElement("FornecedorId", fornecedor.Id),
                new XElement("NomeFornecedor", fornecedor.SupplierName),
                new XElement("CEP", fornecedor.Cep),
                new XElement("Enredeco", fornecedor.Endereco),
                new XElement("Numero", fornecedor.Numero),
                new XElement("Complemento", fornecedor.Complemento),
                new XElement("UF", fornecedor.Uf),
                new XElement("Cidade", fornecedor.Cidade),
                new XElement("Telefone", fornecedor.Telefone),
                new XElement("Ramal", fornecedor.Ramal),
                new XElement("Email", fornecedor.Email),
                new XElement("WebSite", fornecedor.Website), 
                new XElement("IsActive", true)
                );
            doc.Element("Fornecedor").Add(newElement);
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

        public void populaComboBox(ComboBox cmbFornecedor)
        {

            using (var context = new ControleEstoqueEntities1())
            {
                var query = from item in context.Fornecedors
                            select new
                            {
                                fornecedor01Id = item.FornecedorID,
                                nomeFornecedor01 = item.NomeFornecedor
                            };

                cmbFornecedor.DisplayMember = "NomeFornecedor01";
                cmbFornecedor.ValueMember = "Fornecedor01Id";
                cmbFornecedor.DataSource = query.ToArray();
            }
            /*
            fornecedor01 = XElement.Load(xmlPath + "\\Fornecedor.xml");
            var query = from item in fornecedor01.Descendants("Fornecedores")
                        select new
                        {
                            fornecedor01Id = item.Element("FornecedorId").Value,
                            nomeFornecedor01 = item.Element("NomeFornecedor").Value
                        };

            cmbFornecedor.DisplayMember = "NomeFornecedor01";
            cmbFornecedor.ValueMember = "Fornecedor01Id";
            cmbFornecedor.DataSource = query.ToArray();
            */
        }

        public void populaGridView(DataGridView view, string xmlVendor, bool test)
        {
            XElement fornecedor = XElement.Load(xmlVendor);
            if (test)
            {
                using (var context = new ControleEstoqueEntities1())
                {
                    long validation = Convert.ToInt64(true);
                    var produtos = from items in context.Fornecedors
                                   where items.IsActive == validation
                                   select new
                                   {
                                       Codigo_Fornecedor = items.FornecedorID,
                                       Nome_Fornecedor = items.NomeFornecedor,
                                       CEP = items.CEP,
                                       Logradouro = items.Logradouro,
                                       Numero = items.Numero,
                                       Complemento = (items.Complemento == null ? "" : items.Complemento),
                                       UF = items.UF,
                                       Cidade = items.Cidade,
                                       Telefone = items.Telefone == null ? "" : items.Telefone,
                                       Ramal = items.Ramal == null ? "" : items.Ramal,
                                       Email = items.Email == null ? "" : items.Email,
                                       WebSite = items.Website == null ? "" : items.Website

                                   };

                    view.DataSource = produtos.ToArray();
                    view.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                /*
                    var produtos = from items in fornecedor.Descendants("Fornecedores")
                                   where ((bool)items.Element("IsActive")) == true
                                   select new
                                   {
                                       Codigo_Fornecedor = items.Element("FornecedorId").Value,
                                       Nome_Fornecedor = items.Element("NomeFornecedor").Value,
                                       CEP = items.Element("CEP").Value,
                                       Logradouro = items.Element("Enredeco").Value,
                                       Numero = items.Element("Numero").Value,
                                       Complemento = (items.Element("Complemento") == null ? "" : items.Element("Complemento").Value),
                                       UF = items.Element("UF").Value,
                                       Cidade = items.Element("Cidade").Value,
                                       Telefone = items.Element("Telefone") == null ? "" : items.Element("Telefone").Value,
                                       Ramal = items.Element("Ramal") == null ? "" : items.Element("Ramal").Value,
                                       Email = items.Element("Email") == null ? "" : items.Element("Email").Value,
                                       WebSite = items.Element("WebSite") == null ? "" : items.Element("WebSite").Value

                                   };
                //view.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders);
                //view.AutoResizeColumn();
                
                //view.AutoSize = true;
                view.DataSource = produtos.ToArray();
                view.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                view.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                */
            }
            else
            {

                using (var context = new ControleEstoqueEntities1())
                {
                    long validation = Convert.ToInt64(true);
                    var produtos = from items in context.Fornecedors
                                   select new
                                   {
                                       Codigo_Fornecedor = items.FornecedorID,
                                       Nome_Fornecedor = items.NomeFornecedor,
                                       CEP = items.CEP,
                                       Logradouro = items.Logradouro,
                                       Numero = items.Numero,
                                       Complemento = (items.Complemento == null ? "" : items.Complemento),
                                       UF = items.UF,
                                       Cidade = items.Cidade,
                                       Telefone = items.Telefone == null ? "" : items.Telefone,
                                       Ramal = items.Ramal == null ? "" : items.Ramal,
                                       Email = items.Email == null ? "" : items.Email,
                                       WebSite = items.Website == null ? "" : items.Website

                                   };

                    view.DataSource = produtos.ToArray();
                    view.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }


        }

        public void populaGridView(DataGridView view, string xmlVendor,bool test, string text)
        {

            
            XElement fornecedor = XElement.Load(xmlVendor);
            if (test)
            {
                using (var context = new ControleEstoqueEntities1())
                {
                    long validation = Convert.ToInt64(true);
                    var produtos = from items in context.Fornecedors
                                   where items.NomeFornecedor.StartsWith(text.ToUpper())
                                     && items.IsActive == validation
                                   select new
                                   {
                                       Codigo_Fornecedor = items.FornecedorID,
                                       Nome_Fornecedor = items.NomeFornecedor,
                                       CEP = items.CEP,
                                       Logradouro = items.Logradouro,
                                       Numero = items.Numero,
                                       Complemento = (items.Complemento == null ? "" : items.Complemento),
                                       UF = items.UF,
                                       Cidade = items.Cidade,
                                       Telefone = items.Telefone == null ? "" : items.Telefone,
                                       Ramal = items.Ramal == null ? "" : items.Ramal,
                                       Email = items.Email == null ? "" : items.Email,
                                       WebSite = items.Website == null ? "" : items.Website

                                   };



                    view.AutoSize = true;
                    view.DataSource = produtos.ToArray();
                    view.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            else
            {
                using (var context = new ControleEstoqueEntities1())
                {
                    long validation = Convert.ToInt64(true);
                    var produtos = from items in context.Fornecedors
                                   where items.NomeFornecedor.StartsWith(text.ToUpper())
                                   select new
                                   {
                                       Codigo_Fornecedor = items.FornecedorID,
                                       Nome_Fornecedor = items.NomeFornecedor,
                                       CEP = items.CEP,
                                       Logradouro = items.Logradouro,
                                       Numero = items.Numero,
                                       Complemento = (items.Complemento == null ? "" : items.Complemento),
                                       UF = items.UF,
                                       Cidade = items.Cidade,
                                       Telefone = items.Telefone == null ? "" : items.Telefone,
                                       Ramal = items.Ramal == null ? "" : items.Ramal,
                                       Email = items.Email == null ? "" : items.Email,
                                       WebSite = items.Website == null ? "" : items.Website

                                   };



                    view.AutoSize = true;
                    view.DataSource = produtos.ToArray();
                    view.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    view.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        public List<Supplier> querySupplier(string text, bool verify, string xmlVendor)
        {
            if (text != "")
            {
                if (verify)
                {

                    using (var context = new ControleEstoqueEntities1())
                    {
                        long validation = Convert.ToInt64(true);
                        var produtos = from items in context.Fornecedors
                                       where items.NomeFornecedor.StartsWith(text.ToUpper())
                                         && items.IsActive == validation
                                       select new Supplier
                                       {
                                           Id = (int)items.FornecedorID,
                                           SupplierName = items.NomeFornecedor,
                                           Cep = items.CEP,
                                           Endereco = items.Logradouro,
                                           Numero = (int)items.Numero,
                                           Complemento = (items.Complemento == null ? "" : items.Complemento),
                                           Uf = items.UF,
                                           Cidade = items.Cidade,
                                           Telefone = items.Telefone == null ? "" : items.Telefone,
                                           Ramal = items.Ramal == null ? "" : items.Ramal,
                                           Email = items.Email == null ? "" : items.Email,
                                           Website = items.Website == null ? "" : items.Website,
                                           IsActive = items.IsActive
                                       };

                        /*
                        XElement fornecedor = XElement.Load(xmlVendor);

                    var produtos = from items in fornecedor.Descendants("Fornecedores")
                                   where ((string)items.Element("NomeFornecedor")).StartsWith(text.ToUpper())
                                     && ((bool)items.Element("IsActive")) == true
                                   select new Supplier
                                   {
                                       Id = Convert.ToInt32(items.Element("FornecedorId").Value),
                                       SupplierName = items.Element("NomeFornecedor").Value,
                                       Cep = items.Element("CEP").Value,
                                       Endereco = items.Element("Enredeco").Value,
                                       Numero = Convert.ToInt32(items.Element("Numero").Value),
                                       Complemento = (items.Element("Complemento") == null ? "" : items.Element("Complemento").Value),
                                       Uf = items.Element("UF").Value,
                                       Cidade = items.Element("Cidade").Value,
                                       Telefone = items.Element("Telefone") == null ? "" : items.Element("Telefone").Value,
                                       Ramal = items.Element("Ramal") == null ? "" : items.Element("Ramal").Value,
                                       Email = items.Element("Email") == null ? "" : items.Element("Email").Value,
                                       Website = items.Element("WebSite") == null ? "" : items.Element("WebSite").Value,
                                       IsActive = Convert.ToBoolean(items.Element("IsActive").Value)

                                   };

    */
                        List<Supplier> listaProduto = produtos.ToList();
                        return listaProduto;
                    }
                }
                else
                {

                    using (var context = new ControleEstoqueEntities1())
                    {
                        long validation = Convert.ToInt64(true);
                        var produtos = from items in context.Fornecedors
                                       where items.NomeFornecedor.StartsWith(text.ToUpper())
                                       select new Supplier
                                       {
                                           Id = (int)items.FornecedorID,
                                           SupplierName = items.NomeFornecedor,
                                           Cep = items.CEP,
                                           Endereco = items.Logradouro,
                                           Numero = (int)items.Numero,
                                           Complemento = (items.Complemento == null ? "" : items.Complemento),
                                           Uf = items.UF,
                                           Cidade = items.Cidade,
                                           Telefone = items.Telefone == null ? "" : items.Telefone,
                                           Ramal = items.Ramal == null ? "" : items.Ramal,
                                           Email = items.Email == null ? "" : items.Email,
                                           Website = items.Website == null ? "" : items.Website,
                                           IsActive = (items.IsActive)
                                       };

                        /*
                        XElement fornecedor = XElement.Load(xmlVendor);

                    var produtos = from items in fornecedor.Descendants("Fornecedores")
                                   where ((string)items.Element("NomeFornecedor")).StartsWith(text.ToUpper())
                                     && ((bool)items.Element("IsActive")) == true
                                   select new Supplier
                                   {
                                       Id = Convert.ToInt32(items.Element("FornecedorId").Value),
                                       SupplierName = items.Element("NomeFornecedor").Value,
                                       Cep = items.Element("CEP").Value,
                                       Endereco = items.Element("Enredeco").Value,
                                       Numero = Convert.ToInt32(items.Element("Numero").Value),
                                       Complemento = (items.Element("Complemento") == null ? "" : items.Element("Complemento").Value),
                                       Uf = items.Element("UF").Value,
                                       Cidade = items.Element("Cidade").Value,
                                       Telefone = items.Element("Telefone") == null ? "" : items.Element("Telefone").Value,
                                       Ramal = items.Element("Ramal") == null ? "" : items.Element("Ramal").Value,
                                       Email = items.Element("Email") == null ? "" : items.Element("Email").Value,
                                       Website = items.Element("WebSite") == null ? "" : items.Element("WebSite").Value,
                                       IsActive = Convert.ToBoolean(items.Element("IsActive").Value)

                                   };

    */
                        List<Supplier> listaProduto = produtos.ToList();
                        return listaProduto;
                    }

                    /*
                    XElement fornecedor = XElement.Load(xmlVendor);

                    var produtos = from items in fornecedor.Descendants("Fornecedores")
                                   where ((string)items.Element("NomeFornecedor")).StartsWith(text.ToUpper())
                                   select new Supplier
                                   {
                                       Id = Convert.ToInt32(items.Element("FornecedorId").Value),
                                       SupplierName = items.Element("NomeFornecedor").Value,
                                       Cep = items.Element("CEP").Value,
                                       Endereco = items.Element("Enredeco").Value,
                                       Numero = Convert.ToInt32(items.Element("Numero").Value),
                                       Complemento = (items.Element("Complemento") == null ? "" : items.Element("Complemento").Value),
                                       Uf = items.Element("UF").Value,
                                       Cidade = items.Element("Cidade").Value,
                                       Telefone = items.Element("Telefone") == null ? "" : items.Element("Telefone").Value,
                                       Ramal = items.Element("Ramal") == null ? "" : items.Element("Ramal").Value,
                                       Email = items.Element("Email") == null ? "" : items.Element("Email").Value,
                                       Website = items.Element("WebSite") == null ? "" : items.Element("WebSite").Value,
                                       IsActive = Convert.ToBoolean(items.Element("IsActive").Value)

                                   };*/
                    
                }
            }
            else
            {
                if (verify)
                {
                    using (var context = new ControleEstoqueEntities1())
                    {
                        long validation = Convert.ToInt64(true);
                        var produtos = from items in context.Fornecedors
                                       where items.IsActive == validation
                                       select new Supplier
                                       {
                                           Id = (int)items.FornecedorID,
                                           SupplierName = items.NomeFornecedor,
                                           Cep = items.CEP,
                                           Endereco = items.Logradouro,
                                           Numero = (int)items.Numero,
                                           Complemento = (items.Complemento == null ? "" : items.Complemento),
                                           Uf = items.UF,
                                           Cidade = items.Cidade,
                                           Telefone = items.Telefone == null ? "" : items.Telefone,
                                           Ramal = items.Ramal == null ? "" : items.Ramal,
                                           Email = items.Email == null ? "" : items.Email,
                                           Website = items.Website == null ? "" : items.Website,
                                           IsActive = (items.IsActive)
                                       };

                        /*
                        XElement fornecedor = XElement.Load(xmlVendor);

                    var produtos = from items in fornecedor.Descendants("Fornecedores")
                                   where ((string)items.Element("NomeFornecedor")).StartsWith(text.ToUpper())
                                     && ((bool)items.Element("IsActive")) == true
                                   select new Supplier
                                   {
                                       Id = Convert.ToInt32(items.Element("FornecedorId").Value),
                                       SupplierName = items.Element("NomeFornecedor").Value,
                                       Cep = items.Element("CEP").Value,
                                       Endereco = items.Element("Enredeco").Value,
                                       Numero = Convert.ToInt32(items.Element("Numero").Value),
                                       Complemento = (items.Element("Complemento") == null ? "" : items.Element("Complemento").Value),
                                       Uf = items.Element("UF").Value,
                                       Cidade = items.Element("Cidade").Value,
                                       Telefone = items.Element("Telefone") == null ? "" : items.Element("Telefone").Value,
                                       Ramal = items.Element("Ramal") == null ? "" : items.Element("Ramal").Value,
                                       Email = items.Element("Email") == null ? "" : items.Element("Email").Value,
                                       Website = items.Element("WebSite") == null ? "" : items.Element("WebSite").Value,
                                       IsActive = Convert.ToBoolean(items.Element("IsActive").Value)

                                   };

    */
                        List<Supplier> listaProduto = produtos.ToList();
                        return listaProduto;
                    }
                    /*
                    XElement fornecedor = XElement.Load(xmlVendor);

                    var produtos = from items in fornecedor.Descendants("Fornecedores")
                                   where ((bool)items.Element("IsActive")) == true
                                   select new Supplier
                                   {
                                       Id = Convert.ToInt32(items.Element("FornecedorId").Value),
                                       SupplierName = items.Element("NomeFornecedor").Value,
                                       Cep = items.Element("CEP").Value,
                                       Endereco = items.Element("Enredeco").Value,
                                       Numero = Convert.ToInt32(items.Element("Numero").Value),
                                       Complemento = (items.Element("Complemento") == null ? "" : items.Element("Complemento").Value),
                                       Uf = items.Element("UF").Value,
                                       Cidade = items.Element("Cidade").Value,
                                       Telefone = items.Element("Telefone") == null ? "" : items.Element("Telefone").Value,
                                       Ramal = items.Element("Ramal") == null ? "" : items.Element("Ramal").Value,
                                       Email = items.Element("Email") == null ? "" : items.Element("Email").Value,
                                       Website = items.Element("WebSite") == null ? "" : items.Element("WebSite").Value,
                                       IsActive = Convert.ToBoolean(items.Element("IsActive").Value)

                                   };
                    List<Supplier> listaProduto = produtos.ToList();
                    return listaProduto;

    */
                }
                else
                {
                    using (var context = new ControleEstoqueEntities1())
                    {
                        long validation = Convert.ToInt64(true);
                        var produtos = from items in context.Fornecedors
                                       select new Supplier
                                       {
                                           Id = (int)items.FornecedorID,
                                           SupplierName = items.NomeFornecedor,
                                           Cep = items.CEP,
                                           Endereco = items.Logradouro,
                                           Numero = (int)items.Numero,
                                           Complemento = (items.Complemento == null ? "" : items.Complemento),
                                           Uf = items.UF,
                                           Cidade = items.Cidade,
                                           Telefone = items.Telefone == null ? "" : items.Telefone,
                                           Ramal = items.Ramal == null ? "" : items.Ramal,
                                           Email = items.Email == null ? "" : items.Email,
                                           Website = items.Website == null ? "" : items.Website,
                                           IsActive = (items.IsActive)
                                       };

                        /*
                        XElement fornecedor = XElement.Load(xmlVendor);

                    var produtos = from items in fornecedor.Descendants("Fornecedores")
                                   where ((string)items.Element("NomeFornecedor")).StartsWith(text.ToUpper())
                                     && ((bool)items.Element("IsActive")) == true
                                   select new Supplier
                                   {
                                       Id = Convert.ToInt32(items.Element("FornecedorId").Value),
                                       SupplierName = items.Element("NomeFornecedor").Value,
                                       Cep = items.Element("CEP").Value,
                                       Endereco = items.Element("Enredeco").Value,
                                       Numero = Convert.ToInt32(items.Element("Numero").Value),
                                       Complemento = (items.Element("Complemento") == null ? "" : items.Element("Complemento").Value),
                                       Uf = items.Element("UF").Value,
                                       Cidade = items.Element("Cidade").Value,
                                       Telefone = items.Element("Telefone") == null ? "" : items.Element("Telefone").Value,
                                       Ramal = items.Element("Ramal") == null ? "" : items.Element("Ramal").Value,
                                       Email = items.Element("Email") == null ? "" : items.Element("Email").Value,
                                       Website = items.Element("WebSite") == null ? "" : items.Element("WebSite").Value,
                                       IsActive = Convert.ToBoolean(items.Element("IsActive").Value)

                                   };

    */
                        List<Supplier> listaProduto = produtos.ToList();
                        return listaProduto;
                    }
                }
            }
                


        }

        #endregion



    }
}
