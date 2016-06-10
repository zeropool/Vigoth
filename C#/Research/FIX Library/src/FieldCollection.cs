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
#if NET_2_0
using System.Collections.Generic;
#else
using System.Collections;
#endif

namespace FIX4NET
{
#if NET_2_0
    public class FieldCollection : List<IField>
#else
    public class FieldCollection : ArrayList
#endif
    {
#if NET_2_0
#else
        public new IField this[int index]
        {
            get { return (IField)base[index]; }
            set { base[index] = value; }
        }
#endif

        public IField Find(int tag)
        {
            foreach (IField field in this)
                if (field.Tag == tag)
                    return field;
            return null;
        }

        public string GetValue(int tag)
        {
            IField field = Find(tag);
            if (field != null)
                return field.Value;
            return null;
        }
    }
}
