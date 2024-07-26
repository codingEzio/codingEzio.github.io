#include <signal.h>
#include <stdio.h>
#include <signal.h>
#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

void signal_handler(int signum) {
    printf("[received signal] %s\n", strsignal(signum));

    if (signum == SIGQUIT) {
        printf("Terminating...\n");
        exit(0);
    }
}

int main() {
    // Ctrl+C
    // Ctrl+Z
    signal(SIGINT, signal_handler);
    signal(SIGTERM, signal_handler);

    // kill -USR1 <pid>
    // kill -USR2 <pid>
    signal(SIGUSR1, signal_handler);
    signal(SIGUSR2, signal_handler);

    signal(SIGQUIT, signal_handler);

    while(1) {
        printf("[pid: %d] [ctrl+\\ to exit] \n", getpid());
        sleep(2);
    }

    return 0;
}