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
    public partial class frmPrincipal : Form
    {
        ConexaoDB conexao = new ConexaoDB(); // Instância do objeto de conexão com o banco de dados
        string sql; // String que armazena a query SQL
        MySqlCommand cmd; // String que armazena a query SQL

        string id; // String que armazena o id de registro do cliente  

        public frmPrincipal()
        {
            InitializeComponent();
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListagemGridDB();
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            Des_Habiliatar(0, true);
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome!");
                txtNome.Text = "";
                txtNome.Focus();
                return;
            } 
            else if (!ValidaCPF(mskTxtCPF.Text))
            {
                MessageBox.Show("Esse CPF é invalido!");
                mskTxtCPF.Text = "";
                mskTxtCPF.Focus();
                return;
            }
            else if( mskTxtTelCel.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Telefone!");
                mskTxtTelCel.Text = "";
                mskTxtTelCel.Focus();
                return;
            }


            Des_Habiliatar(1, false);
            conexao.AbrirConcexao(); // Abre a conexão com o banco de dados

            // Define a query SQL para inserir um novo cliente
            sql = "INSERT INTO cliente (nome, endereco, cpf, telefone) VALUES(@nome, @endereco, @cpf, @telefone)";

            // Instancia um novo objeto MySqlCommand, passando a query SQL e a conexão com o banco de dados como parâmetros
            cmd = new MySqlCommand(sql, conexao.conex);

            // Define os parâmetros da query SQL, passando os valores dos campos de cadastro
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@cpf", mskTxtCPF.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@telefone", mskTxtTelCel.Text);

            cmd.ExecuteNonQuery(); // Executa a query SQL
            conexao.FecharConexao(); // Fecha a conexão com o banco de dados

            Des_Habiliatar(0, false);
            ListagemGridDB();

            MessageBox.Show("Registro salvo com sucesso!", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Des_Habiliatar(0, false);
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realizar essa exclusão?", "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Des_Habiliatar(0, false);
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;

            conexao.AbrirConcexao();

            sql = "DELETE FROM `cliente` WHERE id=@id";

            cmd = new MySqlCommand(sql, conexao.conex);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            conexao.FecharConexao();

            ListagemGridDB();

            MessageBox.Show("Exclusão feita com sucesso!", "Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realizar essa edição?", "Salvar Edição", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            else if (!ValidaCPF(mskTxtCPF.Text))
            {
                MessageBox.Show("Esse CPF é invalido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskTxtCPF.Text = "";
                mskTxtCPF.Focus();
                return;
            }
            else if (mskTxtTelCel.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Telefone!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskTxtTelCel.Text = "";
                mskTxtTelCel.Focus();
                return;
            }


            Des_Habiliatar(1, false);

            conexao.AbrirConcexao(); // Abre a conexão com o banco de dados

            // Define a query SQL para atualizar o cadastro de um cliente
            sql = "UPDATE cliente SET nome=@nome, endereco=@endereco, cpf=@cpf, telefone=@telefone WHERE id=@id";

            // Instancia um novo objeto MySqlCommand, passando a query SQL e a conexão com o banco de dados como parâmetros
            cmd = new MySqlCommand(sql, conexao.conex);

            // Define os parâmetros da query SQL, passando os valores dos campos de cadastro
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@cpf", mskTxtCPF.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@telefone", mskTxtTelCel.Text);

            cmd.ExecuteNonQuery(); // Executa a query SQL
            conexao.FecharConexao(); // Fecha a conexão com o banco de dados

            Des_Habiliatar(0, false);
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            ListagemGridDB();

            MessageBox.Show("Edição feita com sucesso!", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Des_Habiliatar(2, true);
            id = dataGrid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
            txtEndereco.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
            mskTxtCPF.Text = dataGrid.CurrentRow.Cells[3].Value.ToString().Replace(".",",");
            mskTxtTelCel.Text = dataGrid.CurrentRow.Cells[4].Value.ToString();
        }

        // Método que habilita ou desabilita a edição dos campos de cadastro
        private void Des_Habiliatar(int txt = 0, bool dh = false)
        {
            if (txt == 0)
            {
                // Limpa os campos de cadastro
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
                btnExcluir.Enabled = !dh;
                btnCancelar.Enabled = dh;
                btnEditar.Enabled = !dh;

            }
            else if (txt == 1)
            {
                txtNome.Enabled = dh;
                txtNome.Enabled = dh;
                txtEndereco.Enabled = dh;
                mskTxtCPF.Enabled = dh;
                mskTxtTelCel.Enabled = dh;
                btnNovoCadastro.Enabled = dh;
                btnSalvar.Enabled = dh;
                btnExcluir.Enabled = dh;
                btnCancelar.Enabled = dh;
                btnEditar.Enabled = dh;
            }
            else if(txt == 2)
            {
                txtNome.Enabled = dh;
                txtNome.Enabled = dh;
                txtEndereco.Enabled = dh;
                mskTxtCPF.Enabled = dh;
                mskTxtTelCel.Enabled = dh;
                btnNovoCadastro.Enabled = !dh;
                btnSalvar.Enabled = !dh;
                btnExcluir.Enabled = dh;
                btnCancelar.Enabled = dh;
                btnEditar.Enabled = dh;
            }
        }

        // O método ValidaCPF retorna True para um CPF válido e False para um CPF inválido
        // Código da DevMedia: http://www.devmedia.com.br/articles/viewcomp_forprint.asp?comp=3950
        public static bool ValidaCPF(string vrCPF)

        {

            string valor = vrCPF.Replace(",", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;

        }

        // Função para formatar as colunas do grid
        private void FormatacaoGrid()
        {
            // Define os títulos das colunas do grid
            dataGrid.Columns[0].HeaderText = "Código";
            dataGrid.Columns[1].HeaderText = "Nome";
            dataGrid.Columns[2].HeaderText = "Endereço";
            dataGrid.Columns[3].HeaderText = "CPF";
            dataGrid.Columns[4].HeaderText = "Telefone";
        }

        // Função para carregar os dados do banco de dados no grid
        private void ListagemGridDB()
        {
            conexao.AbrirConcexao(); 

            sql = "SELECT * FROM cliente ORDER BY NOME ASC"; // Define a consulta SQL para selecionar todos os registros da tabela cliente ordenados pelo nome
            
            cmd = new MySqlCommand(sql, conexao.conex);
            
            MySqlDataAdapter da = new MySqlDataAdapter(); 
            da.SelectCommand = cmd;  // Atribui o objeto do tipo MySqlCommand ao objeto do tipo MySqlDataAdapter
            DataTable dt = new DataTable(); 
            da.Fill(dt); // Preenche o objeto do tipo DataTable com os dados do banco de dados usando o objeto do tipo MySqlDataAdapter
            dataGrid.DataSource = dt; // Atribui o objeto do tipo DataTable como fonte de dados do grid
            
            conexao.FecharConexao(); 
            
            FormatacaoGrid(); // Formata as colunas do grid
        }

        // Realiza uma consulta no banco de dados para buscar por um clientes atraves do nomes
        private void Buscar(string nome)
        {
            conexao.AbrirConcexao();

            sql = "SELECT * FROM cliente WHERE nome LIKE @nome ORDER BY nome ASC";

            cmd = new MySqlCommand(sql, conexao.conex);

            cmd.Parameters.AddWithValue("@nome", nome + "%");

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;  
            DataTable dt = new DataTable();
            da.Fill(dt); 
            dataGrid.DataSource = dt;

            conexao.FecharConexao();

            FormatacaoGrid();
        }

    }
}
