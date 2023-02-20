using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SCH___Sistema_de_Controle_de_Hospedagem
{
    class ConexaoDB
    {
        public string conexao = "SERVER=localhost; DATABASE=bd_forpro_hotel; UID=root; PWD=; PORT=;"; // string de conexão com o banco de dados

        public MySqlConnection conex = null; // objeto de conexão com o banco de dados

        public void AbrirConcexao()
        {
            try
            {
                conex = new MySqlConnection(conexao);
                conex.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show("Problema ao abrir o servidor. Erro: " + err.Message);
            }
        }

        public void FecharConexao()
        {
            try
            {
                conex = new MySqlConnection(conexao);
                conex.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Problema ao fechar o servidor. Erro: " + err.Message);
            }
        }
    }
}
