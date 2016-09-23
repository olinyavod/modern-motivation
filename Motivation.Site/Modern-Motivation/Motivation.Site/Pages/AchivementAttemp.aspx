<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AchivementAttemp.aspx.cs" Inherits="Motivation.Site.Pages.AchivementAttemp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="col-lg-12">
        <h1 class="page-header">Список достижений к утверждению</h1>
        
        <asp:SqlDataSource runat="server" ID="ATTEMPS_SOURCE"
        ConnectionString="<%$ ConnectionStrings:MotivationDb%>"
        SelectCommand="
                SELECT 
	                ach.Id AS RecId,
	                ach.Comment AS AchName,
                    ach.IsCompleted,
                    usr.Name AS UserName,
                    grp.Name AS GroupName,
					ach.CreateDate,
					typ.Comment AS Achivement,
					typ.MaxCount, 
					ach.FileUrl,
                    ach.IsAccepted
                    FROM dbo.AchivmentAttemps AS ach
                    JOIN dbo.Users AS usr ON usr.Id = ach.UserId
                    JOIN dbo.UserGroups AS grp ON grp.Id = usr.UserGroupId
					JOIN dbo.AchivmentType AS typ ON typ.Id = ach.AchivnedTypeId
                    WHERE ach.IsAccepted = 0
            "
        UpdateCommand="
            UPDATE 
                dbo.AchivmentAttemps 
                SET 
                    IsCompleted = 1,
                    IsAccepted = @IsAccepted
                WHERE Id = @RecId">
        <UpdateParameters>
            <asp:Parameter Name="IsAccepted" DbType="Boolean" />
            <asp:Parameter Name="RecId" DbType="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</div>
    <div class="table-responsive">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" ID="ATTEMPS"
                    DataSourceID="ATTEMPS_SOURCE"
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
                        <asp:TemplateField HeaderText="Сотрудник">
                            <ItemTemplate>
                                <asp:Label ID="U_NAME" runat="server" Text='<%#Eval("UserName") %>' />
                            </ItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="U_NAME_ED" runat="server" Text='<%#Eval("UserName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Наименование достижения">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="ACH_NAME" Text='<%#Eval("AchName") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label runat="server" ID="ACH_NAME_ED" Text='<%#Eval("AchName") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Номинальное количество">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="ACH_COUNT" Text='<%#Eval("MaxCount") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label runat="server" ID="ACH_COUNT_ED" Text='<%#Eval("MaxCount") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Дата отправки достижения">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="DATE" Text='<%#Eval("CreateDate") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("CreateDate") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Фaйл">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" NavigateUrl='<%#Eval("FileUrl")%>' Text="Ссылка"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HyperLink runat="server" NavigateUrl='<%#Eval("FileUrl")%>' Text="Ссылка"/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Утвержден?">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" Enabled="false" Checked='<%#Eval("IsAccepted")%>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox runat="server" ID="IS_ACCEPTED" Checked='<%#Bind("IsAccepted")%>'/>
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
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

