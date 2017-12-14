using ControledeEstoque.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControledeEstoque
{
    public partial class BancoDeDados : Form
    {
        public BancoDeDados()
        {
            InitializeComponent();
        }

        private void BancoDeDados_Load(object sender, EventArgs e)
        {
            string conexao = System.Configuration.ConfigurationManager.ConnectionStrings["ControleEstoqueEntities1"].ConnectionString;
            string[] words = conexao.Split(';');

           // foreach (string word in words)
               // MessageBox.Show(word);
            int count = words[2].Length - 1;
            int begin = words[2].Length - 47;
            txtBancoDeDados.Text = words[2].Substring(40, ((words[2].Length-1)-40));
            txtBancoDeDados.Enabled = true;
            btnMudarBanco.Focus();
        }

        private void btnMudarBanco_Click(object sender, EventArgs e)
        {
            if(fbdDataBase.ShowDialog() == DialogResult.OK)
            {
                Classes.Path.pathXML.Path = fbdDataBase.SelectedPath;
                Classes.Path.pathXML.XmlPath = Classes.Path.pathXML.Path + @"\XMLData";
                Classes.Path.pathXML.ImagePath = Classes.Path.pathXML.Path + @"\XMLData\Image";
                bool xmlFolder = Directory.Exists(Classes.Path.pathXML.XmlPath);
                bool imageFolder = Directory.Exists(Classes.Path.pathXML.ImagePath);
                if (!xmlFolder)
                    Directory.CreateDirectory(Classes.Path.pathXML.XmlPath);

                if (!imageFolder)
                    Directory.CreateDirectory(Classes.Path.pathXML.ImagePath);
                Product.prod.createXMLProductFile(Classes.Path.pathXML.XmlPath);
                Classes.Fornecedor.supplier.createXMLSupplierFile(Classes.Path.pathXML.XmlPath);

                txtBancoDeDados.Text = Classes.Path.pathXML.Path;

                Classes.Path.pathXML.update();
            }
        }
    }
}
