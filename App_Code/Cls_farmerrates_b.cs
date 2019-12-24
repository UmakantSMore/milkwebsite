using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_farmerrates_b
    {

        #region Constructor
        public Cls_farmerrates_b()
        { }
        #endregion

        #region Public Methods

        /*
        public DataTable SelectAllAdmin()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmerrates_db objCls_farmerrates_db = new Cls_farmerrates_db();
                dt = objCls_farmerrates_db.SelectAllAdmin();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmerrates_db objCls_farmerrates_db = new Cls_farmerrates_db();
                dt = objCls_farmerrates_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable farmerrates_WSSelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmerrates_db objCls_farmerrates_db = new Cls_farmerrates_db();
                dt = objCls_farmerrates_db.farmerrates_WSSelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable farmerrates_WSSelectById(Int64 cid)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmerrates_db objCls_farmerrates_db = new Cls_farmerrates_db();
                dt = objCls_farmerrates_db.farmerrates_WSSelectById(cid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public bool Delete(Int64 cid)
        {
            bool result = false;
            try
            {
                Cls_farmerrates_db objCls_farmerrates_db = new Cls_farmerrates_db();
                if (objCls_farmerrates_db.Delete(cid))
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
        public bool farmerrates_IsActive(Int64 farmerratesId, Boolean IsActive)
        {
            try
            {
                Cls_farmerrates_db objCls_farmerrates_db = new Cls_farmerrates_db();
                if (objCls_farmerrates_db.farmerrates_IsActive(farmerratesId, IsActive))
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

        public Int64 Insert(farmerrates objfarmerrates)
        {
            Int64 result = 0;
            try
            {
                Cls_farmerrates_db objCls_farmerrates_db = new Cls_farmerrates_db();
                result = Convert.ToInt64(objCls_farmerrates_db.Insert(objfarmerrates));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(farmerrates objfarmerrates)
        {
            Int64 result = 0;
            try
            {
                Cls_farmerrates_db objCls_farmerrates_db = new Cls_farmerrates_db();
                result = Convert.ToInt64(objCls_farmerrates_db.Update(objfarmerrates));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public DataTable SelectByFarmerId(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmerrates_db objCls_farmerrates_db = new Cls_farmerrates_db();
                dt = objCls_farmerrates_db.SelectByFarmerId(id);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        



        #endregion


    }
    public class farmerrates
    {
        public farmerrates()
        { }


        #region Private Variables
        private Int64 _id;
        private Int64 _farmerid;
        private Int64 _productid;
        private string _product;
        private Decimal _rate;
        
        private Boolean _isdeleted;
        #endregion

        //id, farmerid, productid, rate, isdeleted

        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Int64 farmerid
        {
            get { return _farmerid; }
            set { _farmerid = value; }
        }
        public Int64 productid
        {
            get { return _productid; }
            set { _productid = value; }
        }

        public string productname
        {
            get { return _product; }
            set { _product = value; }
        }
        public decimal rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        public Boolean isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }

        #endregion
    }

}
