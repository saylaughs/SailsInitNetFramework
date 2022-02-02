using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SailsInitNetFramework
{
    public class FileHelper
    {
        List<string> readList = null;
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> readFiles(string path)
        {
            StreamReader reader = new StreamReader(path, Encoding.UTF8); 
            string lines;
            readList = new List<string>();
            while ((lines = reader.ReadLine()) != null)
            {
                readList.Add(lines.ToString()+ "\r\n");
            }
            reader.Close();
            return readList;
        }
        /// <summary>
        /// 文件写入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="str"></param>
        public void writeFiles(string path, string str)
        {
            FileStream fs = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
        }
    }
}
