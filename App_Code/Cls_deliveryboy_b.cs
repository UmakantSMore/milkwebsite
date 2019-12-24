using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_deliveryboy_b
{
    public Cls_deliveryboy_b()
    {
        //
        // TODO: Add constructor logic here
        //
    }
        #region Public Methods

        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_deliveryboy_db objCls_deliveryboy_db = new Cls_deliveryboy_db();
                dt = objCls_deliveryboy_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }


        public deliveryboyMaster  SelectById(Int64 id)
        {
            deliveryboyMaster objdeliveryboyMaster = new deliveryboyMaster();
            try
            {
                Cls_deliveryboy_db objCls_deliveryboy_db = new Cls_deliveryboy_db();

                objdeliveryboyMaster = objCls_deliveryboy_db.SelectById(id);
                return objdeliveryboyMaster;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objdeliveryboyMaster;
            }
        }

        public Int64 Insert(deliveryboyMaster objdeliveryboyMaster)
        {
            Int64 result = 0;
            try
            {
                Cls_deliveryboy_db objCls_deliveryboy_db = new Cls_deliveryboy_db();

                result = Convert.ToInt64(objCls_deliveryboy_db.Insert(objdeliveryboyMaster));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public Int64 Update(deliveryboyMaster objdeliveryboyMaster)
        {
            Int64 result = 0;
            try
            {
                Cls_deliveryboy_db objCls_deliveryboy_db = new Cls_deliveryboy_db();

                result = Convert.ToInt64(objCls_deliveryboy_db.Update(objdeliveryboyMaster));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public bool Delete(Int32 id)
        {
            try
            {
                Cls_deliveryboy_db objCls_deliveryboy_db = new Cls_deliveryboy_db();

                if (objCls_deliveryboy_db.Delete(id))
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

        public bool deliveryboy_IsActive(Int64 ProductId, Boolean IsActive)
        {
            try
            {
                Cls_deliveryboy_db  objCls_product_db = new Cls_deliveryboy_db();
                if (objCls_product_db.deliveryboy_IsActive(ProductId, IsActive))
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
    public class deliveryboyMaster
    {
        public deliveryboyMaster()
        { }
        //vid, vendorName, Address1, Address2, MobileNo1, MobileNo2, email, landline, fk_countryId, fk_stateId, fk_cityId, createddate, isdelete, isactive
        #region Private Variables
        private Int64 _id;
        private string  _Name;
        private String _img;
        private String _Address1;   
        private String _MobileNo1;        
        private String _password;
        private String _email;
        private String _landline;    
        private String _latitude;
        private String _loginitude;
        private DateTime _createddate;
        private Boolean _isdelete;
        private Boolean _isactive;
        #endregion



        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string  Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public String img
        {
            get { return _img; }
            set { _img = value; }
        }
        public String Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }
      
        public String MobileNo1
        {
            get { return _MobileNo1; }
            set { _MobileNo1 = value; }
        }
        
        public String password
        {
            get { return _password; }
            set { _password = value; }
        }
        public String email
        {
            get { return _email; }
            set { _email = value; }
        }
        public String landline
        {
            get { return _landline; }
            set { _landline = value; }
        }
         
        public String latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        public String loginitude
        {
            get { return _loginitude; }
            set { _loginitude = value; }
        }

        public DateTime createddate
        {
            get { return _createddate; }
            set { _createddate = value; }
        }
        public Boolean isdelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }
        public Boolean isactive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }




        #endregion
    }

}
