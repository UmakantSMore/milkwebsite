using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLayer;
   

public partial class ManangeDeliveryboyCustomerList : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
    private void Binddeliveryboy()
    {
        DataTable dtStudent = new DataTable();
        Cls_deliveryboy_b obj = new Cls_deliveryboy_b();
        dtStudent = obj.SelectAll();
        ddlDeliveryboy.Items.Clear();
        if (dtStudent != null)
        {
            if (dtStudent.Rows.Count > 0)
            {
                ddlDeliveryboy.DataSource = dtStudent;
                ddlDeliveryboy.DataTextField = "Name";
                ddlDeliveryboy.DataValueField = "id";
                ddlDeliveryboy.DataBind();
            }
            else
            {

            }
        }
        else
        {

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack )
        {
            Binddeliveryboy();
        }
    }

    protected void ddlDeliveryboy_SelectedIndexChanged(object sender, EventArgs e)
    {
        // deliveryboy_customerList
        DataTable dtStudent = new DataTable();
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "deliveryboy_customerList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fk_deliveryboyId",Convert.ToInt64(ddlDeliveryboy.SelectedValue.ToString()));
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtStudent);
        }
        catch { }
        finally { con.Close(); }
        if (dtStudent != null)
        {
            if (dtStudent.Rows.Count > 0)
            {
                repCustomer.DataSource = dtStudent;
                repCustomer.DataBind();
            }
            else
            {
                repCustomer.DataSource = null;
                repCustomer.DataBind();
            }
        }
        else
        {
            repCustomer.DataSource = null;
            repCustomer.DataBind();
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        Int64 srrr = int.Parse((item.FindControl("lblsr") as Label).Text);
        int t = 0;
        try
        {
            con.Open();
            string s = " update tbl_deliveryboyCustomerlist set isdelete=1 where id=" + srrr + "";
            SqlCommand cmd = new SqlCommand(s, con);
            t = cmd.ExecuteNonQuery();
        }
        catch { }
        finally { con.Close(); }
        spnMessage.Visible = true;
        if (t > 0)
        {
            ddlDeliveryboy_SelectedIndexChanged(null, null);
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Customer Remove Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Customer Not Remove";
        }
    }
}