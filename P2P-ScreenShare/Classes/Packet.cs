using System;
using System.Collections.Generic;
using System.Text;

namespace P2P_ScreenShare.Communications {
    public class Packet {
        public enum tPacketType : byte {
            EMPTY = 0x99,
            Ping = 0x00,
            ImageRequest = 0x01,
            Image = 0x02
        }
        public const int HEADER_SIZE = 5;
        private byte[] m_buffer = new byte[0];
        public byte[] Buffer {
            get { return m_buffer; }
            protected set { m_buffer = value; }
        }
        public int Length {
            get {
                return Buffer.Length;
            }
        }
        public tPacketType PacketType {
            get {
                return (tPacketType)Buffer[HEADER_SIZE - 1];
            }
            set {
                Buffer[HEADER_SIZE - 1] = (byte)value;
            }
        }
        /// <summary>
        /// This constructor should be used to create a COMPLETE packet from a byte array
        /// </summary>
        /// <param name="receivedBuffer"></param>
        public Packet(byte[] receivedBuffer) {
            this.Buffer = receivedBuffer;
        }
        /// <summary>
        /// This constructor should be used to create a packet to send
        /// </summary>
        /// <param name="packetToSend"></param>
        /// <param name="pType"></param>
        public Packet(byte[] packetToSend, tPacketType pType) {
            Buffer = new byte[packetToSend.Length + HEADER_SIZE];
            BitConverter.GetBytes(this.Buffer.Length).CopyTo(this.Buffer, 0);
            this.PacketType = pType;
            packetToSend.CopyTo(this.Buffer, HEADER_SIZE);
        }
        private void ResizeBuffer(int size) {
            if (m_buffer.Length < size) {
                byte[] newbuf = new byte[size];
                m_buffer.CopyTo(newbuf, 0);
                m_buffer = newbuf;
            }
        }
        public void Append(byte[] data) {
            int tackStart = Buffer.Length;
            ResizeBuffer(Buffer.Length + data.Length);
            data.CopyTo(Buffer, Buffer.Length - 1);
        }
        public byte[] GetBytes() {
            return Buffer;
        }
    }
}
