using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechSupportApp
{
    public partial class frmDashboard : Form
    {
        // --- INICIO DA CORREÇÃO ---
        // Este é o Construtor. Sem ele, a tela fica branca!
        public frmDashboard()
        {
            InitializeComponent(); // Esse comando "desenha" a tela
        }
        // --- FIM DA CORREÇÃO ---

        private void btnNovo_Click(object sender, EventArgs e)
        {
            // Pode deixar vazio ou apagar se não usar
        }

        private void btnNovoChamado_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Cria uma nova instância da tela de Abertura de Chamado
                frmNovoChamado telaNovoChamado = new frmNovoChamado();

                // 2. Exibe a tela. 
                telaNovoChamado.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a tela de chamados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // Se precisar carregar dados ao abrir, coloque aqui
        }

        private void btnEditarChamado_Click(object sender, EventArgs e) // O nome pode variar dependendo do seu botão
        {
            try
            {
                // 1. Cria a instancia da tela de Edição
                frmEditarChamado telaEditar = new frmEditarChamado();

                // 2. Abre a tela. 
                // Usamos ShowDialog() para impedir que o usuário mexa no Dashboard enquanto edita
                telaEditar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir tela de edição: " + ex.Message);
            }
        }
    }
}