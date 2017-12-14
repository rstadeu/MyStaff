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
using System.Xml;
using System.Xml.Linq;
using DotCEP;
using DotCEP.Localidades;
using ControledeEstoque.Classes;

namespace ControledeEstoque.Fornecedor
{
   
    public partial class addSupplier : Form
    {
        public static readonly string xmlPath = Classes.Path.pathXML.XmlPath;
        public static readonly string imagePath = Classes.Path.pathXML.ImagePath;
        
        
        public addSupplier()
        {
            InitializeComponent();
            txtEndereco.Enabled = false;
            txtEstado.Enabled = false;
            txtCidade.Enabled = false;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void addSupplier_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Endereco endereco = new Endereco();

                endereco = Consultas.ObterEnderecoCompleto(txtCep.Text);

                if (endereco.logradouro == "" || endereco.logradouro == null)
                {
                    txtEndereco.Enabled = true;
                }else
                {
                    txtEndereco.Enabled = false;
                }
                txtEndereco.Text = endereco.logradouro;
                txtCidade.Text = endereco.localidade;
                txtEstado.Text = endereco.uf;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                MessageBox.Show("Verificar o CEP ou se há conexão de internet.");
            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (txtEmail.Text != "" && !(IsValidEmail(txtEmail.Text)))
            {
                MessageBox.Show("Entre um endereço de email valido!");
                txtEmail.Text = "";
                txtEmail.Focus();
            }

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Classes.Fornecedor.supplier.SupplierName = txtFornecedor.Text.ToUpper();
            Classes.Fornecedor.supplier.Cep = txtCep.Text.ToUpper();
            Classes.Fornecedor.supplier.Endereco = txtEndereco.Text.ToUpper();
            Classes.Fornecedor.supplier.Numero = Convert.ToInt32(txtNumero.Text.ToUpper());
            Classes.Fornecedor.supplier.Complemento = txtComplemento.Text.ToUpper();
            Classes.Fornecedor.supplier.Uf = txtEstado.Text.ToUpper();
            Classes.Fornecedor.supplier.Cidade = txtCidade.Text.ToUpper();
            Classes.Fornecedor.supplier.Telefone = maskedTextBox1.Text.ToUpper();
            Classes.Fornecedor.supplier.Ramal = maskedTextBox2.Text.ToUpper();
            Classes.Fornecedor.supplier.Email = txtEmail.Text.ToLower();
            Classes.Fornecedor.supplier.Website = txtWebSite.Text.ToLower();


          int retorno =    Classes.Fornecedor.supplier.addSupplier(xmlPath, Classes.Fornecedor.supplier);

            if(retorno == 1)
            {
                if(MessageBox.Show("Dados salvos com Sucesso!")== DialogResult.OK)
                {
                    txtFornecedor.Text = "";
                    txtCep.Text = "";
                    txtEndereco.Text = "";
                    txtNumero.Text = "";
                    txtComplemento.Text = "";
                    txtEstado.Text = "";
                    txtCidade.Text = "";
                    maskedTextBox1.Text = "";
                    maskedTextBox2.Text = "";
                    txtEmail.Text = "";
                    txtWebSite.Text = "";            

                    

                }
            }

        }
    }
}
