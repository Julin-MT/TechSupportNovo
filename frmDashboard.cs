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
using TechSupportApp.DAO;


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
                // Esconde colunas técnicas ou desnecessárias nessa visão rápida
                // IMPORTANTE: Os nomes dentro de [""] devem ser iguais ao da classe Ticket.cs
                if (dataGridView1.Columns["Prioridade"] != null) dataGridView1.Columns["Prioridade"].Visible = false;
                if (dataGridView1.Columns["UsuarioId"] != null) dataGridView1.Columns["UsuarioId"].Visible = false;
                if (dataGridView1.Columns["NomeUsuario"] != null) dataGridView1.Columns["NomeUsuario"].Visible = false;
                if (dataGridView1.Columns["EmailUsuario"] != null) dataGridView1.Columns["EmailUsuario"].Visible = false;
                if (dataGridView1.Columns["DataCriacao"] != null) dataGridView1.Columns["DataCriacao"].Visible = false;
                if (dataGridView1.Columns["DataFechamento"] != null) dataGridView1.Columns["DataFechamento"].Visible = false;
                if (dataGridView1.Columns["Categoria"] != null) dataGridView1.Columns["Categoria"].Visible = false;
                if (dataGridView1.Columns["Observacoes"] != null) dataGridView1.Columns["Observacoes"].Visible = false;

                // Renomeia os cabeçalhos para ficar bonito
                if (dataGridView1.Columns["Id"] != null) dataGridView1.Columns["Id"].HeaderText = "Cód.";
                if (dataGridView1.Columns["Titulo"] != null) dataGridView1.Columns["Titulo"].HeaderText = "Título do Chamado";
                if (dataGridView1.Columns["Descricao"] != null) dataGridView1.Columns["Descricao"].HeaderText = "Descrição";
                if (dataGridView1.Columns["Status"] != null) dataGridView1.Columns["Status"].HeaderText = "Situação";

                // Ajusta a largura para preencher a tela cinza
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // --- Seus Botões Antigos (Mantidos) ---

        private void btnNovo_Click(object sender, EventArgs e)
        {
            // Botão vazio (pode apagar se não usar)
        }

        private void btnNovoChamado_Click(object sender, EventArgs e)
        {
            try
            {
                frmNovoChamado telaNovoChamado = new frmNovoChamado();
                telaNovoChamado.ShowDialog();

                // DICA EXTRA: Depois de fechar a tela de novo chamado, 
                // é bom recarregar o grid para o novo chamado aparecer:
                // CarregarGrid(); <--- (Pode descomentar isso depois se quiser testar)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a tela de chamados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarChamado_Click(object sender, EventArgs e)
        {
            try
            {
                frmEditarChamado telaEditar = new frmEditarChamado();
                telaEditar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir tela de edição: " + ex.Message);
            }
        }
    }
}