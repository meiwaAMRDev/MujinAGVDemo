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
        //BindingListの宣言
        BindingList<MovingParam> _user_bind_list = new BindingList<MovingParam>();
        string loadPath = $"CSVSample/SampleCSV.csv";
        private FileIO fileIO = new FileIO();

        public frmMovingCSV()
        {
            InitializeComponent();
        }

        private void frmMovingCSV_Load(object sender, EventArgs e)
        {
            dgvMovingParam.DataSource = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _user_bind_list.Add(new MovingParam());

            dgvMovingParam.DataSource = _user_bind_list;
            dgvMovingParam.AutoResizeColumns();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var saveName = $"CSVSample/SampleCSV.csv";
            saveCSV(saveName);
        }

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

        private void btnLoad_Click(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            _user_bind_list.Clear();
        }
    }
}
