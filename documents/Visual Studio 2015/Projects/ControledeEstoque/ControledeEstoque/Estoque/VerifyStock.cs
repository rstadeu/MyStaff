using ControledeEstoque.Classes;
using DocumentFormat.OpenXml.Packaging;
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
    public partial class VerifyStock : Form
    {
        public VerifyStock()
        {
            InitializeComponent();
            
        }

        private void VerifyStock_Load(object sender, EventArgs e)
        {
            TreeNode rootNode = new TreeNode("Panalpina");
            tvwStock.ImageList = imageList1;

            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 0;

            tvwStock.Nodes.Add(rootNode);

           List<stock> estoque = new List<stock>();
            stock temp = new stock();

            estoque = temp.getDataForTreeView();
            int i = 0;
            foreach(stock s in estoque)
            {
                long iD = s.StockId;
                tvwStock.Nodes[0].Nodes.Add(s.StockName);
                tvwStock.Nodes[0].Nodes[i].ImageIndex = 1;
                tvwStock.Nodes[0].Nodes[i].SelectedImageIndex = 1;
                List<alocacao> alocacoes = new List<alocacao>();

                alocacao alocacao = new alocacao();
                
                alocacoes = alocacao.getDataForTreeview(Convert.ToInt32(iD));
                int j = 0;

                foreach(alocacao a in alocacoes)
                {
                    tvwStock.Nodes[0].Nodes[i].Nodes.Add(a.AllocationName);
                    tvwStock.Nodes[0].Nodes[i].Nodes[j].ImageIndex = 2;
                    tvwStock.Nodes[0].Nodes[i].Nodes[j].SelectedImageIndex = 2;

                    j++;
                }

                i++;
            }

            

            
            Transferencia f = new Transferencia();
            f.populaGrid(dgvStock);
            this.Text = "Estoque -  \\" + tvwStock.Nodes[0].Text + "\\";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Files xlsx|*.xlsx";
            saveFileDialog1.Title = "Export to Excel";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = SpreadsheetDocument.Create(saveFileDialog1.FileName + ".xlsx", DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
                {
                    //DataView dt = (DataView)dgvFornecedores.DataSource;
                    var workbookPart = workbook.AddWorkbookPart();
                    workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                    workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);
                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipID = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    uint sheetID = 1;
                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetID = sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipID, SheetId = sheetID, Name = "Lista de Produtos em estoque" };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                    List<string> columns = new List<string>();


                    columns.Add("ID");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell0 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell0.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell0.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("ID");
                    headerRow.AppendChild(cell0);

                    columns.Add("Estoque");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell1 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell1.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell1.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Estoque");
                    headerRow.AppendChild(cell1);

                    columns.Add("Alocação");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell2 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell2.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell2.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Alocação");
                    headerRow.AppendChild(cell2);

                    columns.Add("Produto");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell3 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell3.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell3.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Produto");
                    headerRow.AppendChild(cell3);

                    columns.Add("Quantidade");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell4 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell4.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell4.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Quantidade");
                    headerRow.AppendChild(cell4);

                    
                    sheetData.AppendChild(headerRow);

                    List<Classes.Transferencia.ExcelData> estoque = new List<Transferencia.ExcelData>();

                    Classes.Produto.produtoParaExcel prod = new Classes.Produto.produtoParaExcel();
                    //prod.queryProduto
                    Transferencia t = new Transferencia();
                    estoque = t.getDataExcel();

                    foreach (Classes.Transferencia.ExcelData f in estoque)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell13 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell13.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell13.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.ID_Estoque.ToString());
                        newRow.AppendChild(cell13);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell14 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell14.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell14.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Estoque.ToString());
                        newRow.AppendChild(cell14);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell15 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell15.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell15.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Alocacao.ToString());
                        newRow.AppendChild(cell15);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell16 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell16.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell16.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Produto.ToString());
                        newRow.AppendChild(cell16);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell17 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell17.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell17.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Quantidade.ToString());
                        newRow.AppendChild(cell17);

                        sheetData.AppendChild(newRow);
                    }

                    MessageBox.Show("Dados Exportados com Sucesso");

                }
            }//copiar até aqui

            




        }

        private void tvwStock_Click(object sender, EventArgs e)
        {

        }

        private void tvwStock_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void tvwStock_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Transferencia f0 = new Transferencia();
            f0.populaGrid(dgvStock);
            this.Text = "Estoque -  \\" + tvwStock.SelectedNode.Text + "\\";
            if (tvwStock.SelectedNode.Level == 1)
            {
                Transferencia f = new Transferencia();
                f.populaGrid(dgvStock, tvwStock.SelectedNode.Text);
                //MessageBox.Show("level " + tvwStock.SelectedNode.Level.ToString() + " and Parent " + tvwStock.SelectedNode.Parent.Text + " and " + tvwStock.SelectedNode.Text + " Selected");
                this.Text = "Estoque -  \\" + tvwStock.Nodes[0].Text + "\\"+ tvwStock.SelectedNode.Text + "\\";
            }
            else if(tvwStock.SelectedNode.Level ==2)
            {
                Transferencia f = new Transferencia();
                f.populaGrid(dgvStock,tvwStock.SelectedNode.Parent.Text, tvwStock.SelectedNode.Text);
                this.Text = "Estoque -  \\" + tvwStock.Nodes[0].Text + "\\" + tvwStock.SelectedNode.Parent.Text + "\\" + tvwStock.SelectedNode.Text + "\\";
            }

            
        }



    }
}
