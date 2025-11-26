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




namespace TechSupportApp
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        
        private async void frmDashboard_Load(object sender, EventArgs e)
        {
            await CarregarGrid();
        }


        private async Task CarregarGrid()
        {
            try
            {
                TicketDAO dao = new TicketDAO();

                // 1. Busca TUDO da API
                List<Ticket> listaTotal = await dao.ListarTickets();

                // 2. A MUDANÇA ESTÁ AQUI (Ordenação)
                // A lógica: Quem for "Concluído" vai para o final da fila (True fica depois de False)
                // E dentro de cada grupo, ordenamos pelo ID (do mais novo para o mais velho)
                var listaOrdenada = listaTotal
                    .OrderBy(x => x.Status == "Concluído")
                    .ThenByDescending(x => x.Id)
                    .ToList();

                // 3. Joga no Grid
                dataGridView1.DataSource = null; // Limpa para evitar bugs visuais
                dataGridView1.DataSource = listaOrdenada;

                // 4. Configura as colunas (Largura, Títulos, Datas)
                ConfigurarColunas();

                // 5. Pinta as linhas de cinza (Visual Profissional)
                PintarLinhas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os chamados: " + ex.Message, "Erro de Conexão");
            }
        }

        // --- COPIE E COLE ESSE MÉTODO NOVO NO SEU CÓDIGO ---
        private void PintarLinhas()
        {
            // Percorre cada linha do grid para ver o status
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Pega o ticket que está nessa linha
                Ticket ticket = (Ticket)row.DataBoundItem;

                if (ticket != null && ticket.Status == "Concluído")
                {
                    // Se estiver concluído, pinta de cinza claro e letra cinza escuro
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
                    row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
                }
                else
                {
                    // Se estiver aberto, mantém branco com letra preta
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                }
            }
        }


        private void ConfigurarColunas()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                // --- 1. COLUNAS QUE QUEREMOS ESCONDER ---
                if (dataGridView1.Columns["UsuarioId"] != null) dataGridView1.Columns["UsuarioId"].Visible = false;
                if (dataGridView1.Columns["NomeUsuario"] != null) dataGridView1.Columns["NomeUsuario"].Visible = false;
                if (dataGridView1.Columns["EmailUsuario"] != null) dataGridView1.Columns["EmailUsuario"].Visible = false;

                // (Apaguei Categoria e Observacoes daqui porque agora queremos ver!)

                // --- 2. COLUNAS QUE QUEREMOS VER ---

                // Categoria (Novo)
                if (dataGridView1.Columns["Categoria"] != null)
                {
                    dataGridView1.Columns["Categoria"].Visible = true;
                    dataGridView1.Columns["Categoria"].HeaderText = "Categoria";
                }

                // Observações / Solução (Novo)
                if (dataGridView1.Columns["Observacoes"] != null)
                {
                    dataGridView1.Columns["Observacoes"].Visible = true;
                    dataGridView1.Columns["Observacoes"].HeaderText = "Solução / Obs";
                }

                // Prioridade
                if (dataGridView1.Columns["Prioridade"] != null)
                {
                    dataGridView1.Columns["Prioridade"].Visible = true;
                    dataGridView1.Columns["Prioridade"].HeaderText = "Prioridade";
                }

                // Datas
                if (dataGridView1.Columns["DataCriacao"] != null)
                {
                    dataGridView1.Columns["DataCriacao"].Visible = true;
                    dataGridView1.Columns["DataCriacao"].HeaderText = "Aberto em";
                    dataGridView1.Columns["DataCriacao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                if (dataGridView1.Columns["DataFechamento"] != null)
                {
                    dataGridView1.Columns["DataFechamento"].Visible = true;
                    dataGridView1.Columns["DataFechamento"].HeaderText = "Fechado em";
                    dataGridView1.Columns["DataFechamento"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                // Colunas Padrão
                if (dataGridView1.Columns["Id"] != null)
                {
                    dataGridView1.Columns["Id"].HeaderText = "Cód.";
                    dataGridView1.Columns["Id"].Width = 50;
                }
                if (dataGridView1.Columns["Titulo"] != null) dataGridView1.Columns["Titulo"].HeaderText = "Título";
                if (dataGridView1.Columns["Descricao"] != null) dataGridView1.Columns["Descricao"].HeaderText = "Descrição";
                if (dataGridView1.Columns["Status"] != null) dataGridView1.Columns["Status"].HeaderText = "Situação";

                // Ajuste Final
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // --- Seus Botões Antigos (Mantidos) ---

        private void btnNovo_Click(object sender, EventArgs e)
        {
            // Botão vazio (pode apagar se não usar)
        }

        // 1. Adicionamos 'async' aqui
        private async void btnNovoChamado_Click(object sender, EventArgs e)
        {
            try
            {
                frmNovoChamado telaNovoChamado = new frmNovoChamado();

                // O código espera a janela fechar aqui
                telaNovoChamado.ShowDialog();

                // 2. Assim que fechar, atualizamos a lista (Descomentado e com await)
                await CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a tela de chamados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditarChamado_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria a tela de edição
                frmEditarChamado telaEditar = new frmEditarChamado();

                // Abre a tela e TRAVA o código aqui até você fechar a janelinha
                telaEditar.ShowDialog();

                // --- AQUI A MÁGICA ---
                // Assim que a janela fecha, o código continua e recarrega a lista
                // Isso faz o chamado "Concluído" sumir da lista de abertos na hora!
                await CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir tela de edição: " + ex.Message);
            }
        }

        private void tabPageConcluidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}