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

namespace ControledeEstoque.Produto
{
    public partial class FotoProduto : Form
    {
        public FotoProduto()
        {
            InitializeComponent();

            pictureBox1.Height = staticPicture.imagem.Height;
            pictureBox1.Width = staticPicture.imagem.Width;
            pictureBox1.Image = staticPicture.imagem.Picture;
        }

        private void FotoProduto_Load(object sender, EventArgs e)
        {

        }
    }
}
