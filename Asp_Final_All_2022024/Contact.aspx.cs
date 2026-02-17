using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp_Final_All_2022024
{
    public partial class Contact : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Aus"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCountry();
               Show();
            }
            
        }

        //public void Getcountry()
        //{
        //    con.Open();
        //   // SqlCommand cmd = new SqlCommand("select * from Country ", con);
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT CountryID, CountryName FROM Country", con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //  //  cmd.ExecuteNonQuery();
        //    con.Close();
        //    ddlcountry.DataSource = dt;
        //    ddlcountry.DataValueField = "CountryID";
        //    ddlcountry.DataTextField = "CountryName";
        //    ddlcountry.DataBind();
        //    ddlcountry.Items.Insert(0,new ListItem("select","0"));
        //}

        public void GetCountry()
        {
            
          
            SqlDataAdapter da = new SqlDataAdapter("SELECT CountryID, CountryName FROM Country", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlcountry.DataSource = dt;
            ddlcountry.DataTextField = "CountryName";
            ddlcountry.DataValueField = "CountryID";
            ddlcountry.DataBind();

            ddlcountry.Items.Insert(0, new ListItem("Select Country", "0"));
        }


        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlstate.Items.Clear();
            ddlcity.Items.Clear();
            Getstate();
        }

        public void Getstate()
        {
            if (ddlcountry.SelectedValue != "0")
            {
                SqlCommand cmd = new SqlCommand("SELECT StateID, StateName FROM State WHERE CountryID = @CountryID", con);
                cmd.Parameters.AddWithValue("@CountryID", ddlcountry.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlstate.DataSource = dt;
                ddlstate.DataTextField = "StateName";
                ddlstate.DataValueField = "StateID";
                ddlstate.DataBind();

                ddlstate.Items.Insert(0, new ListItem("Select State", "0"));
            }


            // ddlstate.Items.Insert(0, new ListItem("--select--","0"));
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select * from State where CountryID=" + ddlcountry.SelectedItem.Value,  con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //ddlstate.DataSource = dt;
            //ddlstate.DataValueField = "StateID";
            //ddlstate.DataTextField = "StateName";
            //ddlstate.DataBind();
            // ddlstate.Items.Insert(0, new ListItem("--select--","0"));
        }
        

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlcity.Items.Clear();
            Getcity();
        }

        public void Getcity()
        {
            if (ddlstate.SelectedValue != "0")
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT CityID, CityName FROM City WHERE StateID = @StateID", con);

                cmd.Parameters.AddWithValue("@StateID", ddlstate.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlcity.DataSource = dt;
                ddlcity.DataTextField = "CityName";
                ddlcity.DataValueField = "CityID";
                ddlcity.DataBind();

                ddlcity.Items.Insert(0, new ListItem("Select City", "0"));
            }
        

            //con.Open();
            //SqlCommand cmd = new SqlCommand("select * from City  where StateID=" + ddlstate.SelectedItem.Value, con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //ddlcity.DataSource = dt;
            //ddlcity.DataValueField = "CityID";
            //ddlcity.DataTextField = "CityName";
            //ddlcity.DataBind();
            // ddlcity.Items.Insert(0, new ListItem("--select--", "0"));
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                string varibal = "";

                for (int i = 0; i < chkhobbies.Items.Count; i++)
                {
                    if (chkhobbies.Items[i].Selected)
                    {
                        varibal += chkhobbies.Items[i].Text + ",";
                    }
                }

                varibal = varibal.TrimEnd(',');

                string FN = "";

                if (fuimg.HasFile)
                {
                    FN = Path.GetFileName(fuimg.FileName);
                    fuimg.SaveAs(Server.MapPath("~/PICS/" + FN));
                }

                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ALL_CURD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@CountryID", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@StateID", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@CityID", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@Gender", rbl.SelectedValue);
                cmd.Parameters.AddWithValue("@Hobbies", varibal);
                cmd.Parameters.AddWithValue("@Image_Upload", FN);

                int a = cmd.ExecuteNonQuery();
                con.Close();

                if (a > 0)
                {
                    Response.Write("<script>alert('Data Saved Successfully')</script>");
                    Show();   // 🔥 refresh grid
                    Clear();      // optional clear form
                }
                else
                {
                    Response.Write("<script>alert('Data Not Saved')</script>");
                }
            }

            else if (btnsave.Text =="Update" )
            {
                string varibal = "";
                for (int i = 0; i < chkhobbies.Items.Count; i++)
                {
                    if (chkhobbies.Items[i].Selected == true)
                    {
                        varibal += chkhobbies.Items[i].Text + ',';
                    }
                }
                varibal = varibal.Trim(',');
                string FN = Path.GetFileName(fuimg.PostedFile.FileName);

                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ALL_CURD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@id", ViewState["Aus"]);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@CountryID", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@StateID", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@CityID", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@Gender", rbl.SelectedValue);
                cmd.Parameters.AddWithValue("@Hobbies", varibal);
               
                if (FN != "")
                {
                    cmd.Parameters.AddWithValue("@Image_Upload", FN);
                    fuimg.SaveAs(Server.MapPath("PICS" + "\\" + FN));
                    File.Delete(Server.MapPath("PICS" + "\\" + ViewState["Aus"])); 
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Image_Upload", ViewState["Aus"]);
                }
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Update..')</script>");
            }

            Show();
            Clear();
        }

        public void Show()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_ALL_CURD", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Action", "ShowData");

            DataTable dt = new DataTable();
            da.Fill(dt);

            Grd.DataSource = dt;
            Grd.DataBind();
        

            //con.Open();
            //SqlCommand cmd = new SqlCommand("SP_ALL_CURD", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Action", "ShowData");
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //Grd.DataSource = dt;
            //Grd.DataBind();
        }

        protected void Grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Aus")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ALL_CURD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Edit");
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();
                txtname.Text = dt.Rows[0]["Name"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["CountryID"].ToString();
                Getstate();
                ddlstate.SelectedValue = dt.Rows[0]["StateID"].ToString();
                Getcity();
                ddlcity.SelectedValue = dt.Rows[0]["CityID"].ToString();
                rbl.SelectedValue = dt.Rows[0]["Gender"].ToString();
                ViewState["fuimg"] = dt.Rows[0]["Image_Upload"].ToString();
                ViewState["Aus"] = e.CommandArgument;
                btnsave.Text = "Update";
                //btnsave.BackColor =='Red';
                string depts = dt.Rows[0]["Hobbies"].ToString();
                string[] dept = depts.Split(',');
                if (dept.Length > 0)
                {
                    for (int i = 0; i < dept.Length; i++)
                    {
                        for (int j = 0; j < chkhobbies.Items.Count; j++)
                        {
                            if (chkhobbies.Items[j].Text == dept[i])
                            {
                                chkhobbies.Items[j].Selected = true;
                            }
                        }
                    }
                }


            }
            if (e.CommandName == "Bus")
            {
              
                 int rowIndex = Convert.ToInt32(((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex);
               
               
                // Get Image Name from GridView DataKeys

                int id = Convert.ToInt32(Grd.DataKeys[rowIndex]["id"]);
                string imageName = Grd.DataKeys[rowIndex]["Image_Upload"].ToString();
                

                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ALL_CURD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Delete");
                cmd.Parameters.AddWithValue("@id", id);
                int a=cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Response.Write("<script>alert('Data Deleted..')</script>");
                }
                con.Close();

                // Delete Image File Safely
                string path = Server.MapPath("~/PICS/" + imageName);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                Show(); // Refresh Grid
            }
        }

        public void Clear()
        {
            txtname.Text = "";
            ddlcountry.SelectedIndex = 0;
            ddlstate.SelectedIndex = 0;
            ddlcity.SelectedIndex = 0;
            
            rbl.ClearSelection();

            foreach (ListItem item in chkhobbies.Items)
            {
                item.Selected = false;
            }

            txtname.Focus();
        }
    }
}