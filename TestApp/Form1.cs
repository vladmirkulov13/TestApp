using CsQuery;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        #region Кнопка все слова
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                richTextBox2.Clear();
                label3.Text = "";
                label3.Text = "All words";
                Parser parser = new Parser(textBox1.Text);
                richTextBox1.Text = Parser.Text;
                parser.GetSeparateHTML();
                List<string> words = new List<string>();


                foreach (string s in Parser.Subs)
                {
                    if (words.Contains(s))
                    {
                        continue;
                    }
                    else
                    {
                        words.Add(s);
                        int count = 0;
                        foreach (string s2 in Parser.Subs)
                        {
                            if (s == s2)
                            {
                                count++;
                            }
                        }
                        // для вывода абсолютно всех слов 
                        richTextBox2.Text += s + '-' + count.ToString() + '\n';
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        
            }
        #endregion

        #region Кнопка русские слова
        private void button2_Click(object sender, EventArgs e)
        {
            try {
                richTextBox2.Clear();
                label3.Text = "";
                label3.Text = "Russian words";
                Parser parser = new Parser(textBox1.Text);
                richTextBox1.Text = Parser.Text;
                parser.GetSeparateHTML();
                List<string> rusWords = new List<string>();

                foreach (string s in Parser.Subs)
                {
                    if (rusWords.Contains(s))
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < s.Length; i++)
                        {
                            char c = s[i];
                            if (c >= 'а' && c <= 'я')
                            {
                                rusWords.Add(s);
                                break;
                            }
                        }
                    }
                }

                foreach (string rus in rusWords)
                {
                    int count = 0;
                    foreach (string s2 in rusWords)
                    {
                        if (rus == s2)
                        {
                            count++;
                        }
                    }
                    // вывод только русских слов
                    richTextBox2.Text += rus + '-' + count.ToString() + '\n';
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        
        #endregion
    }
}

