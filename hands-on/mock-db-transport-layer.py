"""metadata
Python: 3.12.4
macOS: > BigSur (macOS 11)
"""

import socket

def start_server():
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind(('localhost', 3306))
    server_socket.listen(5)
    print("Server listening on port 3306...")

    while True:
        client_socket, addr = server_socket.accept()
        print(f"Connection from {addr}")
        data = client_socket.recv(1024).decode('utf-8')
        process_request(data, client_socket)
        client_socket.close()

def process_request(data, client_socket):
    if "SELECT" in data:
        client_socket.send("Query received".encode('utf-8'))

start_server()


# Run this to test
# echo "SELECT * FROM users" | nc localhost 3306