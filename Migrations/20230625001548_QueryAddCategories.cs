using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadsApi.Migrations
{
    public partial class QueryAddCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            USE [appLeads]
            GO
            SET IDENTITY_INSERT [dbo].[Categories] ON 

            INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Interior Painters')
            INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Painters')
            INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'General Building Work')
            INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Home Renovations')
            INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Others')
            SET IDENTITY_INSERT [dbo].[Categories] OFF
            GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
