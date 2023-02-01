using System.Diagnostics;
using TwoFactorAuthentication1.Classes;
using TwoFactorAuthentication1.Data;
using TwoFactorAuthNet;
using TwoFactorAuthNet.Providers.Time;

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

        var tfa = new TwoFactorAuth(_issuer);
        _secret = tfa.CreateSecret(180);
        textBox1.Text = _secret;
        _code = tfa.GetCode(_secret);
        textBox2.Text = _code;

        using var context = new Context();
        var item = context.Verifications.FirstOrDefault();
        item.EmailAddress = EmailAddressTextBox.Text;
        item.Secret = _secret;
        item.Code = _code;
        item.CreatedDate = DateTime.Now;
        item.CreatedTime = DateTime.Now.TimeOfDay;
        Debug.WriteLine(context.SaveChanges());
        CreatedTimeLabel.Text = DateTime.Now.ToString("h:mm:ss tt");

        StopWatcher.Instance.Start();

    }

    private void VerifyButton_Click(object sender, EventArgs e)
    {
        var tfa = new TwoFactorAuth(_issuer, 6);
        
        var success = tfa.VerifyCode(_secret , textBox2.Text);

        MessageBox.Show($"{success}");
    }

    private void VerificationButton_Click(object sender, EventArgs e)
    {
        using var context = new Context();
        var issuer = context.Organizations.FirstOrDefault(x => x.CompanyName == "Company1");
        var tfa = new TwoFactorAuth(issuer!.Issuer, 6);

        var item = context.Verifications.FirstOrDefault(x => x.EmailAddress == EmailAddressTextBox.Text);
        if (item != null)
        {
            CodeTextBox.Text = item.Code;
            if (InvalidCodeCheckBox.Checked)
            {
                CodeTextBox.Text += "0";
            }
            var success = tfa.VerifyCode(item.Secret, CodeTextBox.Text);
            MessageBox.Show($"{success}");
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        var testdate = DateTime.Now;
        var tp1 = new TestTimeProvider(testdate);
        var tp2 = new TestTimeProvider(testdate.AddSeconds(15));  
        var target = new TwoFactorAuth(timeprovider: tp1);

        try
        {
            target.EnsureCorrectTime(new[] { tp2 }, 16);
            Debug.WriteLine("Done");
        }
        catch (Exception exception) 
        {

            Debug.WriteLine(exception.Message);

        }
        
    }
    internal class TestTimeProvider : ITimeProvider
    {
        private readonly DateTime _time;

        public TestTimeProvider(DateTime time)
        {
            _time = time;
        }

        public Task<DateTime> GetTimeAsync()
        {
            return Task.FromResult(_time);
        }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        
        ElapsedLabel.Text = StopWatcher.Instance.ElapsedFormatted;
    }
}
