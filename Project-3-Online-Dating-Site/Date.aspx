<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Date.aspx.cs" Inherits="Project_3_Online_Dating_Site.Date" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/Date.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
<%--            //https://www.w3schools.com/w3css/w3css_navigation.asp
            //Literally Copy their template for the nav bar--%>
            <div class="topnav">
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
        <div class ="Filter">
            <div>
                <h2>Requesting Dates</h2>
                <asp:Repeater ID="rptRequestingDate" runat="server" OnItemCommand="rptRequestingDate_ItemCommand">
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
                           <asp:Button ID="btnRequest" CommandName="RequestingDate" CommandArgument='<%# Eval("UserId") %>' Text="Request" runat="server" />
                         </div>
                   </ItemTemplate>
                </asp:Repeater>
            </div>
            <div>
                <h2>Receiving Dates Requests</h2>
                <asp:Repeater ID="rptReceivingDateRequests" runat="server" OnItemCommand="rptReceivingDateRequests_ItemCommand">
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
                            <asp:Label ID="lblRequestTimeStamp" runat="server" Text="Request Timestamp: "></asp:Label>
                            <asp:Label ID="lblRequestDisplayTimeStamp" runat="server" Text='<%# Eval("RequestTimestamp") %>'></asp:Label><br />
                            <asp:Button ID="btnAccept" CommandName="AcceptRequest" CommandArgument='<%# Eval("UserId") %>' Text="Accept" runat="server" />
                            <asp:Button ID="btnDecline" CommandName="DeclineRequest" CommandArgument='<%# Eval("UserId") %>' Text="Decline" runat="server" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div>
                <h2>View Date Request Status</h2>
                <asp:Repeater ID="rptViewDateRequestStatus" runat="server" OnItemCommand="rptViewDateRequestStatis_ItemCommand">
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
                            <asp:Label ID="lblStatus" runat="server" Text="Approve Request: "></asp:Label>
                            <asp:Label ID="lblDisplayStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label><br />
                            <asp:Label ID="lblRequestTimeStamp" runat="server" Text="Request Timestamp: "></asp:Label>
                            <asp:Label ID="lblRequestDisplayTimeStamp" runat="server" Text='<%# Eval("RequestTimestamp") %>'></asp:Label><br />
                             <asp:Label ID="lblResponeTimeStamp" runat="server" Text="Respone Timestamp: "></asp:Label>
                            <asp:Label ID="lblDisplayResponeTimeStamp" runat="server" Text='<%# Eval("ResponeTimestamp") %>'></asp:Label><br />
 
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            </div>
        </div>
        <div id="footer">
            <p>Footer</p>
        </div>
    </form>
</body>
</html>
