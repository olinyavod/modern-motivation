<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AchivementTypes.aspx.cs" Inherits="Motivation.Site.Pages.AchivementTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h1 class="page-header">Список типовых достижений</h1>

            <asp:SqlDataSource runat="server" ID="ACHIVEMENTS_SOURCE"
        ConnectionString="<%$ ConnectionStrings:MotivationDb%>"
        SelectCommand="
                SELECT 
	                typ.Id AS RecId,
	                typ.Comment,
                    typ.MaxCount,
                    typ.ExpCount,
                    typ.CoinsCount
                    FROM dbo.AchivmentType AS typ
            "
        UpdateCommand="
            UPDATE 
                dbo.AchivmentType 
                SET 
                    Comment = @Comment,
                    MaxCount = @MaxCount,
                    ExpCount = @ExpCount,
                    CoinsCount = @CoinsCount 
                WHERE Id = @RecId">
        <UpdateParameters>
            <asp:Parameter Name="RecId" DbType="Int32" />
            <asp:Parameter Name="MaxCount" Type="Int32" />
            <asp:Parameter Name="ExpCount" DbType="Int32" />
            <asp:Parameter Name="CoinsCount" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </div>

    <div class="table-responsive">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" ID="ACHIVEMENTS"
                    DataSourceID="ACHIVEMENTS_SOURCE"
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
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Comment") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server"  TextMode="MultiLine" ID="DESCR" CssClass="form-control" Text='<%#Bind("Comment") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DESCR" ErrorMessage="*" Display="Dynamic" ValidationGroup="edit" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Количество элементов">
                            <ItemTemplate>
                                <asp:Label runat="server"  Text='<%#Eval("MaxCount") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="NAME" CssClass="form-control" Text='<%#Bind("MaxCount") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Опыт">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ExpCount") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="EXP" CssClass="form-control" Text='<%#Bind("ExpCount") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Монеты">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("CoinsCount") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="EXP" CssClass="form-control" Text='<%#Bind("CoinsCount") %>' />
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
                        <td>Комментарий</td>
                        <td>
                           <asp:TextBox runat="server" TextMode="MultiLine" ID="COMMENT" CssClass="form-control"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Макс количество</td>
                        <td>
                           <asp:TextBox runat="server" TextMode="Number" ID="MAX_COUNT"  CssClass="form-control"/>
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
                            <asp:Button runat="server" CssClass="btn btn-lg btn-primary" Text="Добавить" OnClick="Add" />
                        </td>
                    </tr>
                </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>
