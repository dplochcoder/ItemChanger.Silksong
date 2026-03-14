namespace ItemChangerTesting;

internal record TestMetadata
{
    public required TestFolder Folder { get; init; }
    public required string MenuName { get; init; }
    public required string MenuDescription { get; init; }
    /// <summary>
    /// A number which controls how tests are ordered in the menu, with higher revisions showing earlier.
    /// Recommended to use YYYYMMDD00 for chronological ordering with some wiggle room in the final digits.
    /// </summary>
    public required long Revision { get; init; }
}
