using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class managecollectionproducts : System.Web.UI.Page
{
    common ocommon = new common();
    int count = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindProducts();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Products";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Information Updated Successfully!!!";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Information Saved Successfully!!!";
        }
    }

    private void BindProducts()
    {
        DataTable dtproduct = (new Cls_farmerproducts_b().SelectAll());
        if (dtproduct != null)
        {
            if (dtproduct.Rows.Count > 0)
            {
                repProduct.DataSource = dtproduct;
                repProduct.DataBind();
            }
            else
            {
                repProduct.DataSource = null;
                repProduct.DataBind();
            }
        }
        else
        {
            repProduct.DataSource = null;
            repProduct.DataBind();
        }
    }

    protected void repProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Label srno = (Label)e.Item.FindControl("lblsrno");
            srno.Text = count.ToString();
            count++;
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditcollectionproduct.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
        }
    }


    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        spnMessage.Visible = true;
        Int64 id = int.Parse((item.FindControl("lblid") as Label).Text);
        bool yes = (new Cls_farmermaster_b().Delete(id));
        if (yes)
        {
            BindProducts();
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Record Deleted Successfully!!!";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Failed To Delete Record...";
        }


    }

  
    protected void btnNewProduct_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditcollectionproduct.aspx"));
    }



}