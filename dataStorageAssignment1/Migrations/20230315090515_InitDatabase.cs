using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataStorageAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeEmployeeComment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrandStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrandStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Errands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrandTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrandsStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrandStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Errands_CommentEntity_EmployeeCommentId",
                        column: x => x.EmployeeCommentId,
                        principalTable: "CommentEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Errands_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Errands_ErrandStatus_ErrandStatusId",
                        column: x => x.ErrandStatusId,
                        principalTable: "ErrandStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Errands_CustomerId",
                table: "Errands",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Errands_EmployeeCommentId",
                table: "Errands",
                column: "EmployeeCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Errands_ErrandStatusId",
                table: "Errands",
                column: "ErrandStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errands");

            migrationBuilder.DropTable(
                name: "CommentEntity");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ErrandStatus");
        }
    }
}
