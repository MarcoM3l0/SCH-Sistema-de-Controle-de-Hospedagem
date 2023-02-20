using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SCH___Sistema_de_Controle_de_Hospedagem
{
    class ConexaoBd
    {
        public string conexao = "SERVER=localhost; DATABASE=bd_forpro_hotel; UID=root; PWD=; PORT=;";

        public MySqlConnection conex = null;

        public void AbrirConcexao()
        {
            try
            {

            }
            catch (Exception err)
            {
                MessageBox.Show();
            }
        }

        public void FecharConexao()
        {

        }
    }
}
