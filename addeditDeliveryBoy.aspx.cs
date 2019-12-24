using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class addeditDeliberyBoy : System.Web.UI.Page
{
    int categoryImageFrontWidth = 500;
    int categoryImageFrontHeight = 605;
    string categoryMainPath = "~/uploads/deliveryboy/";
    string categoryFrontPath = "~/uploads/deliveryboy/front/";
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
           
            if (Request.QueryString["id"] != null)
            {
                BindVendor(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "UPDATE";
                hPageTitle.InnerText = "Update Delivery Boy";
                Page.Title = "Update Delivery Boy";
            }
            else
            {
                hPageTitle.InnerText = "New Delivery Boy";
                Page.Title = "New Delivery Boy";
                btnSave.Text = "ADD";
            }
        }
    }

    private void Clear()
    {
        txtName .Text = string.Empty;
        txtAddress1.Text = string.Empty;
        txtpassword .Text = string.Empty;
        txtMobileNo1.Text = string.Empty;
        
        txtLandline.Text = string.Empty;
        txtEmail.Text = string.Empty;
        imgCategory.Visible = false;
        ViewState["fileName"] = null;
    }

    public void BindVendor(Int64 BankId)
    {
        deliveryboyMaster objdeliveryboyMaster = (new Cls_deliveryboy_b ().SelectById(BankId));
        if (objdeliveryboyMaster != null)
        {
            
            txtName .Text = objdeliveryboyMaster.Name ;
            txtAddress1.Text = objdeliveryboyMaster.Address1;
            txtpassword .Text = objdeliveryboyMaster.password;
            txtMobileNo1.Text = objdeliveryboyMaster.MobileNo1;
            
            txtLandline.Text = objdeliveryboyMaster.landline;
            txtEmail.Text = objdeliveryboyMaster.email;


            if (!string.IsNullOrEmpty(objdeliveryboyMaster.img))
            {
                imgCategory.Visible = true;
                ViewState["fileName"] = objdeliveryboyMaster.img;
                imgCategory.ImageUrl = categoryFrontPath + objdeliveryboyMaster.img;
                btnImageUpload.Visible = false;
                btnRemove.Visible = true;
            }
            else
            {
                btnImageUpload.Visible = true;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/ManageDeliveryBoy.aspx"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        deliveryboyMaster objdeliveryboyMaster = new deliveryboyMaster();


        objdeliveryboyMaster.Name  = txtName .Text.Trim();
        objdeliveryboyMaster.Address1 = txtAddress1.Text.Trim();
        objdeliveryboyMaster.password = txtpassword.Text.Trim();
        objdeliveryboyMaster.MobileNo1 = txtMobileNo1.Text.Trim();
         
        objdeliveryboyMaster.landline = txtLandline.Text.Trim();
        objdeliveryboyMaster.email = txtEmail.Text.Trim();




        if (ViewState["fileName"] != null)
        {
            objdeliveryboyMaster.img = ViewState["fileName"].ToString();
        }


        if (Request.QueryString["id"] != null)
        {
            objdeliveryboyMaster.id = Convert.ToInt32(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            bool res = CheckMobileNumberExitOrNot(objdeliveryboyMaster.MobileNo1, "u", objdeliveryboyMaster.id.ToString());
            if (res == true)
            {
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Duplicate Mobile No";
            }
            else
            {
                Result = (new Cls_deliveryboy_b().Update(objdeliveryboyMaster));
                if (Result > 0)
                {
                    Clear();
                    Response.Redirect(Page.ResolveUrl("~/ManageDeliveryBoy.aspx? mode=u"));
                }
                else
                {
                    Clear();
                    spnMessgae.Style.Add("color", "red");
                    spnMessgae.InnerText = "Delivery Boy Not Updated";
                    BindVendor(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                }
            }
        }
        else
        {
            bool res = CheckMobileNumberExitOrNot(objdeliveryboyMaster.MobileNo1, "i", "0");
            if (res == true)
            {
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Duplicate Mobile No";
            }
            else
            {
                Result = (new Cls_deliveryboy_b().Insert(objdeliveryboyMaster));
                if (Result > 0)
                {
                    Clear();
                    Response.Redirect(Page.ResolveUrl("~/ManageDeliveryBoy.aspx? mode=i"));
                }
                else
                {
                    Clear();
                    spnMessgae.Style.Add("color", "red");
                    spnMessgae.InnerText = "Delivery Boy Not Inserted";

                }
            }
        }
    }

    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        if (fpCategory.HasFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(fpCategory.FileName.Replace(' ', '_')) + DateTime.Now.Ticks.ToString() + Path.GetExtension(fpCategory.FileName);
            fpCategory.SaveAs(MapPath(categoryMainPath + fileName));
            ocommon.CreateThumbnail1("uploads\\deliveryboy\\", categoryImageFrontWidth, categoryImageFrontHeight, "~/Uploads/deliveryboy/front/", fileName);
            imgCategory.Visible = true;
            imgCategory.ImageUrl = categoryFrontPath + fileName;
            ViewState["fileName"] = fileName;
            btnRemove.Visible = true;
            btnImageUpload.Visible = false;
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        var filePath = Server.MapPath("~/uploads/deliveryboy/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        var filePath1 = Server.MapPath("~/uploads/deliveryboy/front/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath1))
        {
            File.Delete(filePath1);
        }

        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgCategory.Visible = false;
    }

    public bool CheckMobileNumberExitOrNot(string MobileNumber,string type,string id)
    {
        bool IsExit = false;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        try
        {
            DataTable dtMobile = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "deliveryboy_CheckMobileNumberExit";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mobileno", MobileNumber);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("id", Convert.ToInt64(id));
            cmd.Connection = con;
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(dtMobile);
            con.Close();
            if (dtMobile != null)
            {
                if (dtMobile.Rows.Count > 0)
                {
                    IsExit = true;
                }
                else
                {
                    IsExit = false;
                }
            }
            else
            {
                IsExit = false;
            }
        }
        catch (Exception)
        {
            IsExit = false;
        }
        finally
        {
            con.Close();
        }
        return IsExit;
    }



}