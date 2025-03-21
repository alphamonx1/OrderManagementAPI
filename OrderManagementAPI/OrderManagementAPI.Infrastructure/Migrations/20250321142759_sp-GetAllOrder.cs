using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagementAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class spGetAllOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[sp_GetAllOrder]
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        SELECT * FROM Orders
                    END";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
