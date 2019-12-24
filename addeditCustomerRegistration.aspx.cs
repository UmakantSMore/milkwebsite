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

public partial class addeditCustomerRegistration : System.Web.UI.Page
{
    int categoryImageFrontWidth = 500;
    int categoryImageFrontHeight = 605;
    string categoryMainPath = "~/uploads/customer/";
    string categoryFrontPath = "~/uploads/customer/front/";
    common ocommon = new common();
    SqlConnection ConnectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
    private void BindProductCombo()
    {
        DataTable dtProcess = new Cls_product_b().SelectAll();

        ddlProduct.Items.Clear();
        if (dtProcess != null)
        {
            if (dtProcess.Rows.Count > 0)
            {

                ddlProduct.DataSource = dtProcess;
                ddlProduct.DataTextField = "productname";
                ddlProduct.DataValueField = "pid";
                ddlProduct.DataBind();
                ListItem objListItem = new ListItem("--Select Product--", "0");
                ddlProduct.Items.Insert(0, objListItem);
            }
            else
            {
                ddlProduct.DataSource = null;
                ddlProduct.DataBind();
            }
        }
        else
        {
            ddlProduct.DataSource = null;
            ddlProduct.DataBind();
        }
    }
    public void BindProductGrid(Int64 id)
    {
        try
        {
            ConnectionString.Open();
            DataTable ds = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Customer_Registrationgrid";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;
            cmd.Parameters.AddWithValue("@Fk_customerId", id);
            //con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);


            repProduct.DataSource = ds;
            repProduct.DataBind();
            ViewState["dtprod"] = ds;




            ConnectionString.Close();
        }
        catch { }
        finally { ConnectionString.Close(); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            BindProductCombo();
            if (Request.QueryString["id"] != null)
            {
                BindCustomer(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));

                btnSave.Text = "UPDATE";
                hPageTitle.InnerText = "Update Customer";
                Page.Title = "Update Customer";
            }
            else
            {
                BindProductGrid(-1);
                hPageTitle.InnerText = "New Customer";
                Page.Title = "New Customer";
                btnSave.Text = "ADD";
            }
        }
    }

    private void Clear()
    {
        //        txtName
        //txtEmail
        //txtPhoneno
        //txtAddress1
        //txtpassword
        //txtAnnivarsaryDate
        //txtBirthdate
        //txtBusiness
        //txtJob
        //txtReference
        //rdoDays_daily
        //rdoDays_alternetdays
        //rdoShift_morning
        //rdoShift_evening
        //rdoDayTime_6To8
        //rdoDayTime_after8
        //rdodoorstepDelivery_doorbell
        //rdodoorstepDelivery_withoutDoorbell

        txtName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtPhoneno.Text = string.Empty;
        txtAddress1.Text = string.Empty;
        txtpassword.Text = string.Empty;
        txtAnnivarsaryDate.Text = string.Empty;
        txtBirthdate.Text = string.Empty;
        txtBusiness.Text = string.Empty;
        txtJob.Text = string.Empty;
        txtReference.Text = string.Empty;
        rdoDays_daily.Checked = true;
        rdoDays_alternetdays.Checked = false;
        rdoShift_morning.Checked = true;
        rdoShift_evening.Checked = false;
        rdoDayTime_6To8.Checked = true;
        rdoDayTime_after8.Checked = false;
        rdodoorstepDelivery_doorbell.Checked = true;
        rdodoorstepDelivery_withoutDoorbell.Checked = false;
        //txtName.Text = string.Empty;
        //txtAddress1.Text = string.Empty;
        //txtpassword.Text = string.Empty;
        //txtMobileNo1.Text = string.Empty;

        //txtLandline.Text = string.Empty;
        //txtEmail.Text = string.Empty;
        imgCategory.Visible = false;
        ViewState["fileName"] = null;
    }

    public void BindCustomer(Int64 BankId)
    {
        customerRegistration objcustomerRegistration = (new Cls_customerRegistration_b().SelectById(BankId));
        if (objcustomerRegistration != null)
        {
            txtName.Text = objcustomerRegistration.customerName;
            txtEmail.Text = objcustomerRegistration.email;
            txtPhoneno.Text = objcustomerRegistration.phoneNo ;
            txtAddress1.Text = objcustomerRegistration.phoneNo;
            txtpassword.Text = objcustomerRegistration.password;
            txtAnnivarsaryDate.Text = objcustomerRegistration.annivarsaryDate.ToString();
            txtBirthdate.Text = objcustomerRegistration.birthdate.ToString();
            txtBusiness.Text = objcustomerRegistration.business;
            txtJob.Text = objcustomerRegistration.job;
            txtReference.Text = objcustomerRegistration.reference;

            string days = "", deliveryShift = "", deliveryTime = "", doorStep = "";


            if (objcustomerRegistration.days == "Daily")
            {
                rdoDays_daily.Checked = true;
                rdoDays_alternetdays.Checked = false;
            }
            else if (objcustomerRegistration.days == "Alternet Days")
            {
                rdoDays_daily.Checked = false;
                rdoDays_alternetdays.Checked = true;
            }
            //----
            if (objcustomerRegistration.deliveryShift == "Morning")
            {
                rdoShift_morning.Checked = true;
                rdoShift_evening.Checked = false;

            }
            else if (objcustomerRegistration.deliveryShift == "Evening")
            {
                rdoShift_morning.Checked = false;
                rdoShift_evening.Checked = true;
            }
            //----
            if (objcustomerRegistration.deliveryTime == "6am To 8 am")
            {
                rdoDayTime_6To8.Checked = true;
                rdodoorstepDelivery_doorbell.Checked = false;
                //deliveryTime = rdoDayTime_6To8.Text.Trim();
            }
            else if (objcustomerRegistration.deliveryTime == "After 8am")
            {
                rdoDayTime_6To8.Checked = false;
                rdodoorstepDelivery_doorbell.Checked = true;
            }
            //----
            if (objcustomerRegistration.doorStep == "Doorbell")
            {
                rdodoorstepDelivery_doorbell.Checked = true;
                rdodoorstepDelivery_withoutDoorbell.Checked = false;

            }
            else if (objcustomerRegistration.doorStep == "Without Doorbell")
            {
                rdodoorstepDelivery_doorbell.Checked = false;
                rdodoorstepDelivery_withoutDoorbell.Checked = true;
            }


            if (!string.IsNullOrEmpty(objcustomerRegistration.img))
            {
                imgCategory.Visible = true;
                ViewState["fileName"] = objcustomerRegistration.img;
                imgCategory.ImageUrl = categoryMainPath + objcustomerRegistration.img;
                btnImageUpload.Visible = false;
                btnRemove.Visible = true;
            }
            else
            {
                btnImageUpload.Visible = true;
            }


            try
            {
                ConnectionString.Open();
                ConnectionString.Close();
            }
            catch { }
            finally { ConnectionString.Close(); }
        }
        BindProductGrid(BankId);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/manageCustomerRegistration.aspx"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        customerRegistration objcustomerRegistration = new customerRegistration();


        //     id, customerName, email, phoneNo, address, isdelete, isactive, password, latitude, lognitude, img,
        //annivarsaryDate,
        //birthdate, business, job, reference, days, deliveryShift, deliveryTime, doorStep
        objcustomerRegistration.customerName = txtName.Text.Trim();
        objcustomerRegistration.email = txtAddress1.Text.Trim();
        objcustomerRegistration.phoneNo = txtPhoneno.Text.Trim();
        objcustomerRegistration.address = txtAddress1.Text.Trim();
        objcustomerRegistration.password = txtpassword.Text.Trim();
        objcustomerRegistration.latitude = "";
        objcustomerRegistration.lognitude = "";
        objcustomerRegistration.annivarsaryDate = Convert.ToDateTime(txtAnnivarsaryDate.Text.Trim());
        objcustomerRegistration.birthdate = Convert.ToDateTime(txtBirthdate.Text.Trim());
        objcustomerRegistration.business = txtBusiness.Text.Trim();
        objcustomerRegistration.job = txtJob.Text.Trim();
        objcustomerRegistration.reference = txtReference.Text.Trim();

        if (ViewState["fileName"] != null)
        {
            objcustomerRegistration.img = ViewState["fileName"].ToString();
        }
        string days = "", deliveryShift = "", deliveryTime = "", doorStep = "";
        if (rdoDays_daily.Checked == true)
        {
            days = rdoDays_daily.Text.Trim();
        }
        else if (rdoDays_daily.Checked == true)
        {
            days = rdoDays_daily.Text.Trim();
        }
        //----
        if (rdoShift_morning.Checked == true)
        {
            deliveryShift = rdoShift_morning.Text.Trim();
        }
        else if (rdoShift_evening.Checked == true)
        {
            deliveryShift = rdoShift_evening.Text.Trim();
        }
        //----
        if (rdoDayTime_6To8.Checked == true)
        {
            deliveryTime = rdoDayTime_6To8.Text.Trim();
        }
        else if (rdoDayTime_after8.Checked == true)
        {
            deliveryTime = rdoDayTime_after8.Text.Trim();
        }
        //----
        if (rdodoorstepDelivery_doorbell.Checked == true)
        {
            doorStep = rdodoorstepDelivery_doorbell.Text.Trim();
        }
        else if (rdodoorstepDelivery_withoutDoorbell.Checked == true)
        {
            doorStep = rdodoorstepDelivery_withoutDoorbell.Text.Trim();
        }
        objcustomerRegistration.days = days.Trim();
        objcustomerRegistration.deliveryShift = deliveryShift.Trim();
        objcustomerRegistration.deliveryTime = deliveryTime.Trim();
        objcustomerRegistration.doorStep = doorStep.Trim();

        if (Request.QueryString["id"] != null)
        {
            objcustomerRegistration.id = Convert.ToInt32(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            bool res = CheckMobileNumberExitOrNot(objcustomerRegistration.phoneNo, "u", objcustomerRegistration.id.ToString());
            if (res == true)
            {
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Duplicate Mobile No";
            }
            else
            {
                Result = (new Cls_customerRegistration_b().Update(objcustomerRegistration));

                if (Result > 0)
                {
                    try
                    {
                        DataTable ds = new DataTable();
                        ds = (DataTable)ViewState["dtprod"];

                        ConnectionString.Close();
                        ConnectionString.Open();
                        foreach (RepeaterItem item in repProduct.Items)
                        {
                            Label fk_productId = (Label)item.FindControl("lblProductId");
                            TextBox qty = (TextBox)item.FindControl("lblQty");
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Customer_ProductUpdate";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = ConnectionString;

                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@id";
                            param.Value = 0;
                            param.SqlDbType = SqlDbType.Int;
                            param.Direction = ParameterDirection.InputOutput;
                            cmd.Parameters.Add(param);
                            cmd.Parameters.AddWithValue("@fk_productId", Convert.ToInt64(fk_productId.Text));
                            cmd.Parameters.AddWithValue("@Fk_customerId", Result);
                            cmd.Parameters.AddWithValue("@qty", qty.Text);
                            Int64 result =cmd.ExecuteNonQuery();
                            

                           
                        }

                    }
                    catch (Exception p)
                    { }
                    finally { ConnectionString.Close(); }
                    Clear();
                    Response.Redirect(Page.ResolveUrl("~/manageCustomerRegistration.aspx? mode=u"));
                }
                else
                {
                    Clear();
                    spnMessgae.Style.Add("color", "red");
                    spnMessgae.InnerText = "Customer Not Updated";
                    BindCustomer(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                }
            }
        }
        else
        {
            bool res = CheckMobileNumberExitOrNot(objcustomerRegistration.phoneNo, "i", "0");
            if (res == true)
            {
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Duplicate Mobile No";
            }
            else
            {
                Result = (new Cls_customerRegistration_b().Insert(objcustomerRegistration));

                if (Result > 0)
                {
                    try
                    {
                        DataTable ds = new DataTable();
                        ds = (DataTable)ViewState["dtprod"];

                        ConnectionString.Close();
                        ConnectionString.Open();
                        foreach (RepeaterItem item in repProduct.Items)
                        {
                            Label fk_productId = (Label)item.FindControl("lblProductId");
                            TextBox qty = (TextBox)item.FindControl("lblQty");
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Customer_ProductUpdate";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = ConnectionString;

                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@id";
                            param.Value = 0;
                            param.SqlDbType = SqlDbType.Int;
                            param.Direction = ParameterDirection.InputOutput;
                            cmd.Parameters.Add(param);
                            cmd.Parameters.AddWithValue("@fk_productId", Convert.ToInt64(fk_productId.Text));
                            cmd.Parameters.AddWithValue("@Fk_customerId", Result);
                            cmd.Parameters.AddWithValue("@qty",qty.Text );
                            Int64 result = cmd.ExecuteNonQuery();
                         

 
                        }

                    }
                    catch (Exception p)
                    { }
                    finally { ConnectionString.Close(); }

                    Clear();
                    Response.Redirect(Page.ResolveUrl("~/manageCustomerRegistration.aspx? mode=i"));
                }
                else
                {
                    Clear();
                    spnMessgae.Style.Add("color", "red");
                    spnMessgae.InnerText = "Customer Boy Not Inserted";

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
            ocommon.CreateThumbnail1("uploads\\customer\\", categoryImageFrontWidth, categoryImageFrontHeight, "~/Uploads/customer/front/", fileName);
            imgCategory.Visible = true;
            imgCategory.ImageUrl = categoryFrontPath + fileName;
            ViewState["fileName"] = fileName;
            btnRemove.Visible = true;
            btnImageUpload.Visible = false;
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        var filePath = Server.MapPath("~/uploads/customer/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        var filePath1 = Server.MapPath("~/uploads/customer/front/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath1))
        {
            File.Delete(filePath1);
        }

        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgCategory.Visible = false;
    }

    public bool CheckMobileNumberExitOrNot(string MobileNumber, string type, string id)
    {
        bool IsExit = false;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        try
        {
            DataTable dtMobile = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "customer_CheckMobileNumberExit";
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




    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }

    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        try
        {

            if (ddlProduct.SelectedIndex == 0 || txtQty.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('Please Enter All Fields ');", true);
                return;
            }

            DataTable dtprodn = new DataTable();
            dtprodn = (DataTable)ViewState["dtprod"];

            DataRow[] drr = dtprodn.Select("fk_productId='" + ddlProduct.SelectedValue.ToString() + " ' ");
            if (drr.Length > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('This Product already add')", true);
            }
            else
            {
                DataRow dr = dtprodn.NewRow();
                int srr = 0;
                srr = dtprodn.Rows.Count + 1;
                dr["sr"] = srr.ToString();
                dr["fk_productId"] = ddlProduct.SelectedValue.ToString();
                dr["productName"] = ddlProduct.SelectedItem.ToString();
                dr["qty"] = txtQty.Text;
                dtprodn.Rows.Add(dr);
            }


            repProduct.DataSource = dtprodn;
            repProduct.DataBind();
            ViewState["dtprod"] = dtprodn;
            ddlProduct.SelectedIndex = 0;
            txtQty.Text = string.Empty;


        }
        catch (Exception ex)
        {

            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ConnectionString.Open();

            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

            Int64 pid = int.Parse((item.FindControl("lblProductId") as Label).Text);

            //string pid = (gvproduct.Rows[ind].Cells[0].Text);        

            DataTable dtprodn = new DataTable();
            dtprodn = (DataTable)ViewState["dtprod"];



            Int64 txtsr = int.Parse((item.FindControl("txtsr") as Label).Text);
            DataRow[] drr = dtprodn.Select("sr='" + txtsr + " ' ");

            foreach (var row in drr)
                row.Delete();


            //-----------------
            dtprodn.AcceptChanges();
            repProduct.DataSource = dtprodn;
            repProduct.DataBind();

            if (Request.QueryString["id"] != null)
            {
                Int64 OrderID = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
                string s = "update tbl_customerProduct set isdelete =1  where Fk_customerId = " + OrderID + " and fk_productId=" + pid + "";
                SqlCommand cmd = new SqlCommand(s, ConnectionString);
                int t = cmd.ExecuteNonQuery();


            }

            ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('Product Remove Successfully');", true);
            ConnectionString.Close();
        }
        catch (Exception p)
        { }
        finally { ConnectionString.Close(); }
    }

    protected void Label1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void lblQty_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtprodn = new DataTable();
            dtprodn = (DataTable)ViewState["dtprod"];
            foreach (RepeaterItem item in repProduct.Items)
            {
                Label fk_productId = (Label)item.FindControl("lblProductId");
                TextBox qty = (TextBox)item.FindControl("lblQty");   
               
                DataRow[] drr = dtprodn.Select("fk_productId='" + fk_productId.Text  + " ' ");
                if(drr.Length==0)
                {

                   
                }
                else
                {
                    foreach (var row in drr)
                    {
                        //  row["sr"] = "3";
                        // row["fk_productId"] = "3";
                        //  row["productName"] = "3";
                        row["qty"] = qty.Text;
                    }

                    dtprodn.AcceptChanges();
                    ViewState["dtprod"] = dtprodn;

                  

                }

            }
        }
        catch
        {

        }
        finally { }
       
    }
}