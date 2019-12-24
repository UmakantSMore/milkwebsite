using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class managefarmers : System.Web.UI.Page
{
    string FarmerMainPath = "~/uploads/farmers/";
    string FarmerFrontPath = "~/uploads/farmers/front/";
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindFarmers();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Farmers";
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

    private void BindFarmers()
    {
        DataTable dtfarmer = (new Cls_farmermaster_b().SelectAll());
        if (dtfarmer != null)
        {
            if (dtfarmer.Rows.Count > 0)
            {
                repCategory.DataSource = dtfarmer;
                repCategory.DataBind();
            }
            else
            {
                repCategory.DataSource = null;
                repCategory.DataBind();
            }
        }
        else
        {
            repCategory.DataSource = null;
            repCategory.DataBind();
        }
    }

    protected void repCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            //DropDownList ddlSeqNo = (DropDownList)e.Item.FindControl("ddlSeqNo");
            //Image imgCategory = (Image)e.Item.FindControl("imgCategory");
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditfarmer.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
            //imgfarmer.ImageUrl = FarmerFrontPath + DataBinder.Eval(e.Item.DataItem, "img").ToString();
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
                BindFarmers();
                spnMessage.Style.Add("color", "green");
                spnMessage.InnerText = "Record Deleted Successfully!!!";
            }
            else
            {
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Failed To Delete Record...";
            }
        

    }

    /*
    protected void IsActive_CheckedChanged(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as CheckBox).Parent as RepeaterItem;
        Int64 CategoryId = int.Parse((item.FindControl("lblCategoryId") as Label).Text);
        bool chkSelected = Convert.ToBoolean((item.FindControl("IsActive") as CheckBox).Checked);
        bool yes = (new Cls_category_b().Category_IsActive(CategoryId, chkSelected));
        if (yes)
        {
            BindCategory();
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Category Updated Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Category Not Updated";
        }
    }

        protected void ddlSeqNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList DDLSeqNo = (DropDownList)sender;
        RepeaterItem item = (sender as DropDownList).Parent as RepeaterItem;
        Int64 CategoryId = int.Parse((item.FindControl("lblCategoryId") as Label).Text);
        Int64 PreSeqNo = int.Parse((item.FindControl("lblSeqNo") as Label).Text);
        Update_SeqNo_Category_DB(CategoryId, PreSeqNo, Convert.ToInt64(DDLSeqNo.SelectedValue));
    }

        public void Update_SeqNo_Category_DB(Int64 CategoryId, Int64 PrevSeqNo, Int64 SeqNo)
    {
        SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update_SeqNo_Category";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Con;
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            cmd.Parameters.AddWithValue("@PrevSeqNo", PrevSeqNo);
            cmd.Parameters.AddWithValue("@SeqNo", SeqNo);
            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Category Updated Successfully";
            BindCategory();
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
        }
        finally
        {
            Con.Close();
        }
    }

    */


    protected void btnNewFarmer_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditfarmer.aspx"));
    }

    
    
}