using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFizzBuzzModels.Models
{
    public class FizzBuzzModel
    {
        public int FizzNum { get; set;  }
        public int BuzzNum { get; set; }
        public string Output { get; set; }

        public FizzBuzzModel(int input1, int input2)
        {
            FizzNum = input1;
            BuzzNum = input2;
        }

        public FizzBuzzModel()
        {
        }
    }
}
