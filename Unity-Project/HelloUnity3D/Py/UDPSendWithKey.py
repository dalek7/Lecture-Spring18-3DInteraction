import socket
import sys
from pynput.keyboard import Key, Listener

''' 
Script used for 717300, 3D Interaction Design, Hallym University

Example

python UDPSendWithKey.py 192.168.1.100 12345

or simply

python UDPSendWithKey.py 
'''

UDP_IP = "127.0.0.1"
UDP_PORT = 12345
MESSAGE = "Hello, World!"

if len(sys.argv) > 2:
	UDP_IP = sys.argv[1]
	UDP_PORT = int(sys.argv[2])

elif len(sys.argv) < 1:	#default
	UDP_IP = "127.0.0.1"
	UDP_PORT = 12345

def on_press(key):

    if key== Key.up:
        #print("Up !")
        send("w", UDP_IP, UDP_PORT)
    elif key== Key.down:
        #print("Down !")
        send("s", UDP_IP, UDP_PORT)
    elif key== Key.left:
        #print("Left !")
        send("a", UDP_IP, UDP_PORT)
    elif key== Key.right:
        #print("Right !")
        send("d", UDP_IP, UDP_PORT)
    elif key== Key.space:
        #print("Space !")
        send("j", UDP_IP, UDP_PORT)


def on_release(key):
    # print('{0} release'.format(key))
    if key == Key.esc:
        # Stop listener
        return False


def send(data, port=12345, addr='127.0.0.1'):
    """send(data[, port[, addr]]) - multicasts a UDP datagram."""
    # Create the socket

    #print("UDP target IP:", UDP_IP)
    #print("UDP target port:", UDP_PORT)
    print("Sending message to {}:{}: {}".format(UDP_IP, UDP_PORT, data))

    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)  # UDP
    #sock.sendto(bytes(data, "utf-8"), (UDP_IP, UDP_PORT))
    sock.sendto(bytes(data.encode("utf-8")), (UDP_IP, UDP_PORT))

# Collect events until released
with Listener(
        on_press=on_press,
        on_release=on_release) as listener:
    listener.join()