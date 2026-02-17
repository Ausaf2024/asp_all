using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Asp_Final_All_2022024
{
    public partial class Login : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ABC"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.Text;
            

                 SqlDataReader dr = cmd.ExecuteReader(); 
            
                if (txtuser.Text.ToString() != "Shahin")
                {
                    Response.Write("<script>alert('username is not valid..');</script>");
                    return;
                }
                else if (txtpass.Text != "Sha@123")
                {
                    Response.Write("<script>alert('Password is not valid..');</script>");
                    return;
                }

                if (dr.HasRows)
                {
                    Response.Write("<script>window.location='contact.aspx';</script>");

                }
                else
                {
                    Response.Write("<script>window.location='Login.aspx';alert('Username Password is not valid..')</script>");


                }
            
            con.Close();

        }
        
    }
}