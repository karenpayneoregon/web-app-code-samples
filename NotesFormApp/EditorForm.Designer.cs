namespace NotesFormApp
{
    partial class EditorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.IdentifierLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BodyTextTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DueDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CompletetedCheckBox = new System.Windows.Forms.CheckBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Note  id";
            // 
            // IdentifierLabel
            // 
            this.IdentifierLabel.AutoSize = true;
            this.IdentifierLabel.Location = new System.Drawing.Point(123, 33);
            this.IdentifierLabel.Name = "IdentifierLabel";
            this.IdentifierLabel.Size = new System.Drawing.Size(50, 20);
            this.IdentifierLabel.TabIndex = 1;
            this.IdentifierLabel.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "BodyText";
            // 
            // BodyTextTextBox
            // 
            this.BodyTextTextBox.Location = new System.Drawing.Point(54, 103);
            this.BodyTextTextBox.Name = "BodyTextTextBox";
            this.BodyTextTextBox.Size = new System.Drawing.Size(710, 27);
            this.BodyTextTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Due Date";
            // 
            // DueDateDateTimePicker
            // 
            this.DueDateDateTimePicker.Location = new System.Drawing.Point(54, 171);
            this.DueDateDateTimePicker.Name = "DueDateDateTimePicker";
            this.DueDateDateTimePicker.Size = new System.Drawing.Size(250, 27);
            this.DueDateDateTimePicker.TabIndex = 5;
            // 
            // CompletetedCheckBox
            // 
            this.CompletetedCheckBox.AutoSize = true;
            this.CompletetedCheckBox.Location = new System.Drawing.Point(54, 226);
            this.CompletetedCheckBox.Name = "CompletetedCheckBox";
            this.CompletetedCheckBox.Size = new System.Drawing.Size(105, 24);
            this.CompletetedCheckBox.TabIndex = 6;
            this.CompletetedCheckBox.Text = "Completed";
            this.CompletetedCheckBox.UseVisualStyleBackColor = true;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(54, 293);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(250, 28);
            this.CategoryComboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(53, 356);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(251, 29);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(513, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.CompletetedCheckBox);
            this.Controls.Add(this.DueDateDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BodyTextTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IdentifierLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label IdentifierLabel;
        private Label label2;
        private TextBox BodyTextTextBox;
        private Label label3;
        private DateTimePicker DueDateDateTimePicker;
        private CheckBox CompletetedCheckBox;
        private ComboBox CategoryComboBox;
        private Label label4;
        private Button SaveButton;
        private Button button1;
    }
}