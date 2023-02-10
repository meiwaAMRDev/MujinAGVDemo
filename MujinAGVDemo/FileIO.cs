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
            allLines = new List<string>();
            bool result;
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
        /// <summary>
        /// ファイルを保存する
        /// </summary>
        /// <param name="savePath">保存先ファイルパス</param>
        /// <param name="allLines">書き込む文字列のリスト</param>
        /// <returns>保存成功ならtrue</returns>
        public bool TrySaveAllLines(string savePath, List<string> allLines)
        {
            try
            {
                using (var sw = new StreamWriter(savePath, false, Encoding.UTF8))
                {
                    foreach (var line in allLines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.Logger.Error(ex);
                return false;
            }
            return true;
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
            try
            {

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
            catch (Exception ex)
            {
                do
                {
                    Messages.Logger.Error($"設定ファイル読込エラー[{ex.Message}][{ex.StackTrace}]");
                    ex = ex.InnerException;
                }
                while (ex != null);
                return false;
            }
        }
    }
}
