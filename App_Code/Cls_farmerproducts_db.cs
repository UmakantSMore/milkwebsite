using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_farmerproducts_db
    {
        SqlConnection ConnectionString = new SqlConnection();
        #region Constructor
        public Cls_farmerproducts_db()
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




        public DataTable SelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmerproducts_SelectAll";
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

        public bool Delete(Int64 id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmerproducts_Delete";
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

      
        public farmerproducts SelectById(Int64 id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            farmerproducts objfarmerproducts = new farmerproducts();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmerproducts_SelectById";
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
                                    //id, name

                                    objfarmerproducts.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                    objfarmerproducts.name = ds.Tables[0].Rows[0]["name"].ToString();
                                    
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
            return objfarmerproducts;
        }


        public Int64 Insert(farmerproducts objfarmerproducts)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmerproducts_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objfarmerproducts.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);


                cmd.Parameters.AddWithValue("name", objfarmerproducts.name);
                

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

        public Int64 Update(farmerproducts objfarmerproducts)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "farmerproducts_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objfarmerproducts.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("name", objfarmerproducts.name);

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


        /*
          public DataTable SelectAllAdmin()
          {
              DataSet ds = new DataSet();
              SqlDataAdapter da;
              try
              {
                  SqlCommand cmd = new SqlCommand();
                  cmd.CommandText = "farmerproducts_SelectAllAdmin";
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


          public DataTable farmerproducts_WSSelectAll()
          {
              DataSet ds = new DataSet();
              SqlDataAdapter da;
              try
              {
                  SqlCommand cmd = new SqlCommand();
                  cmd.CommandText = "farmerproducts_WSSelectAll";
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

          public bool farmerproducts_IsActive(Int64 farmerproductsId, Boolean IsActive)
          {
              try
              {
                  SqlCommand cmd = new SqlCommand();
                  cmd.CommandText = "farmerproducts_IsActive";
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Connection = ConnectionString;
                  cmd.Parameters.AddWithValue("@id", farmerproductsId);
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

              public DataTable farmerproducts_WSSelectById(Int64 id)
          {
              DataSet ds = new DataSet();
              SqlDataAdapter da;
              try
              {
                  SqlCommand cmd = new SqlCommand();
                  cmd.CommandText = "farmerproducts_WSSelectById";
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


          */

        #endregion
    }




}
