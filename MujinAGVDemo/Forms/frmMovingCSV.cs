using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MujinAGVDemo.Forms
{
    public partial class frmMovingCSV : Form
    {
        #region Private Parameter

        /// <summary>
        /// BindingListの宣言
        /// </summary>
        BindingList<MovingParam> _user_bind_list = new BindingList<MovingParam>();
        /// <summary>
        /// 読込先ファイルパス
        /// </summary>
        string loadPath = $"CSVSample/SampleCSV.csv";
        /// <summary>
        /// 保存先ファイルパス
        /// </summary>
        string savePath = $"CSVSample/SampleCSV.csv";
        private FileIO fileIO = new FileIO();

        #endregion Private Parameter

        #region Constructor

        public frmMovingCSV()
        {
            InitializeComponent();
        }
        public frmMovingCSV(string path)
        {
            InitializeComponent();
            loadPath = path;
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// 移動指示CSVを保存します。
        /// </summary>
        /// <param name="saveName">保存先ファイルパス</param>
        private void saveCSV(string saveName)
        {
            if (_user_bind_list == null)
            {
                MessageBox.Show("データがありません。");
                return;
            }

            //var list=dgvMovingParam.da
            //ファイルをオープンする
            using (var sw = new StreamWriter(saveName, false, Encoding.GetEncoding("Shift_JIS")))
            {
                var isFirst = true;
                _user_bind_list.ToList().ForEach(x =>
                {
                    if (isFirst)
                    {
                        sw.WriteLine(x.CSVHeader());
                        isFirst = false;
                    }

                    sw.WriteLine(x.CSVText());
                });
            }
        }
        /// <summary>
        /// 移動指示CSVを読み込みます。
        /// </summary>
        private void LoadCSV()
        {
            if (!fileIO.TryGetAllLines(loadPath, out var allLines))
            {
                MessageBox.Show("CSVファイルの読込に失敗しました。");
                return;
            }
            _user_bind_list.Clear();

            allLines.ForEach(x =>
            {
                var p = new MovingParam();
                if (p.TryParseToCSV(x))
                {
                    _user_bind_list.Add(p);
                }
            });

            dgvMovingParam.DataSource = _user_bind_list;
            dgvMovingParam.AutoResizeColumns();
        }

        #endregion Method

        #region Event

        private void frmMovingCSV_Load(object sender, EventArgs e)
        {
            textBoxLoadPath.Text = loadPath;
            textBoxSavePath.Text = savePath;

            LoadCSV();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _user_bind_list.Add(new MovingParam());

            dgvMovingParam.DataSource = _user_bind_list;
            dgvMovingParam.AutoResizeColumns();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveCSV(savePath);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCSV();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _user_bind_list.Clear();
        }

        private void textBoxSavePath_DragDrop(object sender, DragEventArgs e)
        {
            dragDrop(sender, e);
        }

        private void textBoxSavePath_DragEnter(object sender, DragEventArgs e)
        {
            dragEnter(e);
        }

        private void textBoxLoadPath_DragDrop(object sender, DragEventArgs e)
        {
            dragDrop(sender, e);
        }

        private void textBoxLoadPath_DragEnter(object sender, DragEventArgs e)
        {
            dragEnter(e);
        }

        private static void dragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたファイルの一覧を取得
            var sFileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (sFileName.Length <= 0)
            {
                return;
            }

            // ドロップ先がTextBoxであるかチェック
            var TargetTextBox = (TextBox)sender;

            if (TargetTextBox == null)
            {
                // TextBox以外のためイベントを何もせずイベントを抜ける。
                return;
            }

            // 現状のTextBox内のデータを削除
            TargetTextBox.Text = "";

            // TextBoxドラックされた文字列を設定
            TargetTextBox.Text = sFileName[0]; // 配列の先頭文字列を設定
        }

        private static void dragEnter(DragEventArgs e)
        {
            // ドラッグ中のファイルやディレクトリの取得
            var sFileName = (string[])e.Data.GetData(DataFormats.FileDrop);

            //ファイルがドラッグされている場合、
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 配列分ループ
                foreach (var sTemp in sFileName)
                {
                    // ファイルパスかチェック
                    if (File.Exists(sTemp) == false)
                    {
                        // ファイルパス以外なので何もしない
                        return;
                    }
                    else
                    {
                        break;
                    }
                }

                // カーソルを[+]へ変更する
                // ここでEffectを変更しないと、以降のイベント（Drop）は発生しない
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void textBoxSavePath_TextChanged(object sender, EventArgs e)
        {
            savePath = textBoxSavePath.Text.Replace("\"", "");
        }

        private void textBoxLoadPath_TextChanged(object sender, EventArgs e)
        {
            loadPath = textBoxLoadPath.Text.Replace("\"", "");
        }

        #endregion Event
    }
}
