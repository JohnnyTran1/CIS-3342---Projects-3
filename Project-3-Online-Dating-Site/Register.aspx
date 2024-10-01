<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project_3_Online_Dating_Site.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <meta name="viewport"  content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <link href="Content/bootstrap.min.css "  rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Style/Login.css" rel="stylesheet"  />
</head>
<body>
    <form id="form1" runat="server">
<%-- This link to where I copy the bootstrap template, example: variation #5--%>
<%--    https://mdbootstrap.com/docs/standard/extended/login/--%>
        <section class="vh-100 gradient-custom">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div class="header-container">
<%--                            <h1>EverAfterMatch - Register</h1>--%>
                        </div>
                        <div class="card bg-dark text-white" style="border-radius: 1rem;">
                            <div class="card-body p-5 text-center">
                                <h4 class="text-white">Register with your Email, Full Name, Username, and Password:</h4>
                                
                                <div class="form-outline form-white mb-4">
                                    <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label" Text="Email"></asp:Label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:CustomValidator ID="valEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Numbers and letters that end with @!" ForeColor="Red" OnServerValidate="rfvEmail_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                                </div>
                                
                                <div class="form-outline form-white mb-4">
                                    <asp:Label ID="lblFullName" runat="server" AssociatedControlID="txtFullName" CssClass="form-label" Text="Full Name"></asp:Label>
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:CustomValidator ID="valFirstName" runat="server" ControlToValidate="txtFullName" ErrorMessage="Letters only!" ForeColor="Red" OnServerValidate="rfvName_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                                </div>
                                
                                <div class="form-outline form-white mb-4">
                                    <asp:Label ID="lblUserName" runat="server" AssociatedControlID="txtUserName" CssClass="form-label" Text="Username"></asp:Label>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:CustomValidator ID="valUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Only letters and numbers!" ForeColor="Red" OnServerValidate="rfvUserName_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                                </div>
                                
                                <div class="form-outline form-white mb-4">
                                    <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="form-label" Text="Password"></asp:Label>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:CustomValidator ID="valPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Need letters and numbers!" ForeColor="Red" OnServerValidate="rfvPassword_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                                </div>
                                
                                <div class="form-outline form-white mb-4">
                                    <asp:Label ID="lblVerifyPassword" runat="server" AssociatedControlID="txtVerifyPassword" CssClass="form-label" Text="Verify Password"></asp:Label>
                                    <asp:TextBox ID="txtVerifyPassword" runat="server" TextMode="Password" CssClass="form-control form-control-lg"></asp:TextBox>
                                    <asp:CustomValidator ID="valVerifyPassword" runat="server" ControlToValidate="txtVerifyPassword" ErrorMessage="Passwords do not match!" ForeColor="Red" OnServerValidate="rfvVerifyPassword_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                                </div>
                                
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-outline-light btn-lg px-5" Text="Submit" OnClick="btnLogin_Click" />
                                <br />
                                <asp:Label ID="lblCheckError" runat="server" CssClass="text-white-50" Text="Yo" Visible="False"></asp:Label>
                                <br />
                                <p class="mb-0">Already a user? <a href="Login.ASPX" class="text-white-50 fw-bold">Log in</a></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
