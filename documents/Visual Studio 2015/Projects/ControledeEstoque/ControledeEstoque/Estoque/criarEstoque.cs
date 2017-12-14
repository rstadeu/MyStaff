using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControledeEstoque.Estoque
{
    public partial class criarEstoque : Form
    {
        public criarEstoque()
        {
            InitializeComponent();
            Classes.stock estoque = new Classes.stock();
            estoque.populaGridView(dataGridView1, Classes.Path.pathXML.XmlPath);
        }

        private void criarEstoque_Load(object sender, EventArgs e)
        {

        }

        private void btnCriarEstoque_Click(object sender, EventArgs e)
        {
            Classes.stock estoque = new Classes.stock();

            estoque.StockName = textBox1.Text.ToUpper();

            estoque.addStock(Classes.Path.pathXML.XmlPath, estoque);

            estoque.populaGridView(dataGridView1, Classes.Path.pathXML.XmlPath);

            textBox1.Text = "";
            textBox1.Focus();
        }
    }
}
