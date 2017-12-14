using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ControledeEstoque.DataBase;

namespace ControledeEstoque.Estoque
{
    public partial class CriarAlocacao : Form
    {
        public CriarAlocacao()
        {
            InitializeComponent();

            using (var context = new ControleEstoqueEntities1())
            {
                var query = from item in context.Stocks
                            select new
                            {
                                StockId = item.StockID,
                                StockName = item.StockName
                            };

                cmbStock.DisplayMember = "StockName";
                cmbStock.ValueMember = "StockId";
                cmbStock.DataSource = query.ToArray();
            }

            Classes.alocacao alocacao = new Classes.alocacao();
            alocacao.populaGridView(grvStock, Classes.Path.pathXML.XmlPath, cmbStock);
        }

        private void CriarAlocacao_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Classes.alocacao alocacao = new Classes.alocacao();

            alocacao.StockId = Convert.ToInt32(cmbStock.SelectedValue);
            alocacao.AllocationName = txtAlocacao.Text.ToUpper();

            alocacao.addAllocation(Classes.Path.pathXML.XmlPath, alocacao);
            alocacao.populaGridView(grvStock, Classes.Path.pathXML.XmlPath, cmbStock);

            txtAlocacao.Text = "";
            txtAlocacao.Focus();
        }

        private void cmbStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            Classes.alocacao alocacao = new Classes.alocacao();
            alocacao.populaGridView(grvStock, Classes.Path.pathXML.XmlPath, cmbStock);
        }
    }
}
