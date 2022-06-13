using System;

public class StringArepheticOperations
{
    private static readonly string[] _meaningList = new string[]{ "", "K", "M", "B", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AG", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "AAA", "AAB", "AAC", "AAD", "AAE", "AAF", "AAG", "AAH", "AAI", "AAG", "AAK", "AAL", "AAM", "AAN", "AAO", "AAP", "AAQ", "AAR", "AAS", "AAT", "AAU", "AAV", "AAW", "AAX", "AAY", "AAZ" };
    public static string GetSourceText(string score)
    {
        if (score.Length > 3)
        {
            string result = "";
            for (int i = 0; i < (score.Length % 3 == 0 ? 3 : score.Length % 3) && i < score.Length; i++)
            {
                result += score[i];
            }
            if (score.Length % 3 > 0)
            {
                result += ",";
                for (int i = result.Length - 1; i < result.Length - 1 + (3 - (score.Length % 3 == 0 ? 3 : score.Length % 3)) && i < score.Length; i++)
                {
                    if (i + result.Length - 2 < score.Length)
                    {
                        result += score[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return $"{result}{_meaningList[score.Length / 3 - (score.Length % 3 == 0 ? 1 : 0)]}";
        }
        else
        {
            return score;
        }
    }
    public static string SumStrings(string number1, string number2)
    {
        string result = "";
        int remainder = 0;
        for (int l1 = number1.Length - 1, l2 = number2.Length - 1; l1 >= 0 || l2 >= 0;)
        {
            int buff1 = l1 >= 0 ? Int16.Parse(number1[l1--].ToString()) : 0;
            int buff2 = l2 >= 0 ? Int16.Parse(number2[l2--].ToString()) : 0;
            int buffResult = buff1 + buff2 + remainder;
            result = (buffResult % 10).ToString() + result;
            remainder = buffResult / 10;
        }
        if (remainder > 0)
        {
            result = remainder.ToString() + result;
        }
        return result;
    }
    //не вміє працювати з відємними числами та значеннями, тому що поки це не потрібно
    public static string SubtractStrings(string number1, string number2)
    {
        if (number1 != number2)
        {
            string result = "";
            bool nextRemainder = false;
            for (int l1 = number1.Length - 1, l2 = number2.Length - 1; l1 >= 0 || l2 >= 0;)
            {
                bool remainder = false;
                int buff1 = l1 >= 0 ? Int16.Parse(number1[l1--].ToString()) : 0;
                int buff2 = l2 >= 0 ? Int16.Parse(number2[l2--].ToString()) : 0;

                if (buff1 - (nextRemainder ? 1 : 0) < buff2)
                {
                    buff1 += 10;
                    remainder = true;
                }
                result = (buff1 - (nextRemainder ? 1 : 0) - buff2).ToString() + result;
                nextRemainder = remainder;
            }

            return RemoveZeros(result);
        }
        else
        {
            return "0";
        }
    }
    //не вміє працювати з відємними числами та значеннями, тому що поки це не потрібно
    public static bool StringsComparison(string number1, string number2)
    {
        if (number1.Length == number2.Length)
        {
            for (int i = 0; i < number1.Length; i++)
            {
                int buff1 = Int16.Parse(number1[i].ToString());
                int buff2 = Int16.Parse(number2[i].ToString());
                if (buff1 > buff2)
                {
                    return true;
                }
                else if(buff1 < buff2)
                {
                    return false;
                }
            }
        }
        else if (number1.Length > number2.Length)
        {
            return true;
        }
        else
        {
            return false;
        }

        return true;
    }
    //цей метод не розрахований під всі можливі варіанти сценарііїв множення, я лиш підлаштував його роботу під потрібні в данний момент сценарії
    public static string MultiplicationOfStrings(string factor1, float factor2)
    {
        if (factor2 != 1f)
        {
            string preResult = "";
            int remainder = 0;
            for (int length = factor1.Length - 1; length >= 0; length--)
            {
                int number = Int16.Parse(factor1[length].ToString());
                int resultN = (int)(number * (factor2 * 10) + remainder);
                preResult = (resultN % 10) + preResult;
                remainder /= 10;
                remainder += resultN / 10;
            }

            preResult = remainder + preResult;
            string result = "";
            for (int i = 0; i < (preResult.Length - 1 > 0 ? preResult.Length - 1 : 0); i++)
            {
                result += preResult[i];
            }

            return RemoveZeros(result);
        }
        else
        {
            return factor1;
        }
    }

    private static string RemoveZeros(string numbersString)
    {
        bool isNullFound = false;
        string result = "";
        for (int i = 0; i < numbersString.Length; i++)
        {
            if (numbersString[i] == '0' && (isNullFound || (i == numbersString.Length - 1 && result == "")))
            {
                result += numbersString[i];
            }
            else if(numbersString[i] != '0')
            {
                result += numbersString[i];
                isNullFound = true;
            }
        }
        return result;
    }
    //ділення також не робив, тому що не було в цьому необхідності
}
