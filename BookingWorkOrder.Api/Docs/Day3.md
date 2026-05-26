# 预约工单系统 - Day 3

## 今日目标
将数据库设计正式落地到代码中，并创建本地数据库（如果本机有 .NET SDK）。

## 今晚任务
1. 创建 `User` / `Appointment` / `WorkOrder` / `WorkOrderLog` 实体类（已完成）
2. 创建 `AppDbContext` / `ApplicationDbContext` 并注册 `DbSet`（已完成）
3. 配置 `appsettings.json` 中的数据库连接字符串（已完成，示例为本地 Trusted Connection）
4. 在 `Program.cs` 注册 DbContext（已完成）
5. 执行 `dotnet build`（需本机有 .NET SDK）
6. 执行 `dotnet ef migrations add InitialCreate`（需 `dotnet-ef` 或已安装的 EF Core 工具）
7. 执行 `dotnet ef database update`（在数据库可达时运行）

## 验收标准
- 项目编译通过
- migration 创建成功
- 本地数据库创建成功，并包含业务表与 `__EFMigrationsHistory`

## 快速命令
```powershell
dotnet restore
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

## 说明与注意
- 我已在代码中实现实体类与 `ApplicationDbContext`，并在 `Program.cs` 中注入。由于当前环境未检测到 `dotnet` 命令，迁移与实际数据库创建需在有 .NET SDK 的机器上运行。
- 如果你希望，我可以继续帮你实现第一个可调用的接口（推荐先实现预约提交 `Appointment` 的 POST 接口），这样在迁移通过后可以直接验证流程。

---
文档自动生成，若需调整字段名（例如 `CreatedAtUtc` 改为 `CreatedAt`）我可以统一替换。