<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project_3_Online_Dating_Site.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/Home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="topnav">
                                   <%-- //https://www.w3schools.com/w3css/w3css_navigation.asp
            //Literally Copy their template for the nav bar--%>
            <a>
                <img src="Images/LoveCupids.png" alt="Logo"/>
            </a>
            <a>
            <asp:Label ID="lblDisplayTitle" runat="server" Text="CupidConnect" Height="100px" Width="480px" style="font-size: 73px;"></asp:Label>
            </a>
            <a class="active" href="#home">
                <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" Height="100px" Width="140px" />
            </a>
            <a>
                <asp:Button ID="btnViewProfile" runat="server" Text="View Profile" OnClick="btnViewProfile_Click" Height="100px" Width="140px" />
            </a>
            <a>
                <asp:Button ID="btnViewLikes" runat="server" Text="Likes" OnClick="btnViewLikes_Click" Height="100px" Width="140px"/>
            </a>
            <a>
                <asp:Button ID="btnViewMatches" runat="server" Text="Match" OnClick="btnViewMatches_Click" Height="100px" Width="140px"/>
            </a>
            <a>
                <asp:Button ID="btnViewDate" runat="server" Text="Dates" OnClick="btnViewDate_Click" Height="100px" Width="140px"/>
            </a>
            <a>
                <asp:Button ID="btnDatePlan" runat="server" Text="Plans" OnClick="btnDatePlan_Click" Height="100px" Width="140px"/>
            </a>
            <a>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" Height="100px" Width="140px"/>
            </a>
        </div>
        <h2 class ="FilterHeading">Filters</h2>
        <div class="Filter">
            <div>
                <asp:Label ID="lblCity" runat="server" Text="Filter by City"></asp:Label>
                <br />
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblState" runat="server" Text="Filter by State"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblCommitmentType" runat="server" Text="Filter by Commitment Type"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlCommitmentType" runat="server"></asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblFilterByOccupation" runat="server" Text="Filter by Occupation"></asp:Label>
                <br />
                <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblInterest" runat="server" Text="Filter by Interest"></asp:Label>
                <br />
                <asp:TextBox ID="txtInterest" runat="server"></asp:TextBox>
            </div>    
            <div>
                <asp:Button ID="btnFilterSearch" runat="server" Text="Filter" OnClick="btnFilterSearch_Click" Height="41px" Width="99px" />
            </div>
        </div>
        <div class ="Body">
            <div>
                <h2>Profile View</h2>
                <asp:Repeater ID="rptUsers" runat="server" OnItemCommand="rptUsers_ItemCommand">
                    <ItemTemplate>
                        <div class ="profile">
                            <asp:Image ID="imgDisplaPhotoURL" runat="server" ImageUrl='<%# Eval("PhotoURL") %>' /><br />
                            <asp:Label ID="lblDisplayFullName" runat="server" Text='<%# Eval("FullName") + "," %>'></asp:Label>
                            <asp:Label ID="lblDisplayAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label><br />
                            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                            <asp:Label ID="lblDisplayUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label><br />
                            <asp:Label ID="lblLocation" runat="server" Text="Location: "></asp:Label>
                            <asp:Label ID="lblDisplayCity" runat="server" Text='<%# Eval("City") + ","%>'></asp:Label>
                            <asp:Label ID="lblDisplayState" runat="server" Text='<%# Eval("State") %>'></asp:Label><br />
                            <asp:Label ID="lblSeeking" runat="server" Text="Seeking for: "></asp:Label>
                            <asp:Label ID="lblDisplayCommitmentType" runat="server" Text='<%# Eval("CommitmentType") %>'></asp:Label><br />
                            <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
                            <asp:Label ID="lblDisplayDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label><br />
        <%--                    <asp:Label ID="lblInterests" runat="server" Text="Interest: "></asp:Label>
                            <asp:Label ID="lblDisplayInterests" runat="server" Text='<%# Eval("Interests") %>'></asp:Label><br />
                            --%><asp:Button ID="btnViewProfile" CommandName="ViewProfile" CommandArgument='<%# Eval("UserId") %>' Text="View" runat="server" Height="41px" Width="99px" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div>
                <h2>Select Profile</h2>
                <asp:Repeater ID="rptViewProfile" runat="server" OnItemCommand="rptProfileView_ItemCommand">
                    <ItemTemplate>
                        <div class ="profile">
                            <asp:Image ID="imgDisplaPhotoURL" runat="server" ImageUrl='<%# Eval("PhotoURL") %>' /><br />
                            <asp:Label ID="lblDisplayFullName" runat="server" Text='<%# Eval("FullName") + "," %>'></asp:Label>
                            <asp:Label ID="lblDisplayAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label><br />
                            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                            <asp:Label ID="lblDisplayUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label><br />
                            <asp:Label ID="lblLocation" runat="server" Text="Location: "></asp:Label>
                            <asp:Label ID="lblDisplayCity" runat="server" Text='<%# Eval("City") + ","%>'></asp:Label>
                            <asp:Label ID="lblDisplayState" runat="server" Text='<%# Eval("State") %>'></asp:Label><br />
                            <asp:Label ID="lblSeeking" runat="server" Text="Seeking for: "></asp:Label>
                            <asp:Label ID="lblDisplayCommitmentType" runat="server" Text='<%# Eval("CommitmentType") %>'></asp:Label><br />
                            <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
                            <asp:Label ID="lblDisplayDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label><br />
                            <asp:Label ID="lblQuote" runat="server" Text="Favorite Quote: "></asp:Label>
                            <asp:Label ID="lblDisplayQuote" runat="server" Text='<%# Eval("FavoriteQuote") %>'></asp:Label><br />
        <%--                    <asp:Label ID="lblInterests" runat="server" Text="Interest: "></asp:Label>
                            <asp:Label ID="lblDisplayInterests" runat="server" Text='<%# Eval("Interests") %>'></asp:Label><br />
         --%>                   <asp:Button ID="btnLike" CommandName="Like" CommandArgument='<%# Eval("UserId") %>' Text="Like" runat="server" />
        <%--                    <asp:Button ID="btnCloses" CommandName="Close" CommandArgument='<%# Eval("UserId") %>' Text="Close" runat="server" />--%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div>
                <h2>Notification(s)</h2>
                <asp:Label ID="lblIncomingRequests" runat="server" Text="You have 0 incoming date requests."></asp:Label><br />
                <asp:Label ID="lblIncomingMatches" runat="server" Text="You have 0 incoming match requests."></asp:Label>
            </div>
        </div>
        <div id="footer">
            <p>Footer</p>
        </div>
    </form>
</body>
</html>
