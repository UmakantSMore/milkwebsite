using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_farmercollection_b
    {

        #region Constructor
        public Cls_farmercollection_b()
        { }
        #endregion

        #region Public Methods

        /*
        public DataTable SelectAllAdmin()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmercollection_db objCls_farmercollection_db = new Cls_farmercollection_db();
                dt = objCls_farmercollection_db.SelectAllAdmin();
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
                Cls_farmercollection_db objCls_farmercollection_db = new Cls_farmercollection_db();
                dt = objCls_farmercollection_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable farmercollection_WSSelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmercollection_db objCls_farmercollection_db = new Cls_farmercollection_db();
                dt = objCls_farmercollection_db.farmercollection_WSSelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable farmercollection_WSSelectById(Int64 cid)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmercollection_db objCls_farmercollection_db = new Cls_farmercollection_db();
                dt = objCls_farmercollection_db.farmercollection_WSSelectById(cid);
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
                Cls_farmercollection_db objCls_farmercollection_db = new Cls_farmercollection_db();
                if (objCls_farmercollection_db.Delete(cid))
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
        public bool farmercollection_IsActive(Int64 farmercollectionId, Boolean IsActive)
        {
            try
            {
                Cls_farmercollection_db objCls_farmercollection_db = new Cls_farmercollection_db();
                if (objCls_farmercollection_db.farmercollection_IsActive(farmercollectionId, IsActive))
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

            public Int64 Update(farmercollection objfarmercollection)
        {
            Int64 result = 0;
            try
            {
                Cls_farmercollection_db objCls_farmercollection_db = new Cls_farmercollection_db();
                result = Convert.ToInt64(objCls_farmercollection_db.Update(objfarmercollection));
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
                Cls_farmercollection_db objCls_farmercollection_db = new Cls_farmercollection_db();
                dt = objCls_farmercollection_db.SelectByFarmerId(id);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }


        
    */

        public Int64 Insert(farmercollection objfarmercollection)
        {
            Int64 result = 0;
            try
            {
                Cls_farmercollection_db objCls_farmercollection_db = new Cls_farmercollection_db();
                result = Convert.ToInt64(objCls_farmercollection_db.Insert(objfarmercollection));
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
    public class farmercollection
    {
        public farmercollection()
        { }


        #region Private Variables
        private Int64 _id;
        private Int64 _farmerid;
        private Int64 _productid;
        private Decimal _quantity;
        private Decimal _rate;
        private DateTime _createddate;
        private Boolean _isdeleted;
        #endregion

        //id, farmerid, productid, quantity, rate, createddate, isdeleted

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

        public decimal quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
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
        public DateTime createddate
        {
            get { return _createddate; }
            set { _createddate = value; }
        }



        #endregion
    }

}
