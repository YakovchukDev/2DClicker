using System;

public class TextConverter
{
    private static readonly string[] _meaningList = new string[]{ "", "K", "M", "B", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AG", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
    public static string GetSourceText(ulong score)
    {
        int count = 0;
        while (score > 999)
        {
            score /= 10;
            count++;
        }
        int remainder = count % 3;
        float value = score;
        for (int i = remainder == 0 ? 0 : 3 - remainder; i > 0; i--)
        {
            value /= 10;
        }
        return $"{Math.Round(value, 3 - remainder)} {_meaningList[(count + 2) / 3]}";
    }
}
