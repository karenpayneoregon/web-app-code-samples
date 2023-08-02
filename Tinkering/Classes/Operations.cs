using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinkering.Models;

namespace Tinkering.Classes;

public class Demo
{

    public static void Remove()
    {
        Customer customer = new Customer();
        Operations<Customer> customerOperations = new();
        customerOperations.Remove(customer);
        customerOperations.Add(customer);

        Order order = new Order();
        Operations<Order> orderOperations = new();
        orderOperations.Remove(order);
    }
}
public interface IOperations<T>
{
    bool Remove(T sender);
    T Add(in T sender);
}

public class Operations<T> : IOperations<T>
{
    public bool Remove(T sender)
    {
        return true;
    }

    public T Add(in T sender)
    {
        return sender;
    }
}
