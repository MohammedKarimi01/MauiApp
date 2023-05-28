using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapp.Models
{
    public class UserInputSingleton
    {
        private static UserInputSingleton instance;

        public string UserInputName { get; set; }

        private UserInputSingleton()
        {
            UserInputName = string.Empty;
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
    }


}
