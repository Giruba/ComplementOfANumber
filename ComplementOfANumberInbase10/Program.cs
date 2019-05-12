using System;

namespace ComplementOfANumberInbase10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Complement of a number in base 10!");
            Console.WriteLine("----------------------------------");
            try
            {
                int number = int.Parse(Console.ReadLine());
                int complement = GetNumberComplement(number);
                Console.WriteLine("The complement of "+number + " is "+complement);
            } catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }

            Console.ReadLine();
        }

        private static int GetNumberComplement(int number) {
            int complement = 0;

            String result = "";

            if (number == 0) {
                return 1;
            }

            //Get the Binary number
            while (number != 0) {
                int quotient = number / 2;
                int remainder = number % 2;
                result = remainder.ToString().Trim() + result;
                number = quotient;
            }

            //Get the complement
            Char[] charArray = result.Trim().ToCharArray();
            for(int index = 0; index < charArray.Length; index++){
                if (charArray[index] == '0'){
                    charArray[index] = '1';
                }
                else {
                    charArray[index] = '0';
                }
            }

            result = new String(charArray);
            //Get the Base10 number
            int powerIndex = result.Length-1;
            charArray = result.Trim().ToCharArray();
            
            for (int index = 0; index < charArray.Length; index++) {
                int actualNumber = charArray[index] - '0';
                complement += (int) (actualNumber * Math.Pow(2, powerIndex--));
            }

            return complement;
        }
    }
}
