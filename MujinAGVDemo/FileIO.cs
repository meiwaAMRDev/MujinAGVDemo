using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;

namespace MujinAGVDemo
{
    public static class FileIO
    {
        /// <summary>
        /// ファイルを読み込む
        /// </summary>
        /// <param name="filePath">ファイルのパス</param>
        /// <param name="allLines">読み込んだ全ての行データ</param>
        /// <returns>読込成功ならtrue</returns>
        public static bool TryGetAllLines(string filePath,out List<string> allLines)
        {
            var result = false;
            allLines = new List<string>();
            try
            {
                if (!File.Exists(filePath))
                {
                    result = false;
                    Setting.Logger.Error(string.Format("file not exist:{0}", filePath));
                }
                allLines = File.ReadAllLines(filePath, Encoding.UTF8).ToList();
            }
            catch(Exception ex)
            {
                Setting.Logger.Error(ex);
            }
            
            result = true;
            return result;
        }
    }
}
