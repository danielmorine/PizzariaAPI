using System.Text;

namespace Pizzaria.Infra.Data.Utils;

public static class StringUtils
{
    public static string GetValueFromFile(string value)
    {
        var connectionString = value;
        if (value.Contains('\\'))
        {
            using FileStream fs = File.Open(value, FileMode.Open);
            byte[] b = new byte[1024];
            UTF8Encoding temp = new(true);

            while (fs.Read(b, 0, b.Length) > 0)
            {
                connectionString = temp.GetString(b);
            }
        }

        return connectionString;
    }
}
