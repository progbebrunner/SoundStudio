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
        public void ValidateUserTest()
        {         
            answer = Testing.ProjectChecking.ValidateUser(lgn, psw);
            Assert.IsFalse(answer);
        }

        [TestMethod()]
        public void ValidatePasswordTest2()
        {
            lgn = "1";
            psw = "1";

            answer = Testing.ProjectChecking.ValidateUser(lgn, psw);
            Assert.IsTrue(answer);
        }

        [TestMethod()]
        public void ValidatePasswordTest3() 
        {
            lgn = "1";
            psw = "";

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
        public void BtnChekTest2()
        {
            btn_click = false;
            answer = Testing.ProjectChecking.BtnCheck(btn_click);
            Assert.IsFalse(answer);
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
            quantity = "3";
            answer = Testing.ProjectChecking.ValidateQuantity(quantity);
            Assert.IsTrue(answer);
        }
        
        [TestMethod()]
        public void ValidateQuantityTest3()
        {
            quantity = "bebra";
            answer = Testing.ProjectChecking.ValidateQuantity(quantity);
            Assert.IsFalse(answer);
        }
    }
}