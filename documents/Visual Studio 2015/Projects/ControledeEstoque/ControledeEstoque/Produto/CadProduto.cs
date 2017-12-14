using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControledeEstoque.Classes;
using System.Drawing.Drawing2D;
using System.IO;
using ControledeEstoque.DataBase;
using System.Xml.Linq;

namespace ControledeEstoque.Produto
{
    public partial class CadProduto : Form
    {
        int width, height;
        Classes.Produto produto = new Classes.Produto();
        public static readonly string xmlPath = Classes.Path.pathXML.XmlPath;
        public static readonly string imagePath = Classes.Path.pathXML.ImagePath;
        BindingSource bs = new BindingSource();
        Classes.addType materialType = new addType();
        Classes.subType materialSubType = new subType();
        Classes.MeasureUnit unidadeMedida = new Classes.MeasureUnit();
        List<productToShow> supplier = new List<productToShow>();

        public CadProduto()
        {
            InitializeComponent();

            Classes.Supplier s = new Supplier();

            s.populaComboBox(cmbFornecedor);

            materialType.populaComboBox(cmbMaterialType);

            unidadeMedida.populaComboBox(cmbMeasurerUnit);

           

        }
        public CadProduto(Classes.Produto prod, string s1, string s2, string s3)
        {
            InitializeComponent();

            txtCodNokia.Text = Convert.ToString(prod.CodNokia);
            /*
            txtCodPanalpina.Text = Convert.ToString(prod.CodPanalpina);
            cmbFornecedor1.Text = s1;
            cmbFornecedor2.Text = s2;
            cmbFornecedor3.Text = s3;
            txtDescricao.Text = prod.Descricao;
            txtProduto.Text = prod.Product;
            */
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void abrirImagemTamanhoRealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FotoProduto foto = new FotoProduto();

            foto.Width = width;
            foto.Height = height;

            foto.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(staticPicture.imagem.Path == null)
            {
                abrirImagemTamanhoRealToolStripMenuItem.Enabled = false;
            }
            else
            {
                abrirImagemTamanhoRealToolStripMenuItem.Enabled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Classes.Produto p = new Classes.Produto();


            string[] words = openFileDialog1.SafeFileName.Split('.');
                p.CodNokia = txtCodNokia.Text;
                p.CodPanalpina = txtCodPanalpina.Text;
                p.Product = txtProduto.Text.ToUpper();
                p.MaterialTypeID = Convert.ToInt32(cmbMaterialType.SelectedValue);
                p.MaterialSubTypeID = Convert.ToInt32(cmbSubType.SelectedValue);
                p.UnitID = Convert.ToInt32(cmbSubType.SelectedValue);
               // Product.prod.EstoqueMinimo = isConvertable;
                p.Descricao = txtDescricao.Text.ToUpper();
                p.PathImagem = imagePath + "\\ImageFile_Product_" + txtProduto.Text.ToUpper() + "." + words[1];

            
            p.addProduto(p);

            long id = p.getID();

            foreach(productToShow pts in supplier)
            {
                using (var context = new ControleEstoqueEntities1())
                {
                    var vendorByProduct = new DataBase.ProdutoFornecedor
                    {
                        ProductID = id,
                        FornecedorID = pts.Id
                    };

                    context.ProdutoFornecedors.Add(vendorByProduct);
                    context.SaveChanges();

                }
            }

            int result = Product.prod.addProduct(xmlPath, Product.prod);
            File.Copy(staticPicture.imagem.Path, p.PathImagem);

            txtCodNokia.Text = "";
            txtCodPanalpina.Text = "";
            txtDescricao.Text = "";
            txtProduto.Text = "";
            cmbFornecedor.Text = "";
            cmbMaterialType.Text = "";
            cmbSubType.Text = "";
            txtCodNokia.Focus();
            pictureBox1.Image = null;
            cmbMeasurerUnit.Text = "";
            dgvFornecedores.DataSource = null;
            bs.DataSource = null;
            supplier.Clear();

            /*

                List<vendorByProduct> suppliers = new List<vendorByProduct>();
            vendorByProduct v = new vendorByProduct();

            suppliers = v.selectData();

            foreach(vendorByProduct vi in suppliers)
            {
                vi.addItem(vi);
            }


                int result = Product.prod.addProduct(xmlPath, Product.prod);
                File.Copy(staticPicture.imagem.Path, Product.prod.PathImagem);

                if (MessageBox.Show("Dados salvo com Sucesso!") == DialogResult.OK)
                {
                    pictureBox1.Image = null;
                    txtCodNokia.Text = "";
                    txtCodPanalpina.Text = "";
                    txtProduto.Text = "";
                    txtDescricao.Text = "";
                    txtCodNokia.Focus();
                }
          */


        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            XElement fornecedor = XElement.Load(Classes.Path.pathXML.XmlPath + @"\Fornecedor.xml");

            using (var context = new ControleEstoqueEntities1())
            {
                long value = Convert.ToInt64(cmbFornecedor.SelectedValue);


                var queryFornecedor = from p in context.Fornecedors
                                      where p.FornecedorID == value
                                      select new productToShow
                                      {
                                          Id = (int)p.FornecedorID,
                                          Fornecedor = p.NomeFornecedor
                                      };
                productToShow vendor = queryFornecedor.First();
                bs.DataSource = typeof(productToShow);
                bs.Add(vendor);
                supplier.Add(vendor);
                dgvFornecedores.DataSource = bs;
                for (int i = 0; i < dgvFornecedores.ColumnCount; i++)
                    dgvFornecedores.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }


        }

        private void CadProduto_Load(object sender, EventArgs e)
        {

        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Arquivos JPG|*.jpg|Arquivos JPEG|*.jpeg|Arquivos PNG |*.png|Arquivos GIF|*.gif";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        staticPicture.imagem.populaImagem(openFileDialog1.FileName);

                        pictureBox1.Image = staticPicture.imagem.ThumbImage;

                        width = staticPicture.imagem.Width;
                        height = staticPicture.imagem.Height;

                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                }
            }

        private void carregarImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Arquivos JPG|*.jpg|Arquivos JPEG|*.jpeg|Arquivos PNG |*.png|Arquivos GIF|*.gif";
            
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    staticPicture.imagem.populaImagem(openFileDialog1.FileName);

                    pictureBox1.Image = staticPicture.imagem.ThumbImage;

                    width = staticPicture.imagem.Width;
                    height = staticPicture.imagem.Height;

                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
            }
        }

        private void cmbMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            materialSubType.populaComboBox(cmbSubType, Convert.ToInt32(cmbMaterialType.SelectedValue));
        }

        public class productToShow
        {
            private long id;
            private string fornecedor;

            public long Id
            {
                get
                {
                    return id;
                }

                set
                {
                    id = value;
                }
            }

            public string Fornecedor
            {
                get
                {
                    return fornecedor;
                }

                set
                {
                    fornecedor = value;
                }
            }
        }
      
    }
}
