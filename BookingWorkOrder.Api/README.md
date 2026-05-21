# BookingWorkOrder.Api — 本地运行说明

## 目标
本仓库包含一个基于 ASP.NET Core 的预约工单系统骨架（API + EF Core 实体）。本 README 说明如何在有 .NET SDK 与 SQL Server 的机器上还原、迁移并运行项目。

## 前置要求
- 安装 .NET SDK 8.x（或与 `BookingWorkOrder.Api.csproj` 中 `TargetFramework` 匹配的 SDK）。
- 本地或可访问的 SQL Server 实例。
- 可选：安装 `dotnet-ef` 全局工具以运行 EF Core 命令：

```powershell
dotnet tool install --global dotnet-ef
# 如果已安装，更新到最新：
# dotnet tool update --global dotnet-ef
```

## 主要文件
- 项目入口：Program.cs
- DbContext：Data/ApplicationDbContext.cs
- 实体：Entities/ 下的 `User`, `Appointment`, `WorkOrder`, `WorkOrderLog`
- Day1 文档：Docs/Day1.md
- Day2 文档：Docs/Day2.md

## 配置连接字符串
编辑 `appsettings.json` 中 `ConnectionStrings:DefaultConnection`，示例（Windows 本机 SQL Server Trusted Connection）：

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BookingWorkOrderDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

如果使用 SQL 登录（用户名/密码），请按格式修改：

```json
"DefaultConnection": "Server=your_sql_host;Database=BookingWorkOrderDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
```

## 在本机还原、编译与运行
1. 在项目目录下还原依赖并编译：

```powershell
dotnet restore
dotnet build
```

2. （可选）生成并应用 EF Core 迁移：

```powershell
# 生成迁移（首次）
dotnet ef migrations add InitialCreate -p BookingWorkOrder.Api -s BookingWorkOrder.Api
# 将迁移应用到数据库
dotnet ef database update -p BookingWorkOrder.Api -s BookingWorkOrder.Api
```

3. 运行 API：

```powershell
dotnet run --project BookingWorkOrder.Api
```

4. 打开 Swagger UI（默认会在启动时打开浏览器或访问 `/swagger`）：

访问 `https://localhost:<port>/swagger` 或 `http://localhost:<port>/swagger`（以控制台输出为准）。

## 常见问题及排查
- `dotnet` 未找到：请确认 .NET SDK 已安装并且 `dotnet` 在 PATH 中。
- `dotnet ef` 未找到：安装 `dotnet-ef` 全局工具，或在项目中添加 `Microsoft.EntityFrameworkCore.Design` 包并使用 `dotnet tool`。
- 无法连接数据库：检查 `appsettings.json` 的连接字符串、SQL Server 是否运行、网络和防火墙设置。若使用 SQL 登录请确认账号密码正确并具有创建数据库权限。
- 迁移失败提示表/列冲突：如果数据库已存在旧结构，可以清空数据库或手动修正迁移；开发环境下直接删除数据库然后 `dotnet ef database update` 是最快方式。

## 开发建议（快速上手）
- 先在开发机器上跑通迁移与启动，验证 `GET /api/health` 返回正常。之后再实现 CRUD Controller。
- 如果你要在不同机器间共享数据库，建议把连接字符串放在用户环境变量或 secrets，而不是提交到仓库。

## 下一步（建议）
- 实现 `Appointment` / `WorkOrder` 的最小 CRUD 接口与相应 DTO。
- 增加简单的认证（开发阶段可使用模拟用户/测试 token）。

---
README 由协助脚本生成，若需补充示例数据或 docker-compose 配置我可以继续添加。