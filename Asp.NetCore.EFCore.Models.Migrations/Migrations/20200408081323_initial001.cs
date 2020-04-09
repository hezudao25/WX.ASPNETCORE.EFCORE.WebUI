using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WX.AspNetCore.EFCore.Models.Migrations.Migrations
{
    public partial class initial001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Zhaoxi");

            migrationBuilder.CreateTable(
                name: "ConmpanyInfo",
                schema: "Zhaoxi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<int>(nullable: true),
                    LastModifierId = table.Column<int>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConmpanyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysLog",
                schema: "Zhaoxi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 36, nullable: false),
                    Introduction = table.Column<string>(maxLength: 1000, nullable: false),
                    Detail = table.Column<string>(maxLength: 4000, nullable: true),
                    LogType = table.Column<byte>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    LastModifierId = table.Column<int>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysMenu",
                schema: "Zhaoxi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: false),
                    SysMenuName = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(maxLength: 500, nullable: true),
                    MenuLevel = table.Column<byte>(nullable: false),
                    MenuType = table.Column<byte>(nullable: false),
                    MenuIcon = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    SourcePath = table.Column<string>(maxLength: 1000, nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRole",
                schema: "Zhaoxi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 36, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateId = table.Column<int>(nullable: false),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysUserInfo",
                schema: "Zhaoxi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    QQ = table.Column<long>(nullable: true),
                    WeChat = table.Column<string>(maxLength: 50, nullable: true),
                    Sex = table.Column<byte>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateId = table.Column<int>(nullable: false),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUserInfo_ConmpanyInfo_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Zhaoxi",
                        principalTable: "ConmpanyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysUserInfoDetail",
                schema: "Zhaoxi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SysUserInfoDetailId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SysUserInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserInfoDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUserInfoDetail_SysUserInfo_SysUserInfoDetailId",
                        column: x => x.SysUserInfoDetailId,
                        principalSchema: "Zhaoxi",
                        principalTable: "SysUserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysUserInfoDetail_SysUserInfo_SysUserInfoId",
                        column: x => x.SysUserInfoId,
                        principalSchema: "Zhaoxi",
                        principalTable: "SysUserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SysUserRoleMapping",
                schema: "Zhaoxi",
                columns: table => new
                {
                    SysUserId = table.Column<int>(nullable: false),
                    SysRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserRoleMapping", x => new { x.SysUserId, x.SysRoleId });
                    table.ForeignKey(
                        name: "FK_SysUserRoleMapping_SysRole_SysRoleId",
                        column: x => x.SysRoleId,
                        principalSchema: "Zhaoxi",
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysUserRoleMapping_SysUserInfo_SysUserId",
                        column: x => x.SysUserId,
                        principalSchema: "Zhaoxi",
                        principalTable: "SysUserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Zhaoxi",
                table: "SysLog",
                columns: new[] { "Id", "CreateTime", "CreatorId", "Detail", "Introduction", "LastModifierId", "LastModifyTime", "LogType", "UserName" },
                values: new object[] { 1, new DateTime(2020, 4, 8, 16, 13, 23, 93, DateTimeKind.Local).AddTicks(4522), 1, null, "Introduction1", null, new DateTime(2020, 4, 8, 16, 13, 23, 95, DateTimeKind.Local).AddTicks(8430), (byte)0, "测试1" });

            migrationBuilder.InsertData(
                schema: "Zhaoxi",
                table: "SysLog",
                columns: new[] { "Id", "CreateTime", "CreatorId", "Detail", "Introduction", "LastModifierId", "LastModifyTime", "LogType", "UserName" },
                values: new object[] { 2, new DateTime(2020, 4, 8, 16, 13, 23, 95, DateTimeKind.Local).AddTicks(9831), 1, null, "Introduction2", null, new DateTime(2020, 4, 8, 16, 13, 23, 95, DateTimeKind.Local).AddTicks(9867), (byte)0, "测试2" });

            migrationBuilder.InsertData(
                schema: "Zhaoxi",
                table: "SysLog",
                columns: new[] { "Id", "CreateTime", "CreatorId", "Detail", "Introduction", "LastModifierId", "LastModifyTime", "LogType", "UserName" },
                values: new object[] { 3, new DateTime(2020, 4, 8, 16, 13, 23, 95, DateTimeKind.Local).AddTicks(9879), 1, null, "Introduction3", null, new DateTime(2020, 4, 8, 16, 13, 23, 95, DateTimeKind.Local).AddTicks(9881), (byte)0, "测试3" });

            migrationBuilder.CreateIndex(
                name: "IX_SysRole_Name",
                schema: "Zhaoxi",
                table: "SysRole",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SysUserInfo_CompanyId",
                schema: "Zhaoxi",
                table: "SysUserInfo",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserInfo_UserName_Phone",
                schema: "Zhaoxi",
                table: "SysUserInfo",
                columns: new[] { "UserName", "Phone" });

            migrationBuilder.CreateIndex(
                name: "IX_SysUserInfoDetail_SysUserInfoDetailId",
                schema: "Zhaoxi",
                table: "SysUserInfoDetail",
                column: "SysUserInfoDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SysUserInfoDetail_SysUserInfoId",
                schema: "Zhaoxi",
                table: "SysUserInfoDetail",
                column: "SysUserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserRoleMapping_SysRoleId",
                schema: "Zhaoxi",
                table: "SysUserRoleMapping",
                column: "SysRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysLog",
                schema: "Zhaoxi");

            migrationBuilder.DropTable(
                name: "SysMenu",
                schema: "Zhaoxi");

            migrationBuilder.DropTable(
                name: "SysUserInfoDetail",
                schema: "Zhaoxi");

            migrationBuilder.DropTable(
                name: "SysUserRoleMapping",
                schema: "Zhaoxi");

            migrationBuilder.DropTable(
                name: "SysRole",
                schema: "Zhaoxi");

            migrationBuilder.DropTable(
                name: "SysUserInfo",
                schema: "Zhaoxi");

            migrationBuilder.DropTable(
                name: "ConmpanyInfo",
                schema: "Zhaoxi");
        }
    }
}
