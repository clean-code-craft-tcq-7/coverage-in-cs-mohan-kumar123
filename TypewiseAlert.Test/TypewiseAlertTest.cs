using Moq;
using System;
using TypewiseAlert.ConcreteClass;
using TypewiseAlert.Interface;
using TypewiseAlert.Model;
using Xunit;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
        #region BreachClassifier_Test_case
        [Fact]
        public void Test_InfersBreach_Low()
        {
            Assert.True(BreachClassifier.inferBreach(12, 20, 30) == AlterterType.BreachType.TOO_LOW);
        }
        [Fact]
        public void Test_InfersBreach_High()
        {
            Assert.True(BreachClassifier.inferBreach(32, 20, 30) == AlterterType.BreachType.TOO_HIGH);
        }
        [Fact]
        public void Test_InfersBreach_Normal()
        {
            Assert.True(BreachClassifier.inferBreach(32, 20, 34) == AlterterType.BreachType.NORMAL);
        }
        [Fact]
        public void Test_classifyTemperatureBreach_Basic()
        {
            //Arrange
            IBreach breach = new BreachClassifier();
            BatteryCharacter batteryChar = new BatteryCharacter();
            batteryChar.coolingType = CoolingType.HI_ACTIVE_COOLING;
            //Act
            AlterterType.BreachType breachType = breach.classifyTemperatureBreach(batteryChar.coolingType, 12);
            //Assert
            Assert.True(breachType == AlterterType.BreachType.NORMAL);
        }
        [Fact]
        public void Test_CheckPassiveCooling_ReturnSuccess()
        {
            //Arrange
            BreachClassifier breachClassifier = new BreachClassifier();
            BatteryCharacter batteryChar = new BatteryCharacter();
            batteryChar.coolingType = CoolingType.PASSIVE_COOLING;
            SampleData sampleData_Expected = new SampleData() { lowerLimit = 0, upperLimit = 35 };
            //Act
            SampleData sampleData = breachClassifier.CheckPassiveCooling(batteryChar.coolingType);
            //Assert
            Assert.True(sampleData_Expected.Equals(sampleData));
        }
        [Fact]
        public void Test_CheckPassiveCooling_IfCase()
        {
            //Arrange
            BreachClassifier breachClassifier = new BreachClassifier();
            BatteryCharacter batteryChar = new BatteryCharacter();
            batteryChar.coolingType = CoolingType.HI_ACTIVE_COOLING;
            SampleData sampleData_Expected = new SampleData() { lowerLimit = 0, upperLimit = 35 };
            //Act
            SampleData sampleData = breachClassifier.CheckPassiveCooling(batteryChar.coolingType);
            //Assert
            Assert.False(sampleData_Expected.Equals(sampleData));
        }
        [Fact]
        public void Test_CheckHighActiveCooling_ReturnSuccess()
        {
            //Arrange
            BreachClassifier breachClassifier = new BreachClassifier();
            BatteryCharacter batteryChar = new BatteryCharacter();
            batteryChar.coolingType = CoolingType.HI_ACTIVE_COOLING;
            SampleData sampleData_Expected = new SampleData() { lowerLimit = 0, upperLimit = 45 };
            //Act
            SampleData sampleData = breachClassifier.CheckHighActiveCooling(batteryChar.coolingType);
            //Assert
            Assert.True(sampleData_Expected.Equals(sampleData));
        }
        [Fact]
        public void Test_CheckHighActiveCooling_ReturnIfCase()
        {
            //Arrange
            BreachClassifier breachClassifier = new BreachClassifier();
            BatteryCharacter batteryChar = new BatteryCharacter();
            batteryChar.coolingType = CoolingType.MED_ACTIVE_COOLING;
            SampleData sampleData_Expected = new SampleData() { lowerLimit = 0, upperLimit = 45 };
            //Act
            SampleData sampleData = breachClassifier.CheckHighActiveCooling(batteryChar.coolingType);
            //Assert
            Assert.False(sampleData_Expected.Equals(sampleData));
        }
        [Fact]
        public void Test_CheckMedActiveCooling_ReturnSuccess()
        {
            //Arrange
            BreachClassifier breachClassifier = new BreachClassifier();
            BatteryCharacter batteryChar = new BatteryCharacter();
            batteryChar.coolingType = CoolingType.MED_ACTIVE_COOLING;
            SampleData sampleData_Expected = new SampleData() { lowerLimit = 0, upperLimit = 40 };
            //Act
            SampleData sampleData = breachClassifier.CheckMedActiveCooling(batteryChar.coolingType);
            //Assert
            Assert.True(sampleData_Expected.Equals(sampleData));
        }
        [Fact]
        public void Test_CheckMedActiveCooling_ReturnIfCase()
        {
            //Arrange
            //Act
            //Assert
        }
        #endregion


        #region TypewiseAlert_Test_Case

        [Fact]
        public void Test_checkAndAlert_CheckNotEqualOfBreachtype()
        {
            //Arrange
            BatteryCharacter batteryChar = new BatteryCharacter();
            // TypewiseAlert.checkAndAlert(AlertTarget.TO_CONTROLLER, batteryChar, 1.0);
            var moq = new Mock<ITypewiseAlert>();
            TypewiseAlert typewiseAlert = new TypewiseAlert();
            AlterterType.BreachType breachType = typewiseAlert.breachType;

            //Act
            typewiseAlert.checkAndAlert(AlertTarget.TO_EMAIL, batteryChar, 36);
            AlterterType.BreachType breachTypeResult = typewiseAlert.breachType;
            //moq.Verify(sut => sut.checkAndAlert(AlertTarget.TO_CONTROLLER, batteryChar, 1.0));

            //Assert
            Assert.NotEqual(breachType, breachTypeResult);
        } 

        [Fact]
        public void Test_checkAndAlert_ControllerAlertChecker()
        {
            //Arrange
            BatteryCharacter batteryChar = new BatteryCharacter();
            var moq = new Mock<ITypewiseAlert>();
            TypewiseAlert typewiseAlert = new TypewiseAlert();
            typewiseAlert.processFactory = null;

            //Act
            typewiseAlert.checkAndAlert(AlertTarget.TO_CONTROLLER, batteryChar, 36);

            //Assert
            ITriggerProcessor triggerProcessor =  typewiseAlert.processFactory.CreateProcessExecutor();
            Assert.True(triggerProcessor.GetBranchtype() == AlterterType.BreachType.TOO_HIGH);
           // Assert.True(triggerProcessor.IsProcesstriggered());
            
        }
        #endregion

        #region Controller_Test_Case


        [Fact]
        public void Test_Controller_TriggeredProcess()
        {
            //Arrange
            Controller controller = new Controller(AlterterType.BreachType.NORMAL);
            bool actual = controller.IsProcesstriggered();
            //Act
            controller.Triggerprocess();
            bool expected = controller.IsProcesstriggered();
            //Assert
            Assert.True(expected);
        }

        #endregion

        #region Email_Test_Case


        [Fact]
        public void Test_Email_TriggeredProcess()
        {
            //Arrange
            Email email = new Email(AlterterType.BreachType.TOO_HIGH);
            bool actual = email.IsProcesstriggered();
            //Act
            email.Triggerprocess();
            bool expected = email.IsProcesstriggered();
            //Assert
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void Test_Email_TriggeredProcess_Normal()
        {
            //Arrange
            Email email = new Email(AlterterType.BreachType.NORMAL);
            bool actual = email.IsProcesstriggered();
            //Act
            email.Triggerprocess();
            bool expected = email.IsProcesstriggered();
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Email_SendEmailForTooLow()
        {
            //Arrange
            Email email = new Email(AlterterType.BreachType.TOO_HIGH);
            bool actual = email.IsProcesstriggered();
            //Act
            email.SendEmailForTooLow(AlterterType.BreachType.TOO_LOW, "a.b@c.com"); 
            bool expected = email.IsProcesstriggered();
            //Assert
            Assert.NotEqual(expected, actual);
        }
        [Fact]
        public void Test_Email_SendEmailForTooHigh()
        {
            //Arrange
            Email email = new Email(AlterterType.BreachType.TOO_HIGH);
            bool actual = email.IsProcesstriggered();
            //Act
            email.SendEmailForTooHigh(AlterterType.BreachType.TOO_HIGH, "a.b@c.com");
            bool expected = email.IsProcesstriggered();
            //Assert
            Assert.NotEqual(expected, actual);
        }
        [Fact]
        public void Test_Email_SendEmail()
        {
            //Arrange
            Email email = new Email(AlterterType.BreachType.TOO_HIGH);
            bool actual = email.IsProcesstriggered();
            //Act
            email.SendEmail("too High", "a.b@c.com");
            bool expected = email.IsProcesstriggered();
            //Assert
            Assert.NotEqual(expected, actual);
        }
        #endregion
    }
}
