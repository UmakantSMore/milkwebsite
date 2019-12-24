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
public partial class ManageAssignCustomer : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
    private void BindCustomer()
    {
        DataTable dtStudent = new DataTable();
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "CustomerNotAssignToDeliveryboy_list";
            cmd.CommandType = CommandType.StoredProcedure;
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
                repCustomer .DataSource = dtStudent;
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
       

        if (!Page.IsPostBack)
        {
            BindCustomer();
            Binddeliveryboy();
            
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Student Record Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Student Record Inserted Successfully";
        }

        HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
        hPageTitle.InnerText = "Manage Registration";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            Int64 StoredId = 0;

            bool yes = false;
            foreach (RepeaterItem item in repCustomer .Items)
            {
                CheckBox chkContainer = (CheckBox)item.FindControl("IsActive");
                Label lblCustomerId = (Label)item.FindControl("lblCustomerId");             

                //txtCustomerPrice
                bool flg = false;
                if (chkContainer.Checked == true)
                {
                    flg = true;
                    //string ProductId = chkContainer.Attributes["attr-ID"];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "insert_assignCustomerTodeliveryboy";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@fk_deliveryboyId", Convert.ToInt64(ddlDeliveryboy.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@fk_customerId", Convert.ToInt64(lblCustomerId.Text));
                    
                    cmd.ExecuteNonQuery();
                }
                else
                {
                }
            }
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Record Saved Successfully";

        }
        catch(Exception p)
        { }
        finally { con.Close(); }
        BindCustomer ();
    }
}