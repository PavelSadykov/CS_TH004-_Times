using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
namespace TH_004_DirectoryA_B;
class Program
{
    static void Main(string[] args)
    {


        // путь к каталогу A
        string pathA = @"C:\path\to\directory\A\";

        // путь к каталогу B
        string pathB = @"C:\path\to\directory\B\";

        // получаем информацию о последнем изменении файла в каталоге B
        string[] files = Directory.GetFiles(pathB, "*", SearchOption.TopDirectoryOnly);
        DateTime lastModified = DateTime.MinValue;
        foreach (string file in files)
        {
            DateTime modified = File.GetLastWriteTime(file);
            if (modified > lastModified)
            {
                lastModified = modified;
            }
        }

        // получаем информацию о последнем изменении файла в каталоге A
        DateTime lastModifiedA = File.GetLastWriteTime(pathA + "file.txt");

        // если файл в каталоге A был изменен позже, чем последний файл в каталоге B
        if (lastModifiedA > lastModified)
        {
            // создаем копию файла в каталоге B
            string fileName = Path.GetFileNameWithoutExtension("file.txt");
            string extension = Path.GetExtension("file.txt");
            string copyName = $"{fileName}_{DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")}{extension}";
            File.Copy(pathA + "file.txt", pathB + copyName);
        }
    }
}
