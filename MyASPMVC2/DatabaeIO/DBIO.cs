
using DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    class DBIO
    {
        //khai báo myDB của Provider vào đây
        MyDb mydb = new MyDb();

        public dbo_TVLT_Users GetObject_User(string uid, string pwd)

        {//1 không sử dụng Parameters - chỉ  là chuỗi truy vấn bth
         // string SQL = "SELECT* FROM dbo_TVLT_Users WHERE  Uid= '" + uid + "' AND Pwd='"+pwd+"' ";
         //phải thao tác b4 tải entityFrameWork vào để .cái sinh ra database lun
         // return mydb.Database.SqlQuery<dbo_TVLT_Users>(SQL).FirstOrDefault();

            //2 có sử dụng Parameters -lằng nhằng k nên dùng
            return mydb.Database.SqlQuery<dbo_TVLT_Users>
                ("SELECT * FROM dbo_TVLT_Users WHERE Uid = @U AND Pwd= @ ",
                new SqlParameter("@U", uid),
                new SqlParameter("@P", pwd))
                .FirstOrDefault();

        }
    }
}
