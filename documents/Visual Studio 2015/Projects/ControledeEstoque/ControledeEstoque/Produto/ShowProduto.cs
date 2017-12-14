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
    public partial class ShowProduto : Form
    {
        int width, height;
        public static readonly string xmlPath = Classes.Path.pathXML.XmlPath;
        public static readonly string imagePath = Classes.Path.pathXML.ImagePath;
#pragma warning disable CS0169 // The field 'ShowProduto.fornecedor03' is never used
#pragma warning disable CS0169 // The field 'ShowProduto.fornecedor02' is never used
#pragma warning disable CS0169 // The field 'ShowProduto.fornecedor01' is never used
        XElement fornecedor01, fornecedor02, fornecedor03;
#pragma warning restore CS0169 // The field 'ShowProduto.fornecedor01' is never used
#pragma warning restore CS0169 // The field 'ShowProduto.fornecedor02' is never used
#pragma warning restore CS0169 // The field 'ShowProduto.fornecedor03' is never used
        BindingSource bs = new BindingSource();
        Classes.Produto p = new Classes.Produto();

        public ShowProduto()
        {
            InitializeComponent();           

        }
        public ShowProduto(Classes.Produto prod, string s1, string s2, string s3)
        {
            InitializeComponent();
            p = prod;
            txtCodNokia.Text = Convert.ToString(prod.CodNokia);
            txtCodPanalpina.Text = Convert.ToString(prod.CodPanalpina);
            txtDescricao.Text = prod.Descricao;
            txtProduto.Text = prod.Product;
            try
            {
                staticPicture.imagem.populaImagem(prod.PathImagem);

                pictureBox1.Image = staticPicture.imagem.ThumbImage;

                width = staticPicture.imagem.Width;
                height = staticPicture.imagem.Height;

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                MessageBox.Show(ex.ToString());
            }


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

        private void txtFornecedor1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFornecedor2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFornecedor3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void CadProduto_Load(object sender, EventArgs e)
        {
            using (var context = new ControleEstoqueEntities1())
            {
                long value = Convert.ToInt64(p.Key);


                var queryFornecedor = from p in context.ProdutoFornecedors
                                      join prod in context.Produtoes
                                      on 
                                      p.ProductID 
                                      equals
                                      prod.ProductID
                                      join f in context.Fornecedors
                                      on
                                      p.FornecedorID
                                      equals
                                      f.FornecedorID
                                      where p.ProductID == value
                                      select new 
                                      {
                                          ID = p.ID,
                                          Fornecedor = f.NomeFornecedor
                                      };
                
                dgvFornecedores.DataSource = queryFornecedor.ToList();
                for (int i = 0; i < dgvFornecedores.ColumnCount; i++)
                    dgvFornecedores.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
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
      
    }
}
