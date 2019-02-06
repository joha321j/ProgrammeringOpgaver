using System.Security.Cryptography;
using DateClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateUnitTestProject
{
    [TestClass]
    public class UnitTestDate
    {
        [TestMethod]
        public void TestMethod_DateConstructor()
        {
            UclDate aDate = new UclDate(2019, 2, 6);
            Assert.IsNotNull(aDate, "UclDate Constructor is not working");
        }
        [TestMethod]
        public void TestMethod_GetYear()
        {
            UclDate testDate = new UclDate(2012, 2, 6);

            Assert.AreEqual(testDate.GetYear(), 2012);
        }
        [TestMethod]
        public void TestMethod_GetMonth()
        {
            UclDate testDate = new UclDate(1992, 03, 10);

            Assert.AreEqual(testDate.GetMonth(), 03);
        }

        [TestMethod]
        public void TestMethod_GetDay()
        {
            UclDate testDate = new UclDate(1997, 12, 23);

            Assert.AreEqual(testDate.GetDay(), 23);
        }

        [TestMethod]
        public void TestMethod_SetYear()
        {
            UclDate testDate = new UclDate(1991, 01, 01);

            int newYear = 17;
            testDate.SetYear(newYear);

            Assert.AreEqual(newYear, testDate.GetYear());
        }

        [TestCategory("Set methods with NegativeValues")]
        [TestMethod]
        public void TestMethod_SetYear_WithNegativeValue()
        {
            UclDate testDate = new UclDate(1771, 1, 1);

            int newYear = -10;

            testDate.SetYear(newYear);

            Assert.AreEqual(newYear, testDate.GetYear());
        }

        [TestMethod]
        public void TestMethod_SetDay_WithNegativeValue()
        {
            UclDate testDate = new UclDate(1, 1, 12);

            int newDay = -12;
            
            testDate.SetDay(newDay);

            Assert.AreEqual(newDay, testDate.GetDay());
        }
        [TestMethod]
        public void TestMethod_SetMonth_WithNegativeValue()
        {
            UclDate testDate = new UclDate(1773, 11, 31);

            int newMonth = -17;

            testDate.SetMonth(newMonth);

            Assert.AreEqual(newMonth, testDate.GetMonth());
        }

        [TestCategory("Formatting")]
        [TestMethod]
        public void TestMethod_GetDateStringYMD()
        {
            UclDate testDate = new UclDate(155, 2, 7);

            Assert.AreEqual("0155-02-07", testDate.GetDatoStringYMD());
        }

        [TestCategory("Formatting")]
        [TestMethod]
        public void TestMethod_GetDateStringDMY()
        {
            UclDate testDate = new UclDate(123, 07, 23);

            Assert.AreEqual("23/07/23", testDate.GetDatoStringDMY());
        }

        [TestMethod]
        public void TestMethod_GetQuater()
        {
            UclDate testDate = new UclDate(1992, 5, 25);

            Assert.AreEqual(2, testDate.GetQuater());
        }

        [TestMethod]
        public void TestMethod_GetQuater_InvalidQuarter()
        {
            UclDate testDate = new UclDate(1992, 13, 24);
            
            Assert.AreNotEqual(4, testDate.GetQuater());
        }

        [TestMethod]
        public void TestMethod_GetMonthTxt()
        {
            UclDate testDate = new UclDate(2017, 01, 24);

            Assert.AreEqual("Januar", testDate.GetMonthTxt());
        }

        [TestMethod]
        public void TestMethod_GetMonthTxt_September()
        {
            UclDate testDate = new UclDate(2078, 09, 25);

            Assert.AreEqual("September", testDate.GetMonthTxt());
        }
        [TestMethod]
        public void TestMethod_GetMonthTxt_InvalidMonth()
        {
            UclDate testDate = new UclDate(2099, 123, 25);

            Assert.AreEqual("Fejl måned", testDate.GetMonthTxt());
        }

        [TestMethod]
        public void TestMethod_GetQuaterTxt()
        {
            UclDate testDate = new UclDate(2017, 9, 1);

            Assert.AreEqual("Juli kvartal", testDate.GetQuaterTxt());
        }

        [TestMethod]
        public void TestMethod_MoveToNextDate_SameMonth()
        {
            UclDate testDate = new UclDate(1997, 7, 12);

            testDate.MoveToNextDate();

            Assert.AreEqual("1997-07-13", testDate.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_MoveToNextDate_NotJuly()
        {
            UclDate testDate = new UclDate(1952, 1, 1);

            testDate.MoveToNextDate();

            Assert.AreEqual("1952-1-2", testDate.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_MoveToNextDate_NewMonth()
        {
            UclDate testDate = new UclDate(1997, 11, 30);

            testDate.MoveToNextDate();

            Assert.AreEqual("1997-12-1", testDate.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_MoveToNextDate_NewYear()
        {
            UclDate testDate = new UclDate(1997, 12, 31);

            testDate.MoveToNextDate();

            Assert.AreEqual("1998-1-1", testDate.GetDatoStringYMD());
        }


        [TestMethod]
        public void TestMethod_MoveToPrevDate_SameMonth()
        {
            UclDate testDate = new UclDate(1997, 7, 12);

            testDate.MoveToPrevDate();

            Assert.AreEqual("1997-7-11", testDate.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_MoveToPrevDate_SameMonthSeptember()
        {
            UclDate testDate = new UclDate(1997, 9, 11);

            testDate.MoveToPrevDate();

            Assert.AreEqual("1997-9-10", testDate.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_MoveToPrevDate_NewMonth()
        {
            UclDate testDate = new UclDate(132, 2, 1);

            testDate.MoveToPrevDate();

            Assert.AreEqual("132-1-31", testDate.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_MoveToPrevDate_NewYear()
        {
            UclDate testDate = new UclDate(1, 1, 1);

            testDate.MoveToPrevDate();

            Assert.AreEqual("0-12-31", testDate.GetDatoStringYMD());
        }

        [TestMethod]

        public void TestMethod_MoveDays()
        {
            UclDate testDate = new UclDate(1234, 7, 2);

            testDate.MoveDays(1);

            Assert.AreEqual("1234-7-3", testDate.GetDatoStringYMD());
        }
        [TestMethod]
        public void TestMethod_MoveDays_365days()
        {
            UclDate testDate = new UclDate(1278, 2, 25);

            testDate.MoveDays(365);

            Assert.AreEqual("1279-2-25", testDate.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_MoveDays_NegativeDays()
        {
            UclDate testDate = new UclDate(1997, 7, 14);

            testDate.MoveDays(-10);

            Assert.AreEqual("1997-7-4", testDate.GetDatoStringYMD());

        }

        [TestMethod]
        public void TestMethod_GetDayNumber()
        {
            UclDate testDate = new UclDate(1994, 7, 18);

            Assert.AreEqual(199, testDate.GetDayNumber());
        }

        [TestMethod]
        public void TestMethod_GetDayNumber_1stJanuary()
        {
            UclDate testDate = new UclDate(0, 1, 1);

            Assert.AreEqual(1, testDate.GetDayNumber());
        }

        [TestMethod]
        public void TestMethod_GetDayNumber_LeapYear()
        {
            UclDate testDate1 = new UclDate(2020, 12, 31);

            UclDate testDate2 = new UclDate(2019, 12, 31);

            Assert.AreNotEqual(testDate1.GetDayNumber(), testDate2.GetDayNumber());
        }

        [TestMethod]
        public void TestMethod_SetDayNumber()
        {
            UclDate testDate = new UclDate(1, 10, 17);

            testDate.SetDayNumber(1, 199);

            Assert.AreEqual("1-7-18", testDate.GetDatoStringYMD());
        }
        [TestMethod]
        public void TestMethod_SetDayNumber_1Day()
        {
            UclDate testDate = new UclDate(1267, 12, 5);

            testDate.SetDayNumber(1267, 1);

            Assert.AreEqual("1267-1-1", testDate.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_SetDayNumber_366Day()
        {
            UclDate testDate = new UclDate();

            testDate.SetDayNumber(1, 366);

            Assert.AreEqual("2-1-1", testDate.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_GetAbsDayNumber()
        {
            UclDate testDate = new UclDate(2, 1, 1);

            int absDayNumber = testDate.GetAbsDayNumber();
            Assert.AreEqual(366, absDayNumber);
        }

        [TestMethod]
        public void TestMethod_GetWeekDay()
        {
            UclDate testDate = new UclDate(2019, 02, 4);

            Assert.AreEqual(1, testDate.GetWeekDay());

            testDate = new UclDate(2019, 02, 5);

            Assert.AreEqual(2, testDate.GetWeekDay());

            testDate = new UclDate(2019, 02, 6);

            Assert.AreEqual(3, testDate.GetWeekDay());

            testDate = new UclDate(2019, 02, 7);

            Assert.AreEqual(4, testDate.GetWeekDay());

            testDate = new UclDate(2019, 02, 8);

            Assert.AreEqual(5, testDate.GetWeekDay());

            testDate = new UclDate(2019, 02, 9);

            Assert.AreEqual(6, testDate.GetWeekDay());

            testDate = new UclDate(2019, 02, 10);

            Assert.AreEqual(7, testDate.GetWeekDay());
        }


    }
}
