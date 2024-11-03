using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        String path = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            path=String.Empty;
            textBox1=new TextBox();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog obj1 = new OpenFileDialog() 
            {   Filter = "Text Documents|*.txt",
                ValidateNames = true,
                Multiselect = false 
            
            }) 

            {
                if (obj1.ShowDialog() == DialogResult.OK)// user select
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(obj1.FileName))
                        {
                            path=obj1.FileName;
                            Task<String>text=sr.ReadLineAsync();
                            textBox1.Text=text.Result;
                        }

                    }catch(Exception ex) {
                        MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                using (SaveFileDialog obj1 = new SaveFileDialog()
                {
                    Filter = "Text Document|*.txt",
                    ValidateNames = true

                }) 
               
                {
                    if(obj1.ShowDialog() == DialogResult.OK) {
                        {
                            try
                            {
                                path= obj1.FileName;
                                using(StreamWriter sw = new StreamWriter(obj1.FileName))

                                {
                                    MessageBox.Show(obj1.FileName);
                                    sw.WriteLine(textBox1.Text);


                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                }
                    else
                    {
                        try
                        {
                            using(StreamWriter sw = new StreamWriter(path))
                            {
                                sw.WriteAsync(textBox1.Text);

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
            }
        }
    }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        { Application.Exit(); 
        
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
               
                if (!string.IsNullOrEmpty(path))
                {
                    using (SaveFileDialog obj1 = new SaveFileDialog()
                    {
                        Filter = "Text Document|*.txt",
                        ValidateNames = true

                    })

                    {
                        if (obj1.ShowDialog() == DialogResult.OK)
                        {
                            {
                                try
                                {
                                    path = obj1.FileName;
                                    using (StreamWriter sw = new StreamWriter(obj1.FileName))

                                    {
                                        MessageBox.Show(obj1.FileName);
                                        sw.WriteLine(textBox1.Text);


                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                using (StreamWriter sw = new StreamWriter(path))
                                {
                                    sw.WriteAsync(textBox1.Text);

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                    }
                }
            }
        }

        
    }
    }
