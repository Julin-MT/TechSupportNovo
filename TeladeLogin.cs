using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Pega os dados da tela diretamente como strings
                string email = txtEmail.Text;
                string senha = txtSenha.Text;

                // Validação básica para não chamar o banco à toa
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    MessageBox.Show("Por favor, preencha o email e a senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Chama a camada de modelo com o novo método
                UsuarioModel model = new UsuarioModel();
                bool loginOk = model.VerificarLogin(email, senha); // <<-- ESTA É A LINHA QUE MUDOU

                if (loginOk)
                {
                    // Mudei de 'frmDashboard' para 'TelaPrincipal' (baseado na sua foto)
                    frmDashboard tela = new frmDashboard();
                    tela.Show();
                    this.Hide();
                }
                else
                {
                    // SE O LOGIN ESTIVER INCORRETO, MOSTRA FALHA
                    MessageBox.Show("Email ou senha incorretos. Tente novamente.", "Falha no Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // SE OCORRER UM ERRO DE CONEXÃO OU OUTRO PROBLEMA
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
