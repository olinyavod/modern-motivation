<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Competitions.aspx.cs" Inherits="Motivation.Site.Pages.Competitions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="col-lg-12">
        <h1 class="page-header">Список соревнований</h1>

            <asp:SqlDataSource runat="server" ID="COMPETIIONS_SOURCE"
        ConnectionString="<%$ ConnectionStrings:MotivationDb%>"
        SelectCommand="
                SELECT 
	                typ.Id AS RecId,
	                typ.StartDate,
                    typ.EndDate,
                    typ.Comment
                    FROM dbo.Compititions AS typ
            "
        UpdateCommand="
            UPDATE 
                dbo.Compititions 
                SET 
                    StartDate = @StartDate,
                    EndDate = @EndDate,
                    Comment = @Comment
                WHERE Id = @RecId">
        <UpdateParameters>
            <asp:Parameter Name="StartDate" DbType="DateTime" />
            <asp:Parameter Name="EndDate" Type="DateTime" />
            <asp:Parameter Name="Comment" DbType="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </div>

    <div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" ID="COMPETIIONS"
                    DataSourceID="COMPETIIONS_SOURCE"
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
                          <asp:TemplateField HeaderText="Описание">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Comment") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="EXP" TextMode="MultiLine" CssClass="form-control" Text='<%#Bind("Comment") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Дата начала">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("StartDate") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" TextMode="Date" ID="DESCR" CssClass="form-control" Text='<%#Bind("StartDate") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DESCR" ErrorMessage="*" Display="Dynamic" ValidationGroup="edit" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Дата завершения">
                            <ItemTemplate>
                                <asp:Label runat="server"  Text='<%#Eval("EndDate") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="NAME" CssClass="form-control" Text='<%#Bind("EndDate") %>' />
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
                        <td>Комментарий</td>
                        <td>
                           <asp:TextBox runat="server" TextMode="MultiLine" ID="COMMENT" CssClass="form-control"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Дата начала</td>
                        <td>
                           <asp:TextBox runat="server"  ID="START_DATE" TextMode="Date" CssClass="form-control"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Дата завершения</td>
                        <td>
                            <asp:TextBox runat="server" TextMode="Date" ID="END_DATE" CssClass="form-control"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button runat="server" CssClass="btn btn-lg btn-primary" Text="Добавить" OnClick="Add" />
                        </td>
                    </tr>
                </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
