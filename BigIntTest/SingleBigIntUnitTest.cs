﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uly.Numerics;
using MSBigInt = System.Numerics.BigInteger;
using System.Diagnostics;

namespace BigIntTest
{
    /// <summary>
    /// 单项单元测试
    /// </summary>
    [TestClass]
    public class SingleBigIntUnitTest
    {
        private string s1, s2;
        BigInteger op1,op2;
        MSBigInt cop1,cop2;
        private string ans1, ans2;

        private Stopwatch _timer = new Stopwatch();
        private long _nanoSecPerTick;
        [TestInitialize]
        public void Init()
        {
            s1 = "999999999999999999999999999999";
            s2 = "-9999.0";
            op1 = new BigInteger(s1);
            op2 = new BigInteger(s2);
            cop1 = MSBigInt.Parse(s1);
            cop2 = MSBigInt.Parse(s2);
            //cop1 = MSBigInt.Parse(op1.ToString());
            //cop2 = MSBigInt.Parse(op2.ToString());
            _timer.Reset();
            _nanoSecPerTick = (1000L * 1000L * 1000L) / Stopwatch.Frequency;
            Console.WriteLine("时间单位：Tick（每Tick为 " + _nanoSecPerTick + " 纳秒）");
            Console.WriteLine("1毫秒 = " + 1000000/_nanoSecPerTick + " Tick");
        }


        [TestMethod]
        public void TestAdd()
        {
            _timer.Start();
            ans1 = (op1 + op2).ToString();
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();

            _timer.Start();
            ans2 = (cop1 + cop2).ToString();
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();
            Assert.AreEqual(ans1,ans2);
        }

        [TestMethod]
        public void TestSub()
        {
            _timer.Start();
            ans1 = (op1 - op2).ToString();
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();

            _timer.Start();
            ans2 = (cop1 - cop2).ToString();
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();
            Assert.AreEqual(ans1, ans2);
        }

        [TestMethod]
        public void TestMul()
        {
            _timer.Start();
            ans1 = (op1 * op2).ToString();
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();

            _timer.Start();
            ans2 = (cop1 * cop2).ToString();
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();
            Assert.AreEqual(ans1, ans2);
        }

        [TestMethod]
        public void TestDiv()
        {
            _timer.Start();
            ans1 = (op1 / op2).ToString();
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();
            
            _timer.Start();
            ans2 = (cop1 / cop2).ToString();
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();
            Assert.AreEqual(ans1, ans2);
        }

        [TestMethod]
        public void TestEqual()
        {
            _timer.Start();
            Assert.IsTrue(op1 == cop1);
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();

            _timer.Start();
            Assert.IsTrue(op2 == cop2);
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();
        }

        [TestMethod]
        public void TestGreaterLess()
        {
            _timer.Start();
            Assert.IsFalse((op1 > op2) ^ (cop1 > cop2)); //异或，两者相同则为False
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();

            _timer.Start();
            Assert.IsFalse((op1 < op2) ^ (cop1 < cop2)); //异或，两者相同则为False
            _timer.Stop();
            Console.WriteLine(_timer.ElapsedTicks);
            _timer.Reset();
        }
    }
}
