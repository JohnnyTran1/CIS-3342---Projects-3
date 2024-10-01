<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProfile.aspx.cs" Inherits="Project_3_Online_Dating_Site.MemberProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/ModifyProfile.css" rel="stylesheet" />
</head>
<body>
    <%--https://www.parents.com/top-1000-baby-girl-names-2757832
    https://www.parents.com/top-1000-baby-boy-names-2757618
    https://en.wikipedia.org/wiki/List_of_best-selling_books
    https://earlybirdbooks.com/most-famous-poems
    https://blog.hubspot.com/sales/famous-quotes
    https://www.google.com/search?q=popular+sayings&rlz=1C1VIQF_enUS1072US1072&oq=popul&gs_lcrp=EgZjaHJvbWUqDggAEEUYJxg7GIAEGIoFMg4IABBFGCcYOxiABBiKBTIOCAEQRRgnGDsYgAQYigUyBggCEEUYOTINCAMQABiSAxiABBiKBTINCAQQABiSAxiABBiKBTINCAUQLhiDARixAxiABDIGCAYQRRg9MgYIBxBFGEHSAQgxMDE3ajBqOagCALACAA&sourceid=chrome&ie=UTF-8--%>
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
            </div>
            <h2>Profile Information: </h2>
           
            <div>
                <div>
                    <h4>Address Information: </h4>
                    <asp:Label ID="lblStreet" runat="server" Text="Street"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtStreet" runat="server" style="width: 128px"></asp:TextBox>
                    <asp:CustomValidator ID="valStreet" runat="server" 
                        ErrorMessage="Street is required!" ForeColor="Red" 
                        OnServerValidate="rfvStreet_ServerValidate" ValidateEmptyText="True">
                    </asp:CustomValidator>
                    <br />

                    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="valCity" runat="server" 
                        ErrorMessage="Letters Only!" ForeColor="Red" 
                        OnServerValidate="rfvCity_ServerValidate" ValidateEmptyText="True">
                    </asp:CustomValidator>
                    <br />

                    <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                    <br />
            
                   <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>
                    <asp:CustomValidator ID="valState" runat="server" ErrorMessage="Must select a state!" ForeColor="Red"
                        ControlToValidate="ddlState" OnServerValidate="rfvState_ServerValidate" ValidateEmptyText="True">
                    </asp:CustomValidator>


                    <br />


                    <asp:Label ID="lblZipCode" runat="server" Text="Zip Code"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="valZipCode" runat="server" 
                        ErrorMessage="Numbers Only!" ForeColor="Red" 
                        OnServerValidate="rfvZipCode_ServerValidate" ValidateEmptyText="True">
                    </asp:CustomValidator>
                    <br />
                </div>

                <%--<h4>Contract Information: </h4>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="valEmail" runat="server" 
                    ErrorMessage="*" ForeColor="Red" 
                    OnServerValidate="rfvEmail_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
                <br />--%>
                <div>
                    <h4>Phone Number Information: </h4>
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
                    <br />
                
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="valPhoneNumber" runat="server" 
                        ErrorMessage="Require 10 digit numbers!" ForeColor="Red" 
                        OnServerValidate="rfvPhoneNumber_ServerValidate" ValidateEmptyText="True">
                    </asp:CustomValidator>
                    <br />
                </div>

                <div>
                    <h4>About Me Information: </h4>
                    <asp:Label ID="lblOccupation" runat="server" Text="Occupation"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="valOccupation" runat="server" 
                        ErrorMessage="Letters Only!" ForeColor="Red" 
                        OnServerValidate="rfvOccupation_ServerValidate" ValidateEmptyText="True">
                    </asp:CustomValidator>
                    <br />

                    <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="valAge" runat="server" 
                        ErrorMessage="Must be 18-100" ForeColor="Red" 
                        OnServerValidate="rfvAge_ServerValidate" ValidateEmptyText="True">
                    </asp:CustomValidator>
                    <br />

                    <asp:Label ID="lblWeight" runat="server" Text="Weight (lbs)"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="valWeight" runat="server" 
                        ErrorMessage="Numbers Only!" ForeColor="Red" 
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
                <div>
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
                </div>
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
            <h4 >Hidden</h4>
             <asp:CheckBox ID="chkHideProfile" runat="server" />
            <asp:Label ID="lblHideProfile" runat="server" Text="Hide Profile"></asp:Label><br />

            <h4>Seeking</h4>
                <asp:Label ID="lblCommitmentType" runat="server" Text="Commitment Type"></asp:Label>
                <asp:CustomValidator ID="valCommitmentType" runat="server" 
                    ErrorMessage="Please select a commitment type." ForeColor="Red" 
                    OnServerValidate="rfvCommitmentType_ServerValidate" ValidateEmptyText="True">
                </asp:CustomValidator>
            <br />

            <table>
                <tr>
                    <td>
                        <input type="radio" name="QCommitmentType" id="CasualDating" value="CasualDating" required />
                        <label for="CasualDating">Casual Dating</label>
                    </td>
                    <td>
                        <input type="radio" name="QCommitmentType" id="ExclusiveDating" value="ExclusiveDating" required />
                        <label for="ExclusiveDating">Exclusive Dating</label>
                    </td>
                    <td>
                        <input type="radio" name="QCommitmentType" id="CommittedRelationship" value="CommittedRelationship" required />
                        <label for="CommittedRelationship">Committed Relationship</label>
                    </td>
                    <td>
                        <input type="radio" name="QCommitmentType" id="Engaged" value="Engaged" required />
                        <label for="Engaged">Engaged</label>
                    </td>
                    <td>
                        <input type="radio" name="QCommitmentType" id="OpenRelationship" value="OpenRelationship" required />
                        <label for="OpenRelationship">Open Relationship</label>
                    </td>
                    <td>
                        <input type="radio" name="QCommitmentType" id="FriendsWithBenefits" value="FriendsWithBenefits" required />
                        <label for="FriendsWithBenefits">Friends with Benefits</label>
                    </td>
                </tr>
            </table>
            </div>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="Submit_Click" Height="59px" Width="115px" />

        <div id="footer">
            <p>Footer</p>
        </div>
    </form>
</body>
</html>
