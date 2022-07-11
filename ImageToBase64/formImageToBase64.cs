namespace ImageToBase64
{
    public partial class formImageToBase64 : Form
    {
        public formImageToBase64()
        {
            InitializeComponent();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            txtBase64.Text = string.Empty;
            openFileDialog1.ShowDialog();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBase64.Text))
            {
                Clipboard.Clear();
                Clipboard.SetText(txtBase64.Text);
            }
            else
            {
                MessageBox.Show("There is no data for copy to clipboard.");
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                byte[] imageArray = File.ReadAllBytes(openFileDialog1.FileName);
                string base64 = Convert.ToBase64String(imageArray);
                txtBase64.Text = base64;
            }
            catch
            {
                MessageBox.Show("Image file is not correct format.");
            }
        }
    }
}