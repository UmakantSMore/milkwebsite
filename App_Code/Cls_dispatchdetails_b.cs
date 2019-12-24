using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_dispatchdetails_b
    {

        #region Constructor
        public Cls_dispatchdetails_b()
        { }
        #endregion

        #region Public Methods

        /*
        public DataTable SelectAllAdmin()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                dt = objCls_dispatchdetails_db.SelectAllAdmin();
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
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                dt = objCls_dispatchdetails_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable dispatchdetails_WSSelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                dt = objCls_dispatchdetails_db.dispatchdetails_WSSelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable dispatchdetails_WSSelectById(Int64 cid)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                dt = objCls_dispatchdetails_db.dispatchdetails_WSSelectById(cid);
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
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                if (objCls_dispatchdetails_db.Delete(cid))
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
        public bool dispatchdetails_IsActive(Int64 dispatchdetailsId, Boolean IsActive)
        {
            try
            {
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                if (objCls_dispatchdetails_db.dispatchdetails_IsActive(dispatchdetailsId, IsActive))
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

            public Int64 Update(dispatchdetails objdispatchdetails)
        {
            Int64 result = 0;
            try
            {
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                result = Convert.ToInt64(objCls_dispatchdetails_db.Update(objdispatchdetails));
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
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                dt = objCls_dispatchdetails_db.SelectByFarmerId(id);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }


        
    */

        public DataTable SelectAllAdmin()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                dt = objCls_dispatchdetails_db.SelectAllAdmin();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public Int64 Insert(dispatchdetails objdispatchdetails)
        {
            Int64 result = 0;
            try
            {
                Cls_dispatchdetails_db objCls_dispatchdetails_db = new Cls_dispatchdetails_db();
                result = Convert.ToInt64(objCls_dispatchdetails_db.Insert(objdispatchdetails));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }




        #endregion


    }
    public class dispatchdetails
    {
        public dispatchdetails()
        { }


        #region Private Variables
        private Int64 _id;
       
        private Int64 _productid;
        private string _productname;
        private Int64 _senderid;
        private Decimal _quantity;
        private DateTime _createddate;
        private Boolean _isdeleted;
        private Boolean _isdelivered;
        #endregion

        //id, productid, quantity, createddate, isdelivered, isdeleted

        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Int64 productid
        {
            get { return _productid; }
            set { _productid = value; }
        }
        public string productname
        {
            get { return _productname; }
            set { _productname = value; }
        }
        public Int64 senderid
        {
            get { return _senderid; }
            set { _senderid = value; }
        }

        public decimal quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public Boolean isdelivered
        {
            get { return _isdelivered; }
            set { _isdelivered = value; }
        }

        public Boolean isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }
        public DateTime createddate
        {
            get { return _createddate; }
            set { _createddate = value; }
        }



        #endregion
    }

}
