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
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ElapsedLabel = new System.Windows.Forms.Label();
            this.CreatedTimeLabel = new System.Windows.Forms.Label();
            this.EmailAddressTextBox = new System.Windows.Forms.TextBox();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.VerificationButton = new System.Windows.Forms.Button();
            this.InvalidCodeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PassLabel = new System.Windows.Forms.Label();
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Verify";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Code";
            this.textBox2.Size = new System.Drawing.Size(433, 27);
            this.textBox2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ElapsedLabel);
            this.groupBox1.Controls.Add(this.CreatedTimeLabel);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 207);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
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
            // CodeTextBox
            // 
            this.CodeTextBox.Location = new System.Drawing.Point(20, 63);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(125, 27);
            this.CodeTextBox.TabIndex = 6;
            this.CodeTextBox.Text = "291540";
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
            this.groupBox2.Controls.Add(this.CodeTextBox);
            this.groupBox2.Controls.Add(this.EmailAddressTextBox);
            this.groupBox2.Location = new System.Drawing.Point(2, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 175);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 421);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 10;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 495);
            this.Controls.Add(this.button3);
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
    private TextBox textBox2;
    private GroupBox groupBox1;
    private TextBox EmailAddressTextBox;
    private TextBox CodeTextBox;
    private Button VerificationButton;
    private CheckBox InvalidCodeCheckBox;
    private GroupBox groupBox2;
    private Button button3;
    private Label CreatedTimeLabel;
    private Label ElapsedLabel;
    private System.Windows.Forms.Timer timer1;
    private Label PassLabel;
}
