import datetime

class CaffeineTimeTracker:
    def __init__(self, bedtime):
        self.bedtime = datetime.datetime.strptime(bedtime, "%H:%M").time()
        self.intake_times = []

    def add_intake(self, time):
        intake_time = datetime.datetime.strptime(time, "%H:%M").time()
        self.intake_times.append(intake_time)

    def get_last_safe_time(self):
        safe_time = datetime.datetime.combine(datetime.date.today(), self.bedtime) - datetime.timedelta(hours=7)
        return safe_time.time()

    def check_intake(self):
        last_safe_time = self.get_last_safe_time()
        late_intakes = [time for time in self.intake_times if time > last_safe_time]

        if late_intakes:
            print(f"警告：在安全时间 {last_safe_time.strftime('%H:%M')} 之后仍有咖啡因摄入")
            for time in late_intakes:
                print(f"  - 摄入时间：{time.strftime('%H:%M')}")
            print("这可能会影响您的睡眠质量。")
        else:
            print("今天的咖啡因摄入时间安排得当，应该不会影响睡眠。")

    def suggest_last_intake(self):
        last_safe_time = self.get_last_safe_time()
        print(f"建议最后咖啡因摄入时间不要晚于：{last_safe_time.strftime('%H:%M')}")

# 使用示例
tracker = CaffeineTimeTracker("23:30")

tracker.add_intake("13:30")
tracker.add_intake("13:30")
tracker.add_intake("13:30")

tracker.check_intake()
tracker.suggest_last_intake()
