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
using TechSupport.DAO;

namespace TechSupportApp
{
    public partial class frmNovoChamado: Form
    {
        public frmNovoChamado()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnSalvarChamado_Click(object sender, EventArgs e)
        {
            // 1. Validação simples (não deixa salvar vazio)
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(panel1.Text))
            {
                MessageBox.Show("Por favor, preencha o Título e a Descrição.", "Aviso");
                return;
            }

            // 2. Desabilita o botão para evitar cliques duplos
            btnSalvarChamado.Enabled = false;
            btnSalvarChamado.Text = "Enviando...";

            try
            {
                // 3. Cria o objeto Ticket com os dados da tela
                Ticket novo = new Ticket();
                novo.Titulo = textBox1.Text;
                novo.Descricao = panel1.Text;
                novo.Prioridade = cmbPrioridade.Text; // Pega o que está selecionado (Alta/Média/Baixa)

                // Dados automáticos
                novo.Status = "Aberto";
                novo.DataCriacao = DateTime.Now;

                // Como não temos login ainda, vou colocar usuario 1 fixo para não dar erro
                novo.UsuarioId = Sessao.UsuarioId;

                // 4. Chama o DAO para enviar
                TicketDAO dao = new TicketDAO();
                bool sucesso = await dao.AbrirTicket(novo);

                if (sucesso)
                {
                    MessageBox.Show("Chamado aberto com sucesso!", "Sucesso");
                    this.Close(); // Fecha a janelinha
                }
                else
                {
                    MessageBox.Show("Erro ao salvar o chamado na API.", "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro técnico: " + ex.Message);
            }
            finally
            {
                // Reabilita o botão se der erro e a tela continuar aberta
                btnSalvarChamado.Enabled = true;
                btnSalvarChamado.Text = "Salvar";
            }
        }

        // Dica: Configure isso no Load para garantir que a caixinha tenha opções
        private void frmNovoChamado_Load(object sender, EventArgs e)
        {
            // Se você ainda não preencheu a ComboBox nas propriedades, pode fazer via código:
            if (cmbPrioridade.Items.Count == 0)
            {
                cmbPrioridade.Items.Add("Baixa");
                cmbPrioridade.Items.Add("Média");
                cmbPrioridade.Items.Add("Alta");
                cmbPrioridade.SelectedIndex = 1; // Deixa "Média" selecionado padrão
            }
        }
    }
}
