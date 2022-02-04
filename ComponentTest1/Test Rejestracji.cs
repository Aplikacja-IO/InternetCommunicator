using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetCommunicator.Api.Services;
using InternetCommunicator.Infrastructure.Context;

namespace ComponentTest1
{
    [TestClass]
    public class UnitTest1
    {
        CommunicatorDbContext _context;
        public UnitTest1()
        {

            [TestMethod]
             public async Task RegisterUserTest()
                {
                    var user = new UserReg()
                    {
                        userId = 5,
                        UserName = "User1",
                        UserPassword = "password",
                        Registerdate = new DateTime(2008, 1, 1, 6, 32, 0);
            
                    };

                    bool isDigitPresent = user.UserPassword.Any(c => char.IsDigit(c));
    


                    Assert.IsNotNull(Registerdate);
                    Assert.IsTrue(user.UserName.lenght > 3,"Nazwa za krotka");
                    Assert.IsTrue((user.UserPassword.lenght >3 || isDigitPresent == true ),"Nazwa za krotka albo brakuje cyfry");

                }
        }
        

      

       
    }
}
