using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControledeEstoque.Produto;
using ControledeEstoque.Classes;
using ControledeEstoque.Fornecedor;
using ControledeEstoque.Estoque;
using ControledeEstoque.Pedido;
using ControledeEstoque.Kits;
using System.IO;

namespace ControledeEstoque
{
    public partial class Form1 : Form
    {
        ToolStripMenuItem tempMenuItemFornecedor = new ToolStripMenuItem();
        public Form1()
        {
            

            InitializeComponent();
            Classes.Path.pathXML = new caminho();
            staticPicture.imagem = new imagemProduto();
            Classes.Path.pathXML.createXMLPathFile();
            bool caminho = Classes.Path.pathXML.verifyData();
            if (!caminho)
            {
                while (Classes.Path.pathXML.Path == null)
                {
                    if (fbdPath.ShowDialog() == DialogResult.OK)
                        Classes.Path.pathXML.definePath(fbdPath.SelectedPath);

                }
                Classes.Path.pathXML.XmlPath = Classes.Path.pathXML.Path + @"\XMLData";
                Classes.Path.pathXML.ImagePath = Classes.Path.pathXML.Path + @"\XMLData\Image";
                bool xmlFolder = Directory.Exists(Classes.Path.pathXML.XmlPath);
                bool imageFolder = Directory.Exists(Classes.Path.pathXML.ImagePath);
                if (!xmlFolder)
                    Directory.CreateDirectory(Classes.Path.pathXML.XmlPath);

                if (!imageFolder)
                    Directory.CreateDirectory(Classes.Path.pathXML.ImagePath);
                Classes.Path.pathXML.addPath(Classes.Path.pathXML);
            }

            Product.prod = new Classes.Produto();

            Product.prod.createXMLProductFile(Classes.Path.pathXML.XmlPath);
            Classes.Fornecedor.supplier = new Supplier();
            Classes.Fornecedor.supplier.createXMLSupplierFile(Classes.Path.pathXML.XmlPath);
            stock estoque = new stock();
            estoque.createXMLProductFile(Classes.Path.pathXML.XmlPath);

            alocacao alocacao = new alocacao();
            alocacao.createXMLAllocationFile(Classes.Path.pathXML.XmlPath);

            Classes.Estoque stock = new Classes.Estoque();
            stock.createXMLEstoqueFile(Classes.Path.pathXML.XmlPath);
            


        }

        public void changeFornecedorStatus(Boolean status)
        {
           
            visualizarFornecedoresToolStripMenuItem.Enabled = status;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void cadastroProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadProduto _cadProduto = new CadProduto();
            _cadProduto.MdiParent = this;
            _cadProduto.Show();
        }

        private void cadastrarFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSupplier supplier = new addSupplier();
            supplier.MdiParent = this;
            supplier.Show();
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BancoDeDados database = new BancoDeDados();
            database.MdiParent = this;
            database.Show();
        }

        private void listaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList listaProduto = new ProductList();
            listaProduto.MdiParent = this;
            listaProduto.Show();
        }

        private void criarEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            criarEstoque estoque = new criarEstoque();
            estoque.MdiParent = this;
            estoque.Show();
        }

        private void criarAlocaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriarAlocacao alocacao = new CriarAlocacao();
            alocacao.MdiParent = this;
            alocacao.Show();

        }

        private void entradaDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntradaProduto entrada = new EntradaProduto();
            entrada.MdiParent = this;
            entrada.Show();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void criarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPedidos order = new FrmPedidos();
            order.MdiParent = this;
            order.Show();
            
        }

        private void verEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyStock stock = new VerifyStock();
            stock.MdiParent = this;
            stock.Show();
        }

        private void visualizarFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizadorFornecedores view = new VisualizadorFornecedores();
            view.MdiParent = this;
            view.Show();
            //changeFornecedorStatus(false);
        }

        private void cadastrarKitDeInstalaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddKits kits = new AddKits();
            kits.MdiParent = this;
            kits.Show();
        }

        private void transferirMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transferencias t = new Transferencias();
            t.MdiParent = this;
            t.Show();

        }

        private void baixaDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaixaEstoque b = new BaixaEstoque();
            b.MdiParent = this;
            b.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Timer Executado");
        }

        private void tipoMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddType t = new AddType();
            t.MdiParent = this;
            t.Show();
        }

        private void subTipoMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSubType a = new AddSubType();
            a.MdiParent = this;
            a.Show();
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUnitMeasure u = new addUnitMeasure();
            u.MdiParent = this;
            u.Show();
        }
    }
}
