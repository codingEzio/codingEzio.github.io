
## Kernel and User

> 如今用户几乎所有操作都依靠 system call

### Difference

- Operating mode for each is Ring 0 and Ring 3
- Operations like File Handling, Network Request all needs to operate under kernel mode
- There were each of its space in the memory
- The kernel has access to all the memory, the user does not

### Switching

> Ref: [1](https://old.reddit.com/r/arduino/comments/416cs0/eli5_what_are_interrupts_what_do_i_need_them_for/)

1. Normal execution under Ring 3
2. .. needs system call
3. Interrupt .. to do system call
4. Interrupt.. I’ve finished system call
5. Normal execution under Ring 3

## 内存

### 虚拟内存

> Ref: [1](https://stackoverflow.com/a/70551110/6273859)

- 每个进程有各自虚拟地址空间 (Virtual Address Space)
- 系统 划分物内存为页 不足swap转硬盘
- 系统 维护页表 含虚拟地址<>物理地址
- 系统 划分多级页表省内 重为一 其他存

## 多任务

### 类型

- *并发*：Concurrency 单时单务 迅速切换
- *并行*：Parallelism 不同核处理不同程序

## Process and Thread

### 线程进程 之 **异同**

> Ref: [1](https://stackoverflow.com/a/5201879/6273859), [2](https://old.reddit.com/r/explainlikeimfive/comments/1awbdz/eli5_registers_and_instructions_in_assembly/), [3](https://stackoverflow.com/a/200543/6273859), [4](https://stackoverflow.com/a/1808710/6273859), [5](https://www.hanselman.com/blog/microsoft-ie8-and-google-chrome-processes-are-the-new-threads)

- 均非实物 而是代码数据处理的抽象
- 线程 于进程 享码数内件 分栈寄器等
- 线程 并发 Concurrency 基石 (多线程
- 系统 告线程何时运 分进程资源(内,文)
- 线程 启动销毁成本较进程\~小 因隔离

### 线程进程 之 **切换**

> 线程进程在这里几乎等同，恢复体量不一样 (though 线需换非共享物)

- 对于进程切换，需要保存和恢复的是进程的全部状态，包括进程的地址空间、上下文、寄存器值、打开的文件、信号处理程序、进程状态等。
- 线程切换时需要保存和恢复的是非共享的资源。这是因为线程共享相同的地址空间和其他系统资源，所以在线程切换时不需要切换地址空间和其他共享资源。相反，需要保存和恢复的是非共享资源，例如线程自身的寄存器、程序计数器和堆栈等
  1. 处理 进程 1
  2. 保存 进程 1 上下文
  3. 加载 进程 2 上下文
  4. 处理 进程 2
  5. …

### Process *States*

- 创建 (new
- 死亡 (exit
- 占用 CPU (running
- 待占用 CPU (ready
- 等待外界因素 (blocked

### Process *Types*

- Orphan and Zombie 孤儿进程与僵尸进程

> Ref: [1](https://stackoverflow.com/a/42303528)

- 👶 Still execute on its own (cpu/mm
- 🧟‍♀️ No execution, occupy entry (!cpu/mm

### Thread *Types*

> Ref: [1](https://stackoverflow.com/a/15984127/6273859), [2](http://www.it.uu.se/education/course/homepage/os/vt18/module-4/implementing-threads/), [3](https://en.wikipedia.org/wiki/Green_thread), [4](https://stackoverflow.com/a/5713198/6273859), [5](https://stackoverflow.com/q/72313714/6273859)

- 所有线程 以内核线程为始
- 两者区别 谁管理(OS or Language)
- 内核线程 又名 Native/OS-level 线程
- 内核线程 处理只涉及系统级的代码
- 用户线程 处理用户级,亦能作系调用
- Green 线程 可看作语规的User Thread
- Green 线程 语言作规 类户线 多核不利

### 线程共享区的资源同步

- ***临界区*** = 对共享资源访问的代码
- 以***信号量*** 限资被访次 用减完规
- 以***锁*** 互斥 对将访享资码锁 完解
  > 锁 (一种同步机制-对于共享资源), here are some scenarios you do *not* want to encounter

  - Starvation & Livelock 活锁与饥饿锁
    > Ref: [1](https://stackoverflow.com/a/6411905/6273859), [2](https://stackoverflow.com/a/6155978/6273859), [3](https://stackoverflow.com/a/1162610/6273859)
    - *活锁*：两者为防死锁作同 左右 无进
    - *饥饿锁*：多个高优先级程占 得无资

  - Deadlock 死锁
    > Ref: [1](https://www.youtube.com/watch?v=Z7iHodl1jsM), [2](https://www.scaler.com/topics/operating-system/deadlock-prevention-in-operating-system/), [3](https://old.reddit.com/r/explainlikeimfive/comments/1nq4a6/eli5the_dining_philosophers_problem/)
    >> <img src="./_assets/handdrawn-system-thread-deadlock.png" width="60%" height="auto" />
    - 条件
      - 此资只可被此线程用 Mutual Excl
      - 主体持有 且申等新资 Hold&Wait
      - 资源不可被抢 仅等 No Preemption
      - P1 P2 等待为永久循环 Circular Wait
    - 避免
      - 线程 提前申请所需所有资源 (不HdWt)
      - 若申不到新 主释当前资 再申新
      - 于申请划定优先级 愈高先得

-----

## 文件系统

### 软链接 与 硬链接

> Ref: [1](https://askubuntu.com/a/801191/1650652), [2](https://unix.stackexchange.com/a/23251/549763)

- 一切文录都有自己的 inode 编号
- 指向 普文件 -> inode
- 指向 硬链接 -> inode
- 指向 软链接 -> 文件 -> inode
- 改映 两者均可 硬链复多份 允删
- 区别 软链可文录跨盘 硬文不跨

### I/O 零拷贝 (ZeroCopy)

> Ref: [1](https://old.reddit.com/r/learnprogramming/comments/3t1znc/eli5_why_mmap_is_faster_than_read/), [2](https://old.reddit.com/r/programming/comments/je3av8/why_mmap_is_faster_than_system_calls/), [3](https://stocktonsols.com/article/sendfile-system-call), [4](https://blog.devgenius.io/linux-zero-copy-d61d712813fe)

- 提高性能 需减异态切和内存拷贝次
- MmAp 文于内存 将其内址映至进程 少写
- sendfile() 或同写读 或不切然系内直写

### I/O 同步-阻塞/非阻塞/多路复用 异步

> Ref: [1](https://www.cs.toronto.edu/~krueger/csc209h/f05/lectures/Week11-Select.pdf)

- `read` 线阻 待内核调读 待拷回 返容
- `read` 立返 继执它务 频询内核 然拷
- `read` 立返 继执它务 内核通程 然拷
- `aio_read` 立返 继执它务 内核作拷

### I/O 多路复用 Multiplexing

> Ref: [1](https://stackoverflow.com/a/40864759/6273859), [2](https://wiyi.org/linux-file-descriptor.html), [3](https://jvns.ca/blog/2017/06/03/async-io-on-linux--select--poll--and-epoll/), [4](https://stackoverflow.com/questions/5256599/what-are-file-descriptors-explained-in-simple-terms)

- 基础 复用即分单线专处理
- 基础 原 CPU询 有新处新
- 基础 现 予三系call察态 机略别
- 基础 fd文述符 单态 表详态 源inod
- 三调 select 核拷众fd 察标返 且忘
- 三调 poll 数构链突fd限 余同select
- 三调 epoll fd态 如变可读信通 (优)

## IPC (Inter-Process Communication)

### What

- a way to for different things to communicate
- like File. I write, you read
- like Shared Memory. I write, you read
- like Message Queue. I sent, you process later (when to use? e.g. buyer do something on e-commerce)
- like Socket, a remote file-like connection, I write, you read (when to use? (e.g. different services making calls to each other)

Types of IPCs

#### *Pipe*: 重定向IO 匿名单亲缘 有名任两程

- Pipe: System call (OS) - TCP/IP sockets (networking)

  > Pipe: A system call for inter-process communication (IPC) that allows processes to communicate by connecting the output of one process to the input of another process. In the Networking sense, pipes can be implemented using TCP/IP sockets to enable communication between processes running on different computers.

- IO redirection: Shell commands (OS) - Network proxies or traffic interception devices (networking)

  > IO redirection: A feature of operating systems that allows input and output streams to be redirected from the standard input/output (stdin/stdout) to a file or another process. In the Networking sense, IO redirection can be used to redirect network traffic from one port to another or to a different destination IP address.

#### *Signal*: 发信号 系统接 找程 通其处理

- Signal: System call (OS) - SNMP (networking)

  > Signal: A system call for delivering software interrupts to a process that can be used to notify the process of an event or to request that the process terminate. In the Networking sense, signals can be sent over a network using protocols such as SNMP to indicate specific events or conditions.

#### *MsgQueue*: 程事件 系统接 另程取之列

- Message Queue: POSIX message queue API (OS) - Message-oriented middleware such as JMS or AMQP (networking)

  > Message Queue: A mechanism for inter-process communication (IPC) that allows processes to send and receive messages asynchronously. In the Networking sense, message queues can be implemented using message-oriented middleware such as JMS or AMQP to enable communication between processes running on different computers.

#### *SharedMem*: 共实体内存通信 易冲突

- Shared Memory: System V shared memory API (OS) - Distributed memory caching systems such as Memcached (networking)

  > Shared Memory: A mechanism for inter-process communication (IPC) that allows multiple processes to access the same region of memory. In the Networking sense, shared memory can be implemented using distributed memory caching systems such as Memcached to enable multiple computers on a network to access the same data.

#### *Semaphore*: 告程限资访 厕匙进减出增

- Semaphore: POSIX semaphore API (OS) - Distributed concurrency control protocols such as Paxos or Raft (networking)

  > Semaphore: A synchronization mechanism that allows multiple processes to access a shared resource without interfering with each other. In the Networking sense, semaphores can be implemented using distributed concurrency control protocols such as Paxos or Raft to ensure that multiple computers on a network can access a shared resource without conflicts.

#### *Socket*: 两物发连-类文件存读 多网络流

- Socket: Berkeley sockets API (OS) - TCP, UDP, or HTTP (networking)

  > Socket: A system call that enables processes to communicate with each other over a network using protocols such as TCP, UDP, or HTTP. In the Networking sense, sockets are used to establish connections between computers on a network, enabling data to be exchanged between them.

-----

## CSAPP

### How do we get from 0s and 1s to a code file

- Zeros and ones represent binary data, which can be grouped into sets of eight bits called bytes.
- Each byte, composed of zeros and ones, can be converted to a decimal value.
- The decimal value corresponds to a specific character in the ASCII table, allowing us to map binary data to ASCII characters.
- By repeating this process for each byte, we can transform multiple sets of zeros and ones into multiple ASCII characters.
- These ASCII characters are then encoded and written into a file, creating a sequence of characters that can be interpreted by text-based applications.

### 0s and 1s in Different Context

- The very same sets/bunch of bits (0s and 1s) might be an integer, a character or machine instructions.

- Therefore, information or program or data you might say, were literally just bits in THIS CONTEXT and bits in THAT CONTEXT

### From hello.c to the executable ./hello

- *Preprocessing Phase*: add/insert implicit imported code, like the import in Python, the \#include in C, in the end, produce a different file, typically ended with .i, a hello.i file.

- *Compilation Phase*: translate C code into assembly instructions, which all non-assembly really are underneath 😉, normally ended with .s, aka. hello.s.

- *Assembly Phase*: translate Assembly code into actual machine instructions (0s and 1s), though this time it was packaged in the form of *relocatable object program* (this time the context of those bytes were machine instructions instead of characters), typically ended with .o, aka. hello.o.

- *Linking Phase*: the linker ld do the merging between the imported stuff (like the stdio.h for basic printing) and the previously generated hello.o, the eventual output is an executable object, i.e. ./hello.

### Abstractions for the Actual Implementations

> Might be software or hardware

- Virtual Machine (abstraction for entire PC)
  - Operating System
  - Processes (abstractions for these three)
    - Processor <- Instruction Set
    - Main Memory (+Files) <- Virtual Memory
    - I/O Devices <- Files

-----

## CPU Land

- Machine code are 0s and 1s
  - Machine code have both binary (0001) and hex formats (0xA3)
  - The machine codes in hex formats were individually mapped to Assembly instructions.

- Different CPUs hold different architectures
- Different architectures diff in the mappings between the hex (machine) code and (assembly) instructions.
- Things like ADD, SUB were called as OPCODE

- One CPU can only hold one architecture
- One CPU can do emulation and/or translations more than the architecture of its own (like how you run x86 apps on Apple M3 machines via the *Rosetta 2* translation layers)


- Machine instructions were loaded onto RAM
  - Machine instructions were ran via CPU executing instructions loaded onto RAM
  - Machine instructions can only be ran when loading onto RAM

- RAM acts like a workspace for CPU, which holds data and instructions, ready for access
- RAM is like a book with multiple pages, that you find data via something like *PageA :: LINE 19 :: POS 2:10*

