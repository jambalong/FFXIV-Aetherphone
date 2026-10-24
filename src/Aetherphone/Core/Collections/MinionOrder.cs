namespace Aetherphone.Core.Collections;

internal static class MinionOrder
{
    private const long OrderWeight = 1_000_000L;

    public static long Key(int companionOrder, int companionRowId) => companionOrder * OrderWeight + companionRowId;
}
