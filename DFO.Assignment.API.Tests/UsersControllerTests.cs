using AutoMapper;
using DFO.Assignment.API.Controllers;
using DFO.Assignment.API.Repositories;
using DFO.Assignment.Domain.Entities;
using DFO.Assignment.Domain.Models.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DFO.Assignment.API.Tests
{
    [TestClass]
    public class UsersControllerTests
    {


        [TestMethod]
        public void GetById_NotFound()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.FindById(It.IsAny<int>()))
                .Returns(default(User));

            var mockMapper = new Mock<IMapper>();
            //mockMapper.Setup(x => x.Map<User>(It.IsAny<UserModel>())).Returns(new User());

            var controller = new UsersController(mockMapper.Object, userRepository.Object);

            // Act
            var result = controller.GetById(0);

                // Assert
          
        }
    }
}
