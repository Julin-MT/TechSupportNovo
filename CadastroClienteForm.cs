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
    public partial class CadastroClienteForm : Form
    {
        public CadastroClienteForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // 1. Pegar os dados que o usuário digitou na tela
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            // 2. Validação simples (verificar se os campos não estão vazios)
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Para a execução aqui se algo estiver faltando
            }

            // 3. Criar uma entidade de usuário com os dados da tela
            UsuarioEntidade novoUsuario = new UsuarioEntidade();
            novoUsuario.Nome = nome; // Supondo que sua entidade tenha a propriedade 'Name'
            novoUsuario.Email = email; // Supondo que sua entidade tenha a propriedade 'Email'
                                       // NÃO SALVAMOS A SENHA DIRETO AQUI!

            // 4. Chamar a camada de Lógica (Model) para fazer o cadastro
            try
            {
                UsuarioModel usuarioModel = new UsuarioModel();
                // A camada Model que deve se preocupar em criptografar a senha e chamar o DAO
                usuarioModel.CadastrarNovoUsuario(novoUsuario, senha);

                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha a tela de cadastro após o sucesso
            }
            catch (Exception ex)
            {
                // Se der algum erro (ex: email já existe), o Model vai avisar
                MessageBox.Show("Erro ao cadastrar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
