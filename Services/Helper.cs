using System.Security.Cryptography;
using System.Text;

namespace WebApp.Services;

public static class Helper
{
    public static byte[] Hash(string plaintext)
    {
        using (HashAlgorithm algorithm = SHA256.Create())
        {
            return algorithm.ComputeHash(Encoding.ASCII.GetBytes(plaintext));
        }
    }
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
    public static string Upload(IFormFile f, string root, int len)
    {
        string ext = Path.GetExtension(f.FileName);
        string fileName = RandomString(len - ext.Length) + ext;
        using (Stream stream = new FileStream(Path.Combine(root, fileName), FileMode.Create))
        {
            f.CopyTo(stream);
        }

        return fileName;
    }
    public static string Upload(IFormFile f, int len)
    {
        string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        return Upload(f, root, len);
    }
}