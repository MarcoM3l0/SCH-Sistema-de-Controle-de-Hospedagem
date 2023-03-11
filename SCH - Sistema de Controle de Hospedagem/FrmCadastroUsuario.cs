using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCH___Sistema_de_Controle_de_Hospedagem
{
    public partial class FrmCadastroUsuario : Form
    {
        ConexaoDB conexao = new ConexaoDB(); // Instância do objeto de conexão com o banco de dados
        string sql; // String  SQL
        MySqlCommand cmd; // String que armazena a query SQL

        //string id; // String que armazena o id de registro do usuário  

        Regex regexEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public FrmCadastroUsuario()
        {
            InitializeComponent();
            Limpar();
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            HabilitarCampus(true);
            txtUsuario.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show("Preencha o campo Usuário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    return;
                }
                else if (txtEMail.Text.Trim() == "")
                {
                    MessageBox.Show("Preencha o campo E-mail!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMail.Focus();
                    return;
                }
                else if (!regexEmail.IsMatch(txtEMail.Text.Trim()))
                {
                    MessageBox.Show("E-mail é inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEMail.Focus();
                    return;
                }
                else if (txtSenha.Text == "")
                {
                    MessageBox.Show("Preencha o campo Senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.Focus();
                    return;
                }
                else if (txtSenha.Text == "")
                {
                    MessageBox.Show("Preencha o campo Senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.Focus();
                    return;
                }

                else if (txtConfSenha.Text == "")
                {
                    MessageBox.Show("Preencha o campo Confirmar Senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfSenha.Focus();
                    return;
                }
                else if (txtSenha.Text != txtConfSenha.Text)
                {
                    MessageBox.Show("As senhas digitada são diferentes!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.Focus();
                    return;
                }

                conexao.AbrirConcexao();

                sql = "INSERT INTO user_adm (user, e_mail, senha) VALUES(@user, @e_mail, @senha)";
                cmd = new MySqlCommand(sql, conexao.conex);

                cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@e_mail", txtEMail.Text);
                cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

                cmd.ExecuteNonQuery();
                conexao.FecharConexao();

                Limpar();
                HabilitarCampus(false);

                MessageBox.Show("Registro salvo com sucesso!", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar salvar o registro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitarCampus(bool hb = false)
        {
            txtUsuario.Enabled = hb;
            txtEMail.Enabled = hb;
            txtSenha.Enabled = hb;
            txtConfSenha.Enabled = hb;
            btnNovoCadastro.Enabled = !hb;
            btnSalvar.Enabled = hb;
        }

        private void Limpar()
        {
            txtUsuario.Text = "";
            txtEMail.Text = "";
            txtSenha.Text = "";
            txtConfSenha.Text = "";
        }

        private void FrmCadastroUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            this.Dispose();
            frm.Show();
        }
    }
}
