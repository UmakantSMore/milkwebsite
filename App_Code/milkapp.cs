using BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for milkapp
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class milkapp : System.Web.Services.WebService
{
    SqlConnection ConnectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    public milkapp()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    /// <FromYogita>

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SelectAllCategory()
    {
        string finalResult = string.Empty;
        try
        {
            DataTable dtCategory = (new Cls_category_b().category_WSSelectAll());
            if (dtCategory != null)
            {
                if (dtCategory.Rows.Count > 0)
                {
                    string output = DataTableToJSONWithJavaScriptSerializer(dtCategory);
                    finalResult = "{\"success\" : 1, \"message\" : \" Category All Data\", \"data\" :" + output + "}";

                }
                else
                {
                    finalResult = "{\"success\" : 0, \"message\" : \"No Category \", \"data\" : \"\"}";
                }
            }
            else
            {
                finalResult = "{\"success\" : 0, \"message\" : \" No Category \", \"data\" : \"\"}";
            }
        }
        catch (Exception ex)
        {
            finalResult = "{\"success\" : 0, \"message\" : \"" + ex.Message + "\", \"data\" : \"\"}";
        }

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Flush();
        Context.Response.Write(finalResult);
        Context.Response.End();
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SelectProductsUsingCategoryId(Int64 CategoryId)
    {
        string finalResult = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        try
        {
            DataTable dtProducts = (new Cls_product_b().Product_WSSelectAllProductUsingCategoryId(CategoryId));
            if (dtProducts != null)
            {
                if (dtProducts.Rows.Count > 0)
                {
                    string output = DataTableToJSONWithJavaScriptSerializer(dtProducts);
                    //string output = range_DataTableToJSONWithJavaScriptSerializer(dtProducts);
                    finalResult = "{\"success\" : 1, \"message\" : \" Category Wise Product Data\", \"data\" :" + output + "}";

                }
                else
                {
                    finalResult = "{\"success\" : 0, \"message\" : \"No Products Exits This Category \", \"data\" : \"\"}";
                }
            }
            else
            {
                finalResult = "{\"success\" : 0, \"message\" : \"No Products Exits This Category \", \"data\" : \"\"}";
            }
        }
        catch (Exception)
        {
            finalResult = "{\"success\" : 0, \"message\" : \"No Products Exits This Category \", \"data\" : \"\"}";
        }
        finally
        {
            con.Close();
        }

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Flush();
        Context.Response.Write(finalResult);
        Context.Response.End();
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void deliveryboy_Login(string mobile, string password)
    {
        string finalResult = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        try
        {
            DataTable dtUser = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "deliveryboy_Login";
            cmd.Parameters.AddWithValue("@MobileNo1", mobile);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(dtUser);
            con.Close();
            if (dtUser != null)
            {
                if (dtUser.Rows.Count > 0)
                {
                    bool Status = Convert.ToBoolean(dtUser.Rows[0]["isactive"]);
                    if (Status)
                    {
                        //UpdateLatitudeLongitudeUsingUserId(Convert.ToInt64(dtUser.Rows[0]["uid"]), Convert.ToString(dtUser.Rows[0]["type"]), Latitude, Longitude);
                        string output = DataTableToJSONWithJavaScriptSerializer(dtUser);
                        finalResult = "{\"success\" : 1, \"message\" : \"Login Successfully\", \"data\" :" + output + "}";
                    }
                    else
                    {
                        finalResult = "{\"success\" : 0, \"message\" : \"Your Account Under Admin Observation.Please wait for admin confirmation\", \"data\" : \"\"}";
                    }
                }
                else
                {
                    finalResult = "{\"success\" : 0, \"message\" : \"Incorrect User Name & Password\", \"data\" : \"\"}";
                }
            }
            else
            {
                finalResult = "{\"success\" : 0, \"message\" : \"Incorrect User Name & Password\", \"data\" : \"\"}";
            }
        }
        catch (Exception ex)
        {
            finalResult = "{\"success\" : 0, \"message\" : \"" + ex.Message + "\", \"data\" : \"\"}";
        }
        finally
        {
            con.Close();
        }

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Flush();
        Context.Response.Write(finalResult);
        Context.Response.End();
    }


    public string customerProfileImage(string img, string ext)
    {
        string FinalFileName = string.Empty;
        string fileName = Guid.NewGuid().ToString();
        byte[] bytes = Convert.FromBase64String(img);
        BinaryWriter Writer = null;
        Writer = new BinaryWriter(File.OpenWrite(System.Web.Hosting.HostingEnvironment.MapPath("~/uploads/customer/") + fileName + "." + ext));
        Writer.Write(bytes);
        Writer.Flush();
        Writer.Close();
        FinalFileName = fileName + "." + ext;
        return FinalFileName;
    }
    [WebMethod]
    public void customerRegistration(string OrderProducts_JSONString, string customerName, string email, string phoneNo, string address, string password, string latitude, string lognitude, string annivarsaryDate, string birthdate, string business, string job, string reference, string img, string imgextension, string days, string deliveryShift, string deliveryTime, string doorStep)
    {
        string finalResult = string.Empty;

        //Customer_orders objorders = new Customer_orders();
        customerRegistration objcustomerRegistration = new customerRegistration();
        objcustomerRegistration.customerName = customerName.ToString();
        objcustomerRegistration.email = email.Trim();
        objcustomerRegistration.phoneNo = phoneNo.Trim();
        objcustomerRegistration.address = address.Trim();
        objcustomerRegistration.password = password.Trim();
        objcustomerRegistration.latitude = latitude.ToString();
        objcustomerRegistration.lognitude = lognitude.ToString();

        if (annivarsaryDate == string.Empty)
        {
            //objcustomerRegistration.annivarsaryDate = Convert.ToDateTime(annivarsaryDate);
        }
        else
        {
            objcustomerRegistration.annivarsaryDate = Convert.ToDateTime(annivarsaryDate);
        }

        //  objcustomerRegistration.annivarsaryDate = Convert.ToDateTime(annivarsaryDate);

        if (birthdate == string.Empty)
        {

        }
        else
        {
            objcustomerRegistration.birthdate = Convert.ToDateTime(birthdate);
        }

        // objcustomerRegistration.birthdate = Convert.ToDateTime(birthdate );
        objcustomerRegistration.business = business.Trim();
        objcustomerRegistration.job = job.Trim();
        objcustomerRegistration.reference = reference.Trim();

        if (!string.IsNullOrEmpty(img))
        {
            objcustomerRegistration.img = customerProfileImage(img, imgextension);

        }

        objcustomerRegistration.days = days.Trim();
        objcustomerRegistration.deliveryShift = deliveryShift.Trim();
        objcustomerRegistration.deliveryTime = deliveryTime.Trim();
        objcustomerRegistration.doorStep = doorStep.Trim();
        //[{"fk_productId":"1","qty":"1"}    ,{"fk_productId":"2","qty":"2"}]
        Int64 OrderProductAdd = 0;
        Int64 OrderId = 0;
        var dtOrderProducts = JsonConvert.DeserializeObject<DataTable>(OrderProducts_JSONString);
        if (dtOrderProducts != null)
        {
            if (dtOrderProducts.Rows.Count > 0)
            {
                //OrderId = (new Cls_Customer_order_b().Insert(objorders));
                // OrderId = (new Cls_orders_b().Insert(objorders));
                bool res = CheckMobileNumberExitOrNot(objcustomerRegistration.phoneNo, "i", "0");
                if (res == true)
                {
                    finalResult = "{\"success\" : 0, \"message\" : \"Duplicate Mobile No\", \"data\" : \"\"}";
                }
                else
                {
                    OrderId = (new Cls_customerRegistration_b().Insert(objcustomerRegistration));

                    if (OrderId > 0)
                    {
                        try
                        {


                            ConnectionString.Close();
                            ConnectionString.Open();
                            // dtOrderProducts
                            for (int i = 0; i < dtOrderProducts.Rows.Count; i++)
                            {
                                //Label fk_productId = (Label)item.FindControl("lblProductId");
                                //TextBox qty = (TextBox)item.FindControl("lblQty");
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
                                cmd.Parameters.AddWithValue("@fk_productId", Convert.ToInt64(dtOrderProducts.Rows[i]["fk_productId"].ToString()));
                                cmd.Parameters.AddWithValue("@Fk_customerId", OrderId);
                                cmd.Parameters.AddWithValue("@qty", Convert.ToInt64(dtOrderProducts.Rows[i]["qty"].ToString()));
                                Int64 result = cmd.ExecuteNonQuery();



                            }

                        }
                        catch (Exception p)
                        { }
                        finally { ConnectionString.Close(); }


                        finalResult = "{\"success\" : 1, \"message\" : \"Record Saved Sucessfully\", \"data\" : \"\"}";
                    }
                    else
                    {
                        finalResult = "{\"success\" :0, \"message\" : \"Record Not Saved\", \"data\" : \"\"}";

                    }
                }
            }
        }

        if ((OrderId > 0))
        {
            //SendOrderMail(OrderId);
            finalResult = "{\"success\" : 1, \"message\" : \"Record Saved Sucessfully\", \"data\" : \"\"}";
        }
        else
        {
            finalResult = "{\"success\" : 0, \"message\" : \"Record Not Saved\", \"data\" : \"\"}";
        }
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Flush();
        Context.Response.Write(finalResult);
        Context.Response.End();
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





    /// </FromYogita>


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void FarmerLogin(string mobile, string password)
    {
        string finalResult = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        try
        {
            DataTable dtUser = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "FarmerLogin";
            cmd.Parameters.AddWithValue("@mobileno", mobile);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(dtUser);
            con.Close();
            if (dtUser != null)
            {
                if (dtUser.Rows.Count > 0)
                {
                    bool Status = Convert.ToBoolean(dtUser.Rows[0]["isactive"]);
                    if (Status)
                    {
                        //UpdateLatitudeLongitudeUsingUserId(Convert.ToInt64(dtUser.Rows[0]["uid"]), Convert.ToString(dtUser.Rows[0]["type"]), Latitude, Longitude);
                        string output = DataTableToJSONWithJavaScriptSerializer(dtUser);
                        finalResult = "{\"success\" : 1, \"message\" : \"Login Successfully\", \"data\" :" + output + "}";
                    }
                    else
                    {
                        finalResult = "{\"success\" : 0, \"message\" : \"Your Account Under Admin Observation.Please wait for admin confirmation\", \"data\" : \"\"}";
                    }
                }
                else
                {
                    finalResult = "{\"success\" : 0, \"message\" : \"Incorrect User Name & Password\", \"data\" : \"\"}";
                }
            }
            else
            {
                finalResult = "{\"success\" : 0, \"message\" : \"Incorrect User Name & Password\", \"data\" : \"\"}";
            }
        }
        catch (Exception ex)
        {
            finalResult = "{\"success\" : 0, \"message\" : \"" + ex.Message + "\", \"data\" : \"\"}";
        }
        finally
        {
            con.Close();
        }

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Flush();
        Context.Response.Write(finalResult);
        Context.Response.End();
    }


    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        var JSONString = new StringBuilder();
        if (table.Rows.Count > 0)
        {
            JSONString.Append("[");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                JSONString.Append("{");
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (j < table.Columns.Count - 1)
                    {
                        JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString().Trim() + "\",");
                    }
                    else if (j == table.Columns.Count - 1)
                    {
                        JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString().Trim() + "\"");
                    }
                }
                if (i == table.Rows.Count - 1)
                {
                    JSONString.Append("}");
                }
                else
                {
                    JSONString.Append("},");
                }
            }
            JSONString.Append("]");
        }
        return JSONString.ToString();
    }



}
