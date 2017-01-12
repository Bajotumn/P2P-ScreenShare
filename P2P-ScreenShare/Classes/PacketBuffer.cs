using System;
using System.Collections.Generic;
using System.Text;

namespace P2P_ScreenShare.Communications {
    public class PacketBuffer{
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

        public PacketBuffer() {
        }
        public PacketBuffer(byte[] buffer) {
            m_buffer = buffer;
        }
        public PacketBuffer(int size) {
            m_buffer = new byte[size];
        }

        protected void Resize(int size) {
            if (m_buffer.Length < size) {
                byte[] newbuf = new byte[size];
                m_buffer.CopyTo(newbuf, 0);
                m_buffer = newbuf;
            }
        }
        public void Append(byte[] data) {
            int tackStart = Buffer.Length;
            int x = 0;
            Resize(Buffer.Length + data.Length);
            for (int i = tackStart; i < Buffer.Length; i++) {
                Buffer[i] = data[x++];
            }
        }
    }

}
