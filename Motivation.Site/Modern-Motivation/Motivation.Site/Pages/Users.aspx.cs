using BikeRent.Web.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Motivation.Site.Pages
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Add(object sender, EventArgs e)
        {
            DBUtils.ExecuteNonQuery(@"
                INSERT INTO dbo.Users(
                    Login,
                    Name,
                    UserGroupId,
                    IsGeneral, 
                    Birthday,
                    Exp,
                    CoinsCount,
                    Password
                )
                VALUES
                (@Login, @Name, @UserGroupId, @IsGeneral, @Birthday, @Exp, @CoinsCount, @Password)",
               new SqlParameter("Login", LOGIN.Text),
               new SqlParameter("UserGroupId", USER_ROLE.SelectedValue),
               new SqlParameter("Name", NAME.Text),
               new SqlParameter("IsGeneral", IS_GENERAL.Checked),
               new SqlParameter("Birthday", DAT.Text),
               new SqlParameter("Exp", EXP.Text),
               new SqlParameter("CoinsCount", COINS.Text),
               new SqlParameter("Password", PASS.Text)
               );

            USERS.DataBind();
        }
    }
}