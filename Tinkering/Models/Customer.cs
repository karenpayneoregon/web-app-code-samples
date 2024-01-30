using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tinkering.Models;
public class Customer :INotifyPropertyChanged
{
    private string _invoiceNumber;
    public int Id { get; set; }
    public string PreFix { get; set; }
    public string Name { get; set; }
    public string CurrentInvoice => $"{PreFix}{InvoiceNumber}";

    public string InvoiceNumber
    {
        get => _invoiceNumber;
        set
        {
            if (value == _invoiceNumber) return;
            _invoiceNumber = value.Replace(PreFix,"");
            OnPropertyChanged();
            OnPropertyChanged(nameof(CurrentInvoice));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}