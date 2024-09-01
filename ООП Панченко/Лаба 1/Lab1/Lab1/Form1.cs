namespace Lab1
{
    public partial class Form1 : Form
    {
        string? textFromTextBox;
        string? textFromTextBox1_1;
        string? textFromTextBox1_2;

        private KeyEventHandler? keyDownHandler;
        public Form1()
        {
            InitializeComponent();
        }

        private void PodstokaChange_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonEnabledFalse();

                textFromTextBox = textBox1.Text;

                Label label = new()
                {
                    Text = "Ââåäèòå ïîäñòðîêó",

                    Location = new System.Drawing.Point(20, 250),
                    Size = new System.Drawing.Size(400, 20)
                };
                TextBox newTextBox = new()
                {
                    Location = new System.Drawing.Point(20, 280),
                    Size = new System.Drawing.Size(200, 20)
                };

                keyDownHandler = (sender, e) => NewTextBox1_PodstokaChange_KeyDown(sender, e, newTextBox, label);
                newTextBox.KeyDown += keyDownHandler;

                Controls.Add(label);
                Controls.Add(newTextBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void NewTextBox1_PodstokaChange_KeyDown(object sender, KeyEventArgs e, TextBox newTextBox, Label label)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textFromTextBox1_1 = newTextBox.Text;
                    label.Text = "Ââåäèòå íîâóþ ïîäñòðîêó";
                    newTextBox.Text = "";
                    newTextBox.KeyDown -= keyDownHandler;
                    newTextBox.KeyDown += (sender, e) => NewTextBox2_PodstokaChange_KeyDown(sender, e, newTextBox, label);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void NewTextBox2_PodstokaChange_KeyDown(object sender, KeyEventArgs e, TextBox newTextBox, Label label)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textFromTextBox.Contains(textFromTextBox1_1))
                    {
                        textFromTextBox1_2 = newTextBox.Text;
                        MessageBox.Show(textFromTextBox.Replace(textFromTextBox1_1, textFromTextBox1_2));
                    }
                    else
                    {
                        MessageBox.Show("Íå ïîëó÷èëîñü");
                    }
                    ButtonEnabledTrue();
                    Controls.Remove(newTextBox);
                    Controls.Remove(label);
                    textFromTextBox1_1 = null;
                    textFromTextBox1_2 = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        ////////////////////////////////////////////


        private void PodstokaDelete_Click(object sender, EventArgs e)
        {
            ButtonEnabledFalse();

            textFromTextBox = textBox1.Text;

            Label label = new()
            {
                Text = "Ââåäèòå ïîäñòðîêó",

                Location = new System.Drawing.Point(20, 250),
                Size = new System.Drawing.Size(400, 20)
            };
            TextBox newTextBox1 = new()
            {
                Location = new System.Drawing.Point(20, 280),
                Size = new System.Drawing.Size(200, 20)
            };

            newTextBox1.KeyDown += (sender, e) => NewTextBox1_PodstokaDelete_KeyDown(sender, e, newTextBox1, label);

            Controls.Add(label);
            Controls.Add(newTextBox1);
        }

        private void NewTextBox1_PodstokaDelete_KeyDown(object sender, KeyEventArgs e, TextBox newTextBox1, Label label)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textFromTextBox1_1 = newTextBox1.Text;

                string[] words = textFromTextBox1_1.Split(' ');
                bool containAllWords = true;

                foreach (var word in words)
                {
                    if (textFromTextBox.Contains(word))
                    {
                        textFromTextBox = textFromTextBox.Replace(word, "");
                    }
                    else
                    {
                        containAllWords = false;
                    }
                }

                if (containAllWords)
                {
                    MessageBox.Show(textFromTextBox);
                }
                else
                {
                    MessageBox.Show("Íå ïîëó÷èëîñü");
                }

                ButtonEnabledTrue();
                Controls.Remove(newTextBox1);
                Controls.Remove(label);
                textFromTextBox1_1 = null;
                textFromTextBox1_2 = null;
            }
        }

        ////////////////////////////////////////////

        private void SymbolIndex_Click(object sender, EventArgs e)
        {
            ButtonEnabledFalse();

            textFromTextBox = textBox1.Text;

            Label label = new()
            {
                Text = "Ââåäèòå èíäåêñ",

                Location = new System.Drawing.Point(20, 250),
                Size = new System.Drawing.Size(400, 20)
            };
            TextBox newTextBox1 = new()
            {
                Location = new System.Drawing.Point(20, 280),
                Size = new System.Drawing.Size(200, 20)
            };

            newTextBox1.KeyDown += (sender, e) => NewTextBox1_SymbolIndex_KeyDown(sender, e, newTextBox1, label);

            Controls.Add(label);
            Controls.Add(newTextBox1);
        }

        private void NewTextBox1_SymbolIndex_KeyDown(object sender, KeyEventArgs e, TextBox newTextBox1, Label label)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textFromTextBox1_1 = newTextBox1.Text;

                if (int.TryParse(textFromTextBox1_1, out int result) && result < textFromTextBox.Length)
                {
                    MessageBox.Show(textFromTextBox[result].ToString());
                }
                else
                {
                    MessageBox.Show("Íå ïîëó÷èëîñü");
                }
                ButtonEnabledTrue();
                Controls.Remove(newTextBox1);
                Controls.Remove(label);
                textFromTextBox1_1 = null;
                textFromTextBox1_2 = null;
            }
        }

        ////////////////////////////////////////////

        private void RowLengh_Click(object sender, EventArgs e)
        {
            textFromTextBox = textBox1.Text;
            MessageBox.Show(textFromTextBox.Length.ToString());
        }

        ////////////////////////////////////////////

        private void ColGlas_Click(object sender, EventArgs e)
        {
            textFromTextBox = textBox1.Text;
            int count = CountVowels(textFromTextBox);

            MessageBox.Show(count.ToString());
        }

        private int CountVowels(string str)
        {
            int count = 0;
            string vowels = "aeiouàå¸èîóûýþÿ"; 
            str = str.ToLower();
            foreach (char c in str)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }

        ////////////////////////////////////////////

        private void ColSogl_Click(object sender, EventArgs e)
        {
            textFromTextBox = textBox1.Text;
            int count = CountConsonants(textFromTextBox);

            MessageBox.Show(count.ToString());
        }

        private int CountConsonants(string str)
        {
            int count = 0;
            string consonants = "bcdfghjklmnpqrstvwxyzáâãäæçéêëìíïðñòôõö÷øù";
            str = str.ToLower();
            foreach (char c in str)
            {
                if (consonants.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }

        ////////////////////////////////////////////

        private void ColPredl_Click(object sender, EventArgs e)
        {
            textFromTextBox = textBox1.Text;
            int count = CountSentences(textFromTextBox);

            MessageBox.Show(count.ToString());
        }
        private int CountSentences(string str)
        {
            char[] separators = { '.', '!', '?' };
            string[] sentences = str.Split(separators);
            sentences = sentences.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            int count = sentences.Length;
            return count;
        }

        ////////////////////////////////////////////


        private void ColWords_Click(object sender, EventArgs e)
        {
            textFromTextBox = textBox1.Text;
            int count = CountWords(textFromTextBox);

            MessageBox.Show(count.ToString());
        }
        private int CountWords(string str)
        {
            char[] separators = { ' ', ',', '.', '!', '?', ':', ';', '-', '—', '(', ')', '*', '#', '¹', '&' };
            string[] words = str.Split(separators);
            words = words.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            int count = words.Length;
            return count;
        }

        ////////////////////////////////////////////

        private void ButtonEnabledFalse()
        {
            PodstokaChange.Enabled = false;
            PodstokaDelete.Enabled = false;
            SymbolIndex.Enabled = false;
            RowLengh.Enabled = false;
            ColGlas.Enabled = false;
            ColSogl.Enabled = false;
            ColPredl.Enabled = false;
            ColWords.Enabled = false;
            textBox1.Enabled = false;
        }
        private void ButtonEnabledTrue()
        {
            PodstokaChange.Enabled = true;
            PodstokaDelete.Enabled = true;
            SymbolIndex.Enabled = true;
            RowLengh.Enabled = true;
            ColGlas.Enabled = true;
            ColSogl.Enabled = true;
            ColPredl.Enabled = true;
            ColWords.Enabled = true;
            textBox1.Enabled = true;
        }
    }
}