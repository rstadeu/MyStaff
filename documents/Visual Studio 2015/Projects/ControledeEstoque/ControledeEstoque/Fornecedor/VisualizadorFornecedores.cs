using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Packaging;
using A = DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml;


namespace ControledeEstoque.Fornecedor
{
    public partial class VisualizadorFornecedores : Form
    {
        public VisualizadorFornecedores()
        {
            InitializeComponent();
        }

        private void VisualizadorFornecedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            //(this.Owner as Form1).changeFornecedorStatus(true);
            
        }

        private void VisualizadorFornecedores_Load(object sender, EventArgs e)
        {
            Classes.Supplier vendor = new Classes.Supplier();
            vendor.populaGridView(dgvFornecedores, Classes.Path.pathXML.XmlPath + @"\Fornecedor.xml", ckbAtivos.Checked);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Classes.Supplier vendor = new Classes.Supplier();
            vendor.populaGridView(dgvFornecedores, Classes.Path.pathXML.XmlPath + @"\Fornecedor.xml",ckbAtivos.Checked, textBox1.Text.ToUpper());
        }

        private void ckbAtivos_CheckedChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {               
                    Classes.Supplier vendor = new Classes.Supplier();
                    vendor.populaGridView(dgvFornecedores, Classes.Path.pathXML.XmlPath + @"\Fornecedor.xml",ckbAtivos.Checked ,textBox1.Text.ToUpper());
            }
            else
            {
                Classes.Supplier vendor = new Classes.Supplier();
                vendor.populaGridView(dgvFornecedores, Classes.Path.pathXML.XmlPath + @"\Fornecedor.xml", ckbAtivos.Checked);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // DataTable dt = (DataTable)(dgvFornecedores.DataSource);
            saveFileDialog1.Filter = "Excel Files|*.xlsx";
            saveFileDialog1.Title = "Export to Excel";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK )
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
                    if(sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
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

                    columns.Add("FORNECEDOR");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell1 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell1.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell1.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("FORNECEDOR");
                    headerRow.AppendChild(cell1);

                    columns.Add("CEP");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell2 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell2.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell2.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("CEP");
                    headerRow.AppendChild(cell2);

                    columns.Add("LOGRADOURO");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell3 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell3.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell3.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("LOGRADOURO");
                    headerRow.AppendChild(cell3);

                    columns.Add("NUMERO");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell4 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell4.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell4.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("NUMERO");
                    headerRow.AppendChild(cell4);

                    columns.Add("COMPLEMENTO");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell5 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell5.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell5.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("COMPLEMENTO");
                    headerRow.AppendChild(cell5);

                    columns.Add("ESTADO");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell6 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell6.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell6.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("ESTADO");
                    headerRow.AppendChild(cell6);

                    columns.Add("CIDADE");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell7 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell7.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell7.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("CIDADE");
                    headerRow.AppendChild(cell7);

                    columns.Add("TELEFONE");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell8 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell8.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell8.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("TELEFONE");
                    headerRow.AppendChild(cell8);

                    columns.Add("RAMAL");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell9 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell9.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell9.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("RAMAL");
                    headerRow.AppendChild(cell9);

                    columns.Add("EMAIL");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell10 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell10.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell10.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("EMAIL");
                    headerRow.AppendChild(cell10);

                    columns.Add("WEBSITE");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell11 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell11.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell11.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("WEBSITE");
                    headerRow.AppendChild(cell11);

                    columns.Add("ATIVO");
                    DocumentFormat.OpenXml.Spreadsheet.Cell cell12 = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell12.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell12.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("ATIVO");
                    headerRow.AppendChild(cell12);

                    sheetData.AppendChild(headerRow);

                    List<Classes.Supplier> produtos = new List<Classes.Supplier>();

                    Classes.Supplier prod = new Classes.Supplier();

                    produtos = prod.querySupplier(textBox1.Text, ckbAtivos.Checked, Classes.Path.pathXML.XmlPath + @"\Fornecedor.xml");

                    foreach(Classes.Supplier f in produtos)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell13 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell13.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell13.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Id.ToString());
                        newRow.AppendChild(cell13);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell14 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell14.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell14.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.SupplierName);
                        newRow.AppendChild(cell14);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell15 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell15.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell15.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Cep.ToString());
                        newRow.AppendChild(cell15);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell16 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell16.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell16.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Endereco.ToString());
                        newRow.AppendChild(cell16);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell17 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell17.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell17.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Numero.ToString());
                        newRow.AppendChild(cell17);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell18 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell18.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell18.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Complemento.ToString());
                        newRow.AppendChild(cell18);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell19 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell19.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell19.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Uf.ToString());
                        newRow.AppendChild(cell19);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell20 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell20.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell20.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Cidade.ToString());
                        newRow.AppendChild(cell20);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell21 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell21.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell21.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Telefone.ToString());
                        newRow.AppendChild(cell21);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell22 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell22.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell22.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Ramal.ToString());
                        newRow.AppendChild(cell22);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell23 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell23.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell23.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Email.ToString().ToLower());
                        newRow.AppendChild(cell23);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell24 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell24.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell24.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.Website.ToString().ToLower());
                        newRow.AppendChild(cell24);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell25 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell25.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell25.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(f.IsActive.ToString());
                        newRow.AppendChild(cell25);

                        sheetData.AppendChild(newRow);
                    }

                    MessageBox.Show("Dados Exportados com Sucesso");

                }
            }


        }





    }
}
