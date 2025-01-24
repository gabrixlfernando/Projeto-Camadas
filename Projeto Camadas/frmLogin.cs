using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoCamadas.BLL;
using ProjetoCamdas.DTO;

namespace Projeto_Camadas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string senha = txtSenha.Text;   

            FuncionarioDTO usuario = new FuncionarioDTO();
            FuncionarioBLL usuarioBLL = new FuncionarioBLL();

            usuario = usuarioBLL.AutenticaFuncionario(nome, senha);

            if (usuario != null )
            {
                MessageBox.Show($"Bem Vindo(a) {nome}!","Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Information);

                frmPrincipal principal = new frmPrincipal();
                principal.Show();
            }
            else
            {
                MessageBox.Show("Não foi possivel efetuar o login.","ERRO",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastro frmCadastro = new frmCadastro();
            frmCadastro.Show();

        }
    }
}
