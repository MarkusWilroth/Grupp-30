namespace FileCopier
{
    /// <summary>
    /// The status for the circular buffer elements
    /// </summary>
    public enum BufferStatus
    {
        Empty,
        Checked,
        New
    }

    /// <summary>
    /// The text boxes
    /// </summary>
    public enum Box
    {
        Src,
        Dst
    }
}