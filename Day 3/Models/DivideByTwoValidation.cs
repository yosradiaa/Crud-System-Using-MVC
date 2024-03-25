using System.ComponentModel.DataAnnotations;

namespace Day_3.Models
{
    public class DivideByTwoValidation:ValidationAttribute
    {
        int z;
        public DivideByTwoValidation(int x)
        {
            z = x;
        }
        public override bool IsValid(object? value)
        {
            int x=(int)value;
            if(x%2==0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
