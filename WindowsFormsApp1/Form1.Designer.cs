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
            this.saveButton = new System.Windows.Forms.Button();
            this.infoTB = new System.Windows.Forms.TextBox();
            this.fileCategoriesButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(34, 397);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(34, 35);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(100, 20);
            this.usernameTB.TabIndex = 2;
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(160, 35);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(100, 20);
            this.passwordTB.TabIndex = 3;
            this.passwordTB.UseSystemPasswordChar = true;
            // 
            // StatusTB
            // 
            this.StatusTB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StatusTB.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTB.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusTB.Location = new System.Drawing.Point(34, 207);
            this.StatusTB.Multiline = true;
            this.StatusTB.Name = "StatusTB";
            this.StatusTB.ReadOnly = true;
            this.StatusTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusTB.Size = new System.Drawing.Size(613, 184);
            this.StatusTB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(715, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // categoryList
            // 
            this.categoryList.FormattingEnabled = true;
            this.categoryList.Location = new System.Drawing.Point(304, 26);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(120, 134);
            this.categoryList.TabIndex = 10;
            // 
            // searchList
            // 
            this.searchList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SearchValue,
            this.NumResults});
            this.searchList.FullRowSelect = true;
            this.searchList.GridLines = true;
            this.searchList.Location = new System.Drawing.Point(465, 26);
            this.searchList.Name = "searchList";
            this.searchList.Size = new System.Drawing.Size(182, 134);
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
            this.categoryButton.Location = new System.Drawing.Point(34, 137);
            this.categoryButton.Name = "categoryButton";
            this.categoryButton.Size = new System.Drawing.Size(100, 23);
            this.categoryButton.TabIndex = 12;
            this.categoryButton.Text = "Add Category";
            this.categoryButton.UseVisualStyleBackColor = true;
            this.categoryButton.Click += new System.EventHandler(this.categoryButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(160, 156);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 23);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Add search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Input category name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Input search value";
            // 
            // searchValueTB
            // 
            this.searchValueTB.Location = new System.Drawing.Point(160, 89);
            this.searchValueTB.Name = "searchValueTB";
            this.searchValueTB.Size = new System.Drawing.Size(100, 20);
            this.searchValueTB.TabIndex = 16;
            // 
            // numResultsTB
            // 
            this.numResultsTB.Location = new System.Drawing.Point(160, 130);
            this.numResultsTB.Name = "numResultsTB";
            this.numResultsTB.Size = new System.Drawing.Size(100, 20);
            this.numResultsTB.TabIndex = 17;
            // 
            // categoryTB
            // 
            this.categoryTB.Location = new System.Drawing.Point(37, 110);
            this.categoryTB.Name = "categoryTB";
            this.categoryTB.Size = new System.Drawing.Size(100, 20);
            this.categoryTB.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "and number of results";
            // 
            // cat_deleteButton
            // 
            this.cat_deleteButton.Location = new System.Drawing.Point(304, 166);
            this.cat_deleteButton.Name = "cat_deleteButton";
            this.cat_deleteButton.Size = new System.Drawing.Size(120, 23);
            this.cat_deleteButton.TabIndex = 20;
            this.cat_deleteButton.Text = "Delete category";
            this.cat_deleteButton.UseVisualStyleBackColor = true;
            this.cat_deleteButton.Click += new System.EventHandler(this.cat_deleteButton_Click);
            // 
            // search_deleteButton
            // 
            this.search_deleteButton.Location = new System.Drawing.Point(465, 166);
            this.search_deleteButton.Name = "search_deleteButton";
            this.search_deleteButton.Size = new System.Drawing.Size(182, 23);
            this.search_deleteButton.TabIndex = 21;
            this.search_deleteButton.Text = "Delete search item";
            this.search_deleteButton.UseVisualStyleBackColor = true;
            this.search_deleteButton.Click += new System.EventHandler(this.search_deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(469, 397);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(178, 23);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Save to specific folder (optional)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // infoTB
            // 
            this.infoTB.Location = new System.Drawing.Point(680, 130);
            this.infoTB.Multiline = true;
            this.infoTB.Name = "infoTB";
            this.infoTB.ReadOnly = true;
            this.infoTB.Size = new System.Drawing.Size(118, 195);
            this.infoTB.TabIndex = 23;
            // 
            // fileCategoriesButton
            // 
            this.fileCategoriesButton.Location = new System.Drawing.Point(28, 166);
            this.fileCategoriesButton.Name = "fileCategoriesButton";
            this.fileCategoriesButton.Size = new System.Drawing.Size(126, 23);
            this.fileCategoriesButton.TabIndex = 24;
            this.fileCategoriesButton.Text = "Add categories from file";
            this.fileCategoriesButton.UseVisualStyleBackColor = true;
            this.fileCategoriesButton.Click += new System.EventHandler(this.fileCategoriesButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fileCategoriesButton);
            this.Controls.Add(this.infoTB);
            this.Controls.Add(this.saveButton);
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
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox infoTB;
        private System.Windows.Forms.Button fileCategoriesButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

