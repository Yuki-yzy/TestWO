# 预约工单系统 - Day 1

## 项目目标
做一个从用户提交预约，到管理员审核，再到生成工单并由工程师处理完成的闭环系统。

## 角色
### Customer
提交预约，查看自己的预约和工单

### Admin
审核预约，生成工单，分配工单，查看全部预约和工单

### Engineer
查看分配给自己的工单，更新处理状态，填写处理记录

## 核心流程
客户提交预约
→ 系统保存预约，状态 = Pending
→ 管理员审核预约
→ 通过：状态 = Approved
→ 生成工单
→ 分配工程师
→ 工程师处理
→ 完成 / 关闭

拒绝：状态 = Rejected

## 状态定义
### AppointmentStatus
Pending / Approved / Rejected / Converted

### WorkOrderStatus
Open / Assigned / InProgress / Done / Closed

## V1 不做
- 短信通知
- 邮件通知
- 文件上传
- 支付
- 报表中心
- 小程序
- 多租户

## 今晚任务
1. 创建 BookingWorkOrder.Api 项目
2. 安装 EF Core SQL Server 包
3. 建基础目录
4. 跑起 Swagger
