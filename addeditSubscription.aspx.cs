using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class addeditSubscription : System.Web.UI.Page
{
    
    common ocommon = new common();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCustomer();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Category Update";
                Page.Title = "Category Update";
            }
            else
            {
                hPageTitle.InnerText = "Category Add";
                Page.Title = "Category Add";
                btnSave.Text = "Add";
                

            }
        }
    }

    private void Clear()
    {
        //txtCategoryName.Text = string.Empty;
        //txtActualPrice.Text = string.Empty;
        //txtCategoryDiscount.Text = string.Empty;
        //txtCategoryShortDescription.Text = string.Empty;
        //txtCategoryLongDescription.Text = string.Empty;
        //btnImageUpload.Visible = true;
        //btnRemove.Visible = false;
        //imgCategory.Visible = false;
        //ViewState["fileName"] = null;
    }

    private void BindCustomer()
    {
        DataTable dtCustoemr= (new Cls_customerRegistration_b ().SelectAll());
        ddlCustomer.Items.Clear();
        if (dtCustoemr != null)
        {
            if (dtCustoemr.Rows.Count > 0)
            {
                ddlCustomer .DataSource = dtCustoemr;
                ddlCustomer.DataTextField = "customerName";
                ddlCustomer.DataValueField = "id";
                ddlCustomer.DataBind();
                ListItem objListItem = new ListItem("--Select Customer--", "0");
                ddlCustomer.Items.Insert(0, objListItem);
            }
        }
    }

    public void BindCategory(Int64 CategoryId)
    {
        //category objcategory = (new Cls_category_b().SelectById(CategoryId));
        //if (objcategory != null)
        //{
        //    //ddlBank.SelectedValue = objcategory.bankid.ToString();
        //    txtCategoryName.Text = objcategory.categoryname;
        //    txtCategoryShortDescription.Text = objcategory.shortdesc;
        //    txtCategoryLongDescription.Text = objcategory.longdescp;
        //    if (!string.IsNullOrEmpty(objcategory.imagename))
        //    {
        //        imgCategory.Visible = true;
        //        ViewState["fileName"] = objcategory.imagename;
        //        imgCategory.ImageUrl = categoryFrontPath + objcategory.imagename;
        //        btnImageUpload.Visible = false;
        //        btnRemove.Visible = true;
        //    }
        //    else
        //    {
        //        btnImageUpload.Visible = true;
        //    }
        //}
    }

    protected override void Render(HtmlTextWriter writer)
    {
        string validatorOverrideScripts = "<script src=\"" + Page.ResolveUrl("~") + "js/validators.js\" type=\"text/javascript\"></script>";
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatorOverrideScripts", validatorOverrideScripts, false);
        base.Render(writer);
    }

    


    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "subscription_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@customerId", Convert.ToInt64(ddlCustomer.SelectedValue));
            cmd.Parameters.AddWithValue("@deliverydate", Convert.ToDateTime(txtdate.Text ));
            con.Open();
            Int64 result= cmd.ExecuteNonQuery();
            if(result>0)
            {
                ddlCustomer.SelectedIndex = 0;
                txtdate.Text = string.Empty;
                ScriptManager.RegisterClientScriptBlock(this,typeof(Page), "", "alert('Subscription done successfully')", true);
            }
            else
            {
                ddlCustomer.SelectedIndex = 0;
                txtdate.Text = string.Empty;
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Subscription not done')", true);

            }
        
        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            con .Close();
        }

        //Int64 Result = 0;
        //category objcategory = new category();
        //objcategory.categoryname = txtCategoryName.Text.Trim();
        //objcategory.actualprice = 0;
        //objcategory.discountprice = 0;
        //objcategory.shortdesc = txtCategoryShortDescription.Text.Trim();
        //objcategory.longdescp = txtCategoryLongDescription.Text.Trim();
        //// objcategory.bankid = Convert.ToInt32("0");
        //if (ViewState["fileName"] != null)
        //{
        //    objcategory.imagename = ViewState["fileName"].ToString();
        //}
        //if (Request.QueryString["id"] != null)
        //{
        //    objcategory.cid = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
        //    Result = (new Cls_category_b().Update(objcategory));
        //    if (Result > 0)
        //    {
        //        Clear();
        //        Response.Redirect(Page.ResolveUrl("~/managecategory.aspx?mode=u"));
        //    }
        //    else
        //    {
        //        Clear();
        //        spnMessgae.Style.Add("color", "red");
        //        spnMessgae.InnerText = "Category Not Updated";
        //        BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
        //    }
        //}
        //else
        //{
        //    Result = (new Cls_category_b().Insert(objcategory));
        //    if (Result > 0)
        //    {
        //        Clear();
        //        Response.Redirect(Page.ResolveUrl("~/managecategory.aspx?mode=i"));
        //    }
        //    else
        //    {
        //        Clear();
        //        spnMessgae.Style.Add("color", "red");
        //        spnMessgae.InnerText = "Category Not Inserted";

        //    }
        //}
    }

   

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managecategory.aspx"));
    }

     
}