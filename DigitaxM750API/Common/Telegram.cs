using System;
using System.Net.Sockets;

namespace DigitaxM750API.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class Telegram
    {
        private int Length { get; set; }

        private byte[] Data { get => FillData(); }
        
        /// <summary>
        /// Transaction Identifier.
        /// Value: 0
        /// </summary>
        private byte Byte00 { get => 0; }

        /// <summary>
        /// Transaction Identifier.
        /// Value: 0
        /// </summary>
        private byte Byte01 { get => 0; }

        /// <summary>
        /// Protocol Identifier.
        /// Value: 0
        /// </summary>
        private byte Byte02 { get => 0; }

        /// <summary>
        /// Protocol Identifier.
        /// Value: 0
        /// </summary>
        private byte Byte03 { get => 0; }

        /// <summary>
        /// Lenght.
        /// Value: 0
        /// </summary>
        private byte Byte04 { get => 0; }

        /// <summary>
        /// Lenght.
        /// Value: 6-11
        /// </summary>
        private byte Byte05 { get => (byte)(Length - 6); }

        /// <summary>
        /// Unit Identifier.
        /// Value: 0
        /// </summary>
        private byte Byte06 { get => 0; }

        /// <summary>
        /// Function code.
        /// Value: 43
        /// </summary>
        private byte Byte07 { get; set; }

        /// <summary>
        /// Start read register address (MSB)
        /// </summary>
        private byte Byte08 { get; set; }

        /// <summary>
        /// Start read register address (LSB)
        /// </summary>
        private byte Byte09 { get; set; }

        /// <summary>
        /// Number of 16-bit registers (MSB)
        /// </summary>
        private byte Byte10 { get; set; }

        /// <summary>
        /// Number of 16-bit registers (LSB)
        /// </summary>
        private byte Byte11 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private byte Byte12 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private byte Byte13 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private byte Byte14 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private byte Byte15 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private byte Byte16 { get; set; }

        private byte[] FillData()
        {
            if (Length > 17)
            {
                Length = 17;
            }

            var telegram = new byte[Length];
            telegram[0] = Byte00;
            telegram[1] = Byte01;
            telegram[2] = Byte02;
            telegram[3] = Byte03;
            telegram[4] = Byte04;
            telegram[5] = Byte05;
            telegram[6] = Byte06;
            telegram[7] = Byte07;
            telegram[8] = Byte08;
            telegram[9] = Byte09;
            telegram[10] = Byte10;
            telegram[11] = Byte11;
            if (Length > 12)
            {
                telegram[12] = Byte12;
            }

            if (Length > 13)
            {
                telegram[13] = Byte13;
            }

            if (Length > 14)
            {
                telegram[14] = Byte14;
            }

            if (Length > 15)
            {
                telegram[15] = Byte15;
            }

            if (Length > 16)
            {
                telegram[16] = Byte16;
            }

            return telegram;
        }

        public bool ReadBool(Socket s, byte[] address)
        {
            var addressBytes = Get16BitAddress(address);
            Length = 12;
            Byte07 = 3;
            Byte08 = addressBytes[0];
            Byte09 = addressBytes[1];
            Byte11 = 1;
            // Send request to the server.
            var bytesSend = Data;
            _ = s.Send(bytesSend, bytesSend.Length, 0);
            // Receive data from the server.
            var bytesReceived = new byte[11];
            _ = s.Receive(bytesReceived, bytesReceived.Length, 0);
            var resultBytes = new byte[] { bytesReceived[10], bytesReceived[9] };
            var result = BitConverter.ToBoolean(resultBytes);
            return result;
        }

        public bool WriteBool(Socket s, byte[] address, bool value)
        {
            var addressBytes = Get16BitAddress(address);
            var valueBytes = BitConverter.GetBytes(value);
            Length = 12;
            Byte07 = 6;
            Byte08 = addressBytes[0];
            Byte09 = addressBytes[1];
            Byte10 = 0;
            Byte11 = valueBytes[0];
            // Send request to the server.
            var bytesSend = Data;
            _ = s.Send(bytesSend, bytesSend.Length, 0);
            // Receive data from the server.
            var bytesReceived = new byte[12];
            _ = s.Receive(bytesReceived, bytesReceived.Length, 0);
            var resultBytes = new byte[] { bytesReceived[11], bytesReceived[10] };
            var result = BitConverter.ToBoolean(resultBytes);
            return result == value;
        }

        public byte Read8Bit(Socket s, byte[] address)
        {
            var addressBytes = Get16BitAddress(address);
            Length = 12;
            Byte07 = 3;
            Byte08 = addressBytes[0];
            Byte09 = addressBytes[1];
            Byte11 = 1;
            // Send request to the server.
            var bytesSend = Data;
            _ = s.Send(bytesSend, bytesSend.Length, 0);
            // Receive data from the server.
            var bytesReceived = new byte[11];
            _ = s.Receive(bytesReceived, bytesReceived.Length, 0);
            return bytesReceived[10];
        }

        public bool Write8Bit(Socket s, byte[] address, byte value)
        {
            var addressBytes = Get16BitAddress(address);
            var valueBytes = BitConverter.GetBytes(value);
            Length = 12;
            Byte07 = 6;
            Byte08 = addressBytes[0];
            Byte09 = addressBytes[1];
            Byte10 = 0;
            Byte11 = valueBytes[0];
            // Send request to the server.
            var bytesSend = Data;
            _ = s.Send(bytesSend, bytesSend.Length, 0);
            // Receive data from the server.
            var bytesReceived = new byte[12];
            _ = s.Receive(bytesReceived, bytesReceived.Length, 0);
            return bytesReceived[11] == value;
        }

        public short Read16Bit(Socket s, byte[] address)
        {
            var addressBytes = Get16BitAddress(address);
            Length = 12;
            Byte07 = 3;
            Byte08 = addressBytes[0];
            Byte09 = addressBytes[1];
            Byte11 = 1;
            // Send request to the server.
            var bytesSend = Data;
            _ = s.Send(bytesSend, bytesSend.Length, 0);
            // Receive data from the server.
            var bytesReceived = new byte[11];
            _ = s.Receive(bytesReceived, bytesReceived.Length, 0);
            var resultBytes = new byte[] { bytesReceived[10], bytesReceived[9] };
            var result = BitConverter.ToInt16(resultBytes);
            return result;
        }

        public bool Write16Bit(Socket s, byte[] address, short value)
        {
            var addressBytes = Get16BitAddress(address);
            var valueBytes = BitConverter.GetBytes(value);
            Length = 12;
            Byte07 = 6;
            Byte08 = addressBytes[0];
            Byte09 = addressBytes[1];
            Byte10 = valueBytes[0];
            Byte11 = valueBytes[1];
            // Send request to the server.
            var bytesSend = Data;
            _ = s.Send(bytesSend, bytesSend.Length, 0);
            // Receive data from the server.
            var bytesReceived = new byte[12];
            _ = s.Receive(bytesReceived, bytesReceived.Length, 0);
            var resultBytes = new byte[] { bytesReceived[11], bytesReceived[10] };
            var result = BitConverter.ToInt16(resultBytes);
            return result == value;
        }

        public int Read32Bit(Socket s, byte[] address)
        {
            var addressBytes = Get32BitAddress(address);
            Length = 12;
            Byte07 = 3;
            Byte08 = addressBytes[0];
            Byte09 = addressBytes[1];
            Byte11 = 2;
            // Send request to the server.
            var bytesSend = Data;
            _ = s.Send(bytesSend, bytesSend.Length, 0);
            // Receive data from the server.
            var bytesReceived = new byte[13];
            _ = s.Receive(bytesReceived, bytesReceived.Length, 0);
            var resultBytes = new byte[] { bytesReceived[12], bytesReceived[11], bytesReceived[10], bytesReceived[9] };
            var result = BitConverter.ToInt32(resultBytes);
            return result;
        }

        public bool Write32Bit(Socket s, byte[] address, int value)
        {
            var addressBytes = Get32BitAddress(address);
            var valueBytes = BitConverter.GetBytes(value);
            Length = 17;
            Byte07 = 16;
            Byte08 = addressBytes[0];
            Byte09 = addressBytes[1];
            Byte10 = 0;
            Byte11 = 2;
            Byte12 = 4;
            Byte13 = valueBytes[3];
            Byte14 = valueBytes[2];
            Byte15 = valueBytes[1];
            Byte16 = valueBytes[0];
            // Send request to the server.
            var bytesSend = Data;
            _ = s.Send(bytesSend, bytesSend.Length, 0);
            // Receive data from the server.
            var bytesReceived = new byte[12];
            _ = s.Receive(bytesReceived, bytesReceived.Length, 0);
            return bytesReceived[11] == 2;
        }

        private static byte[] Get16BitAddress(byte[] address)
        {
            var decimalValue = (short)(address[0] * 100 + address[1] - 1);
            var addressBytes = BitConverter.GetBytes(decimalValue);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(addressBytes);
            }

            return addressBytes;
        }

        private static byte[] Get32BitAddress(byte[] address)
        {
            var value = (short)(address[0] * 100 + address[1] - 1 + 16384);
            var addressBytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(addressBytes);
            }

            return addressBytes;
        }
    }
}
