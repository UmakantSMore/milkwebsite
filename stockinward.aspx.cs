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

public partial class stockinward : System.Web.UI.Page
{
    common ocommon = new common();
    //DataTable dtfarmer = new DataTable();
    DataTable dtproducts = new DataTable();

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                /*
                BindFarmer(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Update Farmer";
                Page.Title = "Update Farmer";
                */
            }
            else
            {
                hPageTitle.InnerText = "Stock Inward";
                Page.Title = "Stock Inward";
                btnSave.Text = "ADD";

            }
        }
    }


    private void Bind()
    {
        //List<SelectListItem> list = new List<SelectListItem>();

        spnMessage.InnerText = string.Empty;

        dtproducts = (new Cls_dispatchdetails_b().SelectAllAdmin());

        if (dtproducts != null)
        {
            if (dtproducts.Rows.Count> 0)
            {
                ViewState["Products"] = dtproducts;

                Repeater1.DataSource = dtproducts;
                Repeater1.DataBind();
                Repeater1.Visible = true;
            }
            else
            {
                spnMessage.Visible = true;
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "No Stock Inward For Now. Visit Again!!!";

                Repeater1.DataSource = null;
                Repeater1.DataBind();
                Repeater1.Visible = false;
            }
        }
        else
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "No Stock Inward For Now. Visit Again!!!";

            Repeater1.DataSource = null;
            Repeater1.DataBind();
            Repeater1.Visible = false;
        }

    }


    private void Clear()
    {

        Repeater1.DataSource = null;
        Repeater1.DataBind();
        //Repeater1.Visible = false;
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        //id, farmerid, productid, quantity, rate, createddate, isdeleted

        Int64 Result = 0, Result1 = 0;

        if (Request.QueryString["id"] != null)
        {

        }
        else
        {


            product objproduct = new product();
            //dispatchdetails objdispatchdetails = new dispatchdetails();

            foreach (RepeaterItem item in Repeater1.Items)
            {

                //qtyrequested = int.Parse((item.FindControl("LabelQuantity") as Label).Text);

                Label id = (Label)item.FindControl("lblid");
                Label pid = (Label)item.FindControl("lblproductid");
                //Label rate = (Label)item.FindControl("lblrate");
                TextBox quantity = (TextBox)item.FindControl("txtqty");

                //objfarmer.farmerid = Convert.ToInt64(hffarmerid.Value);

                objproduct.pid= Convert.ToInt64(pid.Text);
                objproduct.RealStock= Convert.ToInt16(quantity.Text);


                Result = (new Cls_product_b().UpdateProductStockOnly(objproduct));

                if (Result > 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE dispatchdetails SET isdelivered = isdelivered ^ 1 WHERE id = @id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = Convert.ToInt64(id.Text),
                        SqlDbType = SqlDbType.BigInt,
                        Direction = ParameterDirection.InputOutput
                    };
                    cmd.Parameters.Add(param);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }



            }


            if (Result > 0)
            {
                Clear();
                spnMessage.Style.Add("color", "green");
                spnMessage.InnerText = "Information Saved Successfully!!!";

            }
            else
            {
                Clear();
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Failed To Save The Information...";


            }


            //Response.Redirect(Page.ResolveUrl("~/managefarmers.aspx?mode=i"));
            //}

        }

    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        //Response.Redirect(Page.ResolveUrl("~/dashboard.aspx"));
    }
    
}