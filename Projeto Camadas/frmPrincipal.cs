using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Camadas
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mspaint");
        }

        private void pbNotepad_MouseHover(object sender, EventArgs e)
        {
            pbNotepad.Size = new Size(260, 250);
        }

        private void pbNotepad_MouseLeave(object sender, EventArgs e)
        {
            pbNotepad.Size = new Size(230, 221);
        }

        private void pbCalc_MouseHover(object sender, EventArgs e)
        {
            pbCalc.Size = new Size(260, 250);
        }

        private void pbCalc_MouseLeave(object sender, EventArgs e)
        {
            pbCalc.Size = new Size(230, 221);
        }

        private void pbPaint_MouseHover(object sender, EventArgs e)
        {
            pbPaint.Size = new Size(260, 250);
        }

        private void pbPaint_MouseLeave(object sender, EventArgs e)
        {
            pbPaint.Size = new Size(230, 221);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmCadastro frmCadastro = new frmCadastro();
            frmCadastro.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar();
            frmListar.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmAtualizar frmAtualizar = new frmAtualizar();
            frmAtualizar.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmExcluir frmExcluir = new frmExcluir();
            frmExcluir.Show();
        }
    }
}
