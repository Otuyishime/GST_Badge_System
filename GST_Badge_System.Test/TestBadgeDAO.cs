using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GST_Badge_System.Test
{
    [TestClass]
    public class TestBadgeDAO
    {
        [TestMethod]
        public void TestImportBadges()
        {
            int expected = 15;

            DAO.BadgeDAO badgedao = new DAO.BadgeDAO();
            int actual = badgedao.ImportBadges(@"C:\Users\olivi\OneDrive\Documents\Intro Software Tools\Projects\GST_Badge_System\GST_Badge_System\GST_Badge_System.DAO\Data\StaffStudentBadges.csv").Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
