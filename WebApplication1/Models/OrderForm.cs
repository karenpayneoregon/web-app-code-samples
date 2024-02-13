using System.ComponentModel.DataAnnotations;
using WebApplication1.Classes;

namespace WebApplication1.Models;

public class OrderForm
{
    public int Id { get; set; }
    public string? BusinessName { get; set; }
    public string? AccountNumber { get; set; }
    public string? ContactPerson { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    [RequiredNotEmpty]
    public string? CurrentState { get; set; }
    public string? ZipCode { get; set; }

    public int Quantity { get; set; }

    [RequiredNotEmpty]
    public string FormType { get; set; }
}
