using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_farmermaster_b
    {

        #region Constructor
        public Cls_farmermaster_b()
        { }
        #endregion

        #region Public Methods
        public DataTable SelectAllAdmin()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmermaster_db objCls_farmermaster_db = new Cls_farmermaster_db();
                dt = objCls_farmermaster_db.SelectAllAdmin();
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
                Cls_farmermaster_db objCls_farmermaster_db = new Cls_farmermaster_db();
                dt = objCls_farmermaster_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable farmermaster_WSSelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmermaster_db objCls_farmermaster_db = new Cls_farmermaster_db();
                dt = objCls_farmermaster_db.farmermaster_WSSelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public farmermaster SelectById(Int64 cid)
        {
            farmermaster objfarmermaster = new farmermaster();
            try
            {
                Cls_farmermaster_db objCls_farmermaster_db = new Cls_farmermaster_db();
                objfarmermaster = objCls_farmermaster_db.SelectById(cid);
                return objfarmermaster;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objfarmermaster;
            }
        }
        public DataTable farmermaster_WSSelectById(Int64 cid)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_farmermaster_db objCls_farmermaster_db = new Cls_farmermaster_db();
                dt = objCls_farmermaster_db.farmermaster_WSSelectById(cid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public Int64 Insert(farmermaster objfarmermaster)
        {
            Int64 result = 0;
            try
            {
                Cls_farmermaster_db objCls_farmermaster_db = new Cls_farmermaster_db();
                result = Convert.ToInt64(objCls_farmermaster_db.Insert(objfarmermaster));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(farmermaster objfarmermaster)
        {
            Int64 result = 0;
            try
            {
                Cls_farmermaster_db objCls_farmermaster_db = new Cls_farmermaster_db();
                result = Convert.ToInt64(objCls_farmermaster_db.Update(objfarmermaster));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public bool Delete(Int64 cid)
        {
            bool result = false;
            try
            {
                Cls_farmermaster_db objCls_farmermaster_db = new Cls_farmermaster_db();
                if (objCls_farmermaster_db.Delete(cid))
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
        public bool farmermaster_IsActive(Int64 farmermasterId, Boolean IsActive)
        {
            try
            {
                Cls_farmermaster_db objCls_farmermaster_db = new Cls_farmermaster_db();
                if (objCls_farmermaster_db.farmermaster_IsActive(farmermasterId, IsActive))
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

        #endregion


    }
    public class farmermaster
    {
        public farmermaster()
        { }


        #region Private Variables
        private Int64 _id;
        private String _name;
        private String _img;
        private String _faddress;
        private String _mobileno;
        //private String _mobile2;
        private String _fpassword;
        private Decimal _milkrate;
        private String _emailid;
        private String _bankname;
        private String _accountno;
        private String _ifsc;
        private Int64 _countryid;
        private Int64 _stateid;
        private Int64 _cityid;

        private Boolean _isdeleted;
        private Boolean _isactive;
        #endregion

        //id, name, img, address, mobileno, mobile2, password, milkrate, emailid, bankname, accountno, ifsc, deviceid, countryid, stateid, cityid, isdeleted, isactive


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
        public string img
        {
            get { return _img; }
            set { _img = value; }
        }
        public string address
        {
            get { return _faddress; }
            set { _faddress = value; }
        }
        public string mobileno
        {
            get { return _mobileno; }
            set { _mobileno = value; }
        }
/*
        public string mobile2
        {
            get { return _mobile2; }
            set { _mobile2 = value; }
        }
  */
    public String password
        {
            get { return _fpassword; }
            set { _fpassword = value; }
        }
        public decimal milkrate
        {
            get { return _milkrate; }
            set { _milkrate = value; }
        }
        public String email
        {
            get { return _emailid; }
            set { _emailid = value; }
        }
        public String bankname
        {
            get { return _bankname; }
            set { _bankname = value; }
        }
        public String accountno
        {
            get { return _accountno; }
            set { _accountno = value; }
        }
        public String ifsc
        {
            get { return _ifsc; }
            set { _ifsc = value; }
        }
        public Int64 countryid
        {
            get { return _countryid; }
            set { _countryid = value; }
        }
        public Int64 stateid
        {
            get { return _stateid; }
            set { _stateid = value; }
        }
        public Int64 cityid
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        public Boolean isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }
        public Boolean isactive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }

        #endregion
    }

}
