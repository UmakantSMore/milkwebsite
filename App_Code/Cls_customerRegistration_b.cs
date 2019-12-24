using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_customerRegistration_b
{
    public Cls_customerRegistration_b()
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
                Cls_customerRegistration_db objCls_customerRegistration_db = new Cls_customerRegistration_db();
                dt = objCls_customerRegistration_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }


        public customerRegistration  SelectById(Int64 id)
        {
            customerRegistration objcustomerRegistration = new customerRegistration ();
            try
            {
                Cls_customerRegistration_db objCls_customerRegistration_db = new Cls_customerRegistration_db();

                objcustomerRegistration = objCls_customerRegistration_db.SelectById(id);
                return objcustomerRegistration;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objcustomerRegistration;
            }
        }

        public Int64 Insert(customerRegistration objcustomerRegistration)
        {
            Int64 result = 0;
            try
            {
                Cls_customerRegistration_db objCls_customerRegistration_db = new Cls_customerRegistration_db();

                result = Convert.ToInt64(objCls_customerRegistration_db.Insert(objcustomerRegistration));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public Int64 Update(customerRegistration objcustomerRegistration)
        {
            Int64 result = 0;
            try
            {
                Cls_customerRegistration_db objCls_customerRegistration_db = new Cls_customerRegistration_db();

                result = Convert.ToInt64(objCls_customerRegistration_db.Update(objcustomerRegistration));
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
                Cls_customerRegistration_db objCls_customerRegistration_db = new Cls_customerRegistration_db();

                if (objCls_customerRegistration_db.Delete(id))
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

        public bool customer_IsActive(Int64 id, Boolean IsActive)
        {
            try
            {
                Cls_customerRegistration_db objCls_customerRegistration_db = new Cls_customerRegistration_db();
                if (objCls_customerRegistration_db.customer_IsActive (id, IsActive))
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
    public class customerRegistration
    {
        public customerRegistration()
        { }
        //vid, vendorName, Address1, Address2, MobileNo1, MobileNo2, email, landline, fk_countryId, fk_stateId, fk_cityId, createddate, isdelete, isactive
        #region Private Variables

       
        private Int64 _id;
        private string _customerName;
        private string _email;
        private string _phoneNo;
        private string _address;
        private bool  _isdelete;
        private bool _isactive;
        private string   _password;
        private string _latitude;
        private string _lognitude;
        private string _img;
        private DateTime  _annivarsaryDate;
        private DateTime _birthdate;
        private string _business;
        private string _job;
        private string _reference;
        private string _days;
        private string _deliveryShift;
        private string _deliveryTime;
        private string _doorStep;

       
        #endregion



        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string customerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string phoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        public bool isdelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }
        public bool isactive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        public string lognitude
        {
            get { return _lognitude; }
            set { _lognitude = value; }
        }
        public string img
        {
            get { return _img; }
            set { _img = value; }
        }
        public DateTime annivarsaryDate
        {
            get { return _annivarsaryDate; }
            set { _annivarsaryDate = value; }
        }
        public DateTime birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }
        public string business
        {
            get { return _business; }
            set { _business = value; }
        }
        public string job
        {
            get { return _job; }
            set { _job = value; }
        }
        public string reference
        {
            get { return _reference; }
            set { _reference = value; }
        }
        public string days
        {
            get { return _days; }
            set { _days = value; }
        }
        public string deliveryShift
        {
            get { return _deliveryShift; }
            set { _deliveryShift = value; }
        }
        public string deliveryTime
        {
            get { return _deliveryTime; }
            set { _deliveryTime = value; }
        }
        public string doorStep
        {
            get { return _doorStep; }
            set { _doorStep = value; }
        }



        #endregion
    }

}
