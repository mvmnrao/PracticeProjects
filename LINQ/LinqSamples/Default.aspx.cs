using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace LinqSamples
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] names = { "Burke", "Connor", "Frank", 
                       "Everett", "Albert", "George", 
                       "Harris", "David" };

            //IEnumerable<string> Query = from Col in names
            //                            where Col.Length > 5 && Col.Length < 7
            //                            orderby Col descending
            //                            select Col.ToUpper();
            //IEnumerable<string> Query = names
            //                            .Where(s => s.Length > 5)
            //                            .OrderBy(s => s)
            //                            .Select(s => s.ToLower());

            //Func<DataTable, bool> filt=t => t.Rows

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            dt.Rows.Add("First Row", 1);
            dt.Rows.Add("Second Row", 2);

            IEnumerator drColl = dt.Rows.GetEnumerator();

            Func<DataTable, DataRow> filterTable = tbl => from r in tbl
                                                          where r[1] == "1"
                                                          select r;
                                              

            Func<DataTable, int> rowsCount = tbl => tbl.Rows.Count;

            LblOutPut.Text += "No.Of Rows: " + rowsCount(dt) + "<br />";

            Func<int, int> sampleFun = i => i + 5;

            LblOutPut.Text += sampleFun(11).ToString() + "<br />";

            Func<string, bool> filter = s => s.Length > 5 && s.Length < 7;
            Func<string, string> orderBy = s => s;
            Func<string, string> select = s => s.ToUpper();

            IEnumerable<string> Query = names
                .Where(filter).OrderBy(orderBy).Select(select);

            LblOutPut.Text += "-------- First Out Put --------<br />";
            foreach (string str in Query)
                LblOutPut.Text = LblOutPut.Text + str + "<br />";
            LblOutPut.Text += "<br />-----<br />";

            LblOutPut.Text += "-------- Second Out Put --------<br />";
            Func<int, bool> f = n => n < 5;
            LblOutPut.Text += "<br />" + f(10);
            LblOutPut.Text += "<br />-----<br />";

            Expression<Func<int, bool>> filterExpression = n => n > 5;
            LblOutPut.Text += "-------- Thired Out Put --------<br />";
            LblOutPut.Text += filterExpression.ToString() +
                                " NodeType:" + filterExpression.NodeType.ToString() +
                                " Body.NodeType:" + filterExpression.Body.NodeType.ToString() +
                                " BinaryExpresssion.Left:" + ((BinaryExpression)filterExpression.Body).Left.ToString();
                                //" Type:" + filterExpression.Type.ToString();
            BinaryExpression body = (BinaryExpression)filterExpression.Body;

            LblOutPut.Text += "<br />-----<br />";
        }
    }
}
