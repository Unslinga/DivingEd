// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Networking
{
    public class Packet : IDisposable
    {
        #region Fields
        private bool disposed = false;
        private List<byte> buffer;
        private int readPos;
        #endregion

        #region Constructors

        public Packet()
        {
            Initialize();
        }



        #endregion

        #region Properties

        public int Length { get { return buffer.Count; } }

        public int UnreadLength { get { return Length - readPos; } }

        #endregion

        #region Public Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Reset(bool shouldReset = true)
        {
            if (shouldReset)
            {
                buffer.Clear();
                readPos = 0;
                return;
            }

            readPos -= 4;
        }

        #endregion

        #region Private Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    buffer = null;
                    readPos = 0;
                }

                disposed = true;
            }
        }

        private void Initialize()
        {
            buffer = new List<byte>();
            readPos = 0;
        }

        #endregion

        #region Write Data

        public void Write(byte data)
        {
            buffer.Add(data);
        }

        public void Write(byte[] data)
        {
            buffer.AddRange(data);
        }

        public void Write(int data)
        {
            buffer.AddRange(BitConverter.GetBytes(data));
        }

        public void Write(float data)
        {
            buffer.AddRange(BitConverter.GetBytes(data));
        }

        public void Write(double data)
        {
            buffer.AddRange(BitConverter.GetBytes(data));
        }

        public void Write(bool data)
        {
            buffer.AddRange(BitConverter.GetBytes(data));
        }

        public void Write(string data)
        {
            Write(data.Length);
            buffer.AddRange(Encoding.ASCII.GetBytes(data));
        }

        public void Write(Vector3 data)
        {
            Write(data.x);
            Write(data.y);
            Write(data.z);
        }

        public void Write(Quaternion data)
        {
            Write(data.x);
            Write(data.y);
            Write(data.z);
            Write(data.w);
        }

        #endregion

        #region Read Data

        public byte[] ReadBytes(int length, bool moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                byte[] data = buffer.GetRange(readPos, length).ToArray();
                if (moveReadPos)
                {
                    readPos += length;
                }
                return data;
            }
            else
                throw new Exception("Could not read value");
        }

        public byte ReadByte(bool moveReadPos = true)
        {
            return ReadBytes(1, moveReadPos)[0];
        }

        public int ReadInt(bool moveReadPos = true)
        {
            return BitConverter.ToInt32(ReadBytes(4, moveReadPos), 0);
        }

        public float ReadFloat(bool moveReadPos = true)
        {
            return BitConverter.ToSingle(ReadBytes(4, moveReadPos), 0);
        }

        public double ReadDouble(bool moveReadPos = true)
        {
            return BitConverter.ToDouble(ReadBytes(8, moveReadPos), 0);
        }

        public bool ReadBool(bool moveReadPos = true)
        {
            return BitConverter.ToBoolean(ReadBytes(1, moveReadPos), 0);
        }

        public string ReadString(bool moveReadPos = true)
        {
            int length = ReadInt();
            return Encoding.ASCII.GetString(ReadBytes(length, moveReadPos));
        }

        public Vector3 ReadVector3(bool moveReadPos = true)
        {
            return new Vector3(ReadFloat(), ReadFloat(), ReadFloat());
        }

        public Quaternion ReadQuaternion(bool moveReadPos = true)
        {
            return new Quaternion(ReadFloat(), ReadFloat(), ReadFloat(), ReadFloat());
        }

        #endregion
    }
}