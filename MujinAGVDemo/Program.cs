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
        static Logger logger = LogManager.GetLogger("ProgramLogger");
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            logger.Info(Messages.StartMsg);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            logger.Info(Messages.EndMsg);
        }
    }
}
