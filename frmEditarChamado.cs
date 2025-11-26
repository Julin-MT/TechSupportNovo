using System;
using System.Windows.Forms;
using TechSupport.DAO;
using TechSupport.Entidades;


namespace TechSupportApp
{
    public partial class frmEditarChamado : Form
    {
        // Guarda o chamado que estamos mexendo
        private Ticket ticketAtual = null;

        // CONSTRUTOR 1: Abre vazio (para usar a lupa)
        public frmEditarChamado()
        {
            InitializeComponent();
        }

        // --- CONSTRUTOR 2: Abre já preenchido (para o duplo clique do Dashboard) ---
        public frmEditarChamado(Ticket ticketRecebido)
        {
            InitializeComponent();
            PreencherTela(ticketRecebido);
        }

        // Método auxiliar para não repetir código
        private void PreencherTela(Ticket ticket)
        {
            ticketAtual = ticket;

            if (ticketAtual != null)
            {
                textBox1.Text = ticketAtual.Id.ToString();          // ID
                textBox2.Text = ticketAtual.DataCriacao.ToString(); // Aberto em
                textBox3.Text = ticketAtual.Titulo;                 // Titulo
                textBox4.Text = ticketAtual.Descricao;              // Descrição
                textBox5.Text = ticketAtual.Status;                 // Status
                textBox6.Text = ticketAtual.Prioridade;             // Prioridade
                textBox7.Text = ticketAtual.Categoria;              // Categoria
                textBox8.Text = ticketAtual.Observacoes;            // Observações
            }
        }

        // --- BOTÃO BUSCAR (btnBuscar) ---
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Digite o ID do chamado.");
                return;
            }

            try
            {
                int id = int.Parse(textBox1.Text);
                TicketDAO dao = new TicketDAO();

                // Busca no banco
                Ticket ticketEncontrado = await dao.BuscarPorId(id);

                if (ticketEncontrado != null)
                {
                    PreencherTela(ticketEncontrado);
                }
                else
                {
                    MessageBox.Show("Chamado não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar: " + ex.Message);
            }
        }

        // --- BOTÃO SALVAR (button1) ---
        private async void button1_Click(object sender, EventArgs e)
        {
            if (ticketAtual == null)
            {
                MessageBox.Show("Busque um chamado primeiro pelo ID.");
                return;
            }

            try
            {
                // Garante que o ID é o mesmo que está digitado na caixa
                ticketAtual.Id = int.Parse(textBox1.Text);

                // Pegamos o que o técnico escreveu nas caixas editáveis
                ticketAtual.Status = "Concluído";        // Status Automático
                ticketAtual.Categoria = textBox7.Text;   // Categoria
                ticketAtual.Observacoes = textBox8.Text; // Observações

                // Manda atualizar
                TicketDAO dao = new TicketDAO();
                bool sucesso = await dao.EditarTicket(ticketAtual);

                if (sucesso)
                {
                    MessageBox.Show("Chamado atualizado com sucesso!");
                    this.Close(); // Fecha a tela para atualizar o Dashboard
                }
                else
                {
                    MessageBox.Show("Erro ao salvar mudanças.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro técnico: " + ex.Message);
            }
        }
    }
}