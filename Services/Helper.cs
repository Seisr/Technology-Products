namespace WebApp.Services;

public static class Helper
{
    public static string RandomString(int len)
    {
        string pattern = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] arr = new char[len];
        Random random = new Random();
        for (int i = 0; i < len; i++)
        {
            arr[i] = pattern[random.Next(0, pattern.Length)];
        }
        return string.Join(string.Empty, arr);
    }
}