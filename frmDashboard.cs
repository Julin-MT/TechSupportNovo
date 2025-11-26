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

                
                List<Ticket> listaTotal = await dao.ListarTickets();

                
                var listaFiltrada = listaTotal.FindAll(x => x.Status == "Aberto");

                
                dataGridView1.DataSource = listaFiltrada;

                
                ConfigurarColunas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os chamados: " + ex.Message, "Erro de Conexão");
            }
        }


        private void ConfigurarColunas()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                // --- COLUNAS QUE QUEREMOS ESCONDER ---
                if (dataGridView1.Columns["UsuarioId"] != null) dataGridView1.Columns["UsuarioId"].Visible = false;
                if (dataGridView1.Columns["NomeUsuario"] != null) dataGridView1.Columns["NomeUsuario"].Visible = false;
                if (dataGridView1.Columns["EmailUsuario"] != null) dataGridView1.Columns["EmailUsuario"].Visible = false;
                if (dataGridView1.Columns["Categoria"] != null) dataGridView1.Columns["Categoria"].Visible = false;
                if (dataGridView1.Columns["Observacoes"] != null) dataGridView1.Columns["Observacoes"].Visible = false;

                // --- COLUNAS VISÍVEIS (AGORA COM PRIORIDADE) ---

                // 1. Prioridade (Mudei para TRUE)
                if (dataGridView1.Columns["Prioridade"] != null)
                {
                    dataGridView1.Columns["Prioridade"].Visible = true; // <--- AGORA APARECE
                    dataGridView1.Columns["Prioridade"].HeaderText = "Prioridade";
                }

                // 2. Datas (Já tínhamos arrumado)
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

                // 3. Colunas Padrão
                if (dataGridView1.Columns["Id"] != null)
                {
                    dataGridView1.Columns["Id"].HeaderText = "Cód.";
                    dataGridView1.Columns["Id"].Width = 50;
                }
                if (dataGridView1.Columns["Titulo"] != null) dataGridView1.Columns["Titulo"].HeaderText = "Título";
                if (dataGridView1.Columns["Descricao"] != null) dataGridView1.Columns["Descricao"].HeaderText = "Descrição";
                if (dataGridView1.Columns["Status"] != null) dataGridView1.Columns["Status"].HeaderText = "Situação";

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
    }
}