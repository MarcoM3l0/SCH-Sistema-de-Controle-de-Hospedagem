﻿using MySql.Data.MySqlClient;
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
            this.Dispose();
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Precisa preencher o campo de usuário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return;
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Precisa preencher o campo de senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return;
            }
            else if (!temUsuario(txtUsuario.Text))
            {
                MessageBox.Show("Usuário não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return;
            }
            else if (!ValidarSenha(txtUsuario.Text, txtSenha.Text))
            {
                MessageBox.Show("Senha errada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return;
            }
            FrmPrincipal frm = new FrmPrincipal();
            frm.Show();
            this.Hide();
        }

        private bool temUsuario(string User)
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

        private bool ValidarSenha(string User, string Senha)
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
    }
}
