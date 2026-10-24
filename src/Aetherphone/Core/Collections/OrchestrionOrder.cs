using System.Globalization;

namespace Aetherphone.Core.Collections;

internal static class OrchestrionOrder
{
    private const long CategoryWeight = 1_000_000L;
    private const long UnnumberedOffset = 100_000L;
    private const long UnnumberedCapacity = 99_999L;
    private const int UnknownCategoryRank = 99;

    public static long Key(CollectionItemDto dto, int responseIndex)
    {
        var rank = CategoryRank(dto.Category?.Id ?? 0);
        if (int.TryParse(dto.Number, NumberStyles.None, CultureInfo.InvariantCulture, out var number))
        {
            return rank * CategoryWeight + number;
        }

        return rank * CategoryWeight + UnnumberedOffset + Math.Max(0L, UnnumberedCapacity - responseIndex);
    }

    private static int CategoryRank(int categoryId) => categoryId switch
    {
        2 => 1,
        9 => 2,
        3 => 11,
        12 => 12,
        4 => 21,
        5 => 31,
        10 => 32,
        11 => 41,
        13 => 51,
        6 => 52,
        7 => 61,
        8 => 71,
        _ => UnknownCategoryRank,
    };
}
