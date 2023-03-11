using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SCH___Sistema_de_Controle_de_Hospedagem
{
    public partial class FrmCadastroCliente : Form
    {
        ConexaoDB conexao = new ConexaoDB(); // Instância do objeto de conexão com o banco de dados
        string sql; // String  SQL
        MySqlCommand cmd; // String que armazena a query SQL

        string id; // String que armazena o id de registro do cliente  

        string fotoUsuario; // String que armazena o caminho da foto

        string mudouFoto = "não"; // String de controle sobre mudança de fotos

        string CPFAntigo;


        public FrmCadastroCliente()
        {
            InitializeComponent();
        }

        private void FrmCadastroCliente_Load(object sender, EventArgs e)
        {
            Limpar();
            ListagemGridDB();
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            HabilitarBotoes(true);
            HabilitarTxt(true);
            btnNovoCadastro.Enabled = false;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try 
            { 
                if(txtNome.Text.Trim() == "")
                {
                    MessageBox.Show("Preencha o campo nome!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }
                else if (!ValidaCPF(mskTxtCPF.Text))
                {
                    MessageBox.Show("Esse CPF é invalido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskTxtCPF.Text = "";
                    mskTxtCPF.Focus();
                    return;
                }
                else if (TemCPF(mskTxtCPF.Text, CPFAntigo))
                {
                    MessageBox.Show("Esse CPF já tem cadastro.", "Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskTxtCPF.Text = "";
                    mskTxtCPF.Focus();
                    return;
                }
                else if( mskTxtTelCel.Text.Trim() == "")
                {
                    MessageBox.Show("Preencha o campo Telefone!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskTxtTelCel.Text = "";
                    mskTxtTelCel.Focus();
                    return;
                }


                HabilitarBotoes(false);
                HabilitarTxt(false);
                conexao.AbrirConcexao(); // Abre a conexão com o banco de dados

                // Define a query SQL para inserir um novo cliente
                sql = "INSERT INTO cliente (nome, endereco, cpf, telefone, foto) VALUES(@nome, @endereco, @cpf, @telefone, @foto)";

                // Instancia um novo objeto MySqlCommand, passando a query SQL e a conexão com o banco de dados como parâmetros
                cmd = new MySqlCommand(sql, conexao.conex);

                // Define os parâmetros da query SQL, passando os valores dos campos de cadastro
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@cpf", mskTxtCPF.Text.Replace(",", "."));
                cmd.Parameters.AddWithValue("@telefone", mskTxtTelCel.Text);
                cmd.Parameters.AddWithValue("foto", Img());

                cmd.ExecuteNonQuery(); // Executa a query SQL
                conexao.FecharConexao(); // Fecha a conexão com o banco de dados

            
                Limpar();
                btnNovoCadastro.Enabled = true;
                ListagemGridDB();

                MessageBox.Show("Registro salvo com sucesso!", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar o registro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarBotoes(false);
            HabilitarTxt(false);
            Limpar();
            mudouFoto = "não";
            btnNovoCadastro.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realizar essa exclusão?", "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            
            HabilitarBotoes(false);
            HabilitarTxt(false);
            Limpar();
            btnNovoCadastro.Enabled = true;

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
            try 
            { 
                if (MessageBox.Show("Deseja realizar essa edição?", "Salvar Edição", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (txtNome.Text.Trim() == "")
                {
                    MessageBox.Show("Preencha o campo nome!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }
                else if (!ValidaCPF(mskTxtCPF.Text))
                {
                    MessageBox.Show("Esse CPF é invalido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskTxtCPF.Text = "";
                    mskTxtCPF.Focus();
                    return;
                }
                else if (TemCPF(mskTxtCPF.Text, CPFAntigo))
                {
                    MessageBox.Show("Esse CPF já tem cadastro.", "Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskTxtCPF.Text = "";
                    mskTxtCPF.Focus();
                    return;
                }
                else if (mskTxtTelCel.Text.Trim() == "")
                {
                    MessageBox.Show("Preencha o campo Telefone!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskTxtTelCel.Text = "";
                    mskTxtTelCel.Focus();
                    return;
                }


                HabilitarBotoes(false);
                HabilitarTxt(false);

                conexao.AbrirConcexao(); // Abre a conexão com o banco de dados
                if (mudouFoto == "sim")
                {
                    // Define a query SQL para atualizar o cadastro de um cliente
                    sql = "UPDATE cliente SET nome=@nome, endereco=@endereco, cpf=@cpf, telefone=@telefone, foto=@foto WHERE id=@id";

                    // Instancia um novo objeto MySqlCommand, passando a query SQL e a conexão com o banco de dados como parâmetros
                    cmd = new MySqlCommand(sql, conexao.conex);

                    // Define os parâmetros da query SQL, passando os valores dos campos de cadastro
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("@cpf", mskTxtCPF.Text.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@telefone", mskTxtTelCel.Text);
                    cmd.Parameters.AddWithValue("foto", Img());
                }
                else if (mudouFoto == "não")
                {
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
                }


                cmd.ExecuteNonQuery(); // Executa a query SQL
                conexao.FecharConexao(); // Fecha a conexão com o banco de dados

                Limpar();
                btnNovoCadastro.Enabled = true;
                ListagemGridDB();

                MessageBox.Show("Edição feita com sucesso!", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao excluir o cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Foto = new OpenFileDialog();
                Foto.Filter = "Foto(*.jpg; *.png) | *.jpg; *.png";

                if (Foto.ShowDialog() == DialogResult.OK)
                {
                    mudouFoto = "sim";
                    fotoUsuario = Foto.FileName.ToString(); // Pega o caminho do arquivo da foto
                    foto.ImageLocation = fotoUsuario;
                }
                else
                    mudouFoto = "não";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao selecionar a foto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex <= -1)
                    return;

                mudouFoto = "não";

                HabilitarBotoes(true);
                HabilitarTxt(true);
                btnNovoCadastro.Enabled = false;
                btnSalvar.Enabled = false;
                id = dataGrid.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
                txtEndereco.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
                mskTxtCPF.Text = dataGrid.CurrentRow.Cells[3].Value.ToString().Replace(".", ",");
                mskTxtTelCel.Text = dataGrid.CurrentRow.Cells[4].Value.ToString();

                CPFAntigo = mskTxtCPF.Text;

                if (dataGrid.CurrentRow.Cells[5].Value != DBNull.Value)
                {
                    byte[] imagem = (byte[])dataGrid.Rows[e.RowIndex].Cells[5].Value;

                    MemoryStream memoryStream = new MemoryStream(imagem);

                    foto.Image = Image.FromStream(memoryStream);
                }
                else
                    foto.Image = Properties.Resources.Perfil;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao selecionar o registro. Detalhes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que habilita ou desabilita a edição dos campos de cadastro
        private void HabilitarBotoes(bool dh = false)
        {
            btnNovoCadastro.Enabled = dh;
            btnSalvar.Enabled = dh;
            btnExcluir.Enabled = dh;
            btnCancelar.Enabled = dh;
            btnEditar.Enabled = dh;
            btnFoto.Enabled = dh;
        }

        private void HabilitarTxt(bool dh = false)
        {
            txtNome.Enabled = dh;
            txtEndereco.Enabled = dh;
            mskTxtCPF.Enabled = dh;
            mskTxtTelCel.Enabled = dh;
        }

        private void Limpar()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            mskTxtCPF.Text = "";
            mskTxtTelCel.Text = "";

            foto.Image = Properties.Resources.Perfil;
            fotoUsuario = @"foto\Perfil.png";

            CPFAntigo = "";
        }
        

        // O método ValidaCPF retorna True para um CPF válido e False para um CPF inválido
        // Código da DevMedia: http://www.devmedia.com.br/articles/viewcomp_forprint.asp?comp=3950
        private static bool ValidaCPF(string vrCPF)

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

        // Método que verifica se um CPF já existe no banco e retorna true se o CPF existe e false caso contrário
        private bool TemCPF(string CPF, string CPFAntigo)
        {
            try
            {
                if (CPFAntigo.Length > 0)
                {
                    if (CPF == CPFAntigo)
                        return false;
                }

                conexao.AbrirConcexao();

                cmd = new MySqlCommand("SELECT * FROM cliente WHERE cpf=@cpf", conexao.conex);
                cmd.Parameters.AddWithValue("@cpf", CPF.Replace(",", "."));
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
                MessageBox.Show("Ocorreu um erro ao verificar o CPF. Detalhes do erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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
            dataGrid.Columns[5].HeaderText = "Foto";

            dataGrid.Columns[5].Visible = false;
        }

        // Função para carregar os dados do banco de dados no grid
        private void ListagemGridDB()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Realiza uma consulta no banco de dados para buscar por um clientes atraves do nomes
        private void Buscar(string nome)
        {
            try
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


                FormatacaoGrid();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocorreu um erro ao buscar os dados no banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.FecharConexao();
            }
        }

        // metodo para enviar imagem para  banco de dados
        private byte[] Img()
        {
            byte[] imagem = null;

            FileStream fileStream = new FileStream(fotoUsuario, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            imagem = binaryReader.ReadBytes((int)fileStream.Length);

            return imagem;
            
        }

        private void FrmCadastroCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            this.Dispose();
            frm.Show();
        }
    } // Fim
}
