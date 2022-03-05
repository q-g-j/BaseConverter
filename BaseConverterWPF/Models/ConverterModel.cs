using System;
using System.Collections.Generic;
using System.Numerics;

namespace BaseConverterWPF.Models
{
    internal class ConverterModel
    {
        public struct ConverterStruct
        {
            public string numberString;
            public bool isValid;
        }

        public ConverterStruct BinaryToDecimal(string binaryNumberString)
        {
            ConverterStruct returnStruct;
            returnStruct.numberString = "";

            returnStruct.isValid = true;

            bool isZero = true;

            for (int i = 0; i < binaryNumberString.Length; i++)
            {
                if (binaryNumberString[i] != '0')
                {
                    isZero = false;
                    break;
                }
            }

            if (isZero)
            {
                returnStruct.numberString = "0";
                return returnStruct;
            }

            for (int i = 0; i < binaryNumberString.Length; i++)
            {
                if (Convert.ToUInt16(binaryNumberString[i]) < 48 || Convert.ToUInt16(binaryNumberString[i]) > 49)
                {
                    returnStruct.isValid = false;
                    return returnStruct;
                }
            }

            BigInteger[] powerTwoPool = new BigInteger[binaryNumberString.Length];

            BigInteger num = BigInteger.Pow(2, binaryNumberString.Length - 1);
            for (int i = 0; i < binaryNumberString.Length; i++)
            {
                powerTwoPool[i] = num;
                num /= 2;
            }

            num = 0;

            for (int i = 0; i < binaryNumberString.Length; i++)
            {
                if (binaryNumberString[i] == '1')
                {
                    num += (BigInteger)powerTwoPool[i];
                }
            }

            returnStruct.numberString = Convert.ToString(num);
            return returnStruct;
        }
        public ConverterStruct OctalToDecimal(string octalNumberString)
        {
            ConverterStruct returnStruct;
            returnStruct.numberString = "";

            returnStruct.isValid = true;

            bool isZero = true;

            for (int i = 0; i < octalNumberString.Length; i++)
            {
                if (octalNumberString[i] != '0')
                {
                    isZero = false;
                    break;
                }
            }

            if (isZero)
            {
                returnStruct.numberString = "0";
                return returnStruct;
            }

            for (int i = 0; i < octalNumberString.Length; i++)
            {
                if (Convert.ToUInt16(octalNumberString[i]) < 48 || Convert.ToUInt16(octalNumberString[i]) > 55)
                {
                    returnStruct.isValid = false;
                    return returnStruct;
                }
            }

            BigInteger[] powerEightPool = new BigInteger[octalNumberString.Length];

            BigInteger num = BigInteger.Pow(8, octalNumberString.Length - 1);
            for (int i = 0; i < octalNumberString.Length; i++)
            {
                powerEightPool[i] = num;
                num /= 8;
            }

            num = 0;

            for (int i = 0; i < octalNumberString.Length; i++)
            {

                num += Convert.ToUInt16(Convert.ToChar(octalNumberString[i]) - 48) * (BigInteger)powerEightPool[i];
            }

            returnStruct.numberString = Convert.ToString(num);
            return returnStruct;
        }
        public ConverterStruct HexadecimalToDecimal(string hexadecimalNumberString)
        {
            ConverterStruct returnStruct;
            returnStruct.numberString = "";

            returnStruct.isValid = true;

            bool isZero = true;

            for (int i = 0; i < hexadecimalNumberString.Length; i++)
            {
                if (hexadecimalNumberString[i] != '0')
                {
                    isZero = false;
                    break;
                }
            }

            if (isZero)
            {
                returnStruct.numberString = "0";
                return returnStruct;
            }

            for (int i = 0; i < hexadecimalNumberString.Length; i++)
            {
                if (!((Convert.ToUInt16(hexadecimalNumberString[i]) >= 48 && Convert.ToUInt16(hexadecimalNumberString[i]) <= 57) ||
                    (Convert.ToUInt16(hexadecimalNumberString[i]) >= 65 && Convert.ToUInt16(hexadecimalNumberString[i]) <= 70) ||
                    (Convert.ToUInt16(hexadecimalNumberString[i]) >= 97 && Convert.ToUInt16(hexadecimalNumberString[i]) <= 102)))
                {
                    returnStruct.isValid = false;
                    return returnStruct;
                }
            }

            BigInteger[] powerSixteenPool = new BigInteger[hexadecimalNumberString.Length];

            BigInteger num = BigInteger.Pow(16, hexadecimalNumberString.Length - 1);
            for (int i = 0; i < hexadecimalNumberString.Length; i++)
            {
                powerSixteenPool[i] = num;
                num /= 16;
            }
            num = 0;

            for (int i = 0; i < hexadecimalNumberString.Length; i++)
            {
                if (hexadecimalNumberString[i] != '0')
                {
                    if (hexadecimalNumberString[i] == 'A' || hexadecimalNumberString[i] == 'a')
                    {
                        num += 10 * (BigInteger)powerSixteenPool[i];
                    }
                    else if (hexadecimalNumberString[i] == 'B' || hexadecimalNumberString[i] == 'b')
                    {
                        num += 11 * (BigInteger)powerSixteenPool[i];
                    }
                    else if (hexadecimalNumberString[i] == 'C' || hexadecimalNumberString[i] == 'c')
                    {
                        num += 12 * (BigInteger)powerSixteenPool[i];
                    }
                    else if (hexadecimalNumberString[i] == 'D' || hexadecimalNumberString[i] == 'd')
                    {
                        num += 13 * (BigInteger)powerSixteenPool[i];
                    }
                    else if (hexadecimalNumberString[i] == 'E' || hexadecimalNumberString[i] == 'e')
                    {
                        num += 14 * (BigInteger)powerSixteenPool[i];
                    }
                    else if (hexadecimalNumberString[i] == 'F' || hexadecimalNumberString[i] == 'f')
                    {
                        num += 15 * (BigInteger)powerSixteenPool[i];
                    }
                    else
                    {
                        num += Convert.ToUInt16(Convert.ToChar(hexadecimalNumberString[i]) - 48) * (BigInteger)powerSixteenPool[i];
                    }
                }
            }

            returnStruct.numberString = Convert.ToString(num);
            return returnStruct;
        }
        public ConverterStruct DecimalToBinary(string decimalNumberString)
        {
            ConverterStruct returnStruct;
            returnStruct.numberString = "";
            returnStruct.isValid = true;
            bool isZero = true;

            for (int i = 0; i < decimalNumberString.Length; i++)
            {
                if (decimalNumberString[i] != '0')
                {
                    isZero = false;
                    break;
                }
            }

            if (isZero)
            {
                returnStruct.numberString = "0";
                return returnStruct;
            }

            for (int i = 0; i < decimalNumberString.Length; i++)
            {
                if (Convert.ToUInt16(decimalNumberString[i]) < 48 || Convert.ToUInt16(decimalNumberString[i]) > 57)
                {
                    returnStruct.isValid = false;
                    return returnStruct;
                }
            }

            List<BigInteger> binaryList = new List<BigInteger>();

            BigInteger decimalNumber = BigInteger.Parse(decimalNumberString);

            while (decimalNumber != 0)
            {
                binaryList.Add(decimalNumber % 2);
                decimalNumber /= 2;
            }

            for (int i = binaryList.Count - 1; i >= 0; i--)
            {
                returnStruct.numberString += Convert.ToString(binaryList[i]);
            }

            return returnStruct;
        }
        public ConverterStruct DecimalToOctal(string decimalNumberString)
        {
            ConverterStruct returnStruct;
            returnStruct.numberString = "";
            returnStruct.isValid = true;
            bool isZero = true;

            for (int i = 0; i < decimalNumberString.Length; i++)
            {
                if (decimalNumberString[i] != '0')
                {
                    isZero = false;
                    break;
                }
            }

            if (isZero)
            {
                returnStruct.numberString = "0";
                return returnStruct;
            }

            for (int i = 0; i < decimalNumberString.Length; i++)
            {
                if (Convert.ToUInt16(decimalNumberString[i]) < 48 || Convert.ToUInt16(decimalNumberString[i]) > 57)
                {
                    returnStruct.isValid = false;
                    return returnStruct;
                }
            }

            List<BigInteger> octalList = new List<BigInteger>();

            BigInteger decimalNumber = BigInteger.Parse(decimalNumberString);

            while (decimalNumber != 0)
            {
                octalList.Add(decimalNumber % 8);
                decimalNumber /= 8;
            }

            for (int i = octalList.Count - 1; i >= 0; i--)
            {
                returnStruct.numberString += Convert.ToString(octalList[i]);
            }

            return returnStruct;
        }
        public ConverterStruct DecimalToHexadecimal(string decimalNumberString)
        {
            ConverterStruct returnStruct;
            returnStruct.numberString = "";
            returnStruct.isValid = true;
            bool isZero = true;

            for (int i = 0; i < decimalNumberString.Length; i++)
            {
                if (decimalNumberString[i] != '0')
                {
                    isZero = false;
                    break;
                }
            }

            if (isZero)
            {
                returnStruct.numberString = "0";
                return returnStruct;
            }

            for (int i = 0; i < decimalNumberString.Length; i++)
            {
                if (Convert.ToUInt16(decimalNumberString[i]) < 48 || Convert.ToUInt16(decimalNumberString[i]) > 57)
                {
                    returnStruct.isValid = false;
                    return returnStruct;
                }
            }

            List<string> hexadecimalList = new List<string>();

            BigInteger decimalNumber = BigInteger.Parse(decimalNumberString);

            while (decimalNumber != 0)
            {
                BigInteger tempNumber = decimalNumber % 16;
                string tempString = "0";
                if (tempNumber >= 10)
                {
                    if (tempNumber == 10) tempString = "A";
                    else if (tempNumber == 11) tempString = "B";
                    else if (tempNumber == 12) tempString = "C";
                    else if (tempNumber == 13) tempString = "D";
                    else if (tempNumber == 14) tempString = "E";
                    else if (tempNumber == 15) tempString = "F";
                }
                else
                {
                    tempString = Convert.ToString(tempNumber);
                }
                hexadecimalList.Add(tempString);
                decimalNumber /= 16;
            }

            for (int i = hexadecimalList.Count - 1; i >= 0; i--)
            {
                returnStruct.numberString += Convert.ToString(hexadecimalList[i]);
            }

            return returnStruct;
        }
    }
}
