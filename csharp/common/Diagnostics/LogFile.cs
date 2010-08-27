﻿/* 
 Copyright (c) 2010, NHIN Direct Project
 All rights reserved.

 Authors:
    Umesh Madan     umeshma@microsoft.com
  
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
Neither the name of the The NHIN Direct Project (nhindirect.org). nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NHINDirect.Diagnostics
{
    /// <summary>
    /// Thread safe Log File
    /// </summary>
    public class LogFile : IDisposable
    {
        LogWriter m_writer;

        public LogFile(LogWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException();
            }
            m_writer = writer;
        }
        
        public void WriteError(Exception exception)
        {
            lock(m_writer)
            {
                m_writer.WriteError(exception);
            }
        }

        public void WriteError(string message)
        {
            lock (m_writer)
            {
                m_writer.WriteLine(LogEventType.Error, message);
            }
        }

        public void WriteLine(LogEventType type, object message)
        {
            lock(m_writer)
            {
                m_writer.WriteLine(type, message);
            }
        }

        public void WriteLine(LogEventType type, string message)
        {
            lock(m_writer)
            {
                m_writer.WriteLine(type, message);
            }
        }

        public void WriteLine(string type, string message)
        {
            lock (m_writer)
            {
                m_writer.WriteLine(type, message);
            }
        }

        public void WriteLine(string message)
        {
            lock(m_writer)
            {
                m_writer.WriteLine(LogEventType.Info, message); 
            }
        }
        
        public void Dispose()
        {
            if (m_writer != null)
            {
                m_writer.Close();
                m_writer = null;
            }
        }
    }
}
