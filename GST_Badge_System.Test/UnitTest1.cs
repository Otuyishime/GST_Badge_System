using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GST_Badge_System.DAO;

namespace GST_Badge_System.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestImportUsers()
        {
            // Arrange
            int expecited = 31;

            // Act
            UserDAO userdao = new UserDAO();
            int actual = userdao.importUsers().Count;

            // Assert
            Assert.AreEqual(expecited, actual);
        }

        [TestMethod]
        public void TestUploadUsers()
        {
            int expected = 1;

            UserDAO userdao = new UserDAO();
            int actual = userdao.uploadUsers();

            Assert.AreEqual(expected, actual);
        }
    }
}
