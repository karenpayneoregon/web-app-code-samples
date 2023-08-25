using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TelerikSamples2.Models;

#pragma warning disable CS8625, CS8612, CS8618
public class Customer : INotifyPropertyChanged
{
    private int _id;    
    private string _name;
    private string _address;

    public Customer(int identifier)
    {
        CustomerId = identifier;
    }

    public Customer()
    {
        
    }
    public int CustomerId
    {
        get => _id;
        set
        {
            if (value == _id) return;
            _id = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            if (value == _name) return;
            _name = value;
            OnPropertyChanged();
        }
    }

    public string Address
    {
        get => _address;
        set
        {
            if (value == _address) return;
            _address = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}