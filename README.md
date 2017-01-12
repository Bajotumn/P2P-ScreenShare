# P2P-ScreenShare
An application originally designed for "cheating" pokerstars.
The problem: several family members playing a single table together together, we want to know what we all have to better play the table and win.
The solution: write a program that sends a portion of the screen to another computer.
P2P screenshare uses simple TCP sockets in C# to send a portion of your screen to multiple end points, using a sender/receiver model. It is coded to allow for 4 "senders" but is theoretically salable to any requirement.

Packet structure is VERY simple with only 2 packet types implemented.
* *Image Packet:*
 * packet[0-3] = int Data size
 * packet[4-?] = byte[] image data
* *Ping Packet:*
 * EMPTY
 
This project also includes a queued console writer for debug purposes, which was almost a separate project altogether...
