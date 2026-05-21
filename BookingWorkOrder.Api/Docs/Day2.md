# 预约工单系统 - Day 2

## 今日目标
完成核心数据库表设计，并在本地项目中建立实体类和 DbContext。

## 核心表

### Users
- Id:int
- UserName:nvarchar(50)
- PasswordHash:nvarchar(255)
- Role:nvarchar(20)
- Phone:nvarchar(20)?
- Email:nvarchar(100)?
- IsActive:bit
- CreatedAt:datetime2

### Appointments
- Id:int
- UserId:int
- AppointmentTime:datetime2
- ServiceType:nvarchar(50)
- Description:nvarchar(500)?
- Status:nvarchar(20)
- ReviewedByUserId:int?
- ReviewNote:nvarchar(500)?
- CreatedAt:datetime2

### WorkOrders
- Id:int
- AppointmentId:int
- AssignedToUserId:int?
- Title:nvarchar(100)
- Description:nvarchar(1000)?
- Priority:nvarchar(20)
- Status:nvarchar(20)
- CreatedAt:datetime2
- UpdatedAt:datetime2?

### WorkOrderLogs
- Id:int
- WorkOrderId:int
- Action:nvarchar(50)
- Note:nvarchar(1000)?
- OperatorUserId:int
- CreatedAt:datetime2

## 表关系
- Users 1 ---- n Appointments
- Appointments 1 ---- 0..1 WorkOrders
- Users 1 ---- n WorkOrders (AssignedToUserId)
- WorkOrders 1 ---- n WorkOrderLogs
- Users 1 ---- n WorkOrderLogs (OperatorUserId)

## 今晚任务
1. 建 `User` / `Appointment` / `WorkOrder` / `WorkOrderLog` 实体类
2. 建 `AppDbContext`（已命名 `ApplicationDbContext`）并注册 `DbSet`
3. 配数据库连接字符串（`appsettings.json`）
4. 在 `Program.cs` 注册 DbContext
5. 尝试运行 migration（如果机器有 .NET SDK）
