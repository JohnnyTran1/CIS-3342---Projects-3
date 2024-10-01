<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="Project_3_Online_Dating_Site.ViewProfile" %>

<!DOCTYPE html>
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Style/ModifyProfile.css" rel="stylesheet" />
<%--    https://mdbootstrap.com/docs/standard/extended/profiles/
    Literrally copy thier bootstrap example--%>

</head>
<body>
    <form id="form1" runat="server">
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
        <div class="container mt-4">
            <div class="row justify-content-center">
                <div class="col-md-8">
<%--            <asp:Label ID="lblPhotoURL" runat="server" Text="Age: "></asp:Label>--%>
                    <a>
                    <asp:Image ID="imgDisplayPhotoURL" runat="server"/><br />
                    </a>
            <br />
<%--            <asp:Repeater ID="rptUsers" runat="server" OnItemCommand="rptUsers_ItemCommand">
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
                    </div>
                </ItemTemplate>
            </asp:Repeater>--%>
        <asp:Button ID="btnEditProfile" runat="server" Text="Edit" OnClick="btnEditProfile_Click1" Height="44px" Width="102px" />
        <div class="card mb-4">
                        <div class="card-body">
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                                    <asp:Label ID="lblUserUsername" runat="server" Text="Username Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblFullName" runat="server" Text="Full Name: "></asp:Label>
                                    <asp:Label ID="lblUserFullName" runat="server" Text="Full Name Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                                    <asp:Label ID="lblUserEmail" runat="server" Text="Email Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                     <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                                     <asp:Label ID="lblUserPassword" runat="server" Text="Password Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
                                    <asp:Label ID="lblUserAddress" runat="server" Text="Address Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: "></asp:Label>
                                    <asp:Label ID="lblUserPhoneNumber" runat="server" Text="Phone Number Place Holder"></asp:Label>
                               </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblOccupation" runat="server" Text="Occupation: "></asp:Label>
                                    <asp:Label ID="lblUserOccupation" runat="server" Text="Occupation Place Holder"></asp:Label>
                               </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblAge" runat="server" Text="Age: "></asp:Label>
                                    <asp:Label ID="lblUserAge" runat="server" Text="Age Place Holder"></asp:Label>
                               </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblWeight" runat="server" Text="Weight: "></asp:Label>
                                    <asp:Label ID="lblUserWeight" runat="server" Text="Weight Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblInterests" runat="server" Text="Interests: "></asp:Label>
                                    <asp:Label ID="lblUserInterests" runat="server" Text="Interests Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblLikes" runat="server" Text="Likes: "></asp:Label>
                                    <asp:Label ID="lblUserLikes" runat="server" Text="Likes Place Holder"></asp:Label>
                               </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblDislikes" runat="server" Text="Dislikes: "></asp:Label>
                                    <asp:Label ID="lblUserDislikes" runat="server" Text="Dislikes Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblFavoriteRestaurant" runat="server" Text="Favorite Restaurant: "></asp:Label>
                                    <asp:Label ID="lblUserFavoriteRestaurant" runat="server" Text="Favorite Restaurant Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblFavoriteMovie" runat="server" Text="Favorite Movie: "></asp:Label>
                                    <asp:Label ID="lblUserFavoriteMovie" runat="server" Text="Favorite Movie Place Holder"></asp:Label>
                               </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblFavoriteBook" runat="server" Text="Favorite Book: "></asp:Label>
                                    <asp:Label ID="lblUserFavoriteBook" runat="server" Text="Favorite Book Place Holder"></asp:Label>
                               </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblFavoritePoem" runat="server" Text="Favorite Poem: "></asp:Label>
                                    <asp:Label ID="lblUserFavoritePoem" runat="server" Text="Favorite Poem Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblFavoriteQuote" runat="server" Text="Favorite Quote: "></asp:Label>
                                    <asp:Label ID="lblUserFavoriteQuote" runat="server" Text="Favorite Quote Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblFavoriteSaying" runat="server" Text="Favorite Saying: "></asp:Label>
                                    <asp:Label ID="lblUserFavoriteSaying" runat="server" Text="Favorite Saying Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblGoals" runat="server" Text="Goals: "></asp:Label>
                                    <asp:Label ID="lblUserGoals" runat="server" Text="Goals Place Holder"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                   <asp:Label ID="lblCommitmentType" runat="server" Text="Commitment Type: "></asp:Label>
                                   <asp:Label ID="lblUserCommitmentType" runat="server" Text="Commitment Type Place Holder"></asp:Label>
                               </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
                                    <asp:Label ID="lblUserDescription" runat="server" Text="Description Place Holder"></asp:Label>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            <div id="footer">
            <p>Footer</p>
        </div>
    </form>
</body>
</html>