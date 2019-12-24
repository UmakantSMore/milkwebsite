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

public partial class addeditfarmer : System.Web.UI.Page
{
    int categoryImageFrontWidth = 500;
    int categoryImageFrontHeight = 605;
    string FarmerMainPath = "~/uploads/farmers/";
    string FarmerFrontPath = "~/uploads/farmers/front/";
    common ocommon = new common();
    DataTable dtProduct = new DataTable();

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindFarmer(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Update Farmer";
                Page.Title = "Update Farmer";
            }
            else
            {
                hPageTitle.InnerText = "New Farmer";
                Page.Title = "New Farmer";
                btnSave.Text = "Add";
                
            }
        }
    }


    private void Bind()
    {
        //List<SelectListItem> list = new List<SelectListItem>();
        
        try
        {

            Cls_farmerproducts_b clsProduct = new Cls_farmerproducts_b();
            dtProduct = clsProduct.SelectAll();

        

        }
        catch { }
        finally { con.Close(); }
        
        if (dtProduct != null)
        {
            if (dtProduct.Rows.Count > 0)
            {
                Session["products"] = dtProduct;
                ddlOperation.DataSource = dtProduct;
                ddlOperation.DataTextField = "name";
                ddlOperation.DataValueField = "id";
                ddlOperation.DataBind();
                

            }
            else
            {
                ddlOperation.DataSource = dtProduct;
                ddlOperation.DataTextField = "name";
                ddlOperation.DataValueField = "id";
                ddlOperation.DataBind();


            }
        }
        else
        {
            ddlOperation.DataSource = dtProduct;
            ddlOperation.DataTextField = "name";
            ddlOperation.DataValueField = "id";
            ddlOperation.DataBind();


        }

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {

        DataTable dtProduct = new DataTable();
        dtProduct = GetProducts();


        if (ViewState["Products"] != null)
        {
            dtProduct = (DataTable)ViewState["Products"];


            Repeater1.DataSource = dtProduct;
            Repeater1.DataBind();
            Repeater1.Visible = true;
        }
        else
        {
            Repeater1.DataSource = null;
            Repeater1.DataBind();
            Repeater1.Visible = false;
        }

        ddlOperation.SelectedIndex = -1;
        txtrate.Text = "0";
    }



    private DataTable GetProducts()
    {

        DataTable dtProduct = null;
        if (ViewState["id"] != null)
        {
            int SrNo = Convert.ToInt32((ViewState["id"]));
            SrNo++;
            ViewState["id"] = SrNo;
        }
        else
        {
            ViewState["id"] = 1;
        }

        if (ViewState["Products"] == null)
        {

            // [ProdId],[ProdName],[ProdBrand] ,[ProdSize]

            dtProduct = new DataTable("Products");
            dtProduct.Columns.Add(new DataColumn("id", typeof(int)));
            dtProduct.Columns.Add(new DataColumn("product", typeof(string)));
            dtProduct.Columns.Add(new DataColumn("productid", typeof(int)));
            dtProduct.Columns.Add(new DataColumn("rate", typeof(string)));
            
            ViewState["Products"] = dtProduct;
        }
        else
        {
            dtProduct = (DataTable)ViewState["Products"];
        }

        DataRow[] drr = dtProduct.Select("id='" + ddlOperation.SelectedValue.ToString() + " ' ");

        if (drr.Length > 0) {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('This product is already in the list.')", true);


        }
        else {
            DataRow dtRow = dtProduct.NewRow();

            dtRow["id"] = ViewState["id"];
            dtRow["product"] = ddlOperation.SelectedItem;
            dtRow["productid"] = ddlOperation.SelectedValue;

            dtRow["rate"] = txtrate.Text.Trim();
            dtProduct.Rows.Add(dtRow);
            ViewState["Products"] = dtProduct;

        }

        return dtProduct;
    }



    protected void Remove_Product(object sender, EventArgs e)
    {
        try
        {
            //  con.Open();

            //GridViewRow gr = (GridViewRow)(sender as Control).Parent.Parent;
            //int ind = gr.RowIndex;
            //string pid = (gvproduct.Rows[ind].Cells[0].Text);
            int id, productid=0;
            Button button = (sender as Button);
            //Get the command argument
            string commandArgument = button.CommandArgument;


            id = int.Parse(commandArgument);

            DataTable dtProduct = new DataTable();

            if (ViewState["Products"] == null)
            {

                // [ProdId],[ProdName],[ProdBrand] ,[ProdSize]

                dtProduct = new DataTable("Products");
                dtProduct.Columns.Add(new DataColumn("id", typeof(int)));
                dtProduct.Columns.Add(new DataColumn("product", typeof(string)));
                dtProduct.Columns.Add(new DataColumn("productid", typeof(int)));
                dtProduct.Columns.Add(new DataColumn("rate", typeof(string)));

                ViewState["Products"] = dtProduct;
            }
            else
            {
                dtProduct = (DataTable)ViewState["Products"];
            }


            // dtProduct = (DataTable)ViewState["Products"];

            DataRow[] drr = dtProduct.Select("id=' " + id + " ' ");
            foreach (var row in drr) {
                productid = Convert.ToInt16(row["productid"]);
                row.Delete();
            }
            // dtProduct.Rows.RemoveAt(prodid);

            dtProduct.AcceptChanges();

            ViewState["Products"] = dtProduct;

            if (Request.QueryString["id"] != null)
            {
                Int64 farmerid = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));

                string s = "DELETE FROM farmerrates WHERE productid = @productid AND farmerid = @farmerid";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@productid", productid);
                cmd.Parameters.AddWithValue("@farmerid", farmerid);
                con.Open();
                int t = cmd.ExecuteNonQuery();
                //if (t > 0)
                {
                    #region " Stock Update "
                    // Product_StockAdd(pid, Qty);
                    #endregion " Stock Update "
                }

            }



            Repeater1.DataSource = dtProduct;
            Repeater1.DataBind();

            ddlOperation.SelectedIndex = -1;
            txtrate.Text = "0";

            ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('Record Removed Successfully');", true);

        }
        catch (Exception p)
        { }
        finally
        {
            con.Close(); 
        }
    }




    private void Clear()
    {
        //id, name, img, address, mobileno, mobile2, password, milkrate, emailid, bankname, accountno, ifsc, deviceid, countryid, stateid, cityid, isdeleted, isactive

        txtname.Text = string.Empty;
        txtaddress.Text = string.Empty;
        txtmobileno.Text = string.Empty;
        txtpassword.Text = string.Empty;
        txtmilkrate.Text = "0";
        txtemailid.Text = string.Empty;
        txtbank.Text = string.Empty;
        txtaccountno.Text = string.Empty;
        txtifsc.Text = string.Empty;
        
        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        imgfarmer.Visible = false;
        ViewState["fileName"] = null;
        ViewState["Products"] = null;
        Repeater1.DataSource = null;
        Repeater1.DataBind();
        Repeater1.Visible = false;
    }

    //private void BindBank()
    //{
    //    DataTable dtBank = (new Cls_bankmaster_b().SelectAll());
    //    if (dtBank != null)
    //    {
    //        if (dtBank.Rows.Count > 0)
    //        {
    //            ddlBank.DataSource = dtBank;
    //            ddlBank.DataTextField = "bankname";
    //            ddlBank.DataValueField = "bankid";
    //            ddlBank.DataBind();
    //            ListItem objListItem = new ListItem("--Select Bank--", "0");
    //            ddlBank.Items.Insert(0, objListItem);
    //        }
    //    }
    //}

    public void BindFarmer(Int64 id)
    {
        farmermaster objfarmer = (new Cls_farmermaster_b().SelectById(id));
        if (objfarmer != null)
        {
            txtname.Text = objfarmer.name;
            txtaddress.Text = objfarmer.address;
            txtmobileno.Text = objfarmer.mobileno;
            txtpassword.Text = objfarmer.password;
            txtmilkrate.Text = objfarmer.milkrate.ToString();
            txtemailid.Text = objfarmer.email;
            txtbank.Text = objfarmer.bankname;
            txtaccountno.Text = objfarmer.accountno;
            txtifsc.Text = objfarmer.ifsc;

            if (!string.IsNullOrEmpty(objfarmer.img))
            {
                imgfarmer.Visible = true;
                ViewState["fileName"] = objfarmer.img;
                imgfarmer.ImageUrl = FarmerFrontPath + objfarmer.img;
                btnImageUpload.Visible = false;
                btnRemove.Visible = true;
            }
            else
            {
                btnImageUpload.Visible = true;
            }
        }

        DataTable dtProductRates = (new Cls_farmerrates_b().SelectByFarmerId(id));
       
        if (dtProductRates != null)
        {
            ViewState["Products"] = dtProductRates;
            ViewState["id"] = dtProductRates.Select().Length;
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

    //protected override void Render(HtmlTextWriter writer)
    //{
    //    string validatorOverrideScripts = "<script src=\"" + Page.ResolveUrl("~") + "js/validators.js\" type=\"text/javascript\"></script>";
    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatorOverrideScripts", validatorOverrideScripts, false);
    //    base.Render(writer);
    //}

    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        if (fpfarmer.HasFile)
        {
            //OnClientClick = "return checkFileExtension()"

            string fileName = Path.GetFileNameWithoutExtension(fpfarmer.FileName.Replace(' ', '_')) + DateTime.Now.Ticks.ToString() + Path.GetExtension(fpfarmer.FileName);
            fpfarmer.SaveAs(MapPath(FarmerMainPath + fileName));
            ocommon.CreateThumbnail1("uploads\\farmers\\", categoryImageFrontWidth, categoryImageFrontHeight, "~/uploads/farmers/front/", fileName);
            //ocommon.CreateThumbnail1(FarmerMainPath, categoryImageFrontWidth, categoryImageFrontHeight, FarmerFrontPath, fileName);
            imgfarmer.Visible = true;
            imgfarmer.ImageUrl = FarmerFrontPath + fileName;
            ViewState["fileName"] = fileName;
            btnRemove.Visible = true;
            btnImageUpload.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0, Result1 = 0;
        farmermaster objfarmer = new farmermaster();
        objfarmer.name = txtname.Text;
        objfarmer.address = txtaddress.Text;
        objfarmer.mobileno = txtmobileno.Text;
        objfarmer.password = txtpassword.Text;
        objfarmer.milkrate = Convert.ToDecimal(txtmilkrate.Text);
        objfarmer.email = txtemailid.Text;
        objfarmer.bankname = txtbank.Text;
        objfarmer.accountno = txtaccountno.Text;
        objfarmer.ifsc = txtifsc.Text;

        if (ViewState["fileName"] != null)
        {
            objfarmer.img = ViewState["fileName"].ToString();
        }
        if (Request.QueryString["id"] != null)
        {
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
        }
        else
        {
            Result = (new Cls_farmermaster_b().Insert(objfarmer));
            if (Result > 0)
            {
                con.Open();
                if (ViewState["Products"] != null)
                    dtProduct = (DataTable)ViewState["Products"];
                farmerrates objrates = new farmerrates();
                foreach (DataRow row in dtProduct.Rows)
                {
                    //id,worksheetid,particularsid,employeeid,workdate,quantity,remark

                    objrates.farmerid = Result;
                    objrates.productid = Convert.ToInt64(row["productid"]);
                    objrates.rate = Convert.ToInt64(row["rate"]);
                    
                    Result1 = (new Cls_farmerrates_b().Insert(objrates));

                    //if (Result1 > 0)
                    // flag = true;


                }

                con.Close();

                Response.Redirect(Page.ResolveUrl("~/managefarmers.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Failed To Save The Information...";
                

            }
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        //var filePath = Server.MapPath("~/uploads/category/" + ViewState["fileName"].ToString());
        var filePath = Server.MapPath(FarmerMainPath+ ViewState["fileName"].ToString());
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        //var filePath1 = Server.MapPath("~/uploads/category/front/" + ViewState["fileName"].ToString());
        var filePath1 = Server.MapPath(FarmerFrontPath+ ViewState["fileName"].ToString());
        if (File.Exists(filePath1))
        {
            File.Delete(filePath1);
        }

        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgfarmer.Visible = false;
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            /*DataTable dtOperations = new DataTable();
            if (Session["products"] != null)
            {
                dtEmployee = (DataTable)Session["products"];
            }
            */

            var ddlOR = (DropDownList)e.Item.FindControl("ddlOperationRep");
            //var ddlOR = (ListBox)e.Item.FindControl("lstproductrep");
            

            if (Session["products"] != null)

            {
                dtProduct = (DataTable)Session["products"];
            }
            if (dtProduct != null)
            {
                if (dtProduct.Rows.Count > 0)
                {
                    


                    ddlOR.DataSource = dtProduct;
                    ddlOR.DataTextField = "name";
                    ddlOR.DataValueField = "id";
                    ddlOR.DataBind();
                    //System.Web.UI.WebControls.ListItem objListItem = new System.Web.UI.WebControls.ListItem("--Select Operation--", "0");
                    //ddlOR.Items.Insert(0, objListItem);

                    Label index = (Label)e.Item.FindControl("lblproductid");

                    ddlOR.SelectedValue = index.Text;




                }
            }


        }
    }

    protected void ddlOperationRep_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlOR = (DropDownList)sender;
        RepeaterItem row = (RepeaterItem)ddlOR.NamingContainer;
        int srno = int.Parse(((Label)row.FindControl("lblSrNo")).Text);
        DropDownList ddlOpRep = (DropDownList)row.FindControl("lstproductrep");
        
        /*
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT wages FROM productparticulars WHERE id = @id";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@id", ddlOpRep.SelectedValue);

        con.Open();
        cmd.ExecuteNonQuery();
        String wages = cmd.ExecuteScalar().ToString();
        txtwages.Text = wages;
        */

        dtProduct = (DataTable)ViewState["Products"];
        DataRow[] drr = dtProduct.Select("SrNo=' " + srno + " ' ");
        foreach (var newrow in drr)
        {
            newrow["productid"] = ddlOR.SelectedValue;
            newrow["product"] = ddlOR.SelectedItem;
            
        }

        dtProduct.AcceptChanges();

    }
    protected void txtraterep_TextChanged(object sender, EventArgs e)
    {
        TextBox rate = (TextBox)sender;
        RepeaterItem row = (RepeaterItem)rate.NamingContainer;
        //TextBox txtName = (TextBox)row.FindControl("TxtName");
        int srno = int.Parse(((Label)row.FindControl("lblSrNo")).Text);

        dtProduct = (DataTable)ViewState["Products"];


        // dtProduct = (DataTable)ViewState["Products"];

        DataRow[] drr = dtProduct.Select("id=' " + srno + " ' ");
        foreach (var newrow in drr)
        {
            newrow["rate"] = rate.Text;
        }
        // dtProduct.Rows.RemoveAt(prodid);

        dtProduct.AcceptChanges();
        //Repeater1.DataSource = dtProduct;
        //Repeater1.DataBind();

    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managefarmers.aspx"));
    }

    protected void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


}