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

public partial class Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GetCategory();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(Util.GetConnection()))
        {
            con.Open();
            string SQL = @"INSERT INTO Products VALUES ( @Name, @CatID, @Code, @Description, @Image, @Price, @IsFeatured, @Available, @CriticalLevel, @Maximum, @Status, @DateAdded, @DateModified)";
 

            //parameterized query 
            using (SqlCommand cmd = new SqlCommand(SQL, con))
            {
                cmd.Parameters.AddWithValue("@Name", Prod_Name.Text);
                cmd.Parameters.AddWithValue("@CatID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Code", Prod_Code.Text);
                cmd.Parameters.AddWithValue("@Description", Prod_Desc.Text);

                string fileExt = Path.GetExtension(Prod_Img.FileName);
                string id = Guid.NewGuid().ToString();
                cmd.Parameters.AddWithValue("@Image", id + fileExt);
                Prod_Img.SaveAs(Server.MapPath("~/img/products/" + id + fileExt));


                cmd.Parameters.AddWithValue("@Price", Prod_Pric.Text);
                cmd.Parameters.AddWithValue("@IsFeatured", ddlFeatured.SelectedValue);
                cmd.Parameters.AddWithValue("@Available", 0);
                cmd.Parameters.AddWithValue("@CriticalLevel", Prod_CritLev.Text);
                cmd.Parameters.AddWithValue("@Maximum", Prod_MaxNumofItems.Text);
                cmd.Parameters.AddWithValue("@Status", "Active");
                cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@DateModified", DBNull.Value);
                cmd.ExecuteNonQuery();
                Response.Redirect("Default.aspx");
            }


            
        }

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
}