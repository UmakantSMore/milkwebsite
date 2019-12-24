using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_customerRegistration_db
{
        SqlConnection ConnectionString = new SqlConnection();
        public Cls_customerRegistration_db()
    {
            string name = string.Empty;
            string conname = string.Empty;
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            if (connections.Count != 0)
            {
                foreach (ConnectionStringSettings connection in connections)
                {
                    name = connection.Name;
                }
                conname = "" + name + "";
            }
            ConnectionString.ConnectionString = ConfigurationManager.ConnectionStrings[conname].ConnectionString;
        }
        #region Public Methods


        public DataTable SelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer_SelectAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                ConnectionString.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return null;
            }
            finally
            {
                ConnectionString.Close();
            }
            return ds.Tables[0];
        }

        public customerRegistration  SelectById(Int64 id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            customerRegistration objcustomerRegistration = new customerRegistration();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer__SelectById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", id);
                ConnectionString.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                //vid, vendorName, Address1, Address2, MobileNo1, MobileNo2, email, landline, fk_countryId, fk_stateId, fk_cityId, createddate, isdelete, isactive

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                             
                                    objcustomerRegistration.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                    objcustomerRegistration.customerName = Convert.ToString(ds.Tables[0].Rows[0]["customerName"]);
                                    objcustomerRegistration.email  = Convert.ToString(ds.Tables[0].Rows[0]["email"]);
                                    objcustomerRegistration.phoneNo  = Convert.ToString(ds.Tables[0].Rows[0]["phoneNo"]);
                                    objcustomerRegistration.address  = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                                    objcustomerRegistration.password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
                                    objcustomerRegistration.email = Convert.ToString(ds.Tables[0].Rows[0]["email"]);                                   
                                    objcustomerRegistration.latitude  = Convert.ToString(ds.Tables[0].Rows[0]["latitude"]);
                                    objcustomerRegistration.lognitude = Convert.ToString(ds.Tables[0].Rows[0]["lognitude"]);
                                    objcustomerRegistration.img  = Convert.ToString(ds.Tables[0].Rows[0]["img"]);
                                    objcustomerRegistration.annivarsaryDate  = Convert.ToDateTime (ds.Tables[0].Rows[0]["annivarsaryDate"]);
                                    objcustomerRegistration.birthdate  = Convert.ToDateTime(ds.Tables[0].Rows[0]["birthdate"]);
                                    objcustomerRegistration.business  = Convert.ToString(ds.Tables[0].Rows[0]["business"]);
                                    objcustomerRegistration.job  = Convert.ToString(ds.Tables[0].Rows[0]["job"]);
                                    objcustomerRegistration.reference  = Convert.ToString(ds.Tables[0].Rows[0]["reference"]);
                                    objcustomerRegistration.days  = Convert.ToString(ds.Tables[0].Rows[0]["days"]);
                                    objcustomerRegistration.deliveryShift  = Convert.ToString(ds.Tables[0].Rows[0]["deliveryShift"]);
                                    objcustomerRegistration.deliveryTime  = Convert.ToString(ds.Tables[0].Rows[0]["deliveryTime"]);
                                    objcustomerRegistration.doorStep  = Convert.ToString(ds.Tables[0].Rows[0]["doorStep"]);
                               

                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return null;
            }
            finally
            {
                ConnectionString.Close();
            }
            return objcustomerRegistration ;
        }

        public Int64 Insert(customerRegistration objcustomerRegistration)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = 0;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@customerName", objcustomerRegistration.customerName);
                cmd.Parameters.AddWithValue("@email", objcustomerRegistration.email);
                cmd.Parameters.AddWithValue("@phoneNo", objcustomerRegistration.phoneNo);
                cmd.Parameters.AddWithValue("@address", objcustomerRegistration.address);
                cmd.Parameters.AddWithValue("@password", objcustomerRegistration.password);

                cmd.Parameters.AddWithValue("@latitude", objcustomerRegistration.latitude);
                cmd.Parameters.AddWithValue("@lognitude", objcustomerRegistration.lognitude);
                cmd.Parameters.AddWithValue("@img", objcustomerRegistration.img);


                cmd.Parameters.AddWithValue("@annivarsaryDate",objcustomerRegistration.annivarsaryDate);
                cmd.Parameters.AddWithValue("@birthdate", objcustomerRegistration.birthdate);
                cmd.Parameters.AddWithValue("@business", objcustomerRegistration.business);
                cmd.Parameters.AddWithValue("@job", objcustomerRegistration.job);
                cmd.Parameters.AddWithValue("@reference", objcustomerRegistration.reference);

                cmd.Parameters.AddWithValue("@days", objcustomerRegistration.days);
                cmd.Parameters.AddWithValue("@deliveryShift", objcustomerRegistration.deliveryShift);
                cmd.Parameters.AddWithValue("@deliveryTime", objcustomerRegistration.deliveryTime);
                cmd.Parameters.AddWithValue("@doorStep", objcustomerRegistration.doorStep);


                

                ConnectionString.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt64(param.Value);
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
            finally
            {
                ConnectionString.Close();
            }
            return result;
        }

        public Int64 Update(customerRegistration objcustomerRegistration)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;


                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcustomerRegistration.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@customerName", objcustomerRegistration.customerName);
                cmd.Parameters.AddWithValue("@email", objcustomerRegistration.email);
                cmd.Parameters.AddWithValue("@phoneNo", objcustomerRegistration.phoneNo);
                cmd.Parameters.AddWithValue("@address", objcustomerRegistration.address);
                cmd.Parameters.AddWithValue("@password", objcustomerRegistration.password);
                //cmd.Parameters.AddWithValue("@latitude", objcustomerRegistration.latitude);
                //cmd.Parameters.AddWithValue("@lognitude", objcustomerRegistration.lognitude);
                cmd.Parameters.AddWithValue("@img", objcustomerRegistration.img);
                cmd.Parameters.AddWithValue("@annivarsaryDate", Convert.ToDateTime(objcustomerRegistration.annivarsaryDate));
                cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(objcustomerRegistration.birthdate));
                cmd.Parameters.AddWithValue("@business", objcustomerRegistration.business);
                cmd.Parameters.AddWithValue("@job", objcustomerRegistration.job);
                cmd.Parameters.AddWithValue("@reference", objcustomerRegistration.reference);
                cmd.Parameters.AddWithValue("@days",objcustomerRegistration.days);
                cmd.Parameters.AddWithValue("@deliveryShift", objcustomerRegistration.deliveryShift);
                cmd.Parameters.AddWithValue("@deliveryTime", objcustomerRegistration.deliveryTime);
                cmd.Parameters.AddWithValue("@doorStep", objcustomerRegistration.doorStep);


                ConnectionString.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt64(param.Value);
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
            finally
            {
                ConnectionString.Close();
            }
            return result;
        }

        public bool Delete(Int32 agentid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                cmd.Parameters.AddWithValue("@id", agentid);

                ConnectionString.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                ConnectionString.Close();
            }
            return true;
        }
        public bool customer_IsActive(Int64 id, Boolean IsActive)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer__IsActive";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@isactive", IsActive);
                ConnectionString.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                ConnectionString.Close();
            }
            return true;
        }

        #endregion
    }
}