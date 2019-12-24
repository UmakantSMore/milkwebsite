using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_farmerproducts_b
    {

        #region Constructor
        public Cls_farmerproducts_b()
        { }
        #endregion

        #region Public Methods

        /*
        public DataTable SelectAllAdmin()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmerproducts_db objCls_farmerproducts_db = new Cls_farmerproducts_db();
                dt = objCls_farmerproducts_db.SelectAllAdmin();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        
        public DataTable farmerproducts_WSSelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmerproducts_db objCls_farmerproducts_db = new Cls_farmerproducts_db();
                dt = objCls_farmerproducts_db.farmerproducts_WSSelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable farmerproducts_WSSelectById(Int64 cid)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmerproducts_db objCls_farmerproducts_db = new Cls_farmerproducts_db();
                dt = objCls_farmerproducts_db.farmerproducts_WSSelectById(cid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        
        public bool farmerproducts_IsActive(Int64 farmerproductsId, Boolean IsActive)
        {
            try
            {
                Cls_farmerproducts_db objCls_farmerproducts_db = new Cls_farmerproducts_db();
                if (objCls_farmerproducts_db.farmerproducts_IsActive(farmerproductsId, IsActive))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    */

        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmerproducts_db objCls_farmerproducts_db = new Cls_farmerproducts_db();
                dt = objCls_farmerproducts_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public Int64 Insert(farmerproducts objfarmerproducts)
        {
            Int64 result = 0;
            try
            {
                Cls_farmerproducts_db objCls_farmerproducts_db = new Cls_farmerproducts_db();
                result = Convert.ToInt64(objCls_farmerproducts_db.Insert(objfarmerproducts));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(farmerproducts objfarmerproducts)
        {
            Int64 result = 0;
            try
            {
                Cls_farmerproducts_db objCls_farmerproducts_db = new Cls_farmerproducts_db();
                result = Convert.ToInt64(objCls_farmerproducts_db.Update(objfarmerproducts));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public farmerproducts SelectById(Int64 cid)
        {
            farmerproducts objfarmerproducts = new farmerproducts();
            try
            {
                Cls_farmerproducts_db objCls_farmerproducts_db = new Cls_farmerproducts_db();
                objfarmerproducts = objCls_farmerproducts_db.SelectById(cid);
                return objfarmerproducts;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objfarmerproducts;
            }
        }

        public bool Delete(Int64 cid)
        {
            bool result = false;
            try
            {
                Cls_farmerproducts_db objCls_farmerproducts_db = new Cls_farmerproducts_db();
                if (objCls_farmerproducts_db.Delete(cid))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                ErrHandler.writeError(ex.Message, ex.StackTrace);
            }
            return result;
        }


        #endregion


    }
    public class farmerproducts
    {
        public farmerproducts()
        { }


        #region Private Variables
        private Int64 _id;
        private string _name;
        
        private Boolean _isdeleted;
        #endregion

        //id, farmerid, productid, rate, isdeleted

        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Boolean isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }

        #endregion
    }

}
