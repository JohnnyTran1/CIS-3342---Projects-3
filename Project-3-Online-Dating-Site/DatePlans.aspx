<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatePlans.aspx.cs" Inherits="Project_3_Online_Dating_Site.PlanDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/DatePlans.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
                       <%-- //https://www.w3schools.com/w3css/w3css_navigation.asp
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
            <h2 class="FilterHeading">Select which user you want to plan a date with or view/change your plan below!</h2>
        <div class ="Filter">
            <div>
                <h2>View accepted date plans</h2>
                 <asp:Repeater ID="rptViewDateRequestStatus" runat="server" OnItemCommand="rptViewDateRequestStatis_ItemCommand">
                     <ItemTemplate>
                         <div class ="profile">
                             <asp:Image ID="imgDisplaPhotoURL" runat="server" ImageUrl='<%# Eval("PhotoURL") %>' /><br />
                             <asp:Label ID="lblDisplayFullName" runat="server" Text='<%# Eval("FullName") + "," %>'></asp:Label>
                             <asp:Label ID="lblDisplayAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label><br />
                             <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                             <asp:Label ID="lblDisplayUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label><br />
                            <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
                             <asp:Label ID="lblDisplayStreet" runat="server" Text='<%# Eval("Street") + " "%>'></asp:Label>
                             <asp:Label ID="lblDisplayCity" runat="server" Text='<%# Eval("City") + ", "%>'></asp:Label>
                             <asp:Label ID="lblDisplayState" runat="server" Text='<%# Eval("State") + " " %>'></asp:Label>
                            <asp:Label ID="lblDisplayZipCode" runat="server" Text='<%# Eval("ZipCode") %>'></asp:Label><br />
                            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                            <asp:Label ID="lblDisplayEmail" runat="server" Text='<%# Eval("EmailAddress") %>'></asp:Label><br />
                             <asp:Label ID="lblPhoneNumber" runat="server" Text="Phonenumber: "></asp:Label>
                            <asp:Label ID="lblDisplayPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label><br />
                             <asp:Label ID="lblOccupation" runat="server" Text="Occupation: "></asp:Label>
                            <asp:Label ID="lblDisplayOccupation" runat="server" Text='<%# Eval("Occupation") %>'></asp:Label><br />
                             <asp:Label ID="lblInterest" runat="server" Text="Interest: "></asp:Label>
                            <asp:Label ID="lblDisplayInterest" runat="server" Text='<%# Eval("Interests") %>'></asp:Label><br />
                             <asp:Label ID="lblLikes" runat="server" Text="Likes: "></asp:Label>
                            <asp:Label ID="lblDisplayLikes" runat="server" Text='<%# Eval("Likes") %>'></asp:Label><br />
                             <asp:Label ID="lblDislikes" runat="server" Text="Dislikes: "></asp:Label>
                            <asp:Label ID="lblDisplayDisLikes" runat="server" Text='<%# Eval("Dislikes") %>'></asp:Label><br />
                             <asp:Label ID="lblFavoriteRestaurant" runat="server" Text="Favorite Restaurant: "></asp:Label>
                            <asp:Label ID="lblDisplayFavoriteRestaurant" runat="server" Text='<%# Eval("FavoriteRestaurant") %>'></asp:Label><br />
                             <asp:Label ID="lblFavoriteMovie" runat="server" Text="FavoriteMovie: "></asp:Label>
                            <asp:Label ID="lblDisplayFavoriteMovie" runat="server" Text='<%# Eval("FavoriteMovie") %>'></asp:Label><br />
                             <asp:Label ID="lblFavoriteBook" runat="server" Text="Favorite Book: "></asp:Label>
                            <asp:Label ID="lblDisplayFavoriteBook" runat="server" Text='<%# Eval("FavoriteBook") %>'></asp:Label><br />
                             <asp:Label ID="lblFavoritePoem" runat="server" Text="Favorite Poem: "></asp:Label>
                            <asp:Label ID="lblDisplayFavoritePoem" runat="server" Text='<%# Eval("FavoritePoem") %>'></asp:Label><br />
                             <asp:Label ID="lblFavoriteQuote" runat="server" Text="Favorite Quote: "></asp:Label>
                            <asp:Label ID="lblDisplayFavoriteQuote" runat="server" Text='<%# Eval("FavoriteQuote") %>'></asp:Label><br />
                             <asp:Label ID="lblFavoriteSaying" runat="server" Text="Favorite Saying: "></asp:Label>
                            <asp:Label ID="lblDisplayFavoriteSaying" runat="server" Text='<%# Eval("FavoriteSaying") %>'></asp:Label><br />
                             <asp:Label ID="lblGoals" runat="server" Text="Goals: "></asp:Label>
                            <asp:Label ID="lblDisplayGoals" runat="server" Text='<%# Eval("Goals") %>'></asp:Label><br />
                             <asp:Label ID="lblSeeking" runat="server" Text="Seeking for: "></asp:Label>
                             <asp:Label ID="lblDisplayCommitmentType" runat="server" Text='<%# Eval("CommitmentType") %>'></asp:Label><br />
                             <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
                             <asp:Label ID="lblDisplayDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label><br />

                            <asp:Button ID="btnPlans" CommandName="StartPlan" CommandArgument='<%# Eval("UserId") %>' Text="Plan" runat="server" />
                         </div>
                     </ItemTemplate>
                 </asp:Repeater>
            </div>
            <div>
                <h2>Enter date, time, description and location for the date!</h2>
                <asp:Label ID="lblLocationEnter" runat="server" Text="Location: "></asp:Label>
                <asp:TextBox ID="txtLocationEnter" runat="server" ></asp:TextBox><br />
                 <asp:CustomValidator ID="valLocation" runat="server" 
                      ErrorMessage="Location is required." ForeColor="Red" 
                      OnServerValidate="valLocation_ServerValidate" ValidateEmptyText="True" ValidationGroup="SubmitGroup"></asp:CustomValidator><br />


                <asp:Label ID="lblDateLabelEnter" runat="server" Text="Date: "></asp:Label>
                <asp:TextBox ID="txtDateEnter" runat="server" TextMode="Date"></asp:TextBox><br />
                 <asp:CustomValidator ID="valDate" runat="server" 
                  ErrorMessage="Date is required." ForeColor="Red" 
                  OnServerValidate="valDate_ServerValidate" ValidateEmptyText="True" ValidationGroup="SubmitGroup"></asp:CustomValidator><br />

                <asp:Label ID="lblTimeEnter" runat="server" Text="Time: "></asp:Label>
                <asp:TextBox ID="txtTimeEnter" runat="server" TextMode="Time"></asp:TextBox><br />
                 <asp:CustomValidator ID="valTime" runat="server" 
                      ErrorMessage="Time is required." ForeColor="Red" 
                      OnServerValidate="valTime_ServerValidate" ValidateEmptyText="True" ValidationGroup="SubmitGroup"></asp:CustomValidator><br />


                <asp:Label ID="lblDescriptionEnter" runat="server" Text="Description: "></asp:Label>
                 <asp:TextBox ID="txtDescriptionEnter" runat="server" ></asp:TextBox><br />
                 <asp:CustomValidator ID="valDescription" runat="server" 
                      ErrorMessage="Description is required." ForeColor="Red" 
                      OnServerValidate="valDescription_ServerValidate" ValidateEmptyText="True" ValidationGroup="SubmitGroup"></asp:CustomValidator><br />

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup="SubmitGroup" />
            </div>
        </div>
       <%-- <asp:Repeater ID="rptSendDatePlan" runat="server" OnItemCommand="rptSendDatePlan_ItemCommand">
           <ItemTemplate>
                <div>
                    <asp:Image ID="ImgDisplaPhotoURL" runat="server" ImageUrl='<%# Eval("PhotoURL") %>' /><br />
                    <asp:Label ID="lblDisplayFullName" runat="server" Text='<%# Eval("FullName") + "," %>'></asp:Label>
                    <asp:Label ID="lblDisplayAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label><br />
                    <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                    <asp:Label ID="lblDisplayUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label><br />
                    <asp:Label ID="lblLocation" runat="server" Text="Location: "></asp:Label>
                    <asp:Label ID="lblDisplayCity" runat="server" Text='<%# Eval("City") + ","%>'></asp:Label>
                    <asp:Label ID="lblDisplayState" runat="server" Text='<%# Eval("State") %>'></asp:Label><br />
                    <asp:Label ID="lblSeeking" runat="server" Text="Seeking for: "></asp:Label>
                    <asp:Label ID="lblDisplayCommitmentType" runat="server" Text='<%# Eval("CommitmentType") %>'></asp:Label><br />
                    <asp:Label ID="lblLocationLabel" runat="server" Text="Location: "></asp:Label>
                    <asp:TextBox ID="txtLocation" runat="server" ></asp:TextBox><br />
                    <asp:Label ID="lblDateLabel" runat="server" Text="Date: "></asp:Label>
                    <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox><br />
                    <asp:Label ID="lblTimeLabel" runat="server" Text="Time: "></asp:Label>
                    <asp:TextBox ID="txtTime" runat="server" TextMode="Time"></asp:TextBox><br />
                    <asp:Label ID="lblDescriptionLabel" runat="server" Text="Description: "></asp:Label>
                    <asp:TextBox ID="txtDescription" runat="server" ></asp:TextBox><br />
                    <asp:Button ID="btnSubmit" CommandName="SendPlan" CommandArgument='<%# Eval("UserId") %>' Text="Send" runat="server" />
                </div>
           </ItemTemplate>
        </asp:Repeater>--%>
        <div class ="Filter">
            <div>
                <h2>View date plans</h2>
                 <asp:Repeater ID="rptViewPlans" runat="server" OnItemCommand="rptViewPlans_ItemCommand">
                     <ItemTemplate>
                         <div class="profile">
                         <asp:Image ID="imgDisplaPhotoURL" runat="server" ImageUrl='<%# Eval("PhotoURL") %>' /><br />
                         <asp:Label ID="lblDisplayFullName" runat="server" Text='<%# Eval("FullName") + "," %>'></asp:Label>
                         <asp:Label ID="lblDisplayAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label><br />
                         <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                         <asp:Label ID="lblDisplayUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label><br />
                        <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
                         <asp:Label ID="lblDisplayStreet" runat="server" Text='<%# Eval("Street") + " "%>'></asp:Label>
                         <asp:Label ID="lblDisplayCity" runat="server" Text='<%# Eval("City") + ", "%>'></asp:Label>
                         <asp:Label ID="lblDisplayState" runat="server" Text='<%# Eval("State") + " " %>'></asp:Label>
                        <asp:Label ID="lblDisplayZipCode" runat="server" Text='<%# Eval("ZipCode") %>'></asp:Label><br />
                        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                        <asp:Label ID="lblDisplayEmail" runat="server" Text='<%# Eval("EmailAddress") %>'></asp:Label><br />
                         <asp:Label ID="lblPhoneNumber" runat="server" Text="Phonenumber: "></asp:Label>
                        <asp:Label ID="lblDisplayPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label><br />

                        <asp:Label ID="lblViewDatePlan" runat="server" Text="Date Plan"></asp:Label><br />
                         <asp:Label ID="lblLocation" runat="server" Text="Location: "></asp:Label>
                        <asp:Label ID="lblDispalyLocation" runat="server" Text='<%# Eval("Location") %>'></asp:Label><br />
                         <asp:Label ID="lblDate" runat="server" Text="Date: "></asp:Label>
                        <asp:Label ID="lblDisplayDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label><br />
                         <asp:Label ID="lblTime" runat="server" Text="Time: "></asp:Label>
                        <asp:Label ID="lblDisplayTime" runat="server" Text='<%# Eval("Time") %>'></asp:Label><br />
                         <asp:Label ID="lblDescriptionPlan" runat="server" Text="Description: "></asp:Label>
                        <asp:Label ID="lblDisplayDescriptionPlan" runat="server" Text='<%# Eval("DescriptionPlan") %>'></asp:Label><br />
                            <asp:Button ID="btnModify" CommandName="Modtify" CommandArgument='<%# Eval("UserId") %>' Text="Change" runat="server" />
                         </div>
                     </ItemTemplate>
                 </asp:Repeater>
            </div>
            <div>
                <h2>Click which user to change the date plan</h2>
                <asp:Label ID="lbltModifyLocation" runat="server" Text="Location: "></asp:Label>
                <asp:TextBox ID="txtModifyLocation" runat="server" ></asp:TextBox><br />
                 <asp:CustomValidator ID="valModifyLocation" runat="server" 
                   ErrorMessage="Location is required." ForeColor="Red" 
                   OnServerValidate="valModifyLocation_ServerValidate" ValidateEmptyText="True" ValidationGroup="ModifyGroup"></asp:CustomValidator><br />

                <asp:Label ID="lblModifyDate" runat="server" Text="Date: "></asp:Label>
                <asp:TextBox ID="txtModifyDate" runat="server" TextMode="Date"></asp:TextBox><br />
                <asp:CustomValidator ID="valModifyDate" runat="server" 
                  ErrorMessage="Date is required." ForeColor="Red" 
                  OnServerValidate="valModifyDate_ServerValidate" ValidateEmptyText="True" ValidationGroup="ModifyGroup"></asp:CustomValidator><br />


                <asp:Label ID="lblModifyTime" runat="server" Text="Time: "></asp:Label>
                <asp:TextBox ID="txtModifyTime" runat="server" TextMode="Time"></asp:TextBox><br />
                <asp:CustomValidator ID="valModifyTime" runat="server" 
                  ErrorMessage="Time is required." ForeColor="Red" 
                  OnServerValidate="valModifyTime_ServerValidate" ValidateEmptyText="True" ValidationGroup="ModifyGroup"></asp:CustomValidator><br />


                <asp:Label ID="lblModifyDescription" runat="server" Text="Description: "></asp:Label>
                <asp:TextBox ID="txtModifyDescription" runat="server" ></asp:TextBox><br />

                <asp:CustomValidator ID="valModifyDescription" runat="server" 
                  ErrorMessage="Description is required." ForeColor="Red" 
                  OnServerValidate="valModifyDescription_ServerValidate" ValidateEmptyText="True" ValidationGroup="ModifyGroup"></asp:CustomValidator><br />

                <asp:Button ID="btnModify" runat="server" Text="Modify" OnClick="btnModify_Click" ValidationGroup="ModifyGroup"/>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
