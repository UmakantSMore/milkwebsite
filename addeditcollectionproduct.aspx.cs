using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class addeditcollectionproduct : System.Web.UI.Page
{

    common ocommon = new common();

    DataTable dtProduct = new DataTable();

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Bind();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindFarmer(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Update Product";
                Page.Title = "Update Product";
            }
            else
            {
                hPageTitle.InnerText = "New Product";
                Page.Title = "New Product";
                btnSave.Text = "Add";

            }
        }
    }
    
    private void Clear()
    {

        txtname.Text = string.Empty;
    }

    
    public void BindFarmer(Int64 id)
    {
        
        farmerproducts objproduct = (new Cls_farmerproducts_b().SelectById(id));
        if (objproduct != null)
        {
            txtname.Text = objproduct.name;
            
        }
        
    }

    
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        farmerproducts objproduct = new farmerproducts();
        objproduct.name = txtname.Text;
        
        if (Request.QueryString["id"] != null)
        {
            objproduct.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_farmerproducts_b().Update(objproduct));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managecollectionproducts.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Product Updation Failed...";
                BindFarmer(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new Cls_farmerproducts_b().Insert(objproduct));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managecollectionproducts.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Failed To Save The Information...";


            }
        }
    }

    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managecollectionproducts.aspx"));
    }


}