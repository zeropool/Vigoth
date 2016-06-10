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
using System.Configuration;

using NUnit.Framework;
using log4net.Config;

namespace FIX4NET.Tests.FIX
{
    [SetUpFixture]
    public class SetupFixture
    {
        [SetUp]
        public void Setup()
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration("FIX4NET.Tests.dll");
            //object section = config.GetSection("log4net");
            XmlConfigurator.Configure();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
