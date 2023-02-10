namespace SeriLogConditional.Classes;

public class Debug
{
    public bool LogSqlCommand { get; set; }
}

public class LogRoot
{
    public Debug Debug { get; set; }
}