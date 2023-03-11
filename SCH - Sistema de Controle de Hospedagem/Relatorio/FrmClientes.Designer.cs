
namespace SCH___Sistema_de_Controle_de_Hospedagem.Relatorio
{
    partial class FrmClientes
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bd_forpro_hotelDataSet = new SCH___Sistema_de_Controle_de_Hospedagem.bd_forpro_hotelDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.clienteTableAdapter = new SCH___Sistema_de_Controle_de_Hospedagem.bd_forpro_hotelDataSetTableAdapters.clienteTableAdapter();
            this.useradmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_admTableAdapter = new SCH___Sistema_de_Controle_de_Hospedagem.bd_forpro_hotelDataSetTableAdapters.user_admTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bd_forpro_hotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.useradmBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataMember = "cliente";
            this.clienteBindingSource.DataSource = this.bd_forpro_hotelDataSet;
            // 
            // bd_forpro_hotelDataSet
            // 
            this.bd_forpro_hotelDataSet.DataSetName = "bd_forpro_hotelDataSet";
            this.bd_forpro_hotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetClientes";
            reportDataSource2.Name = "DataSetUsuarios";
            reportDataSource2.Value = this.useradmBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SCH___Sistema_de_Controle_de_Hospedagem.Relatorio.RelClientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 426);
            this.reportViewer1.TabIndex = 0;
            // 
            // clienteTableAdapter
            // 
            this.clienteTableAdapter.ClearBeforeFill = true;
            // 
            // useradmBindingSource
            // 
            this.useradmBindingSource.DataMember = "user_adm";
            this.useradmBindingSource.DataSource = this.bd_forpro_hotelDataSet;
            // 
            // user_admTableAdapter
            // 
            this.user_admTableAdapter.ClearBeforeFill = true;
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(168)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Cliente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmClientes_FormClosed);
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bd_forpro_hotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.useradmBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private bd_forpro_hotelDataSet bd_forpro_hotelDataSet;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private bd_forpro_hotelDataSetTableAdapters.clienteTableAdapter clienteTableAdapter;
        private System.Windows.Forms.BindingSource useradmBindingSource;
        private bd_forpro_hotelDataSetTableAdapters.user_admTableAdapter user_admTableAdapter;
    }
}