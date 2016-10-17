<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="ADMIN_Products_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Product Details</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
 <div class="container">
        <h1 class="text-left"> Add a Product</h1>
        <div class="col-lg-12">
            <div class="well clearfix">
                <form runat="server" class="form-horizontal">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label col-lg-4">Name</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="Prod_Name" runat="server"
                                    class="form-control" autocomplete="off"
                                    MaxLength="100" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Category</label>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="ddlCategory" runat="server"
                                    CssClass="form-control" required />
                            </div>
                        </div>
                          <div class="form-group">
                            <label class="control-label col-lg-4">Code</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="Prod_Code" runat="server"
                                   class="form-control" autocomplete="off"
                                   MaxLength="20" required />
                            </div>
                        </div>
                        <div class="form-group">
                        <label class="control-label col-lg-4">Description</label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="Prod_Desc" runat="server" CssClass="form-control"  
                                MaxLength="300" TextMode="MultiLine" Rows="3" required />
                        </div>
                    </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Image</label>
                            <div class="col-lg-8">
                                <asp:FileUpload runat="server" ID="Prod_Img" CssClass="form-control" />
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="control-label col-lg-4">Price</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="Prod_Pric" runat="server"
                                    class="form-control" autocomplete="off" Type="Number"
                                    min="0.01" max="500000.00" step="0.01" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Is Featured?</label>
                            <div class="col-lg-8">
                                <asp:DropDownList ID="ddlFeatured" runat="server" CssClass="form-control">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        </div>
                        <div class="col-lg-6"> 
                        <div class="form-group">
                            <label class="control-label col-lg-4">Critical Level</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="Prod_CritLev" runat="server" Type="Number"
                                    class="form-control" autocomplete="off"
                                    MaxLength="12" required />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-4">Maximum</label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="Prod_MaxNumofItems" runat="server" Type="Number"
                                    class="form-control" autocomplete="off"
                                    MaxLength="12" required />
                            </div>
                        </div>
                      
                                <div class="form-group">
                                    <div class="col-lg-offset-4 col-lg-8">
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success btn-lg pull-right" Text="Update" OnClick="btnUpdate_Click" />
                                        <a href="Default.aspx" class="btn btn-default btn-group-lg">Back </a>

                                    </div>
                                </div>

                                </div>
                    </form>
                            </div>
                

            </div>
        </div>

</body>
</html>
