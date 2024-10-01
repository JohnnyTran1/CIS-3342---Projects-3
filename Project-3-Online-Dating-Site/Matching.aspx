<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Matching.aspx.cs" Inherits="Project_3_Online_Dating_Site.Matching" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/Matches.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
            <div class ="Body">
             <h2>See people who you matched</h2>
             <asp:Repeater ID="rptMatching" runat="server" OnItemCommand="rptMatching_ItemCommand">
                 <ItemTemplate>
                     <div class="profile">
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
                        <asp:Label ID="lblTimeStamp" runat="server" Text="Timestamp: "></asp:Label>
                        <asp:Label ID="lblDisplayTimeStamp" runat="server" Text='<%# Eval("MatchTimestamp") %>'></asp:Label><br />
                        <asp:Button ID="btnUnmatch" CommandName="Unmatch" CommandArgument='<%# Eval("UserId") %>' Text="Unmatch" runat="server" />

                     </div>
                 </ItemTemplate>
             </asp:Repeater>
            </div>
        </div>
        <div id="footer">
            <p>Footer</p>
        </div>
    </form>
</body>
</html>
