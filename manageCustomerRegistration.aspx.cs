﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class manageCustomerRegistration : System.Web.UI.Page
{
    string agentFrontPath = "~/uploads/customer/";
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindAgent();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Customer";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Customer Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Customer Inserted Successfully";
        }
    }

    private void BindAgent()
    {
        DataTable dtVendor = (new Cls_customerRegistration_b ().SelectAll());
        if (dtVendor != null)
        {
            if (dtVendor.Rows.Count > 0)
            {
                repcustomer.DataSource = dtVendor;
                repcustomer.DataBind();
            }
            else
            {
                repcustomer.DataSource = null;
                repcustomer.DataBind();
            }
        }
        else
        {
            repcustomer.DataSource = null;
            repcustomer.DataBind();
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditCustomerRegistration.aspx"));
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        //  Int32 BankCount = int.Parse((item.FindControl("lblBankCount") as Label).Text);
        spnMessage.Visible = true;
        //if (BankCount.ToString() == "0")
        //{
        Int32 AgentId = int.Parse((item.FindControl("lblAgentId") as Label).Text);
        bool yes = (new Cls_customerRegistration_b ().Delete(AgentId));

        if (yes)
        {
            BindAgent();
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Customer Deleted Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Customer Boy Not Deleted";
        }
        //}
        //else
        //{
        //    spnMessage.Style.Add("color", "red");
        //    spnMessage.InnerText = "In this bank category added..so you can not delete.";
        //}
    }


    protected void repBank_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditCustomerRegistration.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));

            Image imgCategory = (Image)e.Item.FindControl("imgProfile");
            imgCategory.ImageUrl = agentFrontPath + DataBinder.Eval(e.Item.DataItem, "img").ToString();

        }
    }
    protected void IsActive_CheckedChanged(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as CheckBox).Parent as RepeaterItem;
        Int64 CategoryId = int.Parse((item.FindControl("lblAgentId") as Label).Text);
        bool chkSelected = Convert.ToBoolean((item.FindControl("IsActive") as CheckBox).Checked);
        bool yes = (new Cls_customerRegistration_b ().customer_IsActive (CategoryId, chkSelected));
        if (yes)
        {
            BindAgent();
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Customer Updated Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Customer Not Updated";
        }
    }

}