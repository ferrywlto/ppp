using System.Globalization;

namespace blazor_mix_ssr.Shared;

public static class CultureCollection {
    public static List<CultureInfo> SupportedCultures = new() {
        new CultureInfo("en-GB"),
        new CultureInfo("en-US"),
        new CultureInfo("zh-Hant-HK"),
        new CultureInfo("zh-Hant-TW"),
        new CultureInfo("ja-JP"),
    };

    public static void PrintCultureInfo(CultureInfo cultureInfo) {
        Console.WriteLine($"\tType: {cultureInfo.CultureTypes}");
        Console.WriteLine($"\tName: {cultureInfo.Name}");
        Console.WriteLine($"\tDisplayName: {cultureInfo.DisplayName}");
        Console.WriteLine($"\tNativeName: {cultureInfo.NativeName}");
        Console.WriteLine($"\tEnglishName: {cultureInfo.EnglishName}");
        Console.WriteLine($"\tTwoLettersName: {cultureInfo.TwoLetterISOLanguageName}");
    }
}
