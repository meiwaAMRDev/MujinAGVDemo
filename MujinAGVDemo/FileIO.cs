using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;

namespace MujinAGVDemo
{
    public class FileIO
    {
        /// <summary>
        /// ファイルを読み込む
        /// </summary>
        /// <param name="filePath">ファイルのパス</param>
        /// <param name="allLines">読み込んだ全ての行データ</param>
        /// <returns>読込成功ならtrue</returns>
        public bool TryGetAllLines(string filePath, out List<string> allLines)
        {
            var result = false;
            allLines = new List<string>();
            try
            {
                if (!File.Exists(filePath))
                {
                    result = false;
                    Messages.Logger.Error(string.Format("ファイルが存在しません。:{0}", filePath));
                }
                allLines = File.ReadAllLines(filePath, Encoding.UTF8).ToList();
                if (allLines.Count == 0)
                {
                    result = false;
                    Messages.Logger.Error(string.Format("ファイル内にデータがありません。:{0}", filePath));
                }
            }
            catch (Exception ex)
            {
                Messages.Logger.Error(ex);
            }

            result = true;
            return result;
        }
        public void SaveSetting(string filePath, ParamSettings param)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ParamSettings));
            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                serializer.Serialize(sw, param);
                sw.Close();
            }
        }
        public bool TryLoadSetting(string filePath, out ParamSettings param)
        {
            var result = false;
            param = new ParamSettings();
            if (!File.Exists(filePath))
            {
                Messages.Logger.Error(string.Format("ファイルが存在しません。:{0}", filePath));
                return result;
            }

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ParamSettings));
            using (var sr = new StreamReader(filePath, Encoding.UTF8))
            {
                param = (ParamSettings)serializer.Deserialize(sr);
                result = true;
            }
            return result;
        }
    }
}
