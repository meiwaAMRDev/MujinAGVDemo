using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MujinAGVDemo.Control
{
    public partial class LabelAndTextBox : UserControl
    {
        public LabelAndTextBox()
        {
            InitializeComponent();
        }

        public void SetLabel(string label)
        {
            this.label.Text = label;
        }
        public string GetLabel()
        {
            return this.label.Text;
        }
        public void SetText(string text)
        {
            this.textBox.Text = text;
        }
        public string GetText()
        {
            return this.textBox.Text;
        }
    }
}
