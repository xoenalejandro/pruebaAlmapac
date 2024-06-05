using ApiUsers.Controllers;
using ApiUsers.Models;
using Microsoft.AspNetCore.Mvc;

namespace APITest
{
    public class APITesting
    {

        private UserController _userController;
       

        public APITesting(UserController controller)
        {
            _userController = new UserController(null, null, null);
        }
        [Fact]
        public async Task RegisterUser_ValidInput_ReturnsOk()
        {
            

            var userDTO = new UserDTO { Name = "Juan Rodriguez", Email = "juan@rodriguez.org", Password = "hunter2",
                phones = new List<phonesDTO>
                            {
                                new phonesDTO { Number = "1234567", CityCode = "1", ContryCode = "57" }
                            }
            };
                

            
            var result = await _userController.RegisterUser(userDTO) as OkObjectResult;

          
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
          
        }

        
    }
}