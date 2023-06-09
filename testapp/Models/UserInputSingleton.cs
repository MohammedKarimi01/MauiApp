using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapp.Models
{
    public class UserInputSingleton
    {
        private static UserInputSingleton instance = null;

        public string UserInputName { get; set; }
        public int RandomNumber { get; set; }

        public UserInputSingleton()
        {
            RandomNumber = DoSmth();

        }
        public static UserInputSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInputSingleton();
                }

                return instance;
            }
        }
        public static int DoSmth()
        {
            int rndNumber = 0;
            Random rnd = new Random();
            rndNumber = rnd.Next(5000, 50000);

            return rndNumber;
        }
    }


}
