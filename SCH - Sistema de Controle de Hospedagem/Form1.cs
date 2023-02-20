using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SCH___Sistema_de_Controle_de_Hospedagem
{
    public partial class Form1 : Form
    {
        ConexaoDB conexao = new ConexaoDB(); // Instância do objeto de conexão com o banco de dados
        string sql; // string que armazena a query SQL
        MySqlCommand cmd; // string que armazena a query SQL

        public Form1()
        {
            InitializeComponent();
    }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            Des_Habiliatar(true);
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            conexao.AbrirConcexao(); // Abre a conexão com o banco de dados

            // Define a query SQL para inserir um novo cliente
            sql = "INSERT INTO cliente (nome, endereco, cpf, telefone) VALUES(@nome, @endereco, @cpf, @telefone)";

            // Instancia um novo objeto MySqlCommand, passando a query SQL e a conexão com o banco de dados como parâmetros
            cmd = new MySqlCommand(sql, conexao.conex);

            // Define os parâmetros da query SQL, passando os valores dos campos de cadastro
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@cpf", mskTxtCPF.Text);
            cmd.Parameters.AddWithValue("@telefone", mskTxtTelCel.Text);

            cmd.ExecuteNonQuery(); // Executa a query SQL
            conexao.FecharConexao(); // Fecha a conexão com o banco de dados

            Des_Habiliatar(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Des_Habiliatar(false);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Des_Habiliatar(false);
        }

        // Método que habilita ou desabilita a edição dos campos de cadastro
        private void Des_Habiliatar(bool dh = false)
        {
            // Método que habilita ou desabilita a edição dos campos de cadastro
            txtNome.Text = "";
            txtEndereco.Text = "";
            mskTxtCPF.Text = "";
            mskTxtTelCel.Text = "";

            // Define a propriedade Enabled de cada controle de acordo com o parâmetro do método
            txtNome.Enabled = dh;
            txtNome.Enabled = dh;
            txtEndereco.Enabled = dh;
            mskTxtCPF.Enabled = dh;
            mskTxtTelCel.Enabled = dh;
            btnNovoCadastro.Enabled = !dh;
            btnSalvar.Enabled = dh;
            btnExcluir.Enabled = dh;
            btnCancelar.Enabled = dh;
        }

    }
}
