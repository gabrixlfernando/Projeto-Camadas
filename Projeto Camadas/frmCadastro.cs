using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoCamadas.BLL;
using ProjetoCamdas.DTO;

namespace Projeto_Camadas
{
    public partial class frmCadastro : Form
    {

        FuncionarioDTO funcionario = new FuncionarioDTO();
        FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

        string diretorio = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\\funcionarios\";
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = diretorio;

            openFileDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;";
            openFileDialog.Title = "Escolha a Imagem de Funcionario";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivoImagem = openFileDialog.FileName;

                pbFoto.Image = Image.FromFile(nomeArquivoImagem);
            }
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {
                funcionario.NomeFuncionario = txtNome.Text;
                funcionario.SenhaFuncionario = txtSenha.Text;
                funcionario.EmailFuncionario = txtEmail.Text;
                funcionario.Sexo = cboSexo.Text.ToString();
                funcionario.CPF = mskCPF.Text;
                funcionario.TelefoneFuncionario = mskTelefone.Text;

                DateTime dataSelecionada = dtpData.Value;
                funcionario.DtNascFuncionario = dataSelecionada;

                string nomeImg = $"{txtNome.Text}.jpg";
                if (!Directory.Exists(diretorio)) 
                { 
                        Directory.CreateDirectory(diretorio);
                }

                string urlImagem = Path.Combine(diretorio, nomeImg);

                funcionario.UrlImgFuncionario = urlImagem;

                Image imagem = pbFoto.Image;
                imagem.Save(urlImagem);
            }
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            dtpData.Format = DateTimePickerFormat.Custom;
            dtpData.CustomFormat = "dd/MM/yyyy";


            cboTipo.DisplayMember = "DescricaoTipoFuncionario";
            cboTipo.DataSource = funcionarioBLL.GetTipoFuncionario();
        }
    }
}
