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
using System.Xml.Linq;
using ControledeEstoque.DataBase;

namespace ControledeEstoque.Produto
{
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();

            Classes.Product.prod.populaGridView(grvProdutos, Classes.Path.pathXML.Path + "\\XMLData\\Produto.xml", Classes.Path.pathXML.Path + "\\XMLData\\Fornecedor.xml");


        }

        private void ProductList_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                Classes.Product.prod.populaGridView(grvProdutos, Classes.Path.pathXML.Path + "\\XMLData\\Produto.xml", Classes.Path.pathXML.Path + "\\XMLData\\Fornecedor.xml", textBox1.Text.ToUpper());
            }
            else
            {
                Classes.Product.prod.populaGridView(grvProdutos, Classes.Path.pathXML.Path + "\\XMLData\\Produto.xml", Classes.Path.pathXML.Path + "\\XMLData\\Fornecedor.xml");
            }
            
            //textBox1.Text = textBox1.Text.ToUpper();
        }

        private void grvProdutos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            XElement product = XElement.Load(Path.pathXML.XmlPath + @"\Produto.xml");
            
            string fornecedor1 = "", fornecedor2 = "", fornecedor3 = "";
            foreach (DataGridViewRow row in grvProdutos.SelectedRows)
            {
                Classes.Product.prod.Key = Convert.ToInt32(row.Cells[0].Value.ToString());
                Classes.Product.prod.CodNokia = (row.Cells[1].Value.ToString());
                Classes.Product.prod.CodPanalpina = (row.Cells[2].Value.ToString());
                Classes.Product.prod.Product = row.Cells[3].Value.ToString();
                Classes.Product.prod.Descricao = row.Cells[4].Value.ToString();

            }
            using (var context = new ControleEstoqueEntities1())
            {
                var query = from p in context.Produtoes
                            where p.ProductID == Classes.Product.prod.Key
                            select new Classes.Produto
                            {
                                Key = (p.ProductID),
                                CodPanalpina = (p.PanalpinaCod),
                                CodNokia = (p.CustomerCod),
                                Product = p.Product,
                                Descricao = p.Comments,
                                PathImagem = p.ImagePath
                            };
                Classes.Produto pr = query.First();
                ShowProduto produto = new ShowProduto(pr, fornecedor1, fornecedor2, fornecedor3);
                produto.MdiParent = this.MdiParent;
                produto.Show();
            }
        }

        private void grvProdutos_SelectionChanged(object sender, EventArgs e)
        {
            /*
            string fornecedor1="", fornecedor2="", fornecedor3="";
            foreach( DataGridViewRow row in grvProdutos.SelectedRows)
            {
                Classes.Product.prod.Key = Convert.ToInt32(row.Cells[0].Value.ToString());
                Classes.Product.prod.CodNokia = Convert.ToInt32(row.Cells[1].Value.ToString());
                Classes.Product.prod.CodPanalpina = Convert.ToInt32(row.Cells[2].Value.ToString());
                Classes.Product.prod.Product = row.Cells[3].Value.ToString();
                Classes.Product.prod.Descricao = row.Cells[4].Value.ToString();
                fornecedor1 = row.Cells[5].Value.ToString();
                fornecedor2 = row.Cells[6].Value.ToString();
                fornecedor3 = row.Cells[7].Value.ToString();

            }

            CadProduto produto = new CadProduto(Classes.Product.prod, fornecedor1, fornecedor2, fornecedor3);
            produto.Show();
            */

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
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

                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipID, SheetId = sheetID, Name = "Lista de Fornecedores" };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                    List<string> columns = new List<string>();


                    columns.Add("ID");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell0 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell0.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell0.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("ID");
                    headerRow.AppendChild(cell0);

                    columns.Add("Código Cliente");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell1 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell1.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell1.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Código Cliente");
                    headerRow.AppendChild(cell1);

                    columns.Add("Código Panalpina");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell2 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell2.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell2.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Código Panalpina");
                    headerRow.AppendChild(cell2);

                    columns.Add("Produto");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell3 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell3.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell3.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Produto");
                    headerRow.AppendChild(cell3);

                    columns.Add("Descrição");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell4 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell4.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell4.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Descrição");
                    headerRow.AppendChild(cell4);

                    columns.Add("Fornecedor 1");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell5 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell5.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell5.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Fornecedor 1");
                    headerRow.AppendChild(cell5);

                    columns.Add("Fornecedor 2");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell6 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell6.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell6.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Fornecedor 2");
                    headerRow.AppendChild(cell6);

                    columns.Add("Fornecedor 3");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell7 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell7.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell7.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("Fornecedor 3");
                    headerRow.AppendChild(cell7);
                    sheetData.AppendChild(headerRow);

                    List<Classes.Produto.produtoParaExcel> produtos = new List<Classes.Produto.produtoParaExcel>();
                    
                    Classes.Produto.produtoParaExcel prod = new Classes.Produto.produtoParaExcel();
                    //prod.queryProduto
                    produtos = prod.queryProduto(textBox1.Text, Classes.Path.pathXML.XmlPath + @"\Produto.xml", Classes.Path.pathXML.XmlPath + @"\Fornecedor.xml");

                    foreach (Classes.Produto.produtoParaExcel f in produtos)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell13 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell13.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell13.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.ProdutoID.ToString());
                        newRow.AppendChild(cell13);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell14 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell14.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell14.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.CodigoCliente.ToString());
                        newRow.AppendChild(cell14);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell15 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell15.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell15.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.CodigoPanalpina.ToString());
                        newRow.AppendChild(cell15);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell16 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell16.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell16.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Produto.ToString());
                        newRow.AppendChild(cell16);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell17 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell17.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell17.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Descricao.ToString());
                        newRow.AppendChild(cell17);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell18 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell18.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell18.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Fornecedor_1.ToString());
                        newRow.AppendChild(cell18);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell19 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell19.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell19.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Fornecedor_2.ToString());
                        newRow.AppendChild(cell19);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell20 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell20.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell20.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Fornecedor_3.ToString());
                        newRow.AppendChild(cell20);
                        
                        sheetData.AppendChild(newRow);
                    }

                    MessageBox.Show("Dados Exportados com Sucesso");

                }
            }//copiar até aqui

        }
    }
}
