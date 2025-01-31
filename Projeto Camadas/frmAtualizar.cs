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
    public partial class frmAtualizar : Form
    {
        public frmAtualizar()
        {
            InitializeComponent();
        }

        FuncionarioDTO funcionarioDTO = new FuncionarioDTO();
        FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Digite um Id!", "Mensagem",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtId.Focus();
                return;
            }

            int id = Convert.ToInt32(txtId.Text.Trim());

            funcionarioDTO = funcionarioBLL.PesquisarFuncionario(id);

            if(funcionarioDTO != null)
            {
                pbFoto.ImageLocation = funcionarioDTO.UrlImgFuncionario.ToString();
                txtNome.Text = funcionarioDTO.NomeFuncionario.ToString();
                txtEmail.Text = funcionarioDTO.EmailFuncionario.ToString();
                mskCPF.Text = funcionarioDTO.CPF.ToString();
                mskTelefone.Text = funcionarioDTO.TelefoneFuncionario.ToString();
                dtpData.Text = funcionarioDTO.DtNascFuncionario.ToString();
                txtSenha.Text = funcionarioDTO.SenhaFuncionario.ToString();
                cboSexo.Text = funcionarioDTO.Sexo.ToString();

                string tipo = funcionarioDTO.TpFuncionario.ToString();

                if (tipo == "1")
                {
                    cboTipo.Text = "Administrador";
                }
                else if (tipo == "2")
                {
                    cboTipo.Text = "Operador";
                }else if (tipo == "3")
                {
                    cboTipo.Text = "Mecânico";
                }

                HabilitarCampo();

                

            }
        }

        private void HabilitarCampo()
        {
            pbFoto.Enabled = true;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            mskCPF.Enabled = true;
            mskTelefone.Enabled = true;
            dtpData.Enabled = true;
            txtSenha.Enabled = true;
            cboSexo.Enabled = true;
            cboTipo.Enabled = true;
            btnAtualizar.Enabled = true;
        }

        private bool ValidaForm()
        {
            bool valida;
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                txtNome.BackColor = Color.Red;
                MessageBox.Show("Digite seu nome!", "Mensagem", MessageBoxButtons.OK);
                txtNome.BackColor = DefaultBackColor;
                txtNome.Focus();
                valida = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.BackColor = Color.Red;
                MessageBox.Show("Digite seu email!", "Mensagem", MessageBoxButtons.OK);
                txtEmail.BackColor = DefaultBackColor;
                txtEmail.Focus();
                valida = false;

            }
            else if (string.IsNullOrEmpty(mskCPF.Text) || mskCPF.Text == "   .   .   -")
            {
                mskCPF.BackColor = Color.Red;
                MessageBox.Show("Digite seu email!", "Mensagem", MessageBoxButtons.OK);
                mskCPF.BackColor = DefaultBackColor;
                mskCPF.Focus();
                valida = true;
            }
            else if (string.IsNullOrEmpty(mskTelefone.Text) || mskTelefone.Text == "(  )      -")
            {
                mskTelefone.BackColor = Color.Red;
                MessageBox.Show("Digite seu email!", "Mensagem", MessageBoxButtons.OK);
                mskTelefone.BackColor = DefaultBackColor;
                mskTelefone.Focus();
                valida = true;
            }
            else if (string.IsNullOrEmpty(dtpData.Text) || dtpData.Text.Length < 10)
            {
                dtpData.BackColor = Color.Red;
                MessageBox.Show("Digite seu email!", "Mensagem", MessageBoxButtons.OK);
                dtpData.BackColor = DefaultBackColor;
                dtpData.Focus();
                valida = true;
            }
            else
            {
                valida = true;
            }
            return valida;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {
                funcionarioDTO.IdFuncionario = Convert.ToInt32(txtId.Text);
                funcionarioDTO.NomeFuncionario = txtNome.Text.Trim();
                funcionarioDTO.EmailFuncionario = txtEmail.Text.Trim();
                funcionarioDTO.CPF = mskCPF.Text.Trim();
                funcionarioDTO.TelefoneFuncionario = mskTelefone.Text.Trim();
                funcionarioDTO.SenhaFuncionario = txtSenha.Text.Trim();
                funcionarioDTO.Sexo = cboSexo.Text.Trim();
                funcionarioDTO.DtNascFuncionario = Convert.ToDateTime(dtpData);

            }
        }
    }
}
