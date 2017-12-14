namespace ControledeEstoque
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bancoDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subTipoMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarFornecedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarFornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarKitDeInstalaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarAlocaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradaDeProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baixaDeProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferirMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.unidadeDeMedidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.produtoToolStripMenuItem,
            this.fornecedorToolStripMenuItem,
            this.kitToolStripMenuItem,
            this.estoqueToolStripMenuItem,
            this.pedidosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(743, 56);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bancoDeDadosToolStripMenuItem});
            this.arquivoToolStripMenuItem.Image = global::ControledeEstoque.Properties.Resources.Computer;
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(109, 52);
            this.arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // bancoDeDadosToolStripMenuItem
            // 
            this.bancoDeDadosToolStripMenuItem.Image = global::ControledeEstoque.Properties.Resources.iDatabase;
            this.bancoDeDadosToolStripMenuItem.Name = "bancoDeDadosToolStripMenuItem";
            this.bancoDeDadosToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.bancoDeDadosToolStripMenuItem.Text = "&Banco de Dados";
            this.bancoDeDadosToolStripMenuItem.Click += new System.EventHandler(this.bancoDeDadosToolStripMenuItem_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroProdutoToolStripMenuItem,
            this.listaDeProdutosToolStripMenuItem,
            this.alterarProdutoToolStripMenuItem,
            this.removerProdutoToolStripMenuItem,
            this.adicionarToolStripMenuItem});
            this.produtoToolStripMenuItem.Image = global::ControledeEstoque.Properties.Resources.box_icon;
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(110, 52);
            this.produtoToolStripMenuItem.Text = "&Produto";
            // 
            // cadastroProdutoToolStripMenuItem
            // 
            this.cadastroProdutoToolStripMenuItem.Name = "cadastroProdutoToolStripMenuItem";
            this.cadastroProdutoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.cadastroProdutoToolStripMenuItem.Text = "&Cadastro Produto";
            this.cadastroProdutoToolStripMenuItem.Click += new System.EventHandler(this.cadastroProdutoToolStripMenuItem_Click);
            // 
            // listaDeProdutosToolStripMenuItem
            // 
            this.listaDeProdutosToolStripMenuItem.Name = "listaDeProdutosToolStripMenuItem";
            this.listaDeProdutosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.listaDeProdutosToolStripMenuItem.Text = "Lista de Produtos";
            this.listaDeProdutosToolStripMenuItem.Click += new System.EventHandler(this.listaDeProdutosToolStripMenuItem_Click);
            // 
            // alterarProdutoToolStripMenuItem
            // 
            this.alterarProdutoToolStripMenuItem.Name = "alterarProdutoToolStripMenuItem";
            this.alterarProdutoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.alterarProdutoToolStripMenuItem.Text = "Alterar Produto";
            // 
            // removerProdutoToolStripMenuItem
            // 
            this.removerProdutoToolStripMenuItem.Name = "removerProdutoToolStripMenuItem";
            this.removerProdutoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.removerProdutoToolStripMenuItem.Text = "Remover Produto";
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoMaterialToolStripMenuItem,
            this.subTipoMaterialToolStripMenuItem,
            this.unidadeDeMedidaToolStripMenuItem});
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.adicionarToolStripMenuItem.Text = "Adicionar";
            // 
            // tipoMaterialToolStripMenuItem
            // 
            this.tipoMaterialToolStripMenuItem.Name = "tipoMaterialToolStripMenuItem";
            this.tipoMaterialToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.tipoMaterialToolStripMenuItem.Text = "Tipo Material";
            this.tipoMaterialToolStripMenuItem.Click += new System.EventHandler(this.tipoMaterialToolStripMenuItem_Click);
            // 
            // subTipoMaterialToolStripMenuItem
            // 
            this.subTipoMaterialToolStripMenuItem.Name = "subTipoMaterialToolStripMenuItem";
            this.subTipoMaterialToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.subTipoMaterialToolStripMenuItem.Text = "SubTipo Material";
            this.subTipoMaterialToolStripMenuItem.Click += new System.EventHandler(this.subTipoMaterialToolStripMenuItem_Click);
            // 
            // fornecedorToolStripMenuItem
            // 
            this.fornecedorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarFornecedorToolStripMenuItem,
            this.visualizarFornecedoresToolStripMenuItem});
            this.fornecedorToolStripMenuItem.Image = global::ControledeEstoque.Properties.Resources.Truck;
            this.fornecedorToolStripMenuItem.Name = "fornecedorToolStripMenuItem";
            this.fornecedorToolStripMenuItem.Size = new System.Drawing.Size(127, 52);
            this.fornecedorToolStripMenuItem.Text = "&Fornecedor";
            this.fornecedorToolStripMenuItem.Click += new System.EventHandler(this.fornecedorToolStripMenuItem_Click);
            // 
            // cadastrarFornecedorToolStripMenuItem
            // 
            this.cadastrarFornecedorToolStripMenuItem.Name = "cadastrarFornecedorToolStripMenuItem";
            this.cadastrarFornecedorToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.cadastrarFornecedorToolStripMenuItem.Text = "Cadastrar Fornecedor";
            this.cadastrarFornecedorToolStripMenuItem.Click += new System.EventHandler(this.cadastrarFornecedorToolStripMenuItem_Click);
            // 
            // visualizarFornecedoresToolStripMenuItem
            // 
            this.visualizarFornecedoresToolStripMenuItem.Name = "visualizarFornecedoresToolStripMenuItem";
            this.visualizarFornecedoresToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.visualizarFornecedoresToolStripMenuItem.Text = "Visualizar Fornecedores";
            this.visualizarFornecedoresToolStripMenuItem.Click += new System.EventHandler(this.visualizarFornecedoresToolStripMenuItem_Click);
            // 
            // kitToolStripMenuItem
            // 
            this.kitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarKitDeInstalaçãoToolStripMenuItem});
            this.kitToolStripMenuItem.Image = global::ControledeEstoque.Properties.Resources.applet_48;
            this.kitToolStripMenuItem.Name = "kitToolStripMenuItem";
            this.kitToolStripMenuItem.Size = new System.Drawing.Size(81, 52);
            this.kitToolStripMenuItem.Text = "&Kit";
            // 
            // cadastrarKitDeInstalaçãoToolStripMenuItem
            // 
            this.cadastrarKitDeInstalaçãoToolStripMenuItem.Name = "cadastrarKitDeInstalaçãoToolStripMenuItem";
            this.cadastrarKitDeInstalaçãoToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.cadastrarKitDeInstalaçãoToolStripMenuItem.Text = "Cadastrar Kit de instalação";
            this.cadastrarKitDeInstalaçãoToolStripMenuItem.Click += new System.EventHandler(this.cadastrarKitDeInstalaçãoToolStripMenuItem_Click);
            // 
            // estoqueToolStripMenuItem
            // 
            this.estoqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verEstoqueToolStripMenuItem,
            this.criarEstoqueToolStripMenuItem,
            this.criarAlocaçãoToolStripMenuItem,
            this.entradaDeProdutoToolStripMenuItem,
            this.baixaDeProdutoToolStripMenuItem,
            this.transferirMaterialToolStripMenuItem});
            this.estoqueToolStripMenuItem.Image = global::ControledeEstoque.Properties.Resources.forklift;
            this.estoqueToolStripMenuItem.Name = "estoqueToolStripMenuItem";
            this.estoqueToolStripMenuItem.Size = new System.Drawing.Size(109, 52);
            this.estoqueToolStripMenuItem.Text = "&Estoque";
            // 
            // verEstoqueToolStripMenuItem
            // 
            this.verEstoqueToolStripMenuItem.Name = "verEstoqueToolStripMenuItem";
            this.verEstoqueToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.verEstoqueToolStripMenuItem.Text = "Ver Estoque";
            this.verEstoqueToolStripMenuItem.Click += new System.EventHandler(this.verEstoqueToolStripMenuItem_Click);
            // 
            // criarEstoqueToolStripMenuItem
            // 
            this.criarEstoqueToolStripMenuItem.Name = "criarEstoqueToolStripMenuItem";
            this.criarEstoqueToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.criarEstoqueToolStripMenuItem.Text = "Criar Estoque";
            this.criarEstoqueToolStripMenuItem.Click += new System.EventHandler(this.criarEstoqueToolStripMenuItem_Click);
            // 
            // criarAlocaçãoToolStripMenuItem
            // 
            this.criarAlocaçãoToolStripMenuItem.Name = "criarAlocaçãoToolStripMenuItem";
            this.criarAlocaçãoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.criarAlocaçãoToolStripMenuItem.Text = "Criar Alocação";
            this.criarAlocaçãoToolStripMenuItem.Click += new System.EventHandler(this.criarAlocaçãoToolStripMenuItem_Click);
            // 
            // entradaDeProdutoToolStripMenuItem
            // 
            this.entradaDeProdutoToolStripMenuItem.Name = "entradaDeProdutoToolStripMenuItem";
            this.entradaDeProdutoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.entradaDeProdutoToolStripMenuItem.Text = "Entrada de Produto";
            this.entradaDeProdutoToolStripMenuItem.Click += new System.EventHandler(this.entradaDeProdutoToolStripMenuItem_Click);
            // 
            // baixaDeProdutoToolStripMenuItem
            // 
            this.baixaDeProdutoToolStripMenuItem.Name = "baixaDeProdutoToolStripMenuItem";
            this.baixaDeProdutoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.baixaDeProdutoToolStripMenuItem.Text = "Baixa de Produto";
            this.baixaDeProdutoToolStripMenuItem.Click += new System.EventHandler(this.baixaDeProdutoToolStripMenuItem_Click);
            // 
            // transferirMaterialToolStripMenuItem
            // 
            this.transferirMaterialToolStripMenuItem.Name = "transferirMaterialToolStripMenuItem";
            this.transferirMaterialToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.transferirMaterialToolStripMenuItem.Text = "Transferir &Material";
            this.transferirMaterialToolStripMenuItem.Click += new System.EventHandler(this.transferirMaterialToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.criarPedidoToolStripMenuItem,
            this.alterarPedidoToolStripMenuItem,
            this.removerPedidoToolStripMenuItem});
            this.pedidosToolStripMenuItem.Image = global::ControledeEstoque.Properties.Resources.purchase_order;
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(109, 52);
            this.pedidosToolStripMenuItem.Text = "P&edidos";
            // 
            // criarPedidoToolStripMenuItem
            // 
            this.criarPedidoToolStripMenuItem.Name = "criarPedidoToolStripMenuItem";
            this.criarPedidoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.criarPedidoToolStripMenuItem.Text = "Criar Pedido";
            this.criarPedidoToolStripMenuItem.Click += new System.EventHandler(this.criarPedidoToolStripMenuItem_Click);
            // 
            // alterarPedidoToolStripMenuItem
            // 
            this.alterarPedidoToolStripMenuItem.Name = "alterarPedidoToolStripMenuItem";
            this.alterarPedidoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.alterarPedidoToolStripMenuItem.Text = "Alterar Pedido";
            // 
            // removerPedidoToolStripMenuItem
            // 
            this.removerPedidoToolStripMenuItem.Name = "removerPedidoToolStripMenuItem";
            this.removerPedidoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.removerPedidoToolStripMenuItem.Text = "Remover Pedido";
            // 
            // fbdPath
            // 
            this.fbdPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // unidadeDeMedidaToolStripMenuItem
            // 
            this.unidadeDeMedidaToolStripMenuItem.Name = "unidadeDeMedidaToolStripMenuItem";
            this.unidadeDeMedidaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.unidadeDeMedidaToolStripMenuItem.Text = "Unidade de Medida";
            this.unidadeDeMedidaToolStripMenuItem.Click += new System.EventHandler(this.unidadeDeMedidaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::ControledeEstoque.Properties.Resources.panalpina;
            this.ClientSize = new System.Drawing.Size(743, 531);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Controle de Estoque";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarFornecedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarKitDeInstalaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarFornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bancoDeDadosToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
        private System.Windows.Forms.ToolStripMenuItem listaDeProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarAlocaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradaDeProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baixaDeProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferirMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subTipoMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadeDeMedidaToolStripMenuItem;
    }
}

