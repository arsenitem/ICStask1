using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeGenerationLibrary;

namespace CodeGenTests
{
    [TestClass]
    public class CodeGenTest1
    {
        [TestMethod]
        public void EncryptTest1()
        {
            string name = "Арсений";
            string l_name = "Темник";
            string s_name = "Дмитриевич";
            string b_day = "19.09.1999";
            int g_num = 1;

            string expected = "1ТАД2159";
            string actual = CodeGen.Encrypt(name, l_name, s_name, b_day, g_num);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EncryptTest2()
        {
            string name = "Евгений";
            string l_name = "Шестаков";
            string s_name = "Александрович";
            string b_day = "22.01.2000";
            int g_num = 15;

            string expected = "0ШЕА2451";
            string actual = CodeGen.Encrypt(name, l_name, s_name, b_day, g_num);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EncryptTest3()
        {
            string name = "Алексей";
            string l_name = "Орлов";
            string s_name = "Романович";
            string b_day = "01.01.1998";
            int g_num = 5;

            string expected = "5ОАР0351";
            string actual = CodeGen.Encrypt(name, l_name, s_name, b_day, g_num);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecryptTest1()
        {
            string encrypted = "1ТАД2159";
            string expected = "Т А Д 19.09 1";
            string actual = CodeGen.Decrypt(encrypted);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecryptTest2()
        {
            string encrypted = "0ШЕА2451";
            string expected = "Ш Е А 22.01 0";
            string actual = CodeGen.Decrypt(encrypted);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecryptTest3()
        {
            string encrypted = "5ОАР0351";
            string expected = "О А Р 01.01 5";
            string actual = CodeGen.Decrypt(encrypted);

            Assert.AreEqual(expected, actual);
        }
    }
}
