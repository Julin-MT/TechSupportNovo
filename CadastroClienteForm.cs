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
    public partial class CadastroClienteForm : Form
    {
        public CadastroClienteForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            // 1. Pegar os dados que o usuário digitou na tela
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            // 2. Validação simples
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Criar uma entidade de usuário
            UsuarioEntidade novoUsuario = new UsuarioEntidade();
            novoUsuario.Nome = nome;
            novoUsuario.Email = email;
            // Não precisamos setar a SenhaHash aqui, passamos a senha pura pro DAO enviar

            // 4. Chamar o DAO para enviar para a API
            try
            {
                // Bloqueia o botão para não clicar duas vezes sem querer
                btnCadastrar.Enabled = false;

                UsuarioDAO dao = new UsuarioDAO();

                // --- AQUI A MÁGICA ACONTECE ---
                // Usamos 'await' para esperar a API cadastrar
                bool sucesso = await dao.CadastrarUsuario(novoUsuario, senha);

                if (sucesso)
                {
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha a tela
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar. Verifique se o email já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro técnico ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reabilita o botão independente se deu certo ou errado
                btnCadastrar.Enabled = true;
            }
        }
    }
    }

