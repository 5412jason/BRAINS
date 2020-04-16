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
            int ExpectedNumOfQuestions = 1;
            int departmentID = 1;
            string status = "submitted";
            List<QuestionSet> questionSet;
            int numOfQuestionsRetrieved;

            //Act
            questionSet = SqlManager.GetAllQuestionSets(departmentID, status);
            numOfQuestionsRetrieved = questionSet.Count();

            //Assert
            Assert.AreEqual(ExpectedNumOfQuestions, numOfQuestionsRetrieved);
        }

        [TestMethod()]
        public void AddQuestionTest()
        {
            //Arrange
            bool expected = true;
            QuestionSet questionSet = new QuestionSet();
            Question question = new Question();
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
            int questionUID = 3;
            int qSetUID = 3;
            bool actual;


            //Act
            actual = SqlManager.RemoveQuestion(questionUID, qSetUID);
            

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void GetAllUsersTest()
        {
            //Arrange
            int expectedNumOfUsers = 3;
            List<UserData> userSet = new List<UserData>();
            int numberOfUsersRetrieved;

            //Act
            userSet = SqlManager.GetAllUsers();
            numberOfUsersRetrieved = userSet.Count();

            //Assert
            Assert.AreEqual(expectedNumOfUsers, numberOfUsersRetrieved);

        }
        [TestMethod()]
        public void RemoveUserTest()
        {
            //Arrange
            bool expected = true;
            int uid = 3;
            bool actual;


            //Act
            actual = SqlManager.RemoveUser(uid);
            

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}