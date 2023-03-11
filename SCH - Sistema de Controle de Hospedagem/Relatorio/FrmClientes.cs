using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCH___Sistema_de_Controle_de_Hospedagem.Relatorio
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            frm.Show();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bd_forpro_hotelDataSet.user_adm'. Você pode movê-la ou removê-la conforme necessário.
            this.user_admTableAdapter.Fill(this.bd_forpro_hotelDataSet.user_adm);
            // TODO: esta linha de código carrega dados na tabela 'bd_forpro_hotelDataSet.cliente'. Você pode movê-la ou removê-la conforme necessário.
            this.clienteTableAdapter.Fill(this.bd_forpro_hotelDataSet.cliente);

            this.reportViewer1.RefreshReport();
        }
    }
}
