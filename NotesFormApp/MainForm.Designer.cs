namespace NotesFormApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddOneNoteButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LoadCategoriesButton = new System.Windows.Forms.Button();
            this.LoadNotesButton = new System.Windows.Forms.Button();
            this.CreatePopulateButton = new System.Windows.Forms.Button();
            this.NotesDataGridView = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.EditCurrentButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NotesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.EditCurrentButton);
            this.panel1.Controls.Add(this.AddOneNoteButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.LoadCategoriesButton);
            this.panel1.Controls.Add(this.LoadNotesButton);
            this.panel1.Controls.Add(this.CreatePopulateButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 86);
            this.panel1.TabIndex = 0;
            // 
            // AddOneNoteButton
            // 
            this.AddOneNoteButton.Location = new System.Drawing.Point(12, 51);
            this.AddOneNoteButton.Name = "AddOneNoteButton";
            this.AddOneNoteButton.Size = new System.Drawing.Size(137, 29);
            this.AddOneNoteButton.TabIndex = 3;
            this.AddOneNoteButton.Text = "Add one note";
            this.AddOneNoteButton.UseVisualStyleBackColor = true;
            this.AddOneNoteButton.Click += new System.EventHandler(this.AddOneNoteButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Mock add note";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MockedAddNoteButton_Click);
            // 
            // LoadCategoriesButton
            // 
            this.LoadCategoriesButton.Location = new System.Drawing.Point(159, 16);
            this.LoadCategoriesButton.Name = "LoadCategoriesButton";
            this.LoadCategoriesButton.Size = new System.Drawing.Size(137, 29);
            this.LoadCategoriesButton.TabIndex = 2;
            this.LoadCategoriesButton.Text = "Load categories";
            this.LoadCategoriesButton.UseVisualStyleBackColor = true;
            this.LoadCategoriesButton.Click += new System.EventHandler(this.LoadCategoriesButton_Click);
            // 
            // LoadNotesButton
            // 
            this.LoadNotesButton.Location = new System.Drawing.Point(302, 16);
            this.LoadNotesButton.Name = "LoadNotesButton";
            this.LoadNotesButton.Size = new System.Drawing.Size(137, 29);
            this.LoadNotesButton.TabIndex = 1;
            this.LoadNotesButton.Text = "Load notes";
            this.LoadNotesButton.UseVisualStyleBackColor = true;
            this.LoadNotesButton.Click += new System.EventHandler(this.LoadNotesButton_Click);
            // 
            // CreatePopulateButton
            // 
            this.CreatePopulateButton.Location = new System.Drawing.Point(12, 16);
            this.CreatePopulateButton.Name = "CreatePopulateButton";
            this.CreatePopulateButton.Size = new System.Drawing.Size(137, 29);
            this.CreatePopulateButton.TabIndex = 0;
            this.CreatePopulateButton.Text = "Generate data";
            this.CreatePopulateButton.UseVisualStyleBackColor = true;
            this.CreatePopulateButton.Click += new System.EventHandler(this.CreatePopulateButton_Click);
            // 
            // NotesDataGridView
            // 
            this.NotesDataGridView.AllowUserToAddRows = false;
            this.NotesDataGridView.AllowUserToDeleteRows = false;
            this.NotesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NotesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.NotesDataGridView.Location = new System.Drawing.Point(12, 50);
            this.NotesDataGridView.Name = "NotesDataGridView";
            this.NotesDataGridView.RowHeadersWidth = 51;
            this.NotesDataGridView.RowTemplate.Height = 29;
            this.NotesDataGridView.Size = new System.Drawing.Size(567, 188);
            this.NotesDataGridView.TabIndex = 1;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BodyText";
            this.Column2.HeaderText = "Body";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Completed";
            this.Column3.HeaderText = "Completed";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DueDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "Due by";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // CategoriesComboBox
            // 
            this.CategoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriesComboBox.FormattingEnabled = true;
            this.CategoriesComboBox.Location = new System.Drawing.Point(12, 12);
            this.CategoriesComboBox.Name = "CategoriesComboBox";
            this.CategoriesComboBox.Size = new System.Drawing.Size(232, 28);
            this.CategoriesComboBox.TabIndex = 2;
            // 
            // EditCurrentButton
            // 
            this.EditCurrentButton.Location = new System.Drawing.Point(159, 49);
            this.EditCurrentButton.Name = "EditCurrentButton";
            this.EditCurrentButton.Size = new System.Drawing.Size(137, 29);
            this.EditCurrentButton.TabIndex = 4;
            this.EditCurrentButton.Text = "Edit current";
            this.EditCurrentButton.UseVisualStyleBackColor = true;
            this.EditCurrentButton.Click += new System.EventHandler(this.EditCurrentButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 450);
            this.Controls.Add(this.CategoriesComboBox);
            this.Controls.Add(this.NotesDataGridView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notes/TODO";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NotesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button CreatePopulateButton;
        private DataGridView NotesDataGridView;
        private Button LoadNotesButton;
        private Button LoadCategoriesButton;
        private ComboBox CategoriesComboBox;
        private Button button1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewCheckBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button AddOneNoteButton;
        private Button EditCurrentButton;
    }
}