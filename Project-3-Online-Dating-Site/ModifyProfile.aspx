<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyProfile.aspx.cs" Inherits="Project_3_Online_Dating_Site.ModifyProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/ModifyProfile.css" rel="stylesheet" />
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
            <div>
                <asp:CheckBox ID="chkHideProfile" runat="server" />
                <asp:Label ID="lblHideProfile" runat="server" Text="Hide Profile"></asp:Label><br />
                 <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valEmail" runat="server" 
                                     ErrorMessage="Email is required." ForeColor="Red" 
                                     OnServerValidate="rfvEmail_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                <br />

                <asp:Label ID="lblFullName" runat="server" Text="Full Name: "></asp:Label>

                <br />
                <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valFirstName" runat="server" 
                                     ErrorMessage="Full name is required (Letters only)." ForeColor="Red" 
                                     OnServerValidate="rfvName_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                <br />
                <asp:Label ID="lblUserName" runat="server" Text="Username: "></asp:Label>
                <br />
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valUserName" runat="server" 
                                     ErrorMessage="Username is required." ForeColor="Red" 
                                     OnServerValidate="rfvUserName_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                <br />
                <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                <br />
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valPassword" runat="server" 
                                     ErrorMessage="Password is required." ForeColor="Red" 
                                     OnServerValidate="rfvPassword_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                <br />
                <asp:Label ID="lblVerifyPassword" runat="server" Text="Verify Password: "></asp:Label>
                <br />
                <asp:TextBox ID="txtVerifyPassword" runat="server"></asp:TextBox>
            </div>

            <div>
            <br />
             <h4>Address Information: </h4>
                 <asp:Label ID="lblStreet" runat="server" Text="Street"></asp:Label>
                 <br />
                 <asp:TextBox ID="txtStreet" runat="server" style="width: 128px"></asp:TextBox>
                 <asp:CustomValidator ID="valStreet" runat="server" 
                     ErrorMessage="*" ForeColor="Red" 
                     OnServerValidate="rfvStreet_ServerValidate" ValidateEmptyText="True">
                 </asp:CustomValidator>
                 <br />

                 <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                 <br />
                 <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                 <asp:CustomValidator ID="valCity" runat="server" 
                     ErrorMessage="*" ForeColor="Red" 
                     OnServerValidate="rfvCity_ServerValidate" ValidateEmptyText="True">
                 </asp:CustomValidator>
                 <br />

                 <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                 <br />

                 <asp:DropDownList ID="ddlState" runat="server">
                 </asp:DropDownList>
                 <asp:CustomValidator ID="ValState" runat="server" 
                     ErrorMessage="Must select a state" ForeColor="Red" ControlToValidate="ddlState"
                     OnServerValidate="rfvState_ServerValidate" ValidateEmptyText="True">
                 </asp:CustomValidator>
             <br />


             <asp:Label ID="lblZipCode" runat="server" Text="Zip Code"></asp:Label>
             <br />
             <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
             <asp:CustomValidator ID="valZipCode" runat="server" 
                 ErrorMessage="*" ForeColor="Red" 
                 OnServerValidate="rfvZipCode_ServerValidate" ValidateEmptyText="True">
             </asp:CustomValidator>
             <br />
            </div>

            <div>
                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
                <br />
                <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valPhoneNumber" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvPhoneNumber_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
            <br />
            </div>

            <div>
            <h4>Photo Information</h4>
            <asp:Label ID="lblProfilePhotoURL" runat="server" Text="Photo URL"></asp:Label>
            <br />
            <asp:TextBox ID="txtProfilePhotoURL" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="valProfilePhotoURL" runat="server" 
                ErrorMessage="*" ForeColor="Red" 
                OnServerValidate="rfvProfilePhotoURL_ServerValidate" ValidateEmptyText="True">
            </asp:CustomValidator>
            <br />
            </div>

            <div>
                <h4>About Me Information: </h4>
                <asp:Label ID="lblOccupation" runat="server" Text="Occupation"></asp:Label>
                <br />
                <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valOccupation" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvOccupation_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
                <br />

                <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
                <br />
                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valAge" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvAge_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
                <br />

                <asp:Label ID="lblWeight" runat="server" Text="Weight"></asp:Label>
                <br />
                <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valWeight" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvWeight_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
                <br />

                <asp:Label ID="lblInterests" runat="server" Text="Interests"></asp:Label>
                <br />
                <asp:TextBox ID="txtInterests" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valInterests" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvInterests_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
                <br />

                <asp:Label ID="lblLikes" runat="server" Text="Likes"></asp:Label>
                <br />
                <asp:TextBox ID="txtLikes" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valLikes" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvLikes_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
                <br />

                <asp:Label ID="lblDislikes" runat="server" Text="Dislikes"></asp:Label>
                <br />
                <asp:TextBox ID="txtDislikes" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valDislikes" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvDislikes_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
                <br />

                <asp:Label ID="lblGoals" runat="server" Text="Goals"></asp:Label>
                <br />
                <asp:TextBox ID="txtGoals" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valGoals" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvGoals_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
                <br />

                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                <br />
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valDescription" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvDescription_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
                <br />
            </div>
            <h4>Favorites Information: </h4>
            <asp:Label ID="lblFavoritesRestaurants" runat="server" Text="Favorite Resaurant"></asp:Label>
            <br />
            <asp:TextBox ID="txtFavoritesRestaurants" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="valFavoriteResaurants" runat="server" 
                ErrorMessage="*" ForeColor="Red" 
                OnServerValidate="rfvFavoriteResaurant_ServerValidate" ValidateEmptyText="True">
            </asp:CustomValidator>
            <br />

            <asp:Label ID="lblFavoritesMovies" runat="server" Text="Favorite Movie"></asp:Label>
            <br />
            <asp:TextBox ID="txtFavoritesMovies" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="valFavoriteMovies" runat="server" 
                ErrorMessage="*" ForeColor="Red" 
                OnServerValidate="rfvFavoriteMovies_ServerValidate" ValidateEmptyText="True">
            </asp:CustomValidator>
            <br />

            <asp:Label ID="lblFavoritesBooks" runat="server" Text="Favorite Book"></asp:Label>
            <br />
            <asp:TextBox ID="txtFavoritesBooks" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="valFavoriteBooks" runat="server" 
                ErrorMessage="*" ForeColor="Red" 
                OnServerValidate="rfvFavoriteBooksServerValidate" ValidateEmptyText="True">
            </asp:CustomValidator>
            <br />

            <asp:Label ID="lblFavoritesPoems" runat="server" Text="Favorite Poem"></asp:Label>
            <br />
            <asp:TextBox ID="txtFavoritesPoems" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="valFavoritePoems" runat="server" 
                ErrorMessage="*" ForeColor="Red" 
                OnServerValidate="rfvFavoritePoems_ServerValidate" ValidateEmptyText="True">
            </asp:CustomValidator>
            <br />

            <asp:Label ID="lblFavoritesQuotes" runat="server" Text="Favorite Quote"></asp:Label>
            <br />
            <asp:TextBox ID="txtFavoritesQuotes" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="valFavoriteQuotes" runat="server" 
                ErrorMessage="*" ForeColor="Red" 
                OnServerValidate="rfvFavoriteQuotes_ServerValidate" ValidateEmptyText="True">
            </asp:CustomValidator>
            <br />

            <asp:Label ID="lblFavoriteSayings" runat="server" Text="Favorite Saying"></asp:Label>
            <br />
             <asp:TextBox ID="txtFavoriteSayings" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="valFavoriteSayings" runat="server" 
                ErrorMessage="*" ForeColor="Red" 
                OnServerValidate="rfvFavoriteSayings_ServerValidate" ValidateEmptyText="True">
            </asp:CustomValidator>
            <br />

            <h4>Seeking</h4>
            <asp:Label ID="lblCommitmentType" runat="server" Text="Commitment Type"></asp:Label>
            <asp:CustomValidator ID="valCommitmentType" runat="server" 
                ErrorMessage="*" ForeColor="Red" 
                OnServerValidate="rfvCommitmentType_ServerValidate" ValidateEmptyText="True">
            </asp:CustomValidator>
            <br />
           <div>
                <input type="radio" runat="server" id="radCasualDating" name="CommitmentType" value="CasualDating" />
                <label for="radCasualDating">Casual Dating</label>
            </div>
            <div>
                <input type="radio" runat="server" id="radExclusiveDating" name="CommitmentType" value="ExclusiveDating" />
                <label for="radExclusiveDating">Exclusive Dating</label>
            </div>
            <div>
                <input type="radio" runat="server" id="radCommittedRelationship" name="CommitmentType" value="CommittedRelationship" />
                <label for="radCommittedRelationship">Committed Relationship</label>
            </div>
            <div>
                <input type="radio" runat="server" id="radEngaged" name="CommitmentType" value="Engaged" />
                <label for="radEngaged">Engaged</label>
            </div>
            <div>
                <input type="radio" runat="server" id="radOpenRelationship" name="CommitmentType" value="OpenRelationship" />
                <label for="radOpenRelationship">Open Relationship</label>
            </div>
            <div>
                <input type="radio" runat="server" id="radFriendsWithBenefits" name="CommitmentType" value="FriendsWithBenefits" />
                <label for="radFriendsWithBenefits">Friends with Benefits</label>
            </div>
            <br />
<%--            <asp:Label ID="lbl1" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label>--%>
            <asp:Button ID="btnSaveProfile" runat="server" Text="Save" OnClick="btnSaveProfile_Click" Height="49px" Width="114px" />

        </div>

        <div id="footer">
            <p>Footer</p>
        </div>
    </form>
</body>
</html>
