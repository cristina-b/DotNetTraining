﻿using System;
using System.Collections.Generic;
using Moq;
using ProductionCode.MockingExample;
using Xunit;


namespace xUnit.FullFramework.Mocks
{

 
    public class LunchNotifierTests
    {

        [Fact]
        public void Test_EmployeeInOfficeGetsNotified()
        {
            //
            // Create mocks:
            //
            var loggerMock = new Moq.Mock<ILogger>();

            var bobMock = new Moq.Mock<IEmployee>();
            /*
             * Configure mock so that employee is considered working today and gets notifications via email
             *
             */
            bobMock.Setup(x => x.IsWorkingOnDate(DateTime.Today)).Returns(true);
            bobMock.Setup(x => x.GetNotificationPreference()).Returns(LunchNotifier.NotificationType.Email);


            var employeeServiceMock = new Moq.Mock<IEmployeeService>();
            /*
             * Configure mock so to return employee from above
             *
             */
            employeeServiceMock.Setup(e => e.GetEmployeesInNewYorkOffice())
                .Returns(new List<IEmployee> { bobMock.Object });


            var notificationServiceMock = new Moq.Mock<INotificationService>();
            /*
            * Configure mock so that you can verify a notification was sent via email
            *
            */

            notificationServiceMock.Setup(x => x.SendEmail(bobMock.Object, It.IsAny<string>()));
            //
            // Create instance of class I'm testing:
            //
            var classUnderTest = new LunchNotifier(notificationServiceMock.Object, employeeServiceMock.Object, loggerMock.Object);

            //
            // Run some logic to test:
            //
            classUnderTest.SendLunchtimeNotifications();

            //
            // Check the results:
            //

            /*
            * Add verifications to prove emails notification was sent
            *
            */

            notificationServiceMock.Verify(e => e.SendEmail(It.IsAny<IEmployee>(), It.IsAny<string>()), Times.Once);
            notificationServiceMock.Verify(e => e.SendSlackMessage(It.IsAny<IEmployee>(), It.IsAny<string>()), Times.Never);
        }

        
        [Fact]
        public void Test_ExceptionDoesNotStopNotifications()
        {
            //
            // Create mocks:
            //
            var loggerMock = new Moq.Mock<ILogger>();
            /*
            * Configure mock so that you can verify a error was logged
            *
            */
            loggerMock.Setup(logger => logger.Error(It.IsAny<Exception>()));

            var bobMock = new Moq.Mock<IEmployee>();
            /*
             * Configure mock so that employee is considered working today and gets notifications via email
             *
             */
            bobMock.Setup(employee => employee.IsWorkingOnDate(DateTime.Today)).Returns(true);
            bobMock.Setup(employee => employee.GetNotificationPreference()).Returns(LunchNotifier.NotificationType.Email);

            var marthaMock = new Moq.Mock<IEmployee>();
            /*
             * Configure mock so that employee is considered working today and gets notifications via email
             *
             */
            marthaMock.Setup(e => e.IsWorkingOnDate(DateTime.Today)).Returns(true);
            marthaMock.Setup(e => e.GetNotificationPreference()).Returns(LunchNotifier.NotificationType.Email);

            var employeeServiceMock = new Moq.Mock<IEmployeeService>();
            /*
             * Configure mock so to return both employees from above
             *
             */
            employeeServiceMock.Setup(e => e.GetEmployeesInNewYorkOffice())
                .Returns(new List<IEmployee> { bobMock.Object, marthaMock.Object });

            var notificationServiceMock = new Moq.Mock<INotificationService>();
            /*
             * Configure mock to throw an exception when attempting to send notification via email
             *
             */
            notificationServiceMock.Setup(s => s.SendEmail(It.IsAny<IEmployee>(), It.IsAny<string>())).Throws(new Exception("email service not valid"));

            //
            // Create instance of class I'm testing:
            //
            var classUnderTest = new LunchNotifier(notificationServiceMock.Object, employeeServiceMock.Object, loggerMock.Object);

            //
            // Run some logic to test:
            //
            classUnderTest.SendLunchtimeNotifications();

            //
            // Check the results:
            //

            /*
             * Add verifications to prove emails notification were attempted twice
             *
             * Add verification that error logger was called
             *
             */

            notificationServiceMock.Verify(n => n.SendEmail(It.IsAny<IEmployee>(), It.IsAny<string>()), Times.Exactly(2));
            loggerMock.Verify(e => e.Error(It.IsAny<Exception>()), Times.Exactly(2));
        }


        [Theory]
        [InlineData("2017-01-01 13:00:00", LunchNotifier.LateLunchTemplate)]
        [InlineData("2017-01-01 12:59:59", LunchNotifier.RegularLunchTemplate)]
        public void Test_CorrectTemplateIsUsed_LateLunch_Seam(string currentTime, string expectedTemplate)
        {            
            //
            // Create mocks:
            //
            var loggerMock = new Moq.Mock<ILogger>();

            var bobMock = new Moq.Mock<IEmployee>();
            bobMock.Setup(x => x.IsWorkingOnDate(It.IsAny<DateTime>()))
                .Returns(true);

            /*
            * Configure mock so that employee is considered working today and gets notifications via email
            *
            */

            var employeeServiceMock = new Moq.Mock<IEmployeeService>();
            employeeServiceMock.Setup(x => x.GetEmployeesInNewYorkOffice())
                .Returns(new[] { bobMock.Object });

            /*
            * Configure mock so to return employee from above
            *
            */

            var notificationServiceMock = new Moq.Mock<INotificationService>();

            //
            // Create instance of class I'm testing:
            //
            var classUnderTest = new Moq.Mock<LunchNotifier_SeamAndExplicitInterface>(notificationServiceMock.Object, employeeServiceMock.Object, loggerMock.Object)
            { CallBase = true };
            classUnderTest.As<IDateTimeOverridable>().Setup(x => x.GetDateTime())
                          .Returns(DateTime.Parse(currentTime));
            /*
             * Create a partial mock of the LunchNotifier_UsingSeam class and change the GetDateTime() behavior to return DateTime.Parse(currentTime)
             *
             */

            //
            // Run some logic to test:
            //
            classUnderTest.Object.SendLunchtimeNotifications();

            //
            // Check the results:
            //
            notificationServiceMock.Verify(x => x.SendEmail(It.IsAny<IEmployee>(), expectedTemplate));
        }



    }

}
