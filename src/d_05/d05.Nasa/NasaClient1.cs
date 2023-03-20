public class NasaClient1 : INasaClient<int, string>
{
    public string GetAsync(int input)
    {
        return input.ToString() + "R";
    }
}

public class NasaClient2 : INasaClient<string, bool>
{
    public bool GetAsync(string input)
    {
        return input.Contains('a');
    }
}

public class NasaClient3 : INasaClient<bool, string>
{
    public string GetAsync(bool input)
    {
        return input ? "YES" : "TRUE";
    }
}
