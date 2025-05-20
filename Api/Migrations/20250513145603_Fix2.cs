using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Attachments_TransactionId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TransactionId",
                table: "Attachments",
                column: "TransactionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Transactions_TransactionId",
                table: "Attachments",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Transactions_TransactionId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_TransactionId",
                table: "Attachments");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Attachments_TransactionId",
                table: "Transactions",
                column: "TransactionId",
                principalTable: "Attachments",
                principalColumn: "AttachmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
