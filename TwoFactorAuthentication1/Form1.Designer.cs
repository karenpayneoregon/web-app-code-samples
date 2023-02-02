namespace TwoFactorAuthentication1;

partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CodeTextBoxTop = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ElapsedLabel = new System.Windows.Forms.Label();
            this.CreatedTimeLabel = new System.Windows.Forms.Label();
            this.EmailAddressTextBox = new System.Windows.Forms.TextBox();
            this.CodeTextBoxBottom = new System.Windows.Forms.TextBox();
            this.VerificationButton = new System.Windows.Forms.Button();
            this.InvalidCodeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PassLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Secret";
            this.textBox1.Size = new System.Drawing.Size(433, 27);
            this.textBox1.TabIndex = 1;
            // 
            // CodeTextBoxTop
            // 
            this.CodeTextBoxTop.Location = new System.Drawing.Point(16, 96);
            this.CodeTextBoxTop.Name = "CodeTextBoxTop";
            this.CodeTextBoxTop.PlaceholderText = "Code";
            this.CodeTextBoxTop.Size = new System.Drawing.Size(433, 27);
            this.CodeTextBoxTop.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ElapsedLabel);
            this.groupBox1.Controls.Add(this.CreatedTimeLabel);
            this.groupBox1.Controls.Add(this.CodeTextBoxTop);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 165);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Out";
            // 
            // ElapsedLabel
            // 
            this.ElapsedLabel.AutoSize = true;
            this.ElapsedLabel.Location = new System.Drawing.Point(242, 28);
            this.ElapsedLabel.Name = "ElapsedLabel";
            this.ElapsedLabel.Size = new System.Drawing.Size(50, 20);
            this.ElapsedLabel.TabIndex = 5;
            this.ElapsedLabel.Text = "label1";
            // 
            // CreatedTimeLabel
            // 
            this.CreatedTimeLabel.AutoSize = true;
            this.CreatedTimeLabel.Location = new System.Drawing.Point(116, 28);
            this.CreatedTimeLabel.Name = "CreatedTimeLabel";
            this.CreatedTimeLabel.Size = new System.Drawing.Size(50, 20);
            this.CreatedTimeLabel.TabIndex = 4;
            this.CreatedTimeLabel.Text = "label1";
            // 
            // EmailAddressTextBox
            // 
            this.EmailAddressTextBox.Location = new System.Drawing.Point(20, 30);
            this.EmailAddressTextBox.Name = "EmailAddressTextBox";
            this.EmailAddressTextBox.Size = new System.Drawing.Size(246, 27);
            this.EmailAddressTextBox.TabIndex = 5;
            this.EmailAddressTextBox.Text = "billybob@gmail.com";
            // 
            // CodeTextBoxBottom
            // 
            this.CodeTextBoxBottom.Location = new System.Drawing.Point(20, 63);
            this.CodeTextBoxBottom.Name = "CodeTextBoxBottom";
            this.CodeTextBoxBottom.Size = new System.Drawing.Size(125, 27);
            this.CodeTextBoxBottom.TabIndex = 6;
            this.CodeTextBoxBottom.Text = "291540";
            // 
            // VerificationButton
            // 
            this.VerificationButton.Location = new System.Drawing.Point(282, 30);
            this.VerificationButton.Name = "VerificationButton";
            this.VerificationButton.Size = new System.Drawing.Size(163, 60);
            this.VerificationButton.TabIndex = 7;
            this.VerificationButton.Text = "Verify From db";
            this.VerificationButton.UseVisualStyleBackColor = true;
            this.VerificationButton.Click += new System.EventHandler(this.VerificationButton_Click);
            // 
            // InvalidCodeCheckBox
            // 
            this.InvalidCodeCheckBox.AutoSize = true;
            this.InvalidCodeCheckBox.Location = new System.Drawing.Point(20, 105);
            this.InvalidCodeCheckBox.Name = "InvalidCodeCheckBox";
            this.InvalidCodeCheckBox.Size = new System.Drawing.Size(140, 24);
            this.InvalidCodeCheckBox.TabIndex = 8;
            this.InvalidCodeCheckBox.Text = "Use invalid code";
            this.InvalidCodeCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PassLabel);
            this.groupBox2.Controls.Add(this.InvalidCodeCheckBox);
            this.groupBox2.Controls.Add(this.VerificationButton);
            this.groupBox2.Controls.Add(this.CodeTextBoxBottom);
            this.groupBox2.Controls.Add(this.EmailAddressTextBox);
            this.groupBox2.Location = new System.Drawing.Point(2, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 175);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "In";
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Location = new System.Drawing.Point(288, 97);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(50, 20);
            this.PassLabel.TabIndex = 9;
            this.PassLabel.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(498, 69);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(406, 324);
            this.listBox1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 495);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private Button button1;
    private TextBox textBox1;
    private Button button2;
    private TextBox CodeTextBoxTop;
    private GroupBox groupBox1;
    private TextBox EmailAddressTextBox;
    private TextBox CodeTextBoxBottom;
    private Button VerificationButton;
    private CheckBox InvalidCodeCheckBox;
    private GroupBox groupBox2;
    private Label CreatedTimeLabel;
    private Label ElapsedLabel;
    private System.Windows.Forms.Timer timer1;
    private Label PassLabel;
    private ListBox listBox1;
}
