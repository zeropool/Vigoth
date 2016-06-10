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

namespace FIX4NET.MessageCache.FlatFile
{
    public class MessageCacheFlatFileFactory : IMessageCacheFactory
    {
        private string _path;
        private IFileDateFormat _fileDateFormat = new FileDateFormat();

        /// <summary>
        /// Get/Set the path where data/index files will be stored.
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// Format class used to generate the date trailer on the end of a file name.
        /// </summary>
        public IFileDateFormat FileDateFormat
        {
            get { return _fileDateFormat; }
            set { _fileDateFormat = value; }
        }

        /// <summary>
        /// Creates instance of IMessageCache object used to save/retreive messages.
        /// </summary>
        /// <returns></returns>
        public IMessageCache CreateInstance()
        {
            MessageCacheFlatFile cache = new MessageCacheFlatFile();
            cache.Path = Path;
            cache.FileDateFormat = FileDateFormat;
            return cache;
        }
    }
}
