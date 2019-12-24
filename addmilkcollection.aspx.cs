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

public partial class addmilkcollection : System.Web.UI.Page
{

    common ocommon = new common();
    DataTable dtfarmer = new DataTable();
    DataTable dtproductrates = new DataTable();

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
                hPageTitle.InnerText = "Milk Collection";
                Page.Title = "Milk Collection";
                btnSave.Text = "Add";

            }
        }
    }


    private void Bind()
    {
        //List<SelectListItem> list = new List<SelectListItem>();

        try
        {
            Cls_farmermaster_b clsfarmer = new Cls_farmermaster_b();
            dtfarmer = clsfarmer.SelectAll();



        }
        catch { }
        finally { con.Close(); }

        if (dtfarmer != null)
        {
            if (dtfarmer.Rows.Count > 0)
            {
                Session["farmers"] = dtfarmer;
                lstfarmer.DataSource = dtfarmer;
                lstfarmer.DataTextField = "name";
                lstfarmer.DataValueField = "id";
                lstfarmer.DataBind();


            }
            else
            {
                lstfarmer.DataSource = dtfarmer;
                lstfarmer.DataTextField = "name";
                lstfarmer.DataValueField = "id";
                lstfarmer.DataBind();


            }
        }
        else
        {
            lstfarmer.DataSource = dtfarmer;
            lstfarmer.DataTextField = "name";
            lstfarmer.DataValueField = "id";
            lstfarmer.DataBind();


        }

    }


    private void Clear()
    {

        lstfarmer.SelectedIndex = -1;
        ViewState["Products"] = null;
        Repeater1.DataSource = null;
        Repeater1.DataBind();
        Repeater1.Visible = false;
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        //id, farmerid, productid, quantity, rate, createddate, isdeleted

        Int64 Result = 0;
        
        if (Request.QueryString["id"] != null)
        {
            /*
            objfarmer.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_farmermaster_b().Update(objfarmer));
            if (Result > 0)
            {
                con.Open();
                if (ViewState["Products"] != null)
                    dtProduct = (DataTable)ViewState["Products"];
                farmerrates objrates = new farmerrates();
                foreach (DataRow row in dtProduct.Rows)
                {
                    //id,worksheetid,particularsid,employeeid,workdate,quantity,remark
                    objrates.id = Convert.ToInt64(row["id"]);
                    objrates.farmerid = objfarmer.id;
                    objrates.productid = Convert.ToInt64(row["productid"]);
                    objrates.rate = Convert.ToInt64(row["rate"]);

                    Result1 = (new Cls_farmerrates_b().Update(objrates));

                    //if (Result1 > 0)
                    // flag = true;


                }

                con.Close();

                Response.Redirect(Page.ResolveUrl("~/managefarmers.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Farmer Updation Failed...";
                BindFarmer(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }

            */
        }
        else
        {
            //Result = (new Cls_farmermaster_b().Insert(objfarmer));
            //if (Result > 0)
            //{

            farmercollection objfarmer = new farmercollection();
            
            /*
            if (ViewState["Products"] != null)
                dtproductrates = (DataTable)ViewState["Products"];

            foreach (DataRow row in dtproductrates.Rows)
            {
                //id,worksheetid,particularsid,employeeid,workdate,quantity,remark

                objfarmer.farmerid = Convert.ToInt64( hffarmerid.Value);
                objfarmer.productid = Convert.ToInt64(row["productid"]);
                objfarmer.rate = Convert.ToInt64(row["rate"]);
                objfarmer.quantity = Convert.ToDecimal(row["quantity"]);
                Result = (new Cls_farmercollection_b().Insert(objfarmer));

                //if (Result1 > 0)
                // flag = true;

                if (Result > 0) {
                    Clear();
                    spnMessgae.Style.Add("color", "green");
                    spnMessgae.InnerText = "Information Saved Successfully!!!";

                }
                else
                {
                    Clear();
                    spnMessgae.Style.Add("color", "red");
                    spnMessgae.InnerText = "Failed To Save The Information...";


                }
            }
            */
            foreach (RepeaterItem item in Repeater1.Items) {

                //qtyrequested = int.Parse((item.FindControl("LabelQuantity") as Label).Text);

                Label id = (Label)item.FindControl("lblproductid");
                Label rate = (Label)item.FindControl("lblrate");
                TextBox quantity = (TextBox)item.FindControl("txtqty");
                /*
                objfarmer.farmerid = Convert.ToInt64(hffarmerid.Value);
                objfarmer.productid = Convert.ToInt64((item.FindControl("lblproductid") as Label).Text);
                objfarmer.rate = Convert.ToDecimal((item.FindControl("lblrate") as Label).Text);
                objfarmer.quantity = Convert.ToDecimal((item.FindControl("txtqty") as TextBox).Text);



                */
                objfarmer.farmerid = Convert.ToInt64(hffarmerid.Value);
                objfarmer.productid = Convert.ToInt64(id.Text);
                objfarmer.rate = Convert.ToDecimal(rate.Text);
                objfarmer.quantity = Convert.ToDecimal(quantity.Text);


                Result = (new Cls_farmercollection_b().Insert(objfarmer));
                
            }

            Clear();
            spnMessgae.Style.Add("color", "green");
            spnMessgae.InnerText = "Information Saved Successfully!!!";



            /*
                if (Result > 0)
                {
                    Clear();
                    spnMessgae.Style.Add("color", "green");
                    spnMessgae.InnerText = "Information Saved Successfully!!!";

                }
                else
                {
                    Clear();
                    spnMessgae.Style.Add("color", "red");
                    spnMessgae.InnerText = "Failed To Save The Information...";


                }
            
                */
            //Response.Redirect(Page.ResolveUrl("~/managefarmers.aspx?mode=i"));
            //}

        }

    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        //Response.Redirect(Page.ResolveUrl("~/dashboard.aspx"));
    }




    protected void lstfarmer_SelectedIndexChanged(object sender, EventArgs e)
    {
        spnMessgae.InnerText = string.Empty;
        int id = Convert.ToInt16(hffarmerid.Value);
        DataTable dtProductRates = (new Cls_farmerrates_b().SelectByFarmerId(id));

        if (dtProductRates != null)
        {
            ViewState["Products"] = dtProductRates;

            Repeater1.DataSource = dtProductRates;
            Repeater1.DataBind();
            Repeater1.Visible = true;
        }
        else
        {
            Repeater1.DataSource = null;
            Repeater1.DataBind();
            Repeater1.Visible = false;
        }
    }
}