<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="UserGroups.aspx.cs" Inherits="Motivation.Site.Pages.UserGroups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-lg-12">
        <h1 class="page-header">Группы пользователей</h1>
    </div>

    <asp:SqlDataSource runat="server" ID="GROUPS_SOURCE"
        ConnectionString="<%$ ConnectionStrings:MotivationDb%>"
        SelectCommand="
                SELECT 
	                ug.Id AS RecId,
	                ug.Name
                    FROM dbo.UserGroups AS ug
            "
        UpdateCommand="
            UPDATE 
                dbo.UserGroups 
                SET 
                    Name = @Name
                WHERE Id = @RecId">
        <UpdateParameters>
            <asp:Parameter Name="RecId" DbType="Int32" />
            <asp:Parameter Name="Name" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <div class="table-responsive">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" ID="USER_GROUPS"
                    DataSourceID="GROUPS_SOURCE"
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
                        <asp:TemplateField HeaderText="Наименование группы">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Name") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" CssClass="form-control" ID="DESCR" Text='<%#Bind("Name") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DESCR" ErrorMessage="*" Display="Dynamic" ValidationGroup="edit" />
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
                        <td>Наименование группы</td>
                        <td>
                            <asp:TextBox runat="server" ID="DESCR" CssClass="form-control" placeholder="Наименование" required></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button runat="server" CssClass="btn btn-lg btn-primary" OnClick="OnAddGroup" Text="Добавить" /></td>
                    </tr>
                </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

