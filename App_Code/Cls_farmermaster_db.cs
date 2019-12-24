using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_farmermaster_db
    {
        SqlConnection ConnectionString = new SqlConnection();
        #region Constructor
        public Cls_farmermaster_db()
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
        #endregion

        #region Public Methods

        public DataTable SelectAllAdmin()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmermaster_SelectAllAdmin";
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

        public DataTable SelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmermaster_SelectAll";
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

        public DataTable farmermaster_WSSelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmermaster_WSSelectAll";
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



        public farmermaster SelectById(Int64 id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            farmermaster objfarmermaster = new farmermaster();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmermaster_SelectById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", id);
                ConnectionString.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                {
                                    //id, name, img, faddress, mobileno, mobile2, fpassword, milkrate, emailid, bankname, accountno, ifsc, deviceid, countryid, stateid, cityid, isdeleted, isactive

                                    objfarmermaster.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                    objfarmermaster.name = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                                    objfarmermaster.img= Convert.ToString(ds.Tables[0].Rows[0]["img"]);
                                    objfarmermaster.address= Convert.ToString(ds.Tables[0].Rows[0]["faddress"]);
                                    objfarmermaster.mobileno= Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                                    //objfarmermaster.mobile2= Convert.ToString(ds.Tables[0].Rows[0]["mobile2"]);
                                    objfarmermaster.password= Convert.ToString(ds.Tables[0].Rows[0]["fpassword"]);
                                    objfarmermaster.email= Convert.ToString(ds.Tables[0].Rows[0]["emailid"]);
                                    objfarmermaster.bankname= Convert.ToString(ds.Tables[0].Rows[0]["bankname"]);
                                    objfarmermaster.accountno= Convert.ToString(ds.Tables[0].Rows[0]["accountno"]);
                                    objfarmermaster.ifsc= Convert.ToString(ds.Tables[0].Rows[0]["ifsc"]);
                                    objfarmermaster.milkrate= Convert.ToDecimal(ds.Tables[0].Rows[0]["milkrate"]);
                                    objfarmermaster.countryid = Convert.ToInt64(ds.Tables[0].Rows[0]["countryid"]);
                                    objfarmermaster.stateid = Convert.ToInt64(ds.Tables[0].Rows[0]["stateid"]);
                                    objfarmermaster.cityid = Convert.ToInt64(ds.Tables[0].Rows[0]["cityid"]);

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
            return objfarmermaster;
        }

        public DataTable farmermaster_WSSelectById(Int64 id)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmermaster_WSSelectById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", id);
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

        public Int64 Insert(farmermaster objfarmermaster)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmermaster_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objfarmermaster.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);

                
                cmd.Parameters.AddWithValue("name",objfarmermaster.name);
                cmd.Parameters.AddWithValue("img",objfarmermaster.img);
                cmd.Parameters.AddWithValue("faddress", objfarmermaster.address);
                cmd.Parameters.AddWithValue("mobileno",objfarmermaster.mobileno);
                //cmd.Parameters.AddWithValue("mobile2",objfarmermaster.mobile2);
                cmd.Parameters.AddWithValue("fpassword", objfarmermaster.password);
                cmd.Parameters.AddWithValue("emailid", objfarmermaster.email);
                cmd.Parameters.AddWithValue("bankname", objfarmermaster.bankname);
                cmd.Parameters.AddWithValue("accountno", objfarmermaster.accountno);
                cmd.Parameters.AddWithValue("ifsc", objfarmermaster.ifsc);
                cmd.Parameters.AddWithValue("milkrate", objfarmermaster.milkrate);
                cmd.Parameters.AddWithValue("countryid", objfarmermaster.countryid);
                cmd.Parameters.AddWithValue("stateid", objfarmermaster.stateid);
                cmd.Parameters.AddWithValue("cityid", objfarmermaster.cityid);

                
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

        public Int64 Update(farmermaster objfarmermaster)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmermaster_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objfarmermaster.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("name", objfarmermaster.name);
                cmd.Parameters.AddWithValue("img", objfarmermaster.img);
                cmd.Parameters.AddWithValue("faddress", objfarmermaster.address);
                cmd.Parameters.AddWithValue("mobileno", objfarmermaster.mobileno);
                //cmd.Parameters.AddWithValue("mobile2", objfarmermaster.mobile2);
                cmd.Parameters.AddWithValue("fpassword", objfarmermaster.password);
                cmd.Parameters.AddWithValue("emailid", objfarmermaster.email);
                cmd.Parameters.AddWithValue("bankname", objfarmermaster.bankname);
                cmd.Parameters.AddWithValue("accountno", objfarmermaster.accountno);
                cmd.Parameters.AddWithValue("ifsc", objfarmermaster.ifsc);
                cmd.Parameters.AddWithValue("milkrate", objfarmermaster.milkrate);
                cmd.Parameters.AddWithValue("countryid", objfarmermaster.countryid);
                cmd.Parameters.AddWithValue("stateid", objfarmermaster.stateid);
                cmd.Parameters.AddWithValue("cityid", objfarmermaster.cityid);

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
        public bool Delete(Int64 id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmermaster_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                cmd.Parameters.AddWithValue("@id", id);

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

        public bool farmermaster_IsActive(Int64 farmermasterId, Boolean IsActive)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmermaster_IsActive";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", farmermasterId);
                //cmd.Parameters.AddWithValue("@isactive", IsActive);
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
