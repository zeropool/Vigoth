//    Copyright 2006, 2007, 2008 East Tech Incorporated
//
//    This file is part of FIX4NET.
//
//    FIX4NET is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Lesser General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    FIX4NET is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with FIX4NET.  If not, see <http://www.gnu.org/licenses/>.
//
using System;

namespace FIX4NET.FIX
{
    public class FieldReaderFIX
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string _message;
        private int _messageLen;
        private int _fieldStart;
        private int _fieldDelim;
        private int _fieldEnd;

        public const char TAG_DELIM = '=';
        public const char FIELD_DELIM = (char)1;

        public FieldReaderFIX(string message)
        {
            _message = message;
            if (_message != null)
                _messageLen = _message.Length;
        }

        public IField GetNextField()
        {
            if (_fieldStart >= _messageLen)
                return null;

            _fieldDelim = _message.IndexOf(TAG_DELIM, _fieldStart);
            if (_fieldDelim == -1)
            {
                log.WarnFormat("GetNextField - Failed to find tag delimiter / Message={0} FieldStart={1}", _message, _fieldStart);
                throw new Exception("Failed to find tag delimiter");
            }
            
            _fieldEnd = _message.IndexOf(FIELD_DELIM, _fieldDelim);
            if (_fieldEnd == -1)
            {
                log.WarnFormat("GetNextField - Failed to find field delimiter / Message={0} FieldDelim={1}", _message, _fieldDelim);
                throw new Exception("Failed to find field terminator");
            }

            int tag = Utils.Convert.ParseInt(_message, _fieldStart, _fieldDelim - _fieldStart);
            string value = _message.Substring(_fieldDelim + 1, _fieldEnd - _fieldDelim - 1);
            
            _fieldStart = _fieldEnd + 1;

            return new Field(tag, value);
        }
    }
}
