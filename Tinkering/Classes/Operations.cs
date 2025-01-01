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


public static class RangeHelpers
{
    public static List<Container<T>> Get<T>(List<T> list) =>
        list.Select((element, index) => new Container<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(Enumerable.Range(0, list.Count).Reverse().ToList()[index], true),
            MonthIndex = index + 1
        }).ToList();
}