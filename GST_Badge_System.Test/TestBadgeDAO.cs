using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GST_Badge_System.Test
{
    [TestClass]
    public class TestBadgeDAO
    {
        [TestMethod]
        public void TestImportBadges()
        {
            int expected = 15;
            string dirpath = Directory.GetCurrentDirectory();
            string path = Directory.GetParent(dirpath).FullName;
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;

            DAO.BadgeDAO badgedao = new DAO.BadgeDAO();
            int actual = badgedao.ImportBadges(path+@"\GST_Badge_System.DAO\Data\Staff-Student.csv").Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestListBadges()
        {
            int expected = 46;

            DAO.BadgeDAO bdao = new DAO.BadgeDAO();
            int actual = bdao.list().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
