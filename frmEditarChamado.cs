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

        public frmEditarChamado()
        {
            InitializeComponent();
        }

        // --- BOTÃO BUSCAR (btnBuscar) ---
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            // ASSUMI QUE O CAMPO ID É O textBox1. Se não for, mude aqui!
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
                ticketAtual = await dao.BuscarPorId(id);

                if (ticketAtual != null)
                {
                    // --- PREENCHENDO OS CAMPOS EXATOS DA SUA LISTA ---

                    textBox2.Text = ticketAtual.DataCriacao.ToString(); // Aberto em
                    textBox3.Text = ticketAtual.Titulo;                 // Titulo
                    textBox4.Text = ticketAtual.Descricao;              // Descrição

                    // Campos Editáveis
                    textBox5.Text = ticketAtual.Status;     // Status
                    textBox6.Text = ticketAtual.Prioridade; // Prioridade
                    textBox7.Text = ticketAtual.Categoria;  // Categoria
                    textBox8.Text = ticketAtual.Observacoes;// Observações
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
                // --- AQUI A SOLUÇÃO DE EMERGÊNCIA ---
                // Garante que o ID é o mesmo que está digitado na caixa, 
                // ignorando qualquer erro de mapeamento JSON.
                ticketAtual.Id = int.Parse(textBox1.Text);

                // Pegamos o que o técnico escreveu nas caixas editáveis
                ticketAtual.Status = "Concluído";      // Status
                ticketAtual.Categoria = textBox7.Text;   // Categoria
                ticketAtual.Observacoes = textBox8.Text; // Observações

                // Manda atualizar
                TicketDAO dao = new TicketDAO();
                bool sucesso = await dao.EditarTicket(ticketAtual);

                if (sucesso)
                {
                    MessageBox.Show("Chamado atualizado com sucesso!");

                    // Limpa tudo para o próximo
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    ticketAtual = null;
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