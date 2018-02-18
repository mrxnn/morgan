namespace Morgan
{
    /// <summary>
    /// Simple model that holds information about the order of tags that a music file should be based on when organizing
    /// </summary>
    public class FileHierachicalOrder
    {
        public TagType Level1 { get; set; } = TagType.Genre;
        public TagType Level2 { get; set; } = TagType.Artist;
        public TagType Level3 { get; set; } = TagType.Album;
        public TagType Level4 { get; set; } = TagType.Title;
    }
}
