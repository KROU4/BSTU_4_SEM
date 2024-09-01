namespace Lab1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PodstokaChange = new System.Windows.Forms.Button();
            this.PodstokaDelete = new System.Windows.Forms.Button();
            this.SymbolIndex = new System.Windows.Forms.Button();
            this.RowLengh = new System.Windows.Forms.Button();
            this.ColGlas = new System.Windows.Forms.Button();
            this.ColSogl = new System.Windows.Forms.Button();
            this.ColPredl = new System.Windows.Forms.Button();
            this.ColWords = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(776, 61);
            this.textBox1.TabIndex = 0;
            // 
            // PodstokaChange
            // 
            this.PodstokaChange.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PodstokaChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PodstokaChange.Location = new System.Drawing.Point(12, 90);
            this.PodstokaChange.Name = "PodstokaChange";
            this.PodstokaChange.Size = new System.Drawing.Size(375, 29);
            this.PodstokaChange.TabIndex = 1;
            this.PodstokaChange.Text = "замена подстроки на другую подстроку";
            this.PodstokaChange.UseVisualStyleBackColor = false;
            this.PodstokaChange.Click += new System.EventHandler(this.PodstokaChange_Click);
            // 
            // PodstokaDelete
            // 
            this.PodstokaDelete.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PodstokaDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PodstokaDelete.Location = new System.Drawing.Point(413, 90);
            this.PodstokaDelete.Name = "PodstokaDelete";
            this.PodstokaDelete.Size = new System.Drawing.Size(375, 29);
            this.PodstokaDelete.TabIndex = 2;
            this.PodstokaDelete.Text = "удаление заданных подстрок ";
            this.PodstokaDelete.UseVisualStyleBackColor = false;
            this.PodstokaDelete.Click += new System.EventHandler(this.PodstokaDelete_Click);
            // 
            // SymbolIndex
            // 
            this.SymbolIndex.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SymbolIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SymbolIndex.Location = new System.Drawing.Point(12, 125);
            this.SymbolIndex.Name = "SymbolIndex";
            this.SymbolIndex.Size = new System.Drawing.Size(375, 29);
            this.SymbolIndex.TabIndex = 3;
            this.SymbolIndex.Text = "получение символа по индексу";
            this.SymbolIndex.UseVisualStyleBackColor = false;
            this.SymbolIndex.Click += new System.EventHandler(this.SymbolIndex_Click);
            // 
            // RowLengh
            // 
            this.RowLengh.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RowLengh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RowLengh.Location = new System.Drawing.Point(413, 125);
            this.RowLengh.Name = "RowLengh";
            this.RowLengh.Size = new System.Drawing.Size(375, 29);
            this.RowLengh.TabIndex = 4;
            this.RowLengh.Text = "длина строки";
            this.RowLengh.UseVisualStyleBackColor = false;
            this.RowLengh.Click += new System.EventHandler(this.RowLengh_Click);
            // 
            // ColGlas
            // 
            this.ColGlas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ColGlas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColGlas.Location = new System.Drawing.Point(12, 160);
            this.ColGlas.Name = "ColGlas";
            this.ColGlas.Size = new System.Drawing.Size(375, 29);
            this.ColGlas.TabIndex = 5;
            this.ColGlas.Text = "количество гласных";
            this.ColGlas.UseVisualStyleBackColor = false;
            this.ColGlas.Click += new System.EventHandler(this.ColGlas_Click);
            // 
            // ColSogl
            // 
            this.ColSogl.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ColSogl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColSogl.Location = new System.Drawing.Point(413, 160);
            this.ColSogl.Name = "ColSogl";
            this.ColSogl.Size = new System.Drawing.Size(375, 29);
            this.ColSogl.TabIndex = 6;
            this.ColSogl.Text = "количество согласных";
            this.ColSogl.UseVisualStyleBackColor = false;
            this.ColSogl.Click += new System.EventHandler(this.ColSogl_Click);
            // 
            // ColPredl
            // 
            this.ColPredl.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ColPredl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColPredl.Location = new System.Drawing.Point(12, 195);
            this.ColPredl.Name = "ColPredl";
            this.ColPredl.Size = new System.Drawing.Size(375, 29);
            this.ColPredl.TabIndex = 7;
            this.ColPredl.Text = "количество предложений";
            this.ColPredl.UseVisualStyleBackColor = false;
            this.ColPredl.Click += new System.EventHandler(this.ColPredl_Click);
            // 
            // ColWords
            // 
            this.ColWords.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ColWords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColWords.Location = new System.Drawing.Point(413, 195);
            this.ColWords.Name = "ColWords";
            this.ColWords.Size = new System.Drawing.Size(375, 29);
            this.ColWords.TabIndex = 8;
            this.ColWords.Text = "количество слов в строке";
            this.ColWords.UseVisualStyleBackColor = false;
            this.ColWords.Click += new System.EventHandler(this.ColWords_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(800, 362);
            this.Controls.Add(this.ColWords);
            this.Controls.Add(this.ColPredl);
            this.Controls.Add(this.ColSogl);
            this.Controls.Add(this.ColGlas);
            this.Controls.Add(this.RowLengh);
            this.Controls.Add(this.SymbolIndex);
            this.Controls.Add(this.PodstokaDelete);
            this.Controls.Add(this.PodstokaChange);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button PodstokaChange;
        private Button PodstokaDelete;
        private Button SymbolIndex;
        private Button RowLengh;
        private Button ColGlas;
        private Button ColSogl;
        private Button ColPredl;
        private Button ColWords;
    }
}