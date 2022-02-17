using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWindowsForms
{
    public partial class Frm_MenuFlutuante : Form
    {
        public Frm_MenuFlutuante()
        {
            InitializeComponent();
        }

        private void Frm_MenuFlutuante_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var contextMenu = new ContextMenuStrip();
                var vToolTip1 = new ToolStripMenuItem() { Text = "Item do menu 1", Image = Image.FromFile("C:\\WindowsForms\\Curso\\CursoWindowsForms\\CursoWindowsForms\\Imagens\\key.png") };
                var vToolTip2 = new ToolStripMenuItem() { Text = "Item do menu 2", Image = Image.FromFile("C:\\WindowsForms\\Curso\\CursoWindowsForms\\CursoWindowsForms\\Imagens\\Frm_ValidaSenha.png") };
                contextMenu.Items.Add(vToolTip1);
                contextMenu.Items.Add(vToolTip2);
                contextMenu.Show(this, new Point(e.X, e.Y));
                vToolTip1.Click += new EventHandler(vToolTip1_Click);
                vToolTip2.Click += new EventHandler(vToolTip2_Click);
            }

            void vToolTip1_Click(object sender1, EventArgs e1)
            {
                MessageBox.Show("Pressionei a opção do menu 1");
            }

            void vToolTip2_Click(object sender2, EventArgs e2)
            {
                MessageBox.Show("Pressionei a opção do menu 2");
            }

            ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
            {
                var vToolTip = new ToolStripMenuItem();
                vToolTip.Text = text;

                Image image = (Image)Properties.Resources.ResourceManager.GetObject(nomeImagem);

                vToolTip.Image = image;
                return vToolTip;
            }

        }
    }
}
