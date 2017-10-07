using System.IO;
using System.Text;

namespace MonthlyDutyTable.Utils
{
    public static class FileUtils
    {
        public static void WriteToFile(this string data, string path)
        {
            File.WriteAllText(path, data, Encoding.UTF8);
        }
    }
}
