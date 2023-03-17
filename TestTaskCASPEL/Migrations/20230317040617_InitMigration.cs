using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskCASPEL.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Orders_OrdersID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "OrdersID",
                table: "Books",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_OrdersID",
                table: "Books",
                newName: "IX_Books_OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Orders_OrderID",
                table: "Books",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Orders_OrderID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Books",
                newName: "OrdersID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_OrderID",
                table: "Books",
                newName: "IX_Books_OrdersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Orders_OrdersID",
                table: "Books",
                column: "OrdersID",
                principalTable: "Orders",
                principalColumn: "ID");
        }
    }
}
