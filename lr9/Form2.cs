using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lr9.ModelEF;

namespace lr9
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text)|| String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Fill all fields!");
                return;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No picture");
                return;
            }
            Model1 model1 = new Model1();
            Student student = new Student();

            student.Name = textBox1.Text;
            student.Group_ = textBox2.Text;
            byte[] bImg = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));
            student.Photo = bImg;
            model1.Students.Add(student);
            try
            {
                model1.SaveChanges();
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message);

            }
            MessageBox.Show("Saved");
            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chose picture";
         
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}