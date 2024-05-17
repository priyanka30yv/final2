using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace ADOWinApps
{
    public partial class frmDataSource : Form
    {
        public frmDataSource()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con =new OleDbConnection("Data Source=DESKTOP-NJ7SO96\\SQLEXPRESS;Initial Catalog=Greysoft;Provider=MSOLedbSQL;user id=sa;password=greysoft");
                con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into singer values(?,?,?)";
            cmd.Parameters.Add("1", OleDbType.Integer);
            cmd.Parameters.Add("2", OleDbType.VarChar, 20);
            cmd.Parameters.Add("3", OleDbType.VarChar, 20);
            cmd.Parameters["1"].Value = 179;
            cmd.Parameters["2"].Value = "aman";
            cmd.Parameters["3"].Value = "tollywood";
            cmd.Connection = con;   
            int ans = cmd.ExecuteNonQuery();
            if (ans == 1)
                MessageBox.Show("inserted");
            else
                MessageBox.Show("not inserted");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NJ7SO96\\SQLEXPRESS;Initial Catalog=Greysoft;user id=sa;password=greysoft");
            SqlDataAdapter da = new SqlDataAdapter("select * from singer", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            DataRow[] dr = ds.Tables[0].Select("songtype='classical'");
            DataTable dt1 = ds.Tables[0];
            DataTable dt2=new DataTable();
            for(int i=0;i<dt1.Columns.Count;i++)
            {
                dt2.Columns.Add(dt1.Columns[i].ColumnName, dt1.Columns[i].DataType);
            }
            foreach(DataRow x in dr)
            {
                DataRow myrow=dt2.NewRow();
                myrow[0] = x[0];
                myrow[1] = x[1];
                myrow[2] = x[2];
                dt2.Rows.Add(myrow);
            }
            MessageBox.Show(dt2.Columns.Count.ToString());
            dataGridView2.DataSource= dt2;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NJ7SO96\\SQLEXPRESS;Initial Catalog=Greysoft;user id=sa;password=greysoft");
            SqlDataAdapter da = new SqlDataAdapter("select * from singer", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            DataView dataView = new DataView(ds.Tables[0]);
            dataView.Sort="songtype";
            dataGridView2.DataSource = dataView;

        }

        private void frmDataSource_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'newsPaperDataSet.NewsArticle' table. You can move, or remove it, as needed.
            this.newsArticleTableAdapter.Fill(this.newsPaperDataSet.NewsArticle);

        }
    }
}
