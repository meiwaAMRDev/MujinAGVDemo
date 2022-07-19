using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MujinAGVDemo
{
    static class Program
    {
        static readonly Logger logger = LogManager.GetLogger("ProgramLogger");
        
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            logger.Info($"{Application.ProductName}{Application.ProductVersion}を開始します。");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
            Application.Run(new frmLight());
            logger.Info($"{Application.ProductName}{Application.ProductVersion}を終了します。");
        }
    }
}
