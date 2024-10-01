<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project_3_Online_Dating_Site.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="viewport"  content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <link href="Content/bootstrap.min.css "  rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Style/Login.css" rel="stylesheet"  />
</head>
<body>
    <%-- This link to where I copy the bootstrap template, example: variation #5--%>
<%--    https://mdbootstrap.com/docs/standard/extended/login/--%>
    <form id="form1" runat="server">
        <section class="vh-100 gradient-custom">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <%--<div class="header-container">
                                <h1>EverAfterMatch-Login</h1>
                        </div>--%>                        
                        <div class="card bg-dark text-white" style="border-radius: 1rem;">
                            <div class="card-body p-5 text-center">
                                <div class="mb-md-5 mt-md-4 pb-5">

                                    <h2 class="fw-bold mb-2 text-uppercase">Login</h2>
                                    <p class="text-white-50 mb-5">Please enter your login and password!</p>

                                    <div class="form-outline form-white mb-4">
                                        <asp:Label ID="lblUserName" runat="server" AssociatedControlID="txtUsername" CssClass="form-label" Text="Username"></asp:Label>
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                        <asp:CustomValidator ID="valUsername" runat="server" ControlToValidate="txtUsername" 
                                            ErrorMessage="Enter username!" ForeColor="Red" OnServerValidate="rfvUserName_ServerValidate" 
                                            ValidateEmptyText="True"></asp:CustomValidator>
                                    </div>

                                    <div class="form-outline form-white mb-4">
                                        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="form-label" Text="Password"></asp:Label>
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control form-control-lg"></asp:TextBox>
                                        <asp:CustomValidator ID="valPassword" runat="server" ControlToValidate="txtPassword" 
                                            ErrorMessage="Enter Password!" ForeColor="Red" OnServerValidate="rfvPassword_ServerValidate" 
                                            ValidateEmptyText="True"></asp:CustomValidator>
                                    </div>

                                    <asp:Label ID="lblCheckError" runat="server" Text="Yo" CssClass="small mb-5 pb-lg-2 text-white-50" Visible="False" ForeColor="Red"></asp:Label>
                                    <br />
                                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-outline-light btn-lg px-5" Text="Login" OnClick="btnLogin_Click" />

                                </div>

                                <div>
                                    <p class="mb-0">Don't have an account? <a href="Register.ASPX" class="text-white-50 fw-bold">Sign Up</a></p>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
