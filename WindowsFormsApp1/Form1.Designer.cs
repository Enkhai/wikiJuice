namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.generateButton = new System.Windows.Forms.Button();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.StatusTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.categoryList = new System.Windows.Forms.ListBox();
            this.searchList = new System.Windows.Forms.ListView();
            this.SearchValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumResults = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchValueTB = new System.Windows.Forms.TextBox();
            this.numResultsTB = new System.Windows.Forms.TextBox();
            this.categoryTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cat_deleteButton = new System.Windows.Forms.Button();
            this.search_deleteButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.infoTB = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(51, 611);
            this.generateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(112, 35);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(51, 54);
            this.usernameTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(148, 26);
            this.usernameTB.TabIndex = 2;
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(240, 54);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(148, 26);
            this.passwordTB.TabIndex = 3;
            this.passwordTB.UseSystemPasswordChar = true;
            // 
            // StatusTB
            // 
            this.StatusTB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StatusTB.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTB.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusTB.Location = new System.Drawing.Point(51, 318);
            this.StatusTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StatusTB.Multiline = true;
            this.StatusTB.Name = "StatusTB";
            this.StatusTB.ReadOnly = true;
            this.StatusTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusTB.Size = new System.Drawing.Size(918, 281);
            this.StatusTB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1072, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // categoryList
            // 
            this.categoryList.FormattingEnabled = true;
            this.categoryList.ItemHeight = 20;
            this.categoryList.Location = new System.Drawing.Point(456, 40);
            this.categoryList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(178, 204);
            this.categoryList.TabIndex = 10;
            // 
            // searchList
            // 
            this.searchList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SearchValue,
            this.NumResults});
            this.searchList.FullRowSelect = true;
            this.searchList.GridLines = true;
            this.searchList.Location = new System.Drawing.Point(698, 40);
            this.searchList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchList.Name = "searchList";
            this.searchList.Size = new System.Drawing.Size(271, 204);
            this.searchList.TabIndex = 11;
            this.searchList.UseCompatibleStateImageBehavior = false;
            this.searchList.View = System.Windows.Forms.View.Details;
            // 
            // SearchValue
            // 
            this.SearchValue.Text = "search value";
            this.SearchValue.Width = 77;
            // 
            // NumResults
            // 
            this.NumResults.Text = "number of results";
            this.NumResults.Width = 95;
            // 
            // categoryButton
            // 
            this.categoryButton.Location = new System.Drawing.Point(51, 240);
            this.categoryButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.categoryButton.Name = "categoryButton";
            this.categoryButton.Size = new System.Drawing.Size(150, 35);
            this.categoryButton.TabIndex = 12;
            this.categoryButton.Text = "Add Category";
            this.categoryButton.UseVisualStyleBackColor = true;
            this.categoryButton.Click += new System.EventHandler(this.categoryButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(240, 240);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(150, 35);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Add search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Input category name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Input search value";
            // 
            // searchValueTB
            // 
            this.searchValueTB.Location = new System.Drawing.Point(240, 137);
            this.searchValueTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchValueTB.Name = "searchValueTB";
            this.searchValueTB.Size = new System.Drawing.Size(148, 26);
            this.searchValueTB.TabIndex = 16;
            // 
            // numResultsTB
            // 
            this.numResultsTB.Location = new System.Drawing.Point(240, 200);
            this.numResultsTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numResultsTB.Name = "numResultsTB";
            this.numResultsTB.Size = new System.Drawing.Size(148, 26);
            this.numResultsTB.TabIndex = 17;
            // 
            // categoryTB
            // 
            this.categoryTB.Location = new System.Drawing.Point(56, 169);
            this.categoryTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.categoryTB.Name = "categoryTB";
            this.categoryTB.Size = new System.Drawing.Size(148, 26);
            this.categoryTB.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "and number of results";
            // 
            // cat_deleteButton
            // 
            this.cat_deleteButton.Location = new System.Drawing.Point(456, 255);
            this.cat_deleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cat_deleteButton.Name = "cat_deleteButton";
            this.cat_deleteButton.Size = new System.Drawing.Size(180, 35);
            this.cat_deleteButton.TabIndex = 20;
            this.cat_deleteButton.Text = "Delete category";
            this.cat_deleteButton.UseVisualStyleBackColor = true;
            this.cat_deleteButton.Click += new System.EventHandler(this.cat_deleteButton_Click);
            // 
            // search_deleteButton
            // 
            this.search_deleteButton.Location = new System.Drawing.Point(698, 255);
            this.search_deleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.search_deleteButton.Name = "search_deleteButton";
            this.search_deleteButton.Size = new System.Drawing.Size(273, 35);
            this.search_deleteButton.TabIndex = 21;
            this.search_deleteButton.Text = "Delete search item";
            this.search_deleteButton.UseVisualStyleBackColor = true;
            this.search_deleteButton.Click += new System.EventHandler(this.search_deleteButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 611);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 35);
            this.button1.TabIndex = 22;
            this.button1.Text = "Save to specific folder (optional)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // infoTB
            // 
            this.infoTB.Location = new System.Drawing.Point(1020, 200);
            this.infoTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.infoTB.Multiline = true;
            this.infoTB.Name = "infoTB";
            this.infoTB.ReadOnly = true;
            this.infoTB.Size = new System.Drawing.Size(175, 298);
            this.infoTB.TabIndex = 23;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1200, 1050);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.infoTB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.search_deleteButton);
            this.Controls.Add(this.cat_deleteButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.categoryTB);
            this.Controls.Add(this.numResultsTB);
            this.Controls.Add(this.searchValueTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.categoryButton);
            this.Controls.Add(this.searchList);
            this.Controls.Add(this.categoryList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusTB);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.generateButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "wikiJuice: A Wikipedia source database generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox StatusTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox categoryList;
        private System.Windows.Forms.ListView searchList;
        private System.Windows.Forms.ColumnHeader SearchValue;
        private System.Windows.Forms.ColumnHeader NumResults;
        private System.Windows.Forms.Button categoryButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox searchValueTB;
        private System.Windows.Forms.TextBox numResultsTB;
        private System.Windows.Forms.TextBox categoryTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cat_deleteButton;
        private System.Windows.Forms.Button search_deleteButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox infoTB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

