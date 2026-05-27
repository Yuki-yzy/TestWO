# 预约工单系统 - Day 5

## 今日目标
完成“查看我的预约列表”接口，形成提交预约 + 查询预约的最小闭环。

## 接口
GET /api/appointments/my

## 返回字段
- id
- appointmentTime
- serviceType
- description
- status
- createdAt

## 业务规则
1. 暂时固定当前用户 UserId = 1
2. 只返回当前用户自己的预约
3. 默认按 CreatedAt 倒序返回

## 今晚任务
1. 创建 `AppointmentListItemDto`
2. 在 `AppointmentService` 中新增 `GetMyAppointmentsAsync`
3. 在 `AppointmentsController` 中新增 `GET /api/appointments/my`
4. 用 Swagger 测试接口
5. 对照数据库检查返回结果

## 完成标准
- 能成功查出当前用户预约列表
- 返回字段正确
- 排序正确
- 数据与数据库一致
