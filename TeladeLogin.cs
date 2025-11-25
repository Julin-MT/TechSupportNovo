using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechSupport.DAO;
using TechSupport.Entidades;
using TechSupport.Model;

namespace TechSupportApp
{
    public partial class TeladeLogin: Form
    {
        public TeladeLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpa espaços em branco antes e depois
                string email = txtEmail.Text.Trim();
                string senha = txtSenha.Text.Trim();

                // 1. Validação simples
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    MessageBox.Show("Por favor, preencha email e senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Bloqueia o botão para evitar cliques duplos
                btnEntrar.Enabled = false;
                btnEntrar.Text = "Verificando...";

                // 2. Chama a API
                UsuarioDAO dao = new UsuarioDAO();
                UsuarioEntidade usuarioEncontrado = await dao.FazerLogin(email, senha);

                // Reabilita o botão
                btnEntrar.Enabled = true;
                btnEntrar.Text = "Entrar";

                // 3. Verifica se o usuário existe e se a senha bate
                // (Usamos StringComparison para ignorar maiúsculas/minúsculas na senha, para evitar erro bobo na apresentação)
                if (usuarioEncontrado != null &&
                    usuarioEncontrado.SenhaHash != null &&
                    usuarioEncontrado.SenhaHash.Trim().Equals(senha, StringComparison.OrdinalIgnoreCase))
                {
                    // === LOGIN SUCESSO ===

                    // Preenche o Crachá (Sessão Global)
                    TechSupport.Entidades.Sessao.UsuarioId = usuarioEncontrado.Id;
                    TechSupport.Entidades.Sessao.NomeUsuario = usuarioEncontrado.Nome;

                    // Abre o Dashboard
                    frmDashboard dashboard = new frmDashboard();
                    dashboard.Show();

                    // Esconde a tela de Login
                    this.Hide();
                }
                else
                {
                    // Se chegou aqui, ou o email não existe ou a senha está errada
                    MessageBox.Show("Email ou senha incorretos.", "Erro de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                btnEntrar.Enabled = true;
                btnEntrar.Text = "Entrar";
                MessageBox.Show("Erro de conexão: " + ex.Message, "Erro Técnico");
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnIrParaCadastro_Click(object sender, EventArgs e)
        {
            
            CadastroClienteForm telaCadastro = new CadastroClienteForm();

            
            telaCadastro.ShowDialog();
        }
    }
}
