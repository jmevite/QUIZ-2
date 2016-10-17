using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

//namespaces

using System.Data;
using System.Data.SqlClient;
public partial class ADMIN_Products_Detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)              ///query is existing
        {
            int ProductID = 0; //initial value
            bool validID = int.TryParse(Request.QueryString["ID"].ToString(), out ProductID);

            if (validID)
            {
                if (!IsPostBack)         /// used to update the data 
                {
                    GetData(ProductID);
                    GetCategory();
                }
            }

            else
            {
                Response.Redirect("default.aspx");
            }
        }

        else
        {
            Response.Redirect("Default.aspx");
        }
        /// GetData(int.Parse(Request.QueryString["ID"].ToString()));

    }
    void GetCategory()
    {
        using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        {
            con.Open();
            string SQL = @"SELECT CatID, Category FROM Categories";

            using (SqlCommand cmd = new SqlCommand(SQL, con))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    ddlCategory.DataSource = dr;
                    ddlCategory.DataTextField = "Category";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();

                    ddlCategory.Items.Insert(0, new ListItem("Select from the list", ""));
                }
            }
        }
    }



    void GetData(int ID)
    {
        using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        {
            con.Open();
            string SQL = @"SELECT Name, CatID, Code, Description, Image, Price, IsFeatured, Available, CriticalLevel, Maximum FROM Products WHERE ProductID=@ProductID";


            using (SqlCommand cmd = new SqlCommand(SQL, con))
            {
                cmd.Parameters.AddWithValue("@ProductID", ID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows) // record existing
                    {
                        while (dr.Read())
                        {
                          
                            Prod_Name.Text = dr["Name"].ToString();
                            ddlCategory.Text = dr["CatID"].ToString();
                            Prod_Code.Text = dr["Code"].ToString();
                            Prod_Desc.Text = dr["Description"].ToString();

                            //string fileExt = Path.GetExtension(Prod_Img.FileName);
                            //string id = Guid.NewGuid().ToString();

                            //cmd.Parameters.AddWithValue("@Image", id + fileExt);
                            //Prod_Img.SaveAs(Server.MapPath("~/img/products/" + id + fileExt));

                            Prod_Pric.Text = dr["Price"].ToString();
                            ddlFeatured.SelectedValue = dr["IsFeatured"].ToString();
                            Prod_CritLev.Text = dr["CriticalLevel"].ToString();
                            Prod_MaxNumofItems.Text = dr["Maximum"].ToString();          
                        }

                    }
                    else // record non-existent
                    {
                        Response.Redirect("Default.aspx");
                    }
                }


            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        {
            con.Open();
            string SQL = @"UPDATE Products SET Name=@Name, CatID=@CatID, Code=@Code, Description=@Description, Image=@Image, Price=@Price, IsFeatured=@IsFeatured, Available=Available, CriticalLevel=@CriticalLevel, Maximum=@Maximum, DateModified=@DateModified WHERE ProductID=@ProductID";  ///UPDATE STRING 
    


            //parameterized query 
            using (SqlCommand cmd = new SqlCommand(SQL, con))
            {
                cmd.Parameters.AddWithValue("@Name", Prod_Name.Text);
                cmd.Parameters.AddWithValue("@CatID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Description", Prod_Desc.Text);
                cmd.Parameters.AddWithValue("@Code", Prod_Code.Text);
                if (Prod_Img.HasFile)
                {
                    string file = Path.GetExtension(Prod_Img.FileName);
                    string id = Guid.NewGuid().ToString();
                    cmd.Parameters.AddWithValue("@Image", id + file);
                    Prod_Img.SaveAs(Server.MapPath("~/img/products/" + id + file));
                }

                else
                {
                    cmd.Parameters.AddWithValue("@Image", Session["image"].ToString());
                }


                cmd.Parameters.AddWithValue("@Price", Prod_Pric.Text);
                cmd.Parameters.AddWithValue("@IsFeatured", ddlFeatured.SelectedValue);
                cmd.Parameters.AddWithValue("@CriticalLevel", Prod_CritLev.Text);
                cmd.Parameters.AddWithValue("@Maximum", Prod_MaxNumofItems.Text);
                cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
                cmd.Parameters.AddWithValue("@ProductID", Request.QueryString["ID"].ToString());
                cmd.ExecuteNonQuery();
 
                con.Close(); ////may or may not///

                Response.Redirect("Default.aspx");
            }


        }

    }
}