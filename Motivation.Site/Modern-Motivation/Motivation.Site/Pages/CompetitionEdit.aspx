<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompetitionEdit.aspx.cs" Inherits="Motivation.Site.Pages.CompetitionEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Редактирование соревнований</h1>

        <asp:SqlDataSource runat="server" ID="GROUPS_SOURCE"  
            ConnectionString="<%$ ConnectionStrings:MotivationDb%>"
            SelectCommand="
                SELECT 
                    grp.Id, 
                    grp.Name, 
                    CASE WHEN cmp_grp.Id IS NOT NULL THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END AS IsChecked
	                FROM dbo.UserGroups AS grp
	                LEFT JOIN dbo.CompititionGroup AS cmp_grp ON 
		                grp.Id = cmp_grp.UserGroupId
		                AND cmp_grp.CompititionId = @CompetitionId">
            <SelectParameters>
                <asp:QueryStringParameter Name="CompetitionId" QueryStringField="CompetitionId"/>
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource runat="server" ID="TYPES_SOURCE"  
            ConnectionString="<%$ ConnectionStrings:MotivationDb%>"
            SelectCommand="		SELECT ach.Id, ach.Comment, ach.MaxCount, CASE WHEN amp_ach.Id IS NOT NULL THEN CAST(1 AS bit) ELSE CAST( 0 AS bit) END AS IsChecked
	FROM dbo.AchivmentType AS ach
	LEFT JOIN dbo.CompititionAchivmentypes AS amp_ach ON 
		amp_ach.Id = amp_ach.AchivnedTypeId
		AND amp_ach.CompititionId = @CompetitionId
	">            <SelectParameters>
                <asp:QueryStringParameter Name="CompetitionId" QueryStringField="CompetitionId"/>
            </SelectParameters>
        </asp:SqlDataSource>

        <h2>Список групп к участию</h2>
        <asp:Repeater runat="server" DataSourceID="GROUPS_SOURCE" ID="GROUPS">
            <ItemTemplate>
                <asp:Label runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                <asp:HiddenField ID="ID" runat="server" Value='<%#Eval("Id")%>'/>
                <asp:HiddenField ID="WAS_CHECKED" runat="server" Value='<%#Eval("IsChecked")%>'/>
                <asp:CheckBox runat="server" ID="IS_CHECKED" Checked='<%#Eval("IsChecked")%>'/><br />
            </ItemTemplate>
        </asp:Repeater>

        <h2>Список требуемых достижений</h2>
        <asp:Repeater runat="server" DataSourceID="TYPES_SOURCE" ID="TYPES">
            <ItemTemplate>
                <asp:Label runat="server" Text='<%#Eval("Comment")%>'></asp:Label> <asp:Label runat="server" Text='<%#Eval("MaxCount")%>'></asp:Label>
                <asp:HiddenField ID="ID" runat="server" Value='<%#Eval("Id")%>'/>
                <asp:HiddenField ID="WAS_CHECKED" runat="server" Value='<%#Eval("IsChecked")%>'/>
                <asp:CheckBox runat="server" ID="IS_CHECKED" Checked='<%#Eval("IsChecked")%>'/><br />
            </ItemTemplate>
        </asp:Repeater>

        <asp:Button runat="server" Text="Добавить" OnClick="OnAdd"/>

    </div>
    </form>
</body>
</html>
