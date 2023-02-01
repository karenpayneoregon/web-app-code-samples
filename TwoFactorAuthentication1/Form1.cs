using System.Diagnostics;
using TwoFactorAuthentication1.Classes;
using TwoFactorAuthNet;

namespace TwoFactorAuthentication1;

public partial class Form1 : Form
{
    private string _secret = "";
    private string _code = "";
    private readonly string _issuer = "OED";

    public Form1()
    {
        InitializeComponent();
    }

    private void CreateButton_Click(object sender, EventArgs e)
    {
        timer1.Enabled = false;
        timer1.Enabled = true;
        StopWatcher.Instance.Stop();

        DataOperations.Period = 800; // just over 20 minutes
        var (secret, code) = DataOperations.Generate(EmailAddressTextBox.Text);
        _secret = secret;
        textBox1.Text = _secret;
        _code = code;

        CodeTextBoxTop.Text = _code;
        CodeTextBoxBottom.Text = _code;

        CreatedTimeLabel.Text = DateTime.Now.ToString("h:mm:ss tt");

        StopWatcher.Instance.Start();

    }



    private void VerificationButton_Click(object sender, EventArgs e)
    {
        var success = DataOperations.Simulation(
            textBox1.Text, 
            CodeTextBoxBottom.Text, 
            EmailAddressTextBox.Text,
            "Company1");

        PassLabel.Text = success ? "Accepted" : "Rejected";
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        
        ElapsedLabel.Text = StopWatcher.Instance.ElapsedFormatted;
    }
    
}
