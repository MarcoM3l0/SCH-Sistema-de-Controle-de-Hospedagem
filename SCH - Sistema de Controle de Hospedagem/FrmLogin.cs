using MySql.Data.MySqlClient;
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
    public partial class FrmLogin : Form
    {
        private ConexaoDB conexao = new ConexaoDB(); // Instância do objeto de conexão com o banco de dados
        private string sql; // String  SQL
        private MySqlCommand cmd; // String que armazena a query SQL

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            { 
                // Verifica se os campos de login estão em branco
                if (txtUsuario.Text.Trim() == "" || txtSenha.Text.Trim() == "")
                {
                    MessageBox.Show("Há campo de login em branco, preencha-o", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    return;
                }

                // Verifica se o usuário existe no banco de dados
                else if (!temUsuario(txtUsuario.Text))
                {
                    MessageBox.Show("Usuário não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    return;
                }

                // Verifica se a senha é válida
                else if (!ValidarSenha(txtUsuario.Text, txtSenha.Text))
                {
                    MessageBox.Show("Senha errada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    return;
                }

                // Abre o formulário principal e esconde o formulário de login
                FrmPrincipal frm = new FrmPrincipal();
                frm.Show();
                this.Close();
            }
            catch (Exception c)
            {
                MessageBox.Show("Ocorreu um erro ao processar a solicitação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Verifica se o usuário existe no banco de dados
        private bool temUsuario(string User)
        {
            try
            {
                conexao.AbrirConcexao();

                sql = "SELECT * FROM user_adm WHERE user=@user";
                cmd = new MySqlCommand(sql, conexao.conex);
                cmd.Parameters.AddWithValue("@user", User);

                object result = cmd.ExecuteScalar();

                conexao.FecharConexao();

                int count = result != null ? (int)result : 0;

                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao verificar se o usuário existe: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Verifica se a senha é válida para o usuário
        private bool ValidarSenha(string User, string Senha)
        {
            try
            {
                conexao.AbrirConcexao();
                sql = "SELECT senha FROM user_adm WHERE user=@user";
                cmd = new MySqlCommand(sql, conexao.conex);
                cmd.Parameters.AddWithValue("@user", User);

                string senhaArmazenada = (string)cmd.ExecuteScalar();

                conexao.FecharConexao();

                if (senhaArmazenada == Senha)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao validar a senha do usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
