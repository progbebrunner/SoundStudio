using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.SymbolStore;

namespace Testing.Tests
{
    [TestClass()]
    public class ProjectChecking
    {
        bool answer;
        
        string lgn = "";
        string psw = "";
        bool btn_click;
        string quantity;

        [TestMethod()]
        public void ValidateLgnPswTest()
        {         
            answer = Testing.ProjectChecking.ValidateUser(lgn, psw);
            Assert.IsFalse(answer);
        }

        [TestMethod()]
        public void ValidateLgnPswTest2()
        {
            lgn = "1"; psw = "1";

            answer = Testing.ProjectChecking.ValidateUser(lgn, psw);
            Assert.IsTrue(answer);
        }

        [TestMethod()]
        public void ValidateLgnPswTest3() 
        {
            lgn = "1"; psw = "";

            answer = Testing.ProjectChecking.ValidateUser(lgn, psw);
            Assert.IsFalse(answer);
        }

        [TestMethod()]
        public void BtnChekTest()
        {
            btn_click = true;
            answer = Testing.ProjectChecking.BtnCheck(btn_click);
            Assert.IsTrue(answer);
        }

        [TestMethod()]
        public void ValidateQuantityTest()
        {
            quantity = "";
            answer = Testing.ProjectChecking.ValidateQuantity(quantity);
            Assert.IsFalse(answer);
        }       
        
        
        [TestMethod()]
        public void ValidateQuantityTest2()
        {
            quantity = "bebra";
            answer = Testing.ProjectChecking.ValidateQuantity(quantity);
            Assert.IsFalse(answer);
        }

        [TestMethod()]
        public void ValidateQuantityTest3()
        {
            quantity = "6,9";
            answer = Testing.ProjectChecking.ValidateQuantity(quantity);
            Assert.IsFalse(answer);
        }

        [TestMethod()]
        public void ValidateQuantityTest4()
        {
            quantity = "3";
            answer = Testing.ProjectChecking.ValidateQuantity(quantity);
            Assert.IsTrue(answer);
        }
    }
}