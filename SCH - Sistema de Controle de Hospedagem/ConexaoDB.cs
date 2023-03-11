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
        // Conexão com o banco de dados local
        public string conexao = "SERVER=localhost; DATABASE=bd_forpro_hotel; UID=root; PWD=; PORT=;";

        // Conexão com o banco de dados remoto

        //public string conexao = "SERVER=mysql248.umbler.com; DATABASE=for_pro_hotel_db; UID=; PWD=; PORT=;";

        public MySqlConnection conex = null; // objeto de conexão com o banco de dados

        public void AbrirConcexao()
        {
            try
            {
                conex = new MySqlConnection(conexao);
                conex.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema ao abrir o servidor. Erro: " + ex.Message);
            }
        }

        public void FecharConexao()
        {
            try
            {
                conex = new MySqlConnection(conexao);
                conex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema ao fechar o servidor. Erro: " + ex.Message);
            }
        } 
    }
}
