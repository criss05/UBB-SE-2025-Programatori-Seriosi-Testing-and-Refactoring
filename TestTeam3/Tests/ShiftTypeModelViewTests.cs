using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.DatabaseServices.Interfaces;
using Team3.Models;
using Xunit;
using Team3.Service.Implementations;

namespace Team3.Tests.ModelViewsTests
{
    public class ShiftTypeModelViewTests
    {
        private readonly Mock<IShiftTypeRepo> mockShiftTypeDbService;
        private readonly ShiftTypeModelView shiftTypeModelView;

        public ShiftTypeModelViewTests()
        {
            mockShiftTypeDbService = new Mock<IShiftTypeRepo>();
            mockShiftTypeDbService.Setup(s => s.GetAllShiftTypes()).Returns(new List<ShiftType>());
            shiftTypeModelView = new ShiftTypeModelView(new ShiftTypeService(mockShiftTypeDbService.Object)) ;
        }

        [Fact]
        public void GetShiftTypesByTimeRange_ReturnsFilteredShiftTypes()
        {
            var shiftTypes = new List<ShiftType>
            {
                new ShiftType(1, new TimeOnly(8, 0), new TimeOnly(12, 0)),
                new ShiftType(2, new TimeOnly(13, 0), new TimeOnly(17, 0)),
                new ShiftType(3, new TimeOnly(18, 0), new TimeOnly(22, 0))
            };
            mockShiftTypeDbService.Setup(s => s.GetAllShiftTypes()).Returns(shiftTypes);

            var startTime = new TimeOnly(7, 0);
            var endTime = new TimeOnly(17, 0);

            var result = shiftTypeModelView.GetShiftTypesByTimeRange(startTime, endTime);

            Assert.Equal(2, result.Count);
            Assert.Contains(result, s => s.Id == 1);
            Assert.Contains(result, s => s.Id == 2);
        }

        [Fact]
        public void GetShiftTypesByTimeRange_NoMatches_ThrowsException()
        {
            var shiftTypes = new List<ShiftType>
            {
                new ShiftType(1, new TimeOnly(8, 0), new TimeOnly(12, 0))
            };
            mockShiftTypeDbService.Setup(s => s.GetAllShiftTypes()).Returns(shiftTypes);

            var startTime = new TimeOnly(13, 0);
            var endTime = new TimeOnly(15, 0);

            var ex = Assert.Throws<Exception>(() => shiftTypeModelView.GetShiftTypesByTimeRange(startTime, endTime));
            Assert.Contains("No shift types found", ex.Message);
        }

        [Fact]
        public void GetShiftType_ExistingId_ReturnsShiftType()
        {
            var shiftType = new ShiftType(1, new TimeOnly(8, 0), new TimeOnly(12, 0));
            mockShiftTypeDbService.Setup(s => s.GetShiftType(1)).Returns(shiftType);

            var result = shiftTypeModelView.GetShiftType(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(new TimeOnly(8, 0), result.ShiftTypeStartTime);
            Assert.Equal(new TimeOnly(12, 0), result.ShiftTypeEndTime);
        }

        [Fact]
        public void GetShiftType_NonExistingId_ReturnsNull()
        {
            mockShiftTypeDbService.Setup(s => s.GetShiftType(99)).Throws(new Exception("Not found"));

            var result = shiftTypeModelView.GetShiftType(99);

            Assert.Null(result);
        }

        [Fact]
        public void Constructor_LoadsShiftTypesIntoCollection()
        {
            var shiftTypes = new List<ShiftType>
            {
                new ShiftType(1, new TimeOnly(8, 0), new TimeOnly(12, 0)),
                new ShiftType(2, new TimeOnly(13, 0), new TimeOnly(17, 0))
            };
            mockShiftTypeDbService.Setup(s => s.GetAllShiftTypes()).Returns(shiftTypes);

            var modelView = new ShiftTypeModelView(new ShiftTypeService(mockShiftTypeDbService.Object));

            Assert.Equal(2, modelView.ShiftTypes.Count);
            Assert.Contains(modelView.ShiftTypes, s => s.Id == 1);
            Assert.Contains(modelView.ShiftTypes, s => s.Id == 2);
        }
    }
}
