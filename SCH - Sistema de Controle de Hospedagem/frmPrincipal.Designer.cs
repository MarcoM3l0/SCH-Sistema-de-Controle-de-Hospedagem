
namespace SCH___Sistema_de_Controle_de_Hospedagem
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.menuPrincipal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.cadastroDeClienteToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(800, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // cadastroDeClienteToolStripMenuItem
            // 
            this.cadastroDeClienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.usuarioToolStripMenuItem,
            this.relatorioToolStripMenuItem});
            this.cadastroDeClienteToolStripMenuItem.Name = "cadastroDeClienteToolStripMenuItem";
            this.cadastroDeClienteToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.cadastroDeClienteToolStripMenuItem.Text = "Cadastro";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clienteToolStripMenuItem.Text = " Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuarioToolStripMenuItem.Text = "Usuário";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // relatorioToolStripMenuItem
            // 
            this.relatorioToolStripMenuItem.Name = "relatorioToolStripMenuItem";
            this.relatorioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.relatorioToolStripMenuItem.Text = "Relatório";
            this.relatorioToolStripMenuItem.Click += new System.EventHandler(this.relatorioToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(168)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Principal";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatorioToolStripMenuItem;
    }
}