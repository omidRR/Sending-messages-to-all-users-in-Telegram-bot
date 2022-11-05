using MaterialSkin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace REXBOT
{
    public partial class GETtokenform : MaterialSkin.Controls.MaterialForm
    {
        public static string token;
        public GETtokenform()
        {
            var matskin = MaterialSkinManager.Instance;
            InitializeComponent();
            matskin.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.DARK;
            MaterialSkinManager.Instance.ColorScheme = new ColorScheme(Color.Indigo, Color.Indigo,
                Color.GreenYellow, Color.White, TextShade.WHITE);
        }

        private void GETtokenform_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (tokentxt.Text is "")
            {
                MessageBox.Show("token must not be empty");
                return;
            }
            token = tokentxt.Text;
            this.Hide();
            REXBOT dd = new REXBOT();
            dd.Show();

        }
    }
}
