using Microsoft.VisualStudio.TestTools.UnitTesting;
using BRAINS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS.Tests
{
    [TestClass()]
    public class SqlManagerSQLManagerTests
    {
        [TestMethod()]
        public void GetAllQuestionSetsTest()
        {
            //Arrange
            int ExpectedNumOfQuestions = 25;
            int departmentID = 2034;
            string status = #??;
            List<QuestionSet> questionSet;
            int numOfQuestionsRetrieved;

            //Act
            questionSet = SqlManager.GetAllQuestionSets(departmentID, status);
            numOfQuestionsRetrieved = questionSet.size();

            //Assert
            Assert.AreEqual(ExpectedNumOfQuestions, numOfQuestionsRetrieved);
        }

        [TestMethod()]
        public void FindQuestionSetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModifyQuestionSetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddQuestionTest()
        {
            //Arrange
            bool expected = true;
            QuestionSet questionSet = ?;
            Question question = ?
            bool actual;

            //Act
            actual = SqlManager.AddQuestion(questionSet, question);
                

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveQuestionTest()
        {
            //Arrange
            bool expected = true;
            int questionUID = 23;
            int qSetUID = 57;
            bool actual;


            //Act
            actual = SqlManager.RemoveQuestion(questionUID, qSetUID);
            

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ModifyQuestionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateNewQuestionSetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveQuestionSetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            //Arrange
            int expectedNumOfUsers = 30;
            List<UserData> userSet;
            int numberOfUsersRetrieved;

            //Act
            userSet = SqlManager.List<UserData> GetAllUsers();
            numberOfUsersRetrieved = questionSet.size();

            //Assert
            Assert.AreEqual(expectedNumOfUsers, numberOfUsersRetrieved);
        }

        [TestMethod()]
        public void FindUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AuthenticateCredentialsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModifyUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveUserTest()
        {
            //Arrange
            bool expected = true;
            int uid = 15;
            bool actual;


            //Act
            actual = SqlManager.RemoveUser(uid);
            

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddUserTest()
        {
            //Arrange
            bool expected = true;
            UserData userToAdd = ##???;
            bool actual;


            //Act
            actual = SqlManager.AddUser(userToAdd);
            

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAllViolationsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDepartmentViolationsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddViolationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveViolationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllDepartmentsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveDepartmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddDepartmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUsersInDepartmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindDepartmentByNameTest()
        {
            Assert.Fail();
        }
    }
}