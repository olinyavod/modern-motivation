<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Motivation.Site.Pages.Users" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h1 class="page-header">Пользователи системы</h1>
    </div>
    <asp:SqlDataSource runat="server" ID="USERS_SOURCE"
        ConnectionString="<%$ ConnectionStrings:MotivationDb%>"
        SelectCommand="
                SELECT 
	                usr.Id AS RecId,
	                usr.Login,
                    usr.Name,
	                usr.Password,
	                usr.IsGeneral,
                    usr.Birthday,
                    usr.Exp,
                    usr.CoinsCount,
                    gr.Name AS UserGroupName,
                    usr.UserGroupId 
                    FROM dbo.Users AS usr
                    JOIN dbo.UserGroups AS gr ON gr.Id = usr.UserGroupId 
                    ORDER BY usr.Name
            "
        UpdateCommand="
            UPDATE 
                dbo.Users 
                SET 
                    UserGroupId = @UserGroupId,
                    Name = @Name,
                    Login = @Login,
                    Password  =  @Password,
                    IsGeneral = @IsGeneral,
                    Exp = @Exp,
                    CoinsCount = @CoinsCount
                WHERE Id = @RecId">
        <UpdateParameters>
            <asp:Parameter Name="RecId" DbType="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Login" Type="String" />
            <asp:Parameter Name="Password" Type="String"/>
            <asp:Parameter Name="IsGeneral" Type="Boolean"/>
            <asp:Parameter Name="UserGroupId" DbType="Int32"/>
            <asp:Parameter Name="Birthday" DbType="DateTime"/>
            <asp:Parameter Name="Exp" DbType="Int32"/>
            <asp:Parameter Name="CoinsCount" DbType="Int32"/>
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource runat="server" ID="TYPES_DS"
        ConnectionString="<%$ ConnectionStrings:MotivationDb%>"
        SelectCommand="SELECT gr.Id AS recId, gr.Name FROM dbo.UserGroups AS gr"></asp:SqlDataSource>

    <div class="table-responsive">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" ID="USERS"
                    DataSourceID="USERS_SOURCE"
                    DataKeyNames="RecId"
                    AutoGenerateColumns="false"
                    CellPadding="6"
                    GridLines="None"
                    Style="vertical-align: top"
                    CssClass="table table-bordered table-hover"
                    PageSize="20"
                    Width="100%"
                    AllowPaging="true"
                    ShowHeaderWhenEmpty="true">
                    <PagerSettings Mode="Numeric"
                        Position="Bottom"
                        PageButtonCount="10" />

                    <PagerStyle BackColor="LightBlue"
                        Height="30px"
                        VerticalAlign="Bottom"
                        HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Login">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Login") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="DESCR" CssClass="form-control" Text='<%#Bind("Login") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DESCR" ErrorMessage="*" Display="Dynamic" ValidationGroup="edit" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ФИО">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Name") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="NAME" CssClass="form-control" Text='<%#Bind("Name") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Системная роль">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("UserGroupName") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList runat="server" ID="TYPE_ID" DataSourceID="TYPES_DS" CssClass="form-control" DataValueField="RecId" DataTextField="Name" SelectedValue='<%#Bind("UserGroupId") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Руководитель группы?">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" Enabled="false" Checked='<%#Eval("IsGeneral") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox runat="server" ID="IS_ACTIVE" Checked='<%#Bind("IsGeneral") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
<%--                        <asp:TemplateField HeaderText="День рождения">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" Enabled="false" Checked='<%#Eval("Birthday") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox runat="server" ID="IS_ACTIVE" Checked='<%#Bind("Birthday") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Опыт">
                            <ItemTemplate>
                                <asp:TextBox runat="server" Enabled="false" CssClass="form-control" Text='<%#Eval("Exp") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="EXP" CssClass="form-control" Text='<%#Bind("Exp") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Монеты">
                            <ItemTemplate>
                                <asp:TextBox runat="server" Enabled="false" CssClass="form-control" Text='<%#Eval("CoinsCount") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="COINS" CssClass="form-control" Text='<%#Bind("CoinsCount") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" ValidationGroup="edit" Text="Изменить" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" ValidationGroup="edit" Text="Сохранить" />
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Отмена" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#428bca" ForeColor="White" Font-Bold="True" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#f5f5f5" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <div class="col-lg-12">
                    <h1 class="page-header">Добавить</h1>
                </div>
                <table style="width: 600px">
                    <tr>
                        <td>Login</td>
                        <td>
                            <asp:TextBox runat="server" ID="LOGIN" CssClass="form-control" placeholder="Login" required></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>ФИО</td>
                        <td>
                            <asp:TextBox runat="server" ID="NAME" CssClass="form-control" placeholder="ФИО"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Системная роль</td>
                        <td>
                            <asp:DropDownList runat="server" ID="USER_ROLE" DataSourceID="TYPES_DS" DataValueField="RecId" DataTextField="Name" CssClass="form-control" /></td>
                    </tr>
                    <tr>
                        <td>Пароль</td>
                        <td>
                            <asp:TextBox runat="server" ID="PASS" CssClass="form-control" placeholder="Пароль"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Руководитель группы?</td>
                        <td>
                            <asp:CheckBox runat="server" ID="IS_GENERAL"/>
                        </td>
                    </tr>
                    <tr>
                        <td>День рождения</td>
                        <td>
                            <asp:TextBox runat="server" TextMode="Date" ID="DAT"  CssClass="form-control"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Опыт</td>
                        <td>
                            <asp:TextBox runat="server" TextMode="Number" ID="EXP"  CssClass="form-control"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Монеты</td>
                        <td>
                            <asp:TextBox runat="server" TextMode="Number" ID="COINS"  CssClass="form-control"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button runat="server" CssClass="btn btn-lg btn-primary" OnClick="Add" Text="Добавить" />
                        </td>
                    </tr>
                </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

