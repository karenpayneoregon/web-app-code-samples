namespace TelerikWinFormsApp1;

partial class RadForm1
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
        radButton1 = new Telerik.WinControls.UI.RadButton();
        breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
        ((System.ComponentModel.ISupportInitialize)radButton1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this).BeginInit();
        SuspendLayout();
        // 
        // radButton1
        // 
        radButton1.Location = new System.Drawing.Point(25, 36);
        radButton1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
        radButton1.Name = "radButton1";
        radButton1.Size = new System.Drawing.Size(172, 38);
        radButton1.TabIndex = 0;
        radButton1.Text = "radButton1";
        radButton1.ThemeName = "Breeze";
        // 
        // RadForm1
        // 
        AutoScaleBaseSize = new System.Drawing.Size(8, 20);
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(392, 437);
        Controls.Add(radButton1);
        Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        Name = "RadForm1";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "RadForm1";
        ThemeName = "Breeze";
        ((System.ComponentModel.ISupportInitialize)radButton1).EndInit();
        ((System.ComponentModel.ISupportInitialize)this).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Telerik.WinControls.UI.RadButton radButton1;
    private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
}