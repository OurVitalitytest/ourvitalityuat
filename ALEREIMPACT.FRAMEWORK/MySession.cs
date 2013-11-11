using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace ALEREIMPACT.FRAMEWORK
{
    [Serializable]
    public class MySession
    {
        // private constructor
        private MySession()
        {
        }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session = (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        private string _LabelId;
        public string LabelId
        {
            get { return _LabelId; }
            set { _LabelId = value; }
        }
        private string _UserFirstName;
        public string UserFirstName
        {
            get { return _UserFirstName; }
            set { _UserFirstName = value; }
        }

        private string _searchfriendId;
        public string searchfriendId
        {
            get { return _searchfriendId; }
            set { _searchfriendId = value; }
        }
        private string _CircleId;
        public string CircleId
        {
            get { return _CircleId; }
            set { _CircleId = value; }
        }
        private string _MemberCircleId;
        public string MemberCircleId
        {
            get { return _MemberCircleId; }
            set { _MemberCircleId = value; }
        }

        private string _SelectedCircleUserId;
        public string SelectedCircleUserId
        {
            get { return _SelectedCircleUserId; }
            set { _SelectedCircleUserId = value; }
        }
        private string _SelectedCircleName;
        public string SelectedCircleName
        {
            get { return _SelectedCircleName; }
            set { _SelectedCircleName = value; }
        }

        private string _MemberUserId;
        public string MemberUserId
        {
            get { return _MemberUserId; }
            set { _MemberUserId = value; }
        }

        private Int32 _page_index;
        public Int32 PageIndex
        {
            get { return _page_index; }
            set { _page_index = value; }
        }

        private Int32 _page_size;
        public Int32 PageSize
        {
            get { return _page_size; }
            set { _page_size = value; }
        }

        private Int32 _rows_generated;
        public Int32 RowsGenerated
        {
            get { return _rows_generated; }
            set { _rows_generated = value; }
        }


        private string _Id;
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _LoginId;
        public string LoginId
        {
            get { return _LoginId; }
            set { _LoginId = value; }
        }
        private string _Image;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        private string _ATId;
        public string ATId
        {
            get { return _ATId; }
            set { _ATId = value; }
        }
        private string _UPCID;
        public string UPCID
        {
            get { return _UPCID; }
            set { _UPCID = value; }
        }

        private string _PublicCircleUserId;
        public string PublicCircleUserId
        {
            get { return _PublicCircleUserId; }
            set { _PublicCircleUserId = value; }
        }

        private string _PublicCircleId;
        public string PublicCircleId
        {
            get { return _PublicCircleId; }
            set { _PublicCircleId = value; }
        }

        private string _PublicPermissions;
        public string PublicPermissions
        {
            get { return _PublicPermissions; }
            set { _PublicPermissions = value; }
        }


        private string _StatusID;
        public string StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }

        private string _LinkID;
        public string LinkID
        {
            get { return _LinkID; }
            set { _LinkID = value; }
        }


        private string _ETID;
        public string ETID
        {
            get { return _ETID; }
            set { _ETID = value; }
        }
        private string _UserCircleID;
        public string UserCircleID
        {
            get { return _UserCircleID; }
            set { _UserCircleID = value; }
        }
        private string _SearchNAme;
        public string SearchNAme
        {
            get { return _SearchNAme; }
            set { _SearchNAme = value; }
        }
    }
}
