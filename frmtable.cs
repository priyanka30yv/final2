using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOWinApps
{
    public partial class frmtable : Form
    {
        public frmtable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable t = new DataTable();
            t.Columns.Add("instrumentName",typeof(string));
            t.Columns.Add("price",typeof(int));
            DataRow dr = t.NewRow();
            dr[0] = "harmonium";
            dr[1] = 30000;
            t.Rows.Add(dr);
            dr = t.NewRow();
            dr[0] = "guitar";
            dr[1] = 46200;
            t.Rows.Add(dr);
            dataGridView1.DataSource = t;
           // t.WriteXml("D:\\TRGDemos\\music.xml");
            DataSet ds = new DataSet();
            ds.Tables.Add(t);
            ds.WriteXml("D:\\TRGDemos\\music.xml");
            MessageBox.Show("data saved");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
