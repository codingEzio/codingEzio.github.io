import signal
import time
import sys
import os

def handler(signum, frame):
    print("\n收到信号，准备退出...")

    time.sleep(1.5)
    print("清理完成，再见！")

    sys.exit(0)

# 注册信号处理器 (Ctrl+C, Ctrl+\)
signal.signal(signal.SIGINT, handler)
signal.signal(signal.SIGQUIT, handler)


print(f"开始工作，按 Ctrl+C 或 Ctrl + \\ 退出 (pid: {os.getpid()})...")

while True:
    time.sleep(1)  # 模拟工作
