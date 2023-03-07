using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCH___Sistema_de_Controle_de_Hospedagem
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroCliente frm = new FrmCadastroCliente();
            frm.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuario frm = new FrmCadastroUsuario();
            frm.ShowDialog();
        }
    }
}
