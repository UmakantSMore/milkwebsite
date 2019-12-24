using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_deliveryboy_db
{
        SqlConnection ConnectionString = new SqlConnection();
        public Cls_deliveryboy_db()
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
                cmd.CommandText = "deliveryboyMaster_SelectAll";
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

        public deliveryboyMaster  SelectById(Int64 id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            deliveryboyMaster objVendorMaster = new deliveryboyMaster();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "deliveryboy_SelectById";
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
                                {
                                    objVendorMaster.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                    objVendorMaster.Name = Convert.ToString (ds.Tables[0].Rows[0]["Name"]);
                                    objVendorMaster.img  = Convert.ToString(ds.Tables[0].Rows[0]["img"]);
                                    objVendorMaster.Address1  = Convert.ToString(ds.Tables[0].Rows[0]["Address1"]);
                                     
                                    objVendorMaster.MobileNo1 = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo1"]);
                                    objVendorMaster.password  = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
                                    objVendorMaster.email = Convert.ToString(ds.Tables[0].Rows[0]["email"]);

                                    objVendorMaster.landline = Convert.ToString(ds.Tables[0].Rows[0]["landline"]);
                                    
                                    objVendorMaster.latitude  = Convert.ToString(ds.Tables[0].Rows[0]["latitude"]);
                                    objVendorMaster.loginitude  = Convert.ToString(ds.Tables[0].Rows[0]["loginitude"]);
                                   

                                   

                                }
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
            return objVendorMaster;
        }

        public Int64 Insert(deliveryboyMaster  objVendorMaster)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "deliveryboy_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objVendorMaster.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Name", objVendorMaster.Name );
                cmd.Parameters.AddWithValue("@Address1", objVendorMaster.Address1);
                cmd.Parameters.AddWithValue("@MobileNo1", objVendorMaster.MobileNo1 );                
                cmd.Parameters.AddWithValue("@email", objVendorMaster.email);
                cmd.Parameters.AddWithValue("@landline", objVendorMaster.landline);
                cmd.Parameters.AddWithValue("@img", objVendorMaster.img );
                cmd.Parameters.AddWithValue("@password", objVendorMaster.password );
                cmd.Parameters.AddWithValue("@latitude", objVendorMaster.latitude );
                cmd.Parameters.AddWithValue("@loginitude", objVendorMaster.loginitude );              


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

        public Int64 Update(deliveryboyMaster  objVendorMaster)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "deliveryboy_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;


                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objVendorMaster.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Name", objVendorMaster.Name);
                cmd.Parameters.AddWithValue("@Address1", objVendorMaster.Address1);
                cmd.Parameters.AddWithValue("@MobileNo1", objVendorMaster.MobileNo1);
                cmd.Parameters.AddWithValue("@email", objVendorMaster.email);
                cmd.Parameters.AddWithValue("@landline", objVendorMaster.landline);
                cmd.Parameters.AddWithValue("@img", objVendorMaster.img);
                cmd.Parameters.AddWithValue("@password", objVendorMaster.password);
                //cmd.Parameters.AddWithValue("@latitude", objVendorMaster.latitude);
                //cmd.Parameters.AddWithValue("@loginitude", objVendorMaster.loginitude);


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
                cmd.CommandText = "deliveryboy_Delete";
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
        public bool deliveryboy_IsActive(Int64 ProductId, Boolean IsActive)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "deliveryboy_IsActive";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", ProductId);
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